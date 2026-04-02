using PdfSharpCore.Fonts;
using System;
using System.IO;

namespace ExamReady.Utils
{
    public sealed class PdfFontResolver : IFontResolver
    {
        private const string RegularFace = "ExamReadySans-Regular";
        private const string BoldFace = "ExamReadySans-Bold";

        public string DefaultFontName => "ExamReadySans";

        private static readonly Lazy<byte[]> RegularFontData = new(() => LoadFontBytes(new[]
        {
            "/usr/share/fonts/noto/NotoSansDevanagari-Regular.ttf",
            "/usr/share/fonts/noto/NotoSans-Regular.ttf",
            "/usr/share/fonts/TTF/DejaVuSans.ttf"
        }));

        private static readonly Lazy<byte[]> BoldFontData = new(() => LoadFontBytes(new[]
        {
            "/usr/share/fonts/noto/NotoSansDevanagari-Bold.ttf",
            "/usr/share/fonts/noto/NotoSans-Bold.ttf",
            "/usr/share/fonts/TTF/DejaVuSans-Bold.ttf"
        }));

        public static void EnsureConfigured()
        {
            if (GlobalFontSettings.FontResolver is PdfFontResolver)
            {
                return;
            }

            GlobalFontSettings.FontResolver = new PdfFontResolver();
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            if (!string.Equals(familyName, "ExamReadySans", StringComparison.OrdinalIgnoreCase))
            {
                familyName = "ExamReadySans";
            }

            return new FontResolverInfo(isBold ? BoldFace : RegularFace);
        }

        public byte[] GetFont(string faceName)
        {
            return faceName switch
            {
                BoldFace => BoldFontData.Value,
                _ => RegularFontData.Value
            };
        }

        private static byte[] LoadFontBytes(string[] candidates)
        {
            foreach (var path in candidates)
            {
                if (File.Exists(path))
                {
                    return File.ReadAllBytes(path);
                }
            }

            throw new FileNotFoundException("No suitable PDF font file found on this system.");
        }
    }
}