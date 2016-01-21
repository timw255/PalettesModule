using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Telerik.Sitefinity.Multisite;
using Telerik.Sitefinity.Services;
using PaletteModule.Models;
using Telerik.Sitefinity.Web;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity;
using System.Text.RegularExpressions;

namespace PaletteModule.Web.Controls
{
	[ParseChildren(true)]
	public partial class DynamicTheme : WebControl
	{
		private List<ThemeableSourceFile> sourceFiles;

		[PersistenceMode(PersistenceMode.InnerProperty)]
		public List<ThemeableSourceFile> SourceFiles
		{
			get
			{
				if (this.sourceFiles == null)
				{
					this.sourceFiles = new List<ThemeableSourceFile>();
				}

				return sourceFiles;
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
			this.Page.LoadComplete += new EventHandler(Page_LoadComplete);
		}

		private void Page_LoadComplete(object sender, EventArgs e)
		{
			string currentTheme = Utility.GetCurrentTheme();
			if (!currentTheme.IsNullOrWhitespace())
			{
				string relativeThemePath = Utility.GetThemePath(currentTheme);
				string themePath = HttpContext.Current.Server.MapPath(relativeThemePath);
				string siteName = string.Empty;

				string providerName = string.Empty;
				var cContext = SystemManager.CurrentContext;

				if (cContext is MultisiteContext)
				{
					MultisiteContext msContext = cContext as MultisiteContext;
					siteName = msContext.CurrentSiteContext.Site.Name;
					var provider = msContext.CurrentSite.GetProviders(typeof(PaletteModuleManager).FullName).FirstOrDefault();
					if (provider != null)
					{
						providerName = provider.ProviderName;
					}
				}
				else
				{
					siteName = cContext.CurrentSite.Name;
				}

				List<PaletteItem> list = PaletteModuleManager.GetManager(providerName).GetPaletteItems().ToList();

				PaletteItem palette = PaletteModuleManager.GetManager(providerName).GetPaletteItems().FirstOrDefault(p => p.Title == this.Palette);

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
								string themedFileName = Regex.Replace(string.Format("{0}{1}_{2}{3}-{4}", sourceNameNoExtension, sourceModSuffix, title, modSuffix, siteName).ToLower(), @"[^\w\-\!\$\'\(\)\=\@\d_]+", "-");
								
								string generatedFile = Path.Combine(generatedPath, themedFileName + ".css");

								if (!File.Exists(generatedFile) || File.GetLastWriteTime(sourceFilePath) > File.GetLastWriteTime(generatedFile))
								{
									ThemeEngine.DeleteGeneratedCSS(generatedPath, sourceNameNoExtension, title, siteName);
									ThemeEngine.GenerateThemedCSS(themePath, sourceFile.Name, palette);
								}

								if (File.Exists(generatedFile))
								{
									AddCSSLink(relativeThemePath, themedFileName + ".css");
								}
							}
						}
					}
				}

			}
		}

		private void AddCSSLink(string relativeThemePath, string themedFileName)
		{
			HtmlHead head = Page.Header;
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
