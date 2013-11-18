using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using PalettesModule.Data;
using PalettesModule.Model;

namespace PalettesModule
{
    public class ThemeEngine
    {
        //public static void UpdateGeneratedCSS(Guid paletteId)
        //{
        //    PalettesManager manager = PalettesManager.GetManager();

        //    PaletteItem palette = manager.GetPalette(paletteId);

        //    string urlName = palette.UrlName;

        //    string templateDir = HttpContext.Current.Server.MapPath(@"~/App_Data/Sitefinity/WebsiteTemplates/");
        //    string[] files = Directory.GetFiles(templateDir, string.Format("*_{0}.css", urlName), SearchOption.AllDirectories);
        //    if (files.Length > 0)
        //    {
        //        foreach (string file in files)
        //        {
        //            string parsedFileName = Path.GetFileName(file);
        //            string sourceFileName = parsedFileName.Replace(string.Format("_{0}", urlName), "");
        //            string path = Path.GetDirectoryName(file);

        //            ThemeEngine.GenerateThemedCSS(Path.Combine(string.Format("{0}{1}", path, @"Themeable")), sourceFileName, paletteId);   
        //        }
        //    }
        //}

        public static void DeleteGeneratedCSS(string generatedPath, string sourceNameNoExtension, string urlName)
        {
            if (Directory.Exists(generatedPath))
            {
                string[] filesByPalette = Directory.GetFiles(generatedPath, string.Format("{0}????_{1}????.css", sourceNameNoExtension, urlName), SearchOption.TopDirectoryOnly);

                if (filesByPalette.Length > 0)
                {
                    foreach (string file in filesByPalette)
                    {
                        File.Delete(file);
                    }
                }
            }
        }

        //public static string GenerateThemedCSS(string themePath, string sourceFile, string paletteTitle)
        public static string GenerateThemedCSS(string themePath, string sourceFile, Guid paletteId)
        {
            PalettesManager manager = PalettesManager.GetManager();
            PaletteItem palette = manager.GetPalette(paletteId);
            //PaletteItem palette = manager.GetPalettes().Where(p => p.Title == paletteTitle).FirstOrDefault();

            Dictionary<string, string> theme = new Dictionary<string, string>();

            theme = theme.Union(GenerateSwatch("Dark1", palette.Dark1)).ToDictionary(i => i.Key, i => i.Value);
            theme = theme.Union(GenerateSwatch("Light1", palette.Light1)).ToDictionary(i => i.Key, i => i.Value);
            theme = theme.Union(GenerateSwatch("Dark2", palette.Dark2)).ToDictionary(i => i.Key, i => i.Value);
            theme = theme.Union(GenerateSwatch("Light2", palette.Light2)).ToDictionary(i => i.Key, i => i.Value);
            theme = theme.Union(GenerateSwatch("Accent1", palette.Accent1)).ToDictionary(i => i.Key, i => i.Value);
            theme = theme.Union(GenerateSwatch("Accent2", palette.Accent2)).ToDictionary(i => i.Key, i => i.Value);
            theme = theme.Union(GenerateSwatch("Accent3", palette.Accent3)).ToDictionary(i => i.Key, i => i.Value);
            theme = theme.Union(GenerateSwatch("Accent4", palette.Accent4)).ToDictionary(i => i.Key, i => i.Value);
            theme = theme.Union(GenerateSwatch("Accent5", palette.Accent5)).ToDictionary(i => i.Key, i => i.Value);
            theme = theme.Union(GenerateSwatch("Accent6", palette.Accent6)).ToDictionary(i => i.Key, i => i.Value);
            theme = theme.Union(GenerateSwatch("Hyperlink", palette.Hyperlink)).ToDictionary(i => i.Key, i => i.Value);
            theme = theme.Union(GenerateSwatch("FollowedHyperlink", palette.FollowedHyperlink)).ToDictionary(i => i.Key, i => i.Value);

            string sourceFilePath = Path.Combine(themePath, @"CSS\Themeable", sourceFile);
            FileInfo sourceFileInfo = new FileInfo(sourceFilePath);

            string f = File.ReadAllText(sourceFilePath);

            f = Regex.Replace(f, @"(/\*\s+?\[(ReplaceColor)\(themeColor:""((?:(?:(?:Light|Dark)(?:1|2)|Accent[1-6]|(?:Followed)?Hyperlink)(?:-(?:Lighter|Lightest|Medium|Darker|Darkest))?))""\)\]\s*?\*/\s*?((\S.+?):\s*?(.+?);))", delegate(Match match)
            {
                return Regex.Replace(match.Groups[4].Value, @"#(?:(?:[a-fA-F\d]{3}){1,2})", theme[match.Groups[3].Value]);
            });

            //f = Regex.Replace(f, @"(/\*\s+?\[(ReplaceFont)\(themeFont:""([a-zA-Z0-9-]+?)""\)\]\s=?\*/\s+?((\S.+?):\s*?(.+?);))", delegate(Match match)
            //{
            //    string r = "";

            //    switch (match.Groups[5].Value)
            //    {
            //        case "font":
            //            r = Regex.Replace(match.Groups[4].Value, @"font:\s*?((?:(?:inherit|normal|italic|oblique))?\s*?(?:(?:inherit|normal|small-caps))?\s*?(?:(?:inherit|normal|bold(?:er)?|lighter|[1-9]00))?(?:\s*?(?:\d+(?:%|px|em|pt)?|(?:x(?:x)?-)?(?:small|large)r?)|medium|inherit)(?:\/(?:\d+(?:%|px|em|pt)?|normal|inherit))?\s*?(?:(inherit|default|.+?));)", delegate(Match m)
            //            {
            //                return string.Format("font:{0}", Regex.Replace(m.Groups[1].Value, m.Groups[2].Value, string.Format(" {0}", fonts[match.Groups[3].Value])));
            //            });
            //            break;
            //        case "font-family":
            //            r = string.Format("{0}:{1};", match.Groups[5].Value, fonts[match.Groups[3].Value]);
            //            break;
            //        default:
            //            break;
            //    }

            //    return r;
            //});

            string sourceModSuffix = String.Format("{0:ssff}", sourceFileInfo.LastWriteTime);
            string modSuffix = String.Format("{0:ssff}", palette.LastModified);
            string newFileName = string.Format("{0}{1}_{2}{3}.css", sourceFile.Substring(0, sourceFile.Length - 4), sourceModSuffix, palette.UrlName, modSuffix);

            string newFilePath = Path.Combine(themePath, @"CSS\Generated\", newFileName);

            (new FileInfo(newFilePath)).Directory.Create();

            File.WriteAllText(newFilePath, f);

            return newFileName;
        }

        private static Dictionary<string, string> GenerateSwatch(string label, string baseColor)
        {
            Dictionary<string, string> swatch = new Dictionary<string, string>();

            Color _bColor = ColorTranslator.FromHtml(baseColor);
            int[] _baseColor = new int[] {_bColor.R, _bColor.G, _bColor.B};

            var white = new int[] {255, 255, 255};
            var black= new int[] {0, 0, 0};

            swatch.Add(label, ColorTranslator.ToHtml(_bColor));
            swatch.Add(string.Format("{0}-Lightest", label), GenerateColor(_baseColor, .25, white));
            swatch.Add(string.Format("{0}-Lighter", label), GenerateColor(_baseColor, .45, white));
            swatch.Add(string.Format("{0}-Medium", label), GenerateColor(_baseColor, .76, white));
            swatch.Add(string.Format("{0}-Darker", label), GenerateColor(_baseColor, .75, black));
            swatch.Add(string.Format("{0}-Darkest", label), GenerateColor(_baseColor, .5, black));

            return swatch;
        }

        private static string GenerateColor (int[] baseRGB, double opacity, int[] maskRGB)
        {
	        int[] newColor = new int[] {0, 0, 0};

            for (int i = 0; i < 3; i++)
            {
                newColor[i] = Convert.ToInt32(Math.Round(baseRGB[i] * opacity) + Math.Round(maskRGB[i] * (1.0 - opacity)));
            }

            Color nc = Color.FromArgb(255, newColor[0], newColor[1], newColor[2]);

            return ColorTranslator.ToHtml(nc);
        }
    }
}