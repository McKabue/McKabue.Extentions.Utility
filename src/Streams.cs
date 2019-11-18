using System.IO;
using System.Threading.Tasks;
using Microsoft.IO;

namespace Common_C_Sharp_Utility_Methods
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
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static async Task<Stream> GetReadableStream(this Stream stream)
        {
            RecyclableMemoryStreamManager recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();

            Stream newStream = recyclableMemoryStreamManager.GetStream();
            await stream.CopyToAsync(newStream);

            newStream.Position = 0;
            newStream.Seek(0, SeekOrigin.Begin);

            return newStream;
        }
    }
}