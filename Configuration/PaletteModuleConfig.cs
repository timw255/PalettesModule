using PaletteModule.Data.OpenAccess;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Modules.GenericContent.Configuration;
using Telerik.Sitefinity.Web.Configuration;
using Telerik.Sitefinity.Web.UI.ContentUI.Config;


namespace PaletteModule.Configuration
{
    /// <summary>
    /// Represents the configuration section for PaletteModule module.
    /// </summary>
	public class PaletteModuleConfig : ContentModuleConfigBase
    {
        #region Public and overriden methods
        protected override void InitializeDefaultProviders(ConfigElementDictionary<string, DataProviderSettings> providers)
        {
            providers.Add(new DataProviderSettings(providers)
            {
				Name = "PaletteOpenAccessDataProvider",
				Description = "A provider that stores paleettes data in database using OpenAccess ORM.",
				ProviderType = typeof(PaletteOpenAccessDataProvider),
                Parameters = new NameValueCollection() { { "applicationName", "/PaletteModule" } }
            });
        }
		protected override void InitializeDefaultViews(ConfigElementDictionary<string, ContentViewControlElement> contentViewControls)
		{

		}
        /// <summary>
        /// Gets or sets the name of the default data provider. 
        /// </summary>
        [DescriptionResource(typeof(ConfigDescriptions), "DefaultProvider")]
		[ConfigurationProperty("defaultProvider", DefaultValue = "PaletteOpenAccessDataProvider")]
        public override string DefaultProvider
        {
            get
            {
                return (string)this["defaultProvider"];
            }
            set
            {
                this["defaultProvider"] = value;
            }
        }
        #endregion
    }
}