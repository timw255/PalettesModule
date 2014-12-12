using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Threading;
using System.Globalization;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Multisite;
using Telerik.Sitefinity.Services;
using PaletteModule.Models;

namespace PaletteModule.Web.Controls
{
	[ParseChildren(true)]
	public partial class DynamicTheme : WebControl
	{
		private List<ThemeableSourceFile> _sourceFiles;

		[PersistenceMode(PersistenceMode.InnerProperty)]
		public List<ThemeableSourceFile> SourceFiles
		{
			get
			{
				if (this._sourceFiles == null)
				{
					this._sourceFiles = new List<ThemeableSourceFile>();
				}

				return _sourceFiles;
			}
		}

		public string Palette { get; set; }
		public bool DevelopmentMode { get; set; }

		public DynamicTheme()
		{
			this.Visible = false;
			this.Palette = "";
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			this.Page.PreRenderComplete += new EventHandler(Page_PreRenderComplete);
		}

		private void Page_PreRenderComplete(object sender, EventArgs e)
		{
			string currentTheme = Utility.GetCurrentTheme();
			if (!currentTheme.IsNullOrWhitespace())
			{
				string relativeThemePath = Utility.GetThemePath(currentTheme);
				string themePath = HttpContext.Current.Server.MapPath(relativeThemePath);
				string siteName = string.Empty;

				string provider = string.Empty;
                var cContext = SystemManager.CurrentContext;

                if (cContext is MultisiteContext)
                {
                    MultisiteContext msContext = cContext as MultisiteContext;
                    siteName = msContext.CurrentSiteContext.Site.Name;
                    provider = msContext.CurrentSite.GetDefaultProvider(PaletteModuleClass.ModuleName).ProviderName;
                }
                else
                {
                    siteName = cContext.CurrentSite.Name;
                    //provider = cContext.CurrentSite.GetDefaultProvider(PaletteModuleClass.ModuleName).ProviderName;
                }

                PaletteItem palette = PaletteModuleManager.GetManager(provider).GetPaletteItems().Where(p => p.Title == this.Palette).FirstOrDefault();

				if (palette != null)
				{
					foreach (ThemeableSourceFile sourceFile in this.SourceFiles)
					{
						if (!IsNullOrEmptyOrWhiteSpace(sourceFile.Name) && sourceFile.Name.EndsWith(".css"))
						{
							string title = palette.Title;
							string themeableDir = Path.Combine(themePath, @"CSS\Themeable\");
							string sourceFilePath = Path.Combine(themeableDir, sourceFile.Name);

							if (File.Exists(sourceFilePath))
							{
								FileInfo sourceFileInfo = new FileInfo(sourceFilePath);
								string generatedPath = Path.Combine(themePath, @"CSS\Generated");

								string sourceNameNoExtension = sourceFile.Name.Substring(0, sourceFile.Name.Length - 4);
								string sourceModSuffix = String.Format("{0:ssff}", sourceFileInfo.LastWriteTime);
								string modSuffix = String.Format("{0:ssff}", palette.LastModified);
								string themedFileName = string.Format("{0}{1}_{2}{3}-{4}.css", sourceNameNoExtension, sourceModSuffix, title, modSuffix, siteName);

								string generatedFile = Path.Combine(generatedPath, themedFileName);

								if (!File.Exists(generatedFile) || File.GetLastWriteTime(sourceFilePath) > File.GetLastWriteTime(generatedFile))
								{
                                    ThemeEngine.DeleteGeneratedCSS(generatedPath, sourceNameNoExtension, title, siteName);
									ThemeEngine.GenerateThemedCSS(themePath, sourceFile.Name, palette);
								}

								if (File.Exists(generatedFile))
								{
									AddCSSLink(relativeThemePath, themedFileName);
								}
							}
						}
					}
				}

			}
		}

		private void AddCSSLink(string relativeThemePath, string themedFileName)
		{
			HtmlHead head = (HtmlHead)Page.Header;
			HtmlLink link = new HtmlLink();

			link.Attributes.Add("href", relativeThemePath.Replace("~/App_Data", "") + "/CSS/Generated/" + themedFileName);
			link.Attributes.Add("type", "text/css");
			link.Attributes.Add("rel", "stylesheet");

			head.Controls.Add(link);
		}

		private bool IsNullOrEmptyOrWhiteSpace(string value)
		{
			return (String.IsNullOrEmpty(value) || String.IsNullOrEmpty(value.Trim()));
		}
	}

	public class ThemeableSourceFile
	{
		public string Name { get; set; }
	}
}
