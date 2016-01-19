using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Sitefinity.Web;
using Telerik.Sitefinity.Modules.Pages.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Web.Configuration;
using Telerik.Sitefinity.Multisite;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Modules.Pages;

namespace PaletteModule.Web.Controls
{
    public static class Utility
    {
        public static string GetCurrentTheme()
        {
            Guid currentPageId = GetCurrentPageId();
            PageNode pn = GetPageNode(currentPageId);
			var templates = PageManager.GetManager().GetTemplates().ToList();
            return GetPageTheme(pn);
        }

        public static string GetCurrentThemePath()
        {
            Guid currentPageId = GetCurrentPageId();
            PageNode pn = GetPageNode(currentPageId);
            string pt = GetPageTheme(pn);
            return GetThemePath(pt);
        }

        public static Guid GetCurrentPageId()
        {
		    //SetContext();
            Guid pageId;
			var siteMapProvider = SiteMapBase.GetCurrentProvider();
			var pageNodeForPalette = siteMapProvider.CurrentNode ?? siteMapProvider.RootNode;
			pageId = new Guid(pageNodeForPalette.Key);
            return pageId;
        }

        public static PageNode GetPageNode(Guid pageId)
        {
            var pf = App.WorkWith().Page(pageId);
            return pf.Get();
        }

        public static string GetPageTheme(PageNode pn)
        {
			PageData pageData = null;
			string theme = string.Empty;
			
			if (pn != null)
			{
				pageData = pn.GetPageData();
				if(pageData != null && pageData.Template != null){
					PageTemplate template = pageData.Template;
					theme = GetTemplateTheme(template);
				}
			}

            return theme;
        }

		private static string GetTemplateTheme(PageTemplate template)
		{
			if (template != null && template.Theme == null && template.ParentTemplate != null)
			{
				return GetTemplateTheme(template.ParentTemplate);
			}
			else
			{
				return template.Theme;
			}
		}

        public static string GetThemePath(string theme)
        {
            ConfigManager manager = Config.GetManager();
            AppearanceConfig section = manager.GetSection<AppearanceConfig>();

            return section.FrontendThemes[theme].Path;
        }

	   private static void SetContext()
	   {
          var siteContext = SystemManager.CurrentContext;
          if (siteContext.IsMultisiteMode)
          {
              string siteName = new MultisiteContext().CurrentSiteContext.Site.Name;
              ISite site = new MultisiteContext().GetSiteByName(siteName);
              (siteContext as MultisiteContext).ChangeCurrentSite(site);
          }
	   }
    }
}
