using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Modules.GenericContent.Configuration;
using Telerik.Sitefinity.Web.Configuration;
using PaletteModule.Data.EntityFramework;

namespace PaletteModule.Configuration
{
    /// <summary>
    /// Represents the configuration section for PaletteModule module.
    /// </summary>
    [ObjectInfo(Title = "PaletteModule Config Title", Description = "PaletteModule Config Description")]
    public class PaletteModuleConfig : ModuleConfigBase
    {
        #region Public and overriden methods
        protected override void InitializeDefaultProviders(ConfigElementDictionary<string, DataProviderSettings> providers)
        {
            providers.Add(new DataProviderSettings(providers)
            {
                Name = "PaletteModuleEFDataProvider",
                Title = "Default Products",
                Description = "A provider that stores products data in database using Entity Framework.",
                ProviderType = typeof(PaletteModuleEFDataProvider),
                Parameters = new NameValueCollection() { { "applicationName", "/PaletteModule" } }
            });
        }

        /// <summary>
        /// Gets or sets the name of the default data provider. 
        /// </summary>
        [DescriptionResource(typeof(ConfigDescriptions), "DefaultProvider")]
        [ConfigurationProperty("defaultProvider", DefaultValue = "PaletteModuleEFDataProvider")]
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