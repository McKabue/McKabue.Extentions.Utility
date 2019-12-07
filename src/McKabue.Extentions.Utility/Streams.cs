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
        public static long GetSize(this Stream stream)
        {
            long originalPosition = 0;
            long totalBytesRead = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, 0, 4096)) > 0)
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

            return totalBytesRead;
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