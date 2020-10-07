using System;
using System.Reflection;

namespace McKabue.Extentions.Utility
{
    public static class UriExtensions
    {
        /// <summary>
        /// Uri with a dot, eg:
        ///     http://ir-library.ku.ac.ke/bitstream/123456789/712/3/A%20literary%20study%20of%20dislocation.....pdf
        ///     https://www.cambridge.org/core/services/aop-cambridge-core/content/view/1C0335599E0CBFA304C0AB45122BF086/S0001972000047707a.pdf/making-up-their-own-minds-readers-interpretations-and-the-difference-of-view-in-ghanaian-popular-narratives.pdf
        /// 
        /// https://stackoverflow.com/questions/856885/httpwebrequest-to-url-with-dot-at-the-end
        /// [CanonicalizeAsFilePath](https://referencesource.microsoft.com/#system/net/System/_UriSyntax.cs,572da033d1cbed53,references)3
        /// https://www.c-sharpcorner.com/forums/uri-baseuri-new-uri-giving-problem
        /// https://stackoverflow.com/a/2519684/3563013
        /// https://stackoverflow.com/questions/53390151/who-can-download-this-image-using-net-3-5
        /// https://dzone.com/articles/uri-segments-dots-rest-and-net
        /// https://github.com/microsoft/referencesource/blob/3b1eaf5203992df69de44c783a3eda37d3d4cd10/System/System.txt#L847
        /// https://github.com/microsoft/referencesource/search?q=net_uri_NotAbsolute
        /// 
        /// Failure to do this results to System.InvalidOperationException when trying to make 
        /// HttpClient request.
        /// 
        /// System.InvalidOperationException: This operation is not supported for a relative URI.
        ///     at string Uri.get_Authority()
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>Uri</returns>
        public static Uri UriFixParser(this Uri uri)
        {
            return UriFixParser(uri.OriginalString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uriString"></param>
        /// <returns></returns>
        public static Uri UriFixParser(this string uriString)
        {
            MethodInfo getSyntax = typeof(UriParser).GetMethod("GetSyntax", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            FieldInfo flagsField = typeof(UriParser).GetField("_flags", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (getSyntax != null && flagsField != null)
            {
                foreach (string scheme in new[] { "http", "https" })
                {
                    UriParser parser = (UriParser)getSyntax.Invoke(null, new object[] { scheme });
                    if (parser != null)
                    {
                        int flagsValue = (int)flagsField.GetValue(parser);
                        // Clear the CanonicalizeAsFilePath attribute
                        if ((flagsValue & 0x1000000) != 0)
                            flagsField.SetValue(parser, flagsValue & ~0x1000000);
                    }
                }
            }

            /// <summary>
            /// <see href="https://stackoverflow.com/a/5289768/3563013">
            ///     Create a Uri, possibly without a scheme without throwing
            ///     an exception.
            /// </see>
            /// </summary>
            UriBuilder uriBuilder = new UriBuilder(uriString);

            return new Uri(uriBuilder.Uri.OriginalString);
        }
    }
}