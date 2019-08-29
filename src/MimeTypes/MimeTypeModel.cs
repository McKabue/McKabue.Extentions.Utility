using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common_C_Sharp_Utility_Methods.Enums;
using static Common_C_Sharp_Utility_Methods.MimeTypes.MimeTypeMap;

namespace Common_C_Sharp_Utility_Methods.MimeTypes
{
    public class MimeTypeModel
    {
        private MimeType? mimeType;

        public MimeTypeModel(object mimeType)
        {
            this.mimeType = mimeType as MimeType?;
        }

        public MimeType? MimeType { get => mimeType; set => mimeType = value; }
        public string MimeExtention => MimeType?.GetAttribute<DisplayAttribute>()?.Name;
        public string MimeContentType => MimeType?.GetAttribute<EnumMemberAttribute>()?.Value;
    }
}