using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static McKabue.Extentions.Utility.MimeTypes.MimeTypeMap;

namespace McKabue.Extentions.Utility.MimeTypes
{
    public static class Helpers
    {
        private static readonly Lazy<IEnumerable<MimeTypeModel>> mimeTypeMappings = new Lazy<IEnumerable<MimeTypeModel>>(BuildMappings);

        private static IEnumerable<MimeTypeModel> BuildMappings()
        {
            string[] names = Enum.GetNames(typeof(MimeType));

            foreach (var name in names)
            {
                object @enum;
                Enum.TryParse(typeof(MimeType), name, true, out @enum);

                yield return new MimeTypeModel(@enum);
            }

            yield break;
        }

        public static MimeTypeModel GetMimeFromExtention(this string extensionOrPathName)
        {
            if (extensionOrPathName.IsEmpty())
            {
                return null;
            }

            extensionOrPathName = extensionOrPathName.Trim().ToLowerInvariant();

            if (!extensionOrPathName.StartsWith("."))
            {
                extensionOrPathName = $".{extensionOrPathName?.Split('.')?.LastOrDefault()}";
            }

            IEnumerator<MimeTypeModel> enumerator = mimeTypeMappings.Value.GetEnumerator();
            while (enumerator.MoveNext())
            {
                MimeTypeModel mimeTypeModel = enumerator.Current;
                if (mimeTypeModel.MimeExtention.Equals(extensionOrPathName, StringComparison.OrdinalIgnoreCase))
                {
                    return mimeTypeModel;
                }
            }
            return null;
        }

        public static MimeTypeModel GetMimeFromContentType(this string contentType)
        {
            if (contentType.IsEmpty())
            {
                return null;
            }

            contentType = contentType.Trim().ToLowerInvariant();

            IEnumerator<MimeTypeModel> enumerator = mimeTypeMappings.Value.GetEnumerator();
            while (enumerator.MoveNext())
            {
                MimeTypeModel mimeTypeModel = enumerator.Current;
                if (mimeTypeModel.MimeContentType.Equals(contentType, StringComparison.OrdinalIgnoreCase))
                {
                    return mimeTypeModel;
                }
            }
            return null;
        }

        public static MimeTypeModel GetMimeValues(this MimeType mime) => mimeTypeMappings.Value.FirstOrDefault(i => i.MimeType == mime);

        /// <summary>
        /// https://www.example-code.com/csharp/determine_file_type_from_content.asp
        /// https://github.com/0xbrock/FileTypeChecker
        /// https://www.garykessler.net/library/file_sigs.html
        /// https://www.e-iceblue.com/Tutorials/Spire.PDF/Spire.PDF-Program-Guide/Document-Operation/Detect-if-a-PDF-file-is-PDF/A-in-C.html
        /// 
        /// c# MemoryStream vs Byte Array
        /// https://stackoverflow.com/a/53234494/3563013
        /// https://stackoverflow.com/a/44214909/3563013
        /// 
        /// Stream from response.Content.ReadAsStreamAsync() is not readable randomly
        /// https://stackoverflow.com/a/40351007/3563013
        /// 
        /// https://dotnetfiddle.net/HOreVg
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static async Task<MimeTypeModel> GetMimeFromBinaryContent(this Stream stream)
        {
            if (stream == null)
            {
                return null;
            }

            IEnumerable<string> hex = await GetBytesInHex(stream, 0, 4);

            // https://dotnetfiddle.net/HOreVg
            if (hex.SequenceEqual(new string[] { "25", "50", "44", "46" }))
            {
                return new MimeTypeModel(MimeType.PDF);
            }

            return null;
        }

        public static async Task<MimeTypeModel> GetMimeFromBinaryContent(this Stream stream, bool dispose = false)
        {
            if (dispose)
            {
                using (stream)
                {
                    return await GetMimeFromBinaryContent(stream);
                }
            }

            return await GetMimeFromBinaryContent(stream);
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/api/system.text.asciiencoding.getstring?view=netframework-4.8
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static async Task<IEnumerable<string>> GetBytesInHex(Stream stream, int start, int end)
        {
            using (stream = await stream.CloneStream())
            {
                byte[] buffer = new byte[end - start];

                await stream.ReadAsync(buffer, start, end);

                return buffer.Select(i => string.Format("{0:X2}", i));
            }
        }
    }
}