using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IO;

namespace McKabue.Extentions.Utility
{
    public static class Streams
    {
        /// <summary>
        /// Return the length of a stream that does not have a usable Length property.
        /// 
        /// https://stackoverflow.com/a/20990628/3563013
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static decimal GetSize(
            this Stream stream,
            StreamSizeFormat streamSizeFormat,
            bool countWithBytes = false)
        {
            if (stream == null)
            {
                return 0;
            }

            long totalBytesRead = 0;

            if (!countWithBytes)
            {
                totalBytesRead = stream.Length;
            }
            else
            {
                long originalPosition = 0;

                if (stream.CanSeek)
                {
                    originalPosition = stream.Position;
                    stream.Position = 0;
                }

                try
                {
                    int readInChunksOf4KiB = (int)StreamSizeFormat.KiB * 4;
                    byte[] readBuffer = new byte[readInChunksOf4KiB];

                    int bytesRead;

                    while ((bytesRead = stream.Read(readBuffer, 0, readInChunksOf4KiB)) > 0)
                    {
                        totalBytesRead += bytesRead;
                    }

                }
                finally
                {
                    if (stream.CanSeek)
                    {
                        stream.Position = originalPosition;
                    }
                }
            }

            return (decimal)totalBytesRead / (decimal)getConversionValue(streamSizeFormat);
        }

        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/misc/cs0220">
        /// Compiler Error CS0220
        /// </see>
        /// <see href="https://stackoverflow.com/q/10167219/3563013">
        /// UInt64 and “The operation overflows at compile time in checked mode” - CS0220
        /// </see>
        /// </summary>
        public enum StreamSizeFormat
        {
            B = 1,

            KB = 1000 * B,
            /// <summary>
            /// <see href="https://en.wikipedia.org/wiki/Kibibyte">1 kibibyte is 1024 bytes.</see>
            /// 1 kilobyte is 1000 bytes.
            /// most converters treat them interchacheably.
            /// </summary>
            KiB = 1024 * B,

            /// <summary>
            /// The below figures are powers of KB or KiB
            /// </summary>
            MB = 2,
            MiB = 2,

            GB = 1 + MB,
            GiB = 1 + MiB,

            TB = 1 + GB,
            TiB = 1 + GiB,

            PB = 1 + TB,
            PiB = 1 + TiB,

            EB = 1 + PB,
            EiB = 1 + PiB,

            ZB = 1 + EB,
            ZiB = 1 + EiB,

            YB = 1 + ZB,
            YiB = 1 + ZiB
        }

        private static double getConversionValue(StreamSizeFormat streamSizeFormat)
        {
            if (streamSizeFormat == StreamSizeFormat.MB ||
                streamSizeFormat == StreamSizeFormat.GB ||
                streamSizeFormat == StreamSizeFormat.TB ||
                streamSizeFormat == StreamSizeFormat.PB ||
                streamSizeFormat == StreamSizeFormat.EB ||
                streamSizeFormat == StreamSizeFormat.ZB ||
                streamSizeFormat == StreamSizeFormat.YB)
            {
                return Math.Pow((int)StreamSizeFormat.KB, (int)streamSizeFormat);
            }

            if (streamSizeFormat == StreamSizeFormat.MiB ||
                streamSizeFormat == StreamSizeFormat.GiB ||
                streamSizeFormat == StreamSizeFormat.TiB ||
                streamSizeFormat == StreamSizeFormat.PiB ||
                streamSizeFormat == StreamSizeFormat.EiB ||
                streamSizeFormat == StreamSizeFormat.ZiB ||
                streamSizeFormat == StreamSizeFormat.YiB)
            {
                return Math.Pow((int)StreamSizeFormat.KiB, (int)streamSizeFormat);
            }

            return (int)streamSizeFormat;
        }

        /// <summary>
        /// Stream from response.Content.ReadAsStreamAsync() is not readable randomly.
        /// 
        /// The problem was that I was initializing HttpClient object in 'using' and 
        /// using its response outside the using scope. 
        /// This will dispose the HttpClient object, hence breaking the remote connection and 
        /// that is why I am not able to stream the content.
        /// 
        /// https://stackoverflow.com/a/40351007/3563013
        /// 
        /// c# MemoryStream vs Byte Array
        /// https://stackoverflow.com/a/53234494/3563013
        /// https://stackoverflow.com/a/44214909/3563013
        /// 
        /// Stream from response.Content.ReadAsStreamAsync() is not readable randomly
        /// https://stackoverflow.com/a/40351007/3563013
        /// 
        /// Clone Stream
        /// https://stackoverflow.com/a/147961/3563013
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static async Task<Stream> CloneStream(this Stream stream, bool copyUsingBytes = false)
        {
            RecyclableMemoryStreamManager recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();

            if (stream.CanSeek)
            {
                stream.Position = 0;
                stream.Seek(0, SeekOrigin.Begin);
            }


            Stream newStream = recyclableMemoryStreamManager.GetStream();
            if (copyUsingBytes)
            {
                const int readSize = 4096;
                byte[] buffer = new byte[readSize];

                int count = stream.Read(buffer, 0, readSize);
                while (count > 0)
                {
                    newStream.Write(buffer, 0, count);
                    count = stream.Read(buffer, 0, readSize);
                }
            }
            else
            {
                await stream.CopyToAsync(newStream);
            }

            newStream.Position = 0;
            newStream.Seek(0, SeekOrigin.Begin);

            return newStream;
        }

        /// <summary>
        /// https://stackoverflow.com/a/13312954/3563013
        /// </summary>
        /// <param name="streamProvider"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static IEnumerable<string> ReadAllLines(this Stream stream, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;

            using (stream)
            {
                if (!stream.CanRead)
                {
                    yield break;
                }
                using (StreamReader reader = new StreamReader(stream, encoding))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        yield return line;
                    }
                }
            }
        }
        public static string ReadAllText(this Stream stream, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;

            using (stream)
            {
                if (!stream.CanRead)
                {
                    return string.Empty;
                }
                using (StreamReader reader = new StreamReader(stream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}