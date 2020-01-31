using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using McKabue.Extentions.Utility.Enums;
using static McKabue.Extentions.Utility.MimeTypes.MimeTypeMap;

namespace McKabue.Extentions.Utility.MimeTypes
{
    public class MimeTypeModel
    {
        private MimeType? mimeType;

        public MimeTypeModel(MimeType? mimeType)
        {
            this.mimeType = mimeType;
        }

        public MimeType? MimeType { get => mimeType; set => mimeType = value; }
        public string MimeExtention => MimeType?.GetAttribute<DisplayAttribute>()?.Name;
        public string MimeContentType => MimeType?.GetAttribute<EnumMemberAttribute>()?.Value;
    }
}