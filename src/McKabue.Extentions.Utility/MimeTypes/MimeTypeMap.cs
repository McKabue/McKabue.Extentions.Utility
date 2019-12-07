using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace McKabue.Extentions.Utility.MimeTypes
{
    /// <summary>
    /// https://github.com/samuelneff/MimeTypeMap/blob/master/src/MimeTypes/MimeTypeMap.cs
    /// https://www.garykessler.net/library/file_sigs.html
    /// https://msdn.microsoft.com/en-us/library/system.web.mimemapping.getmimemapping
    /// https://codereview.stackexchange.com/a/85130
    /// </summary>
    public static class MimeTypeMap
    {
        public enum MimeType
        {
            [EnumMember(Value = "text/h323"), Display(Name = ".323")]
            _323,
            [EnumMember(Value = "video/3gpp2"), Display(Name = ".3g2")]
            _3G2,
            [EnumMember(Value = "video/3gpp"), Display(Name = ".3gp")]
            _3GP,
            [EnumMember(Value = "video/3gpp2"), Display(Name = ".3gp2")]
            _3GP2,
            [EnumMember(Value = "video/3gpp"), Display(Name = ".3gpp")]
            _3GPP,
            [EnumMember(Value = "application/x-7z-compressed"), Display(Name = ".7z")]
            _7Z,
            [EnumMember(Value = "audio/audible"), Display(Name = ".aa")]
            AA,
            [EnumMember(Value = "audio/aac"), Display(Name = ".AAC")]
            AAC,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".aaf")]
            AAF,
            [EnumMember(Value = "audio/vnd.audible.aax"), Display(Name = ".aax")]
            AAX,
            [EnumMember(Value = "audio/ac3"), Display(Name = ".ac3")]
            AC3,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".aca")]
            ACA,
            [EnumMember(Value = "application/msaccess.addin"), Display(Name = ".accda")]
            ACCDA,
            [EnumMember(Value = "application/msaccess"), Display(Name = ".accdb")]
            ACCDB,
            [EnumMember(Value = "application/msaccess.cab"), Display(Name = ".accdc")]
            ACCDC,
            [EnumMember(Value = "application/msaccess"), Display(Name = ".accde")]
            ACCDE,
            [EnumMember(Value = "application/msaccess.runtime"), Display(Name = ".accdr")]
            ACCDR,
            [EnumMember(Value = "application/msaccess"), Display(Name = ".accdt")]
            ACCDT,
            [EnumMember(Value = "application/msaccess.webapplication"), Display(Name = ".accdw")]
            ACCDW,
            [EnumMember(Value = "application/msaccess.ftemplate"), Display(Name = ".accft")]
            ACCFT,
            [EnumMember(Value = "application/internet-property-stream"), Display(Name = ".acx")]
            ACX,
            [EnumMember(Value = "text/xml"), Display(Name = ".AddIn")]
            ADDIN,
            [EnumMember(Value = "application/msaccess"), Display(Name = ".ade")]
            ADE,
            [EnumMember(Value = "application/x-bridge-url"), Display(Name = ".adobebridge")]
            ADOBEBRIDGE,
            [EnumMember(Value = "application/msaccess"), Display(Name = ".adp")]
            ADP,
            [EnumMember(Value = "audio/vnd.dlna.adts"), Display(Name = ".ADT")]
            ADT,
            [EnumMember(Value = "audio/aac"), Display(Name = ".ADTS")]
            ADTS,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".afm")]
            AFM,
            [EnumMember(Value = "application/postscript"), Display(Name = ".ai")]
            AI,
            [EnumMember(Value = "audio/aiff"), Display(Name = ".aif")]
            AIF,
            [EnumMember(Value = "audio/aiff"), Display(Name = ".aifc")]
            AIFC,
            [EnumMember(Value = "audio/aiff"), Display(Name = ".aiff")]
            AIFF,
            [EnumMember(Value = "application/vnd.adobe.air-application-installer-package+zip"), Display(Name = ".air")]
            AIR,
            [EnumMember(Value = "application/mpeg"), Display(Name = ".amc")]
            AMC,
            [EnumMember(Value = "application/annodex"), Display(Name = ".anx")]
            ANX,
            [EnumMember(Value = "application/vnd.android.package-archive"), Display(Name = ".apk")]
            APK,
            [EnumMember(Value = "application/x-ms-application"), Display(Name = ".application")]
            APPLICATION,
            [EnumMember(Value = "image/x-jg"), Display(Name = ".art")]
            ART,
            [EnumMember(Value = "application/xml"), Display(Name = ".asa")]
            ASA,
            [EnumMember(Value = "application/xml"), Display(Name = ".asax")]
            ASAX,
            [EnumMember(Value = "application/xml"), Display(Name = ".ascx")]
            ASCX,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".asd")]
            ASD,
            [EnumMember(Value = "video/x-ms-asf"), Display(Name = ".asf")]
            ASF,
            [EnumMember(Value = "application/xml"), Display(Name = ".ashx")]
            ASHX,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".asi")]
            ASI,
            [EnumMember(Value = "text/plain"), Display(Name = ".asm")]
            ASM,
            [EnumMember(Value = "application/xml"), Display(Name = ".asmx")]
            ASMX,
            [EnumMember(Value = "application/xml"), Display(Name = ".aspx")]
            ASPX,
            [EnumMember(Value = "video/x-ms-asf"), Display(Name = ".asr")]
            ASR,
            [EnumMember(Value = "video/x-ms-asf"), Display(Name = ".asx")]
            ASX,
            [EnumMember(Value = "application/atom+xml"), Display(Name = ".atom")]
            ATOM,
            [EnumMember(Value = "audio/basic"), Display(Name = ".au")]
            AU,
            [EnumMember(Value = "video/x-msvideo"), Display(Name = ".avi")]
            AVI,
            [EnumMember(Value = "audio/annodex"), Display(Name = ".axa")]
            AXA,
            [EnumMember(Value = "application/olescript"), Display(Name = ".axs")]
            AXS,
            [EnumMember(Value = "video/annodex"), Display(Name = ".axv")]
            AXV,
            [EnumMember(Value = "text/plain"), Display(Name = ".bas")]
            BAS,
            [EnumMember(Value = "application/x-bcpio"), Display(Name = ".bcpio")]
            BCPIO,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".bin")]
            BIN,
            [EnumMember(Value = "image/bmp"), Display(Name = ".bmp")]
            BMP,
            [EnumMember(Value = "text/plain"), Display(Name = ".c")]
            C,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".cab")]
            CAB,
            [EnumMember(Value = "audio/x-caf"), Display(Name = ".caf")]
            CAF,
            [EnumMember(Value = "application/vnd.ms-office.calx"), Display(Name = ".calx")]
            CALX,
            [EnumMember(Value = "application/vnd.ms-pki.seccat"), Display(Name = ".cat")]
            CAT,
            [EnumMember(Value = "text/plain"), Display(Name = ".cc")]
            CC,
            [EnumMember(Value = "text/plain"), Display(Name = ".cd")]
            CD,
            [EnumMember(Value = "audio/aiff"), Display(Name = ".cdda")]
            CDDA,
            [EnumMember(Value = "application/x-cdf"), Display(Name = ".cdf")]
            CDF,
            [EnumMember(Value = "application/x-x509-ca-cert"), Display(Name = ".cer")]
            CER,
            [EnumMember(Value = "text/plain"), Display(Name = ".cfg")]
            CFG,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".chm")]
            CHM,
            [EnumMember(Value = "application/x-java-applet"), Display(Name = ".class")]
            CLASS,
            [EnumMember(Value = "application/x-msclip"), Display(Name = ".clp")]
            CLP,
            [EnumMember(Value = "text/plain"), Display(Name = ".cmd")]
            CMD,
            [EnumMember(Value = "image/x-cmx"), Display(Name = ".cmx")]
            CMX,
            [EnumMember(Value = "text/plain"), Display(Name = ".cnf")]
            CNF,
            [EnumMember(Value = "image/cis-cod"), Display(Name = ".cod")]
            COD,
            [EnumMember(Value = "application/xml"), Display(Name = ".config")]
            CONFIG,
            [EnumMember(Value = "text/x-ms-contact"), Display(Name = ".contact")]
            CONTACT,
            [EnumMember(Value = "application/xml"), Display(Name = ".coverage")]
            COVERAGE,
            [EnumMember(Value = "application/x-cpio"), Display(Name = ".cpio")]
            CPIO,
            [EnumMember(Value = "text/plain"), Display(Name = ".cpp")]
            CPP,
            [EnumMember(Value = "application/x-mscardfile"), Display(Name = ".crd")]
            CRD,
            [EnumMember(Value = "application/pkix-crl"), Display(Name = ".crl")]
            CRL,
            [EnumMember(Value = "application/x-x509-ca-cert"), Display(Name = ".crt")]
            CRT,
            [EnumMember(Value = "text/plain"), Display(Name = ".cs")]
            CS,
            [EnumMember(Value = "text/plain"), Display(Name = ".csdproj")]
            CSDPROJ,
            [EnumMember(Value = "application/x-csh"), Display(Name = ".csh")]
            CSH,
            [EnumMember(Value = "text/plain"), Display(Name = ".csproj")]
            CSPROJ,
            [EnumMember(Value = "text/css"), Display(Name = ".css")]
            CSS,
            [EnumMember(Value = "text/csv"), Display(Name = ".csv")]
            CSV,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".cur")]
            CUR,
            [EnumMember(Value = "text/plain"), Display(Name = ".cxx")]
            CXX,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".dat")]
            DAT,
            [EnumMember(Value = "application/xml"), Display(Name = ".datasource")]
            DATASOURCE,
            [EnumMember(Value = "text/plain"), Display(Name = ".dbproj")]
            DBPROJ,
            [EnumMember(Value = "application/x-director"), Display(Name = ".dcr")]
            DCR,
            [EnumMember(Value = "text/plain"), Display(Name = ".def")]
            DEF,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".deploy")]
            DEPLOY,
            [EnumMember(Value = "application/x-x509-ca-cert"), Display(Name = ".der")]
            DER,
            [EnumMember(Value = "application/xml"), Display(Name = ".dgml")]
            DGML,
            [EnumMember(Value = "image/bmp"), Display(Name = ".dib")]
            DIB,
            [EnumMember(Value = "video/x-dv"), Display(Name = ".dif")]
            DIF,
            [EnumMember(Value = "application/x-director"), Display(Name = ".dir")]
            DIR,
            [EnumMember(Value = "text/xml"), Display(Name = ".disco")]
            DISCO,
            [EnumMember(Value = "video/divx"), Display(Name = ".divx")]
            DIVX,
            [EnumMember(Value = "application/x-msdownload"), Display(Name = ".dll")]
            DLL,
            [EnumMember(Value = "text/xml"), Display(Name = ".dll.config")]
            DLLCONFIG,
            [EnumMember(Value = "text/dlm"), Display(Name = ".dlm")]
            DLM,
            [EnumMember(Value = "application/msword"), Display(Name = ".doc")]
            DOC,
            [EnumMember(Value = "application/vnd.ms-word.document.macroEnabled.12"), Display(Name = ".docm")]
            DOCM,
            [EnumMember(Value = "application/vnd.openxmlformats-officedocument.wordprocessingml.document"), Display(Name = ".docx")]
            DOCX,
            [EnumMember(Value = "application/msword"), Display(Name = ".dot")]
            DOT,
            [EnumMember(Value = "application/vnd.ms-word.template.macroEnabled.12"), Display(Name = ".dotm")]
            DOTM,
            [EnumMember(Value = "application/vnd.openxmlformats-officedocument.wordprocessingml.template"), Display(Name = ".dotx")]
            DOTX,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".dsp")]
            DSP,
            [EnumMember(Value = "text/plain"), Display(Name = ".dsw")]
            DSW,
            [EnumMember(Value = "text/xml"), Display(Name = ".dtd")]
            DTD,
            [EnumMember(Value = "text/xml"), Display(Name = ".dtsConfig")]
            DTSCONFIG,
            [EnumMember(Value = "video/x-dv"), Display(Name = ".dv")]
            DV,
            [EnumMember(Value = "application/x-dvi"), Display(Name = ".dvi")]
            DVI,
            [EnumMember(Value = "drawing/x-dwf"), Display(Name = ".dwf")]
            DWF,
            [EnumMember(Value = "application/acad"), Display(Name = ".dwg")]
            DWG,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".dwp")]
            DWP,
            [EnumMember(Value = "application/x-dxf"), Display(Name = ".dxf")]
            DXF,
            [EnumMember(Value = "application/x-director"), Display(Name = ".dxr")]
            DXR,
            [EnumMember(Value = "message/rfc822"), Display(Name = ".eml")]
            EML,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".emz")]
            EMZ,
            [EnumMember(Value = "application/vnd.ms-fontobject"), Display(Name = ".eot")]
            EOT,
            [EnumMember(Value = "application/postscript"), Display(Name = ".eps")]
            EPS,
            [EnumMember(Value = "application/etl"), Display(Name = ".etl")]
            ETL,
            [EnumMember(Value = "text/x-setext"), Display(Name = ".etx")]
            ETX,
            [EnumMember(Value = "application/envoy"), Display(Name = ".evy")]
            EVY,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".exe")]
            EXE,
            [EnumMember(Value = "text/xml"), Display(Name = ".exe.config")]
            EXECONFIG,
            [EnumMember(Value = "application/vnd.fdf"), Display(Name = ".fdf")]
            FDF,
            [EnumMember(Value = "application/fractals"), Display(Name = ".fif")]
            FIF,
            [EnumMember(Value = "application/xml"), Display(Name = ".filters")]
            FILTERS,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".fla")]
            FLA,
            [EnumMember(Value = "audio/flac"), Display(Name = ".flac")]
            FLAC,
            [EnumMember(Value = "x-world/x-vrml"), Display(Name = ".flr")]
            FLR,
            [EnumMember(Value = "video/x-flv"), Display(Name = ".flv")]
            FLV,
            [EnumMember(Value = "application/fsharp-script"), Display(Name = ".fsscript")]
            FSSCRIPT,
            [EnumMember(Value = "application/fsharp-script"), Display(Name = ".fsx")]
            FSX,
            [EnumMember(Value = "application/xml"), Display(Name = ".generictest")]
            GENERICTEST,
            [EnumMember(Value = "image/gif"), Display(Name = ".gif")]
            GIF,
            [EnumMember(Value = "application/gpx+xml"), Display(Name = ".gpx")]
            GPX,
            [EnumMember(Value = "text/x-ms-group"), Display(Name = ".group")]
            GROUP,
            [EnumMember(Value = "audio/x-gsm"), Display(Name = ".gsm")]
            GSM,
            [EnumMember(Value = "application/x-gtar"), Display(Name = ".gtar")]
            GTAR,
            [EnumMember(Value = "application/x-gzip"), Display(Name = ".gz")]
            GZ,
            [EnumMember(Value = "text/plain"), Display(Name = ".h")]
            H,
            [EnumMember(Value = "application/x-hdf"), Display(Name = ".hdf")]
            HDF,
            [EnumMember(Value = "text/x-hdml"), Display(Name = ".hdml")]
            HDML,
            [EnumMember(Value = "application/x-oleobject"), Display(Name = ".hhc")]
            HHC,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".hhk")]
            HHK,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".hhp")]
            HHP,
            [EnumMember(Value = "application/winhlp"), Display(Name = ".hlp")]
            HLP,
            [EnumMember(Value = "text/plain"), Display(Name = ".hpp")]
            HPP,
            [EnumMember(Value = "application/mac-binhex40"), Display(Name = ".hqx")]
            HQX,
            [EnumMember(Value = "application/hta"), Display(Name = ".hta")]
            HTA,
            [EnumMember(Value = "text/x-component"), Display(Name = ".htc")]
            HTC,
            [EnumMember(Value = "text/html"), Display(Name = ".htm")]
            HTM,
            [EnumMember(Value = "text/html"), Display(Name = ".html")]
            HTML,
            [EnumMember(Value = "text/webviewhtml"), Display(Name = ".htt")]
            HTT,
            [EnumMember(Value = "application/xml"), Display(Name = ".hxa")]
            HXA,
            [EnumMember(Value = "application/xml"), Display(Name = ".hxc")]
            HXC,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".hxd")]
            HXD,
            [EnumMember(Value = "application/xml"), Display(Name = ".hxe")]
            HXE,
            [EnumMember(Value = "application/xml"), Display(Name = ".hxf")]
            HXF,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".hxh")]
            HXH,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".hxi")]
            HXI,
            [EnumMember(Value = "application/xml"), Display(Name = ".hxk")]
            HXK,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".hxq")]
            HXQ,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".hxr")]
            HXR,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".hxs")]
            HXS,
            [EnumMember(Value = "text/html"), Display(Name = ".hxt")]
            HXT,
            [EnumMember(Value = "application/xml"), Display(Name = ".hxv")]
            HXV,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".hxw")]
            HXW,
            [EnumMember(Value = "text/plain"), Display(Name = ".hxx")]
            HXX,
            [EnumMember(Value = "text/plain"), Display(Name = ".i")]
            I,
            [EnumMember(Value = "image/x-icon"), Display(Name = ".ico")]
            ICO,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".ics")]
            ICS,
            [EnumMember(Value = "text/plain"), Display(Name = ".idl")]
            IDL,
            [EnumMember(Value = "image/ief"), Display(Name = ".ief")]
            IEF,
            [EnumMember(Value = "application/x-iphone"), Display(Name = ".iii")]
            III,
            [EnumMember(Value = "text/plain"), Display(Name = ".inc")]
            INC,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".inf")]
            INF,
            [EnumMember(Value = "text/plain"), Display(Name = ".ini")]
            INI,
            [EnumMember(Value = "text/plain"), Display(Name = ".inl")]
            INL,
            [EnumMember(Value = "application/x-internet-signup"), Display(Name = ".ins")]
            INS,
            [EnumMember(Value = "application/x-itunes-ipa"), Display(Name = ".ipa")]
            IPA,
            [EnumMember(Value = "application/x-itunes-ipg"), Display(Name = ".ipg")]
            IPG,
            [EnumMember(Value = "text/plain"), Display(Name = ".ipproj")]
            IPPROJ,
            [EnumMember(Value = "application/x-itunes-ipsw"), Display(Name = ".ipsw")]
            IPSW,
            [EnumMember(Value = "text/x-ms-iqy"), Display(Name = ".iqy")]
            IQY,
            [EnumMember(Value = "application/x-internet-signup"), Display(Name = ".isp")]
            ISP,
            [EnumMember(Value = "application/x-itunes-ite"), Display(Name = ".ite")]
            ITE,
            [EnumMember(Value = "application/x-itunes-itlp"), Display(Name = ".itlp")]
            ITLP,
            [EnumMember(Value = "application/x-itunes-itms"), Display(Name = ".itms")]
            ITMS,
            [EnumMember(Value = "application/x-itunes-itpc"), Display(Name = ".itpc")]
            ITPC,
            [EnumMember(Value = "video/x-ivf"), Display(Name = ".IVF")]
            IVF,
            [EnumMember(Value = "application/java-archive"), Display(Name = ".jar")]
            JAR,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".java")]
            JAVA,
            [EnumMember(Value = "application/liquidmotion"), Display(Name = ".jck")]
            JCK,
            [EnumMember(Value = "application/liquidmotion"), Display(Name = ".jcz")]
            JCZ,
            [EnumMember(Value = "image/pjpeg"), Display(Name = ".jfif")]
            JFIF,
            [EnumMember(Value = "application/x-java-jnlp-file"), Display(Name = ".jnlp")]
            JNLP,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".jpb")]
            JPB,
            [EnumMember(Value = "image/jpeg"), Display(Name = ".jpe")]
            JPE,
            [EnumMember(Value = "image/jpeg"), Display(Name = ".jpeg")]
            JPEG,
            [EnumMember(Value = "image/jpeg"), Display(Name = ".jpg")]
            JPG,
            [EnumMember(Value = "application/javascript"), Display(Name = ".js")]
            JS,
            [EnumMember(Value = "application/json"), Display(Name = ".json")]
            JSON,
            [EnumMember(Value = "text/jscript"), Display(Name = ".jsx")]
            JSX,
            [EnumMember(Value = "text/plain"), Display(Name = ".jsxbin")]
            JSXBIN,
            [EnumMember(Value = "application/x-latex"), Display(Name = ".latex")]
            LATEX,
            [EnumMember(Value = "application/windows-library+xml"), Display(Name = ".library-ms")]
            LIBRARY_MS,
            [EnumMember(Value = "application/x-ms-reader"), Display(Name = ".lit")]
            LIT,
            [EnumMember(Value = "application/xml"), Display(Name = ".loadtest")]
            LOADTEST,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".lpk")]
            LPK,
            [EnumMember(Value = "video/x-la-asf"), Display(Name = ".lsf")]
            LSF,
            [EnumMember(Value = "text/plain"), Display(Name = ".lst")]
            LST,
            [EnumMember(Value = "video/x-la-asf"), Display(Name = ".lsx")]
            LSX,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".lzh")]
            LZH,
            [EnumMember(Value = "application/x-msmediaview"), Display(Name = ".m13")]
            MD,
            [EnumMember(Value = "text/plain"), Display(Name = ".md")]
            MARKDOWN,
            [EnumMember(Value = "text/plain"), Display(Name = ".markdown")]
            M13,
            [EnumMember(Value = "application/x-msmediaview"), Display(Name = ".m14")]
            M14,
            [EnumMember(Value = "video/mpeg"), Display(Name = ".m1v")]
            M1V,
            [EnumMember(Value = "video/vnd.dlna.mpeg-tts"), Display(Name = ".m2t")]
            M2T,
            [EnumMember(Value = "video/vnd.dlna.mpeg-tts"), Display(Name = ".m2ts")]
            M2TS,
            [EnumMember(Value = "video/mpeg"), Display(Name = ".m2v")]
            M2V,
            [EnumMember(Value = "audio/x-mpegurl"), Display(Name = ".m3u")]
            M3U,
            [EnumMember(Value = "audio/x-mpegurl"), Display(Name = ".m3u8")]
            M3U8,
            [EnumMember(Value = "audio/m4a"), Display(Name = ".m4a")]
            M4A,
            [EnumMember(Value = "audio/m4b"), Display(Name = ".m4b")]
            M4B,
            [EnumMember(Value = "audio/m4p"), Display(Name = ".m4p")]
            M4P,
            [EnumMember(Value = "audio/x-m4r"), Display(Name = ".m4r")]
            M4R,
            [EnumMember(Value = "video/x-m4v"), Display(Name = ".m4v")]
            M4V,
            [EnumMember(Value = "image/x-macpaint"), Display(Name = ".mac")]
            MAC,
            [EnumMember(Value = "text/plain"), Display(Name = ".mak")]
            MAK,
            [EnumMember(Value = "application/x-troff-man"), Display(Name = ".man")]
            MAN,
            [EnumMember(Value = "application/x-ms-manifest"), Display(Name = ".manifest")]
            MANIFEST,
            [EnumMember(Value = "text/plain"), Display(Name = ".map")]
            MAP,
            [EnumMember(Value = "application/xml"), Display(Name = ".master")]
            MASTER,
            [EnumMember(Value = "application/mbox"), Display(Name = ".mbox")]
            MBOX,
            [EnumMember(Value = "application/msaccess"), Display(Name = ".mda")]
            MDA,
            [EnumMember(Value = "application/x-msaccess"), Display(Name = ".mdb")]
            MDB,
            [EnumMember(Value = "application/msaccess"), Display(Name = ".mde")]
            MDE,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".mdp")]
            MDP,
            [EnumMember(Value = "application/x-troff-me"), Display(Name = ".me")]
            ME,
            [EnumMember(Value = "application/x-shockwave-flash"), Display(Name = ".mfp")]
            MFP,
            [EnumMember(Value = "message/rfc822"), Display(Name = ".mht")]
            MHT,
            [EnumMember(Value = "message/rfc822"), Display(Name = ".mhtml")]
            MHTML,
            [EnumMember(Value = "audio/mid"), Display(Name = ".mid")]
            MID,
            [EnumMember(Value = "audio/mid"), Display(Name = ".midi")]
            MIDI,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".mix")]
            MIX,
            [EnumMember(Value = "text/plain"), Display(Name = ".mk")]
            MK,
            [EnumMember(Value = "video/x-matroska-3d"), Display(Name = ".mk3d")]
            MK3D,
            [EnumMember(Value = "audio/x-matroska"), Display(Name = ".mka")]
            MKA,
            [EnumMember(Value = "video/x-matroska"), Display(Name = ".mkv")]
            MKV,
            [EnumMember(Value = "application/x-smaf"), Display(Name = ".mmf")]
            MMF,
            [EnumMember(Value = "text/xml"), Display(Name = ".mno")]
            MNO,
            [EnumMember(Value = "application/x-msmoney"), Display(Name = ".mny")]
            MNY,
            [EnumMember(Value = "video/mpeg"), Display(Name = ".mod")]
            MOD,
            [EnumMember(Value = "video/quicktime"), Display(Name = ".mov")]
            MOV,
            [EnumMember(Value = "video/x-sgi-movie"), Display(Name = ".movie")]
            MOVIE,
            [EnumMember(Value = "video/mpeg"), Display(Name = ".mp2")]
            MP2,
            [EnumMember(Value = "video/mpeg"), Display(Name = ".mp2v")]
            MP2V,
            [EnumMember(Value = "audio/mpeg"), Display(Name = ".mp3")]
            MP3,
            [EnumMember(Value = "video/mp4"), Display(Name = ".mp4")]
            MP4,
            [EnumMember(Value = "video/mp4"), Display(Name = ".mp4v")]
            MP4V,
            [EnumMember(Value = "video/mpeg"), Display(Name = ".mpa")]
            MPA,
            [EnumMember(Value = "video/mpeg"), Display(Name = ".mpe")]
            MPE,
            [EnumMember(Value = "video/mpeg"), Display(Name = ".mpeg")]
            MPEG,
            [EnumMember(Value = "application/vnd.ms-mediapackage"), Display(Name = ".mpf")]
            MPF,
            [EnumMember(Value = "video/mpeg"), Display(Name = ".mpg")]
            MPG,
            [EnumMember(Value = "application/vnd.ms-project"), Display(Name = ".mpp")]
            MPP,
            [EnumMember(Value = "video/mpeg"), Display(Name = ".mpv2")]
            MPV2,
            [EnumMember(Value = "video/quicktime"), Display(Name = ".mqv")]
            MQV,
            [EnumMember(Value = "application/x-troff-ms"), Display(Name = ".ms")]
            MS,
            [EnumMember(Value = "application/vnd.ms-outlook"), Display(Name = ".msg")]
            MSG,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".msi")]
            MSI,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".mso")]
            MSO,
            [EnumMember(Value = "video/vnd.dlna.mpeg-tts"), Display(Name = ".mts")]
            MTS,
            [EnumMember(Value = "application/xml"), Display(Name = ".mtx")]
            MTX,
            [EnumMember(Value = "application/x-msmediaview"), Display(Name = ".mvb")]
            MVB,
            [EnumMember(Value = "application/x-miva-compiled"), Display(Name = ".mvc")]
            MVC,
            [EnumMember(Value = "application/x-mmxp"), Display(Name = ".mxp")]
            MXP,
            [EnumMember(Value = "application/x-netcdf"), Display(Name = ".nc")]
            NC,
            [EnumMember(Value = "video/x-ms-asf"), Display(Name = ".nsc")]
            NSC,
            [EnumMember(Value = "message/rfc822"), Display(Name = ".nws")]
            NWS,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".ocx")]
            OCX,
            [EnumMember(Value = "application/oda"), Display(Name = ".oda")]
            ODA,
            [EnumMember(Value = "application/vnd.oasis.opendocument.database"), Display(Name = ".odb")]
            ODB,
            [EnumMember(Value = "application/vnd.oasis.opendocument.chart"), Display(Name = ".odc")]
            ODC,
            [EnumMember(Value = "application/vnd.oasis.opendocument.formula"), Display(Name = ".odf")]
            ODF,
            [EnumMember(Value = "application/vnd.oasis.opendocument.graphics"), Display(Name = ".odg")]
            ODG,
            [EnumMember(Value = "text/plain"), Display(Name = ".odh")]
            ODH,
            [EnumMember(Value = "application/vnd.oasis.opendocument.image"), Display(Name = ".odi")]
            ODI,
            [EnumMember(Value = "text/plain"), Display(Name = ".odl")]
            ODL,
            [EnumMember(Value = "application/vnd.oasis.opendocument.text-master"), Display(Name = ".odm")]
            ODM,
            [EnumMember(Value = "application/vnd.oasis.opendocument.presentation"), Display(Name = ".odp")]
            ODP,
            [EnumMember(Value = "application/vnd.oasis.opendocument.spreadsheet"), Display(Name = ".ods")]
            ODS,
            [EnumMember(Value = "application/vnd.oasis.opendocument.text"), Display(Name = ".odt")]
            ODT,
            [EnumMember(Value = "audio/ogg"), Display(Name = ".oga")]
            OGA,
            [EnumMember(Value = "audio/ogg"), Display(Name = ".ogg")]
            OGG,
            [EnumMember(Value = "video/ogg"), Display(Name = ".ogv")]
            OGV,
            [EnumMember(Value = "application/ogg"), Display(Name = ".ogx")]
            OGX,
            [EnumMember(Value = "application/onenote"), Display(Name = ".one")]
            ONE,
            [EnumMember(Value = "application/onenote"), Display(Name = ".onea")]
            ONEA,
            [EnumMember(Value = "application/onenote"), Display(Name = ".onepkg")]
            ONEPKG,
            [EnumMember(Value = "application/onenote"), Display(Name = ".onetmp")]
            ONETMP,
            [EnumMember(Value = "application/onenote"), Display(Name = ".onetoc")]
            ONETOC,
            [EnumMember(Value = "application/onenote"), Display(Name = ".onetoc2")]
            ONETOC2,
            [EnumMember(Value = "audio/ogg"), Display(Name = ".opus")]
            OPUS,
            [EnumMember(Value = "application/xml"), Display(Name = ".orderedtest")]
            ORDEREDTEST,
            [EnumMember(Value = "application/opensearchdescription+xml"), Display(Name = ".osdx")]
            OSDX,
            [EnumMember(Value = "application/font-sfnt"), Display(Name = ".otf")]
            OTF,
            [EnumMember(Value = "application/vnd.oasis.opendocument.graphics-template"), Display(Name = ".otg")]
            OTG,
            [EnumMember(Value = "application/vnd.oasis.opendocument.text-web"), Display(Name = ".oth")]
            OTH,
            [EnumMember(Value = "application/vnd.oasis.opendocument.presentation-template"), Display(Name = ".otp")]
            OTP,
            [EnumMember(Value = "application/vnd.oasis.opendocument.spreadsheet-template"), Display(Name = ".ots")]
            OTS,
            [EnumMember(Value = "application/vnd.oasis.opendocument.text-template"), Display(Name = ".ott")]
            OTT,
            [EnumMember(Value = "application/vnd.openofficeorg.extension"), Display(Name = ".oxt")]
            OXT,
            [EnumMember(Value = "application/pkcs10"), Display(Name = ".p10")]
            P10,
            [EnumMember(Value = "application/x-pkcs12"), Display(Name = ".p12")]
            P12,
            [EnumMember(Value = "application/x-pkcs7-certificates"), Display(Name = ".p7b")]
            P7B,
            [EnumMember(Value = "application/pkcs7-mime"), Display(Name = ".p7c")]
            P7C,
            [EnumMember(Value = "application/pkcs7-mime"), Display(Name = ".p7m")]
            P7M,
            [EnumMember(Value = "application/x-pkcs7-certreqresp"), Display(Name = ".p7r")]
            P7R,
            [EnumMember(Value = "application/pkcs7-signature"), Display(Name = ".p7s")]
            P7S,
            [EnumMember(Value = "image/x-portable-bitmap"), Display(Name = ".pbm")]
            PBM,
            [EnumMember(Value = "application/x-podcast"), Display(Name = ".pcast")]
            PCAST,
            [EnumMember(Value = "image/pict"), Display(Name = ".pct")]
            PCT,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".pcx")]
            PCX,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".pcz")]
            PCZ,
            [EnumMember(Value = "application/pdf"), Display(Name = ".pdf")]
            PDF,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".pfb")]
            PFB,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".pfm")]
            PFM,
            [EnumMember(Value = "application/x-pkcs12"), Display(Name = ".pfx")]
            PFX,
            [EnumMember(Value = "image/x-portable-graymap"), Display(Name = ".pgm")]
            PGM,
            [EnumMember(Value = "image/pict"), Display(Name = ".pic")]
            PIC,
            [EnumMember(Value = "image/pict"), Display(Name = ".pict")]
            PICT,
            [EnumMember(Value = "text/plain"), Display(Name = ".pkgdef")]
            PKGDEF,
            [EnumMember(Value = "text/plain"), Display(Name = ".pkgundef")]
            PKGUNDEF,
            [EnumMember(Value = "application/vnd.ms-pki.pko"), Display(Name = ".pko")]
            PKO,
            [EnumMember(Value = "audio/scpls"), Display(Name = ".pls")]
            PLS,
            [EnumMember(Value = "application/x-perfmon"), Display(Name = ".pma")]
            PMA,
            [EnumMember(Value = "application/x-perfmon"), Display(Name = ".pmc")]
            PMC,
            [EnumMember(Value = "application/x-perfmon"), Display(Name = ".pml")]
            PML,
            [EnumMember(Value = "application/x-perfmon"), Display(Name = ".pmr")]
            PMR,
            [EnumMember(Value = "application/x-perfmon"), Display(Name = ".pmw")]
            PMW,
            [EnumMember(Value = "image/png"), Display(Name = ".png")]
            PNG,
            [EnumMember(Value = "image/x-portable-anymap"), Display(Name = ".pnm")]
            PNM,
            [EnumMember(Value = "image/x-macpaint"), Display(Name = ".pnt")]
            PNT,
            [EnumMember(Value = "image/x-macpaint"), Display(Name = ".pntg")]
            PNTG,
            [EnumMember(Value = "image/png"), Display(Name = ".pnz")]
            PNZ,
            [EnumMember(Value = "application/vnd.ms-powerpoint"), Display(Name = ".pot")]
            POT,
            [EnumMember(Value = "application/vnd.ms-powerpoint.template.macroEnabled.12"), Display(Name = ".potm")]
            POTM,
            [EnumMember(Value = "application/vnd.openxmlformats-officedocument.presentationml.template"), Display(Name = ".potx")]
            POTX,
            [EnumMember(Value = "application/vnd.ms-powerpoint"), Display(Name = ".ppa")]
            PPA,
            [EnumMember(Value = "application/vnd.ms-powerpoint.addin.macroEnabled.12"), Display(Name = ".ppam")]
            PPAM,
            [EnumMember(Value = "image/x-portable-pixmap"), Display(Name = ".ppm")]
            PPM,
            [EnumMember(Value = "application/vnd.ms-powerpoint"), Display(Name = ".pps")]
            PPS,
            [EnumMember(Value = "application/vnd.ms-powerpoint.slideshow.macroEnabled.12"), Display(Name = ".ppsm")]
            PPSM,
            [EnumMember(Value = "application/vnd.openxmlformats-officedocument.presentationml.slideshow"), Display(Name = ".ppsx")]
            PPSX,
            [EnumMember(Value = "application/vnd.ms-powerpoint"), Display(Name = ".ppt")]
            PPT,
            [EnumMember(Value = "application/vnd.ms-powerpoint.presentation.macroEnabled.12"), Display(Name = ".pptm")]
            PPTM,
            [EnumMember(Value = "application/vnd.openxmlformats-officedocument.presentationml.presentation"), Display(Name = ".pptx")]
            PPTX,
            [EnumMember(Value = "application/pics-rules"), Display(Name = ".prf")]
            PRF,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".prm")]
            PRM,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".prx")]
            PRX,
            [EnumMember(Value = "application/postscript"), Display(Name = ".ps")]
            PS,
            [EnumMember(Value = "application/PowerShell"), Display(Name = ".psc1")]
            PSC1,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".psd")]
            PSD,
            [EnumMember(Value = "application/xml"), Display(Name = ".psess")]
            PSESS,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".psm")]
            PSM,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".psp")]
            PSP,
            [EnumMember(Value = "application/vnd.ms-outlook"), Display(Name = ".pst")]
            PST,
            [EnumMember(Value = "application/x-mspublisher"), Display(Name = ".pub")]
            PUB,
            [EnumMember(Value = "application/vnd.ms-powerpoint"), Display(Name = ".pwz")]
            PWZ,
            [EnumMember(Value = "text/x-html-insertion"), Display(Name = ".qht")]
            QHT,
            [EnumMember(Value = "text/x-html-insertion"), Display(Name = ".qhtm")]
            QHTM,
            [EnumMember(Value = "video/quicktime"), Display(Name = ".qt")]
            QT,
            [EnumMember(Value = "image/x-quicktime"), Display(Name = ".qti")]
            QTI,
            [EnumMember(Value = "image/x-quicktime"), Display(Name = ".qtif")]
            QTIF,
            [EnumMember(Value = "application/x-quicktimeplayer"), Display(Name = ".qtl")]
            QTL,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".qxd")]
            QXD,
            [EnumMember(Value = "audio/x-pn-realaudio"), Display(Name = ".ra")]
            RA,
            [EnumMember(Value = "audio/x-pn-realaudio"), Display(Name = ".ram")]
            RAM,
            [EnumMember(Value = "application/x-rar-compressed"), Display(Name = ".rar")]
            RAR,
            [EnumMember(Value = "image/x-cmu-raster"), Display(Name = ".ras")]
            RAS,
            [EnumMember(Value = "application/rat-file"), Display(Name = ".rat")]
            RAT,
            [EnumMember(Value = "text/plain"), Display(Name = ".rc")]
            RC,
            [EnumMember(Value = "text/plain"), Display(Name = ".rc2")]
            RC2,
            [EnumMember(Value = "text/plain"), Display(Name = ".rct")]
            RCT,
            [EnumMember(Value = "application/xml"), Display(Name = ".rdlc")]
            RDLC,
            [EnumMember(Value = "text/plain"), Display(Name = ".reg")]
            REG,
            [EnumMember(Value = "application/xml"), Display(Name = ".resx")]
            RESX,
            [EnumMember(Value = "image/vnd.rn-realflash"), Display(Name = ".rf")]
            RF,
            [EnumMember(Value = "image/x-rgb"), Display(Name = ".rgb")]
            RGB,
            [EnumMember(Value = "text/plain"), Display(Name = ".rgs")]
            RGS,
            [EnumMember(Value = "application/vnd.rn-realmedia"), Display(Name = ".rm")]
            RM,
            [EnumMember(Value = "audio/mid"), Display(Name = ".rmi")]
            RMI,
            [EnumMember(Value = "application/vnd.rn-rn_music_package"), Display(Name = ".rmp")]
            RMP,
            [EnumMember(Value = "application/x-troff"), Display(Name = ".roff")]
            ROFF,
            [EnumMember(Value = "audio/x-pn-realaudio-plugin"), Display(Name = ".rpm")]
            RPM,
            [EnumMember(Value = "text/x-ms-rqy"), Display(Name = ".rqy")]
            RQY,
            [EnumMember(Value = "application/rtf"), Display(Name = ".rtf")]
            RTF,
            [EnumMember(Value = "text/richtext"), Display(Name = ".rtx")]
            RTX,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".rvt")]
            RVT,
            [EnumMember(Value = "application/xml"), Display(Name = ".ruleset")]
            RULESET,
            [EnumMember(Value = "text/plain"), Display(Name = ".s")]
            S,
            [EnumMember(Value = "application/x-safari-safariextz"), Display(Name = ".safariextz")]
            SAFARIEXTZ,
            [EnumMember(Value = "application/x-msschedule"), Display(Name = ".scd")]
            SCD,
            [EnumMember(Value = "text/plain"), Display(Name = ".scr")]
            SCR,
            [EnumMember(Value = "text/scriptlet"), Display(Name = ".sct")]
            SCT,
            [EnumMember(Value = "audio/x-sd2"), Display(Name = ".sd2")]
            SD2,
            [EnumMember(Value = "application/sdp"), Display(Name = ".sdp")]
            SDP,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".sea")]
            SEA,
            [EnumMember(Value = "application/windows-search-connector+xml"), Display(Name = ".searchConnector-ms")]
            SEARCHCONNECTOR_MS,
            [EnumMember(Value = "application/set-payment-initiation"), Display(Name = ".setpay")]
            SETPAY,
            [EnumMember(Value = "application/set-registration-initiation"), Display(Name = ".setreg")]
            SETREG,
            [EnumMember(Value = "application/xml"), Display(Name = ".settings")]
            SETTINGS,
            [EnumMember(Value = "application/x-sgimb"), Display(Name = ".sgimb")]
            SGIMB,
            [EnumMember(Value = "text/sgml"), Display(Name = ".sgml")]
            SGML,
            [EnumMember(Value = "application/x-sh"), Display(Name = ".sh")]
            SH,
            [EnumMember(Value = "application/x-shar"), Display(Name = ".shar")]
            SHAR,
            [EnumMember(Value = "text/html"), Display(Name = ".shtml")]
            SHTML,
            [EnumMember(Value = "application/x-stuffit"), Display(Name = ".sit")]
            SIT,
            [EnumMember(Value = "application/xml"), Display(Name = ".sitemap")]
            SITEMAP,
            [EnumMember(Value = "application/xml"), Display(Name = ".skin")]
            SKIN,
            [EnumMember(Value = "application/x-koan"), Display(Name = ".skp")]
            SKP,
            [EnumMember(Value = "application/vnd.ms-powerpoint.slide.macroEnabled.12"), Display(Name = ".sldm")]
            SLDM,
            [EnumMember(Value = "application/vnd.openxmlformats-officedocument.presentationml.slide"), Display(Name = ".sldx")]
            SLDX,
            [EnumMember(Value = "application/vnd.ms-excel"), Display(Name = ".slk")]
            SLK,
            [EnumMember(Value = "text/plain"), Display(Name = ".sln")]
            SLN,
            [EnumMember(Value = "application/x-ms-license"), Display(Name = ".slupkg-ms")]
            SLUPKG_MS,
            [EnumMember(Value = "audio/x-smd"), Display(Name = ".smd")]
            SMD,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".smi")]
            SMI,
            [EnumMember(Value = "audio/x-smd"), Display(Name = ".smx")]
            SMX,
            [EnumMember(Value = "audio/x-smd"), Display(Name = ".smz")]
            SMZ,
            [EnumMember(Value = "audio/basic"), Display(Name = ".snd")]
            SND,
            [EnumMember(Value = "application/xml"), Display(Name = ".snippet")]
            SNIPPET,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".snp")]
            SNP,
            [EnumMember(Value = "text/plain"), Display(Name = ".sol")]
            SOL,
            [EnumMember(Value = "text/plain"), Display(Name = ".sor")]
            SOR,
            [EnumMember(Value = "application/x-pkcs7-certificates"), Display(Name = ".spc")]
            SPC,
            [EnumMember(Value = "application/futuresplash"), Display(Name = ".spl")]
            SPL,
            [EnumMember(Value = "audio/ogg"), Display(Name = ".spx")]
            SPX,
            [EnumMember(Value = "application/x-wais-source"), Display(Name = ".src")]
            SRC,
            [EnumMember(Value = "text/plain"), Display(Name = ".srf")]
            SRF,
            [EnumMember(Value = "text/xml"), Display(Name = ".SSISDeploymentManifest")]
            SSISDEPLOYMENTMANIFEST,
            [EnumMember(Value = "application/streamingmedia"), Display(Name = ".ssm")]
            SSM,
            [EnumMember(Value = "application/vnd.ms-pki.certstore"), Display(Name = ".sst")]
            SST,
            [EnumMember(Value = "application/vnd.ms-pki.stl"), Display(Name = ".stl")]
            STL,
            [EnumMember(Value = "application/x-sv4cpio"), Display(Name = ".sv4cpio")]
            SV4CPIO,
            [EnumMember(Value = "application/x-sv4crc"), Display(Name = ".sv4crc")]
            SV4CRC,
            [EnumMember(Value = "application/xml"), Display(Name = ".svc")]
            SVC,
            [EnumMember(Value = "image/svg+xml"), Display(Name = ".svg")]
            SVG,
            [EnumMember(Value = "application/x-shockwave-flash"), Display(Name = ".swf")]
            SWF,
            [EnumMember(Value = "application/step"), Display(Name = ".step")]
            STEP,
            [EnumMember(Value = "application/step"), Display(Name = ".stp")]
            STP,
            [EnumMember(Value = "application/x-troff"), Display(Name = ".t")]
            T,
            [EnumMember(Value = "application/x-tar"), Display(Name = ".tar")]
            TAR,
            [EnumMember(Value = "application/x-tcl"), Display(Name = ".tcl")]
            TCL,
            [EnumMember(Value = "application/xml"), Display(Name = ".testrunconfig")]
            TESTRUNCONFIG,
            [EnumMember(Value = "application/xml"), Display(Name = ".testsettings")]
            TESTSETTINGS,
            [EnumMember(Value = "application/x-tex"), Display(Name = ".tex")]
            TEX,
            [EnumMember(Value = "application/x-texinfo"), Display(Name = ".texi")]
            TEXI,
            [EnumMember(Value = "application/x-texinfo"), Display(Name = ".texinfo")]
            TEXINFO,
            [EnumMember(Value = "application/x-compressed"), Display(Name = ".tgz")]
            TGZ,
            [EnumMember(Value = "application/vnd.ms-officetheme"), Display(Name = ".thmx")]
            THMX,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".thn")]
            THN,
            [EnumMember(Value = "image/tiff"), Display(Name = ".tif")]
            TIF,
            [EnumMember(Value = "image/tiff"), Display(Name = ".tiff")]
            TIFF,
            [EnumMember(Value = "text/plain"), Display(Name = ".tlh")]
            TLH,
            [EnumMember(Value = "text/plain"), Display(Name = ".tli")]
            TLI,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".toc")]
            TOC,
            [EnumMember(Value = "application/x-troff"), Display(Name = ".tr")]
            TR,
            [EnumMember(Value = "application/x-msterminal"), Display(Name = ".trm")]
            TRM,
            [EnumMember(Value = "application/xml"), Display(Name = ".trx")]
            TRX,
            [EnumMember(Value = "video/vnd.dlna.mpeg-tts"), Display(Name = ".ts")]
            TS,
            [EnumMember(Value = "text/tab-separated-values"), Display(Name = ".tsv")]
            TSV,
            [EnumMember(Value = "application/font-sfnt"), Display(Name = ".ttf")]
            TTF,
            [EnumMember(Value = "video/vnd.dlna.mpeg-tts"), Display(Name = ".tts")]
            TTS,
            [EnumMember(Value = "text/plain"), Display(Name = ".txt")]
            TXT,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".u32")]
            U32,
            [EnumMember(Value = "text/iuls"), Display(Name = ".uls")]
            ULS,
            [EnumMember(Value = "text/plain"), Display(Name = ".user")]
            USER,
            [EnumMember(Value = "application/x-ustar"), Display(Name = ".ustar")]
            USTAR,
            [EnumMember(Value = "text/plain"), Display(Name = ".vb")]
            VB,
            [EnumMember(Value = "text/plain"), Display(Name = ".vbdproj")]
            VBDPROJ,
            [EnumMember(Value = "video/mpeg"), Display(Name = ".vbk")]
            VBK,
            [EnumMember(Value = "text/plain"), Display(Name = ".vbproj")]
            VBPROJ,
            [EnumMember(Value = "text/vbscript"), Display(Name = ".vbs")]
            VBS,
            [EnumMember(Value = "text/x-vcard"), Display(Name = ".vcf")]
            VCF,
            [EnumMember(Value = "application/xml"), Display(Name = ".vcproj")]
            VCPROJ,
            [EnumMember(Value = "text/plain"), Display(Name = ".vcs")]
            VCS,
            [EnumMember(Value = "application/xml"), Display(Name = ".vcxproj")]
            VCXPROJ,
            [EnumMember(Value = "text/plain"), Display(Name = ".vddproj")]
            VDDPROJ,
            [EnumMember(Value = "text/plain"), Display(Name = ".vdp")]
            VDP,
            [EnumMember(Value = "text/plain"), Display(Name = ".vdproj")]
            VDPROJ,
            [EnumMember(Value = "application/vnd.ms-visio.viewer"), Display(Name = ".vdx")]
            VDX,
            [EnumMember(Value = "text/xml"), Display(Name = ".vml")]
            VML,
            [EnumMember(Value = "application/xml"), Display(Name = ".vscontent")]
            VSCONTENT,
            [EnumMember(Value = "text/xml"), Display(Name = ".vsct")]
            VSCT,
            [EnumMember(Value = "application/vnd.visio"), Display(Name = ".vsd")]
            VSD,
            [EnumMember(Value = "application/ms-vsi"), Display(Name = ".vsi")]
            VSI,
            [EnumMember(Value = "application/vsix"), Display(Name = ".vsix")]
            VSIX,
            [EnumMember(Value = "text/xml"), Display(Name = ".vsixlangpack")]
            VSIXLANGPACK,
            [EnumMember(Value = "text/xml"), Display(Name = ".vsixmanifest")]
            VSIXMANIFEST,
            [EnumMember(Value = "application/xml"), Display(Name = ".vsmdi")]
            VSMDI,
            [EnumMember(Value = "text/plain"), Display(Name = ".vspscc")]
            VSPSCC,
            [EnumMember(Value = "application/vnd.visio"), Display(Name = ".vss")]
            VSS,
            [EnumMember(Value = "text/plain"), Display(Name = ".vsscc")]
            VSSCC,
            [EnumMember(Value = "text/xml"), Display(Name = ".vssettings")]
            VSSETTINGS,
            [EnumMember(Value = "text/plain"), Display(Name = ".vssscc")]
            VSSSCC,
            [EnumMember(Value = "application/vnd.visio"), Display(Name = ".vst")]
            VST,
            [EnumMember(Value = "text/xml"), Display(Name = ".vstemplate")]
            VSTEMPLATE,
            [EnumMember(Value = "application/x-ms-vsto"), Display(Name = ".vsto")]
            VSTO,
            [EnumMember(Value = "application/vnd.visio"), Display(Name = ".vsw")]
            VSW,
            [EnumMember(Value = "application/vnd.visio"), Display(Name = ".vsx")]
            VSX,
            [EnumMember(Value = "application/vnd.visio"), Display(Name = ".vtx")]
            VTX,
            [EnumMember(Value = "application/wasm"), Display(Name = ".wasm")]
            WASM,
            [EnumMember(Value = "audio/wav"), Display(Name = ".wav")]
            WAV,
            [EnumMember(Value = "audio/wav"), Display(Name = ".wave")]
            WAVE,
            [EnumMember(Value = "audio/x-ms-wax"), Display(Name = ".wax")]
            WAX,
            [EnumMember(Value = "application/msword"), Display(Name = ".wbk")]
            WBK,
            [EnumMember(Value = "image/vnd.wap.wbmp"), Display(Name = ".wbmp")]
            WBMP,
            [EnumMember(Value = "application/vnd.ms-works"), Display(Name = ".wcm")]
            WCM,
            [EnumMember(Value = "application/vnd.ms-works"), Display(Name = ".wdb")]
            WDB,
            [EnumMember(Value = "image/vnd.ms-photo"), Display(Name = ".wdp")]
            WDP,
            [EnumMember(Value = "application/x-safari-webarchive"), Display(Name = ".webarchive")]
            WEBARCHIVE,
            [EnumMember(Value = "video/webm"), Display(Name = ".webm")]
            WEBM,
            [EnumMember(Value = "image/webp"), Display(Name = ".webp")]
            WEBP,
            [EnumMember(Value = "application/xml"), Display(Name = ".webtest")]
            WEBTEST,
            [EnumMember(Value = "application/xml"), Display(Name = ".wiq")]
            WIQ,
            [EnumMember(Value = "application/msword"), Display(Name = ".wiz")]
            WIZ,
            [EnumMember(Value = "application/vnd.ms-works"), Display(Name = ".wks")]
            WKS,
            [EnumMember(Value = "application/wlmoviemaker"), Display(Name = ".WLMP")]
            WLMP,
            [EnumMember(Value = "application/x-wlpg-detect"), Display(Name = ".wlpginstall")]
            WLPGINSTALL,
            [EnumMember(Value = "application/x-wlpg3-detect"), Display(Name = ".wlpginstall3")]
            WLPGINSTALL3,
            [EnumMember(Value = "video/x-ms-wm"), Display(Name = ".wm")]
            WM,
            [EnumMember(Value = "audio/x-ms-wma"), Display(Name = ".wma")]
            WMA,
            [EnumMember(Value = "application/x-ms-wmd"), Display(Name = ".wmd")]
            WMD,
            [EnumMember(Value = "application/x-msmetafile"), Display(Name = ".wmf")]
            WMF,
            [EnumMember(Value = "text/vnd.wap.wml"), Display(Name = ".wml")]
            WML,
            [EnumMember(Value = "application/vnd.wap.wmlc"), Display(Name = ".wmlc")]
            WMLC,
            [EnumMember(Value = "text/vnd.wap.wmlscript"), Display(Name = ".wmls")]
            WMLS,
            [EnumMember(Value = "application/vnd.wap.wmlscriptc"), Display(Name = ".wmlsc")]
            WMLSC,
            [EnumMember(Value = "video/x-ms-wmp"), Display(Name = ".wmp")]
            WMP,
            [EnumMember(Value = "video/x-ms-wmv"), Display(Name = ".wmv")]
            WMV,
            [EnumMember(Value = "video/x-ms-wmx"), Display(Name = ".wmx")]
            WMX,
            [EnumMember(Value = "application/x-ms-wmz"), Display(Name = ".wmz")]
            WMZ,
            [EnumMember(Value = "application/font-woff"), Display(Name = ".woff")]
            WOFF,
            [EnumMember(Value = "application/font-woff2"), Display(Name = ".woff2")]
            WOFF2,
            [EnumMember(Value = "application/vnd.ms-wpl"), Display(Name = ".wpl")]
            WPL,
            [EnumMember(Value = "application/vnd.ms-works"), Display(Name = ".wps")]
            WPS,
            [EnumMember(Value = "application/x-mswrite"), Display(Name = ".wri")]
            WRI,
            [EnumMember(Value = "x-world/x-vrml"), Display(Name = ".wrl")]
            WRL,
            [EnumMember(Value = "x-world/x-vrml"), Display(Name = ".wrz")]
            WRZ,
            [EnumMember(Value = "text/scriptlet"), Display(Name = ".wsc")]
            WSC,
            [EnumMember(Value = "text/xml"), Display(Name = ".wsdl")]
            WSDL,
            [EnumMember(Value = "video/x-ms-wvx"), Display(Name = ".wvx")]
            WVX,
            [EnumMember(Value = "application/directx"), Display(Name = ".x")]
            X,
            [EnumMember(Value = "x-world/x-vrml"), Display(Name = ".xaf")]
            XAF,
            [EnumMember(Value = "application/xaml+xml"), Display(Name = ".xaml")]
            XAML,
            [EnumMember(Value = "application/x-silverlight-app"), Display(Name = ".xap")]
            XAP,
            [EnumMember(Value = "application/x-ms-xbap"), Display(Name = ".xbap")]
            XBAP,
            [EnumMember(Value = "image/x-xbitmap"), Display(Name = ".xbm")]
            XBM,
            [EnumMember(Value = "text/plain"), Display(Name = ".xdr")]
            XDR,
            [EnumMember(Value = "application/xhtml+xml"), Display(Name = ".xht")]
            XHT,
            [EnumMember(Value = "application/xhtml+xml"), Display(Name = ".xhtml")]
            XHTML,
            [EnumMember(Value = "application/vnd.ms-excel"), Display(Name = ".xla")]
            XLA,
            [EnumMember(Value = "application/vnd.ms-excel.addin.macroEnabled.12"), Display(Name = ".xlam")]
            XLAM,
            [EnumMember(Value = "application/vnd.ms-excel"), Display(Name = ".xlc")]
            XLC,
            [EnumMember(Value = "application/vnd.ms-excel"), Display(Name = ".xld")]
            XLD,
            [EnumMember(Value = "application/vnd.ms-excel"), Display(Name = ".xlk")]
            XLK,
            [EnumMember(Value = "application/vnd.ms-excel"), Display(Name = ".xll")]
            XLL,
            [EnumMember(Value = "application/vnd.ms-excel"), Display(Name = ".xlm")]
            XLM,
            [EnumMember(Value = "application/vnd.ms-excel"), Display(Name = ".xls")]
            XLS,
            [EnumMember(Value = "application/vnd.ms-excel.sheet.binary.macroEnabled.12"), Display(Name = ".xlsb")]
            XLSB,
            [EnumMember(Value = "application/vnd.ms-excel.sheet.macroEnabled.12"), Display(Name = ".xlsm")]
            XLSM,
            [EnumMember(Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"), Display(Name = ".xlsx")]
            XLSX,
            [EnumMember(Value = "application/vnd.ms-excel"), Display(Name = ".xlt")]
            XLT,
            [EnumMember(Value = "application/vnd.ms-excel.template.macroEnabled.12"), Display(Name = ".xltm")]
            XLTM,
            [EnumMember(Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.template"), Display(Name = ".xltx")]
            XLTX,
            [EnumMember(Value = "application/vnd.ms-excel"), Display(Name = ".xlw")]
            XLW,
            [EnumMember(Value = "text/xml"), Display(Name = ".xml")]
            XML,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".xmp")]
            XMP,
            [EnumMember(Value = "application/xml"), Display(Name = ".xmta")]
            XMTA,
            [EnumMember(Value = "x-world/x-vrml"), Display(Name = ".xof")]
            XOF,
            [EnumMember(Value = "text/plain"), Display(Name = ".XOML")]
            XOML,
            [EnumMember(Value = "image/x-xpixmap"), Display(Name = ".xpm")]
            XPM,
            [EnumMember(Value = "application/vnd.ms-xpsdocument"), Display(Name = ".xps")]
            XPS,
            [EnumMember(Value = "text/xml"), Display(Name = ".xrm-ms")]
            XRM_MS,
            [EnumMember(Value = "application/xml"), Display(Name = ".xsc")]
            XSC,
            [EnumMember(Value = "text/xml"), Display(Name = ".xsd")]
            XSD,
            [EnumMember(Value = "text/xml"), Display(Name = ".xsf")]
            XSF,
            [EnumMember(Value = "text/xml"), Display(Name = ".xsl")]
            XSL,
            [EnumMember(Value = "text/xml"), Display(Name = ".xslt")]
            XSLT,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".xsn")]
            XSN,
            [EnumMember(Value = "application/xml"), Display(Name = ".xss")]
            XSS,
            [EnumMember(Value = "application/xspf+xml"), Display(Name = ".xspf")]
            XSPF,
            [EnumMember(Value = "application/octet-stream"), Display(Name = ".xtp")]
            XTP,
            [EnumMember(Value = "image/x-xwindowdump"), Display(Name = ".xwd")]
            XWD,
            [EnumMember(Value = "application/x-compress"), Display(Name = ".z")]
            Z,
            [EnumMember(Value = "application/zip"), Display(Name = ".zip")]
            ZIP
        }
    }
}
