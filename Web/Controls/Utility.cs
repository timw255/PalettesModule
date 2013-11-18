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

namespace PalettesModule.Web.Controls
{
    public static class Utility
    {
        public static string GetCurrentTheme()
        {
            Guid currentPageId = GetCurrentPageId();
            PageNode pn = GetPageNode(currentPageId);
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
            Guid pageId;
            PageSiteNode psn = SiteMapBase.GetActualCurrentNode();
            if (psn == null)
            {
                PagesConfig pagesConfig = Config.Get<PagesConfig>();
                pageId = pagesConfig.HomePageId;
            }
            else
            {
                pageId = psn.Id;
            }
            return pageId;
        }

        public static PageNode GetPageNode(Guid pageId)
        {
            var pf = App.WorkWith().Page(pageId);
            return pf.Get();
        }

        public static string GetPageTheme(PageNode pn)
        {
            return (pn.Page.Template != null) ? pn.Page.Template.Theme : "";
        }

        public static string GetThemePath(string theme)
        {
            ConfigManager manager = Config.GetManager();
            AppearanceConfig section = manager.GetSection<AppearanceConfig>();

            return section.FrontendThemes[theme].Path;
        }
    }
}
