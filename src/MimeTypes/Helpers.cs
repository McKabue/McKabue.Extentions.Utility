using System;
using System.Collections.Generic;
using System.Linq;
using static Common_C_Sharp_Utility_Methods.MimeTypes.MimeTypeMap;

namespace Common_C_Sharp_Utility_Methods.MimeTypes
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

        public static MimeTypeModel GetMimeByExtention(this string extensionOrPathName)
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

        public static MimeTypeModel GetMimeByType(this string contentType)
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

    }
}