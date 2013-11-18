using System;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Modules.GenericContent.Configuration;
using PalettesModule.Data.OpenAccess;
using System.Collections.Specialized;
using Telerik.Sitefinity.Web.UI.ContentUI.Config;
using System.Configuration;
using PalettesModule.Web.UI;

namespace PalettesModule.Configuration
{
	class PalettesConfig : ContentModuleConfigBase
	{
		/// <summary>
		/// Initializes the default providers.
		/// </summary>
		/// <param name="providers">The providers.</param>
		protected override void InitializeDefaultProviders(ConfigElementDictionary<string, DataProviderSettings> providers)
		{
			// add default provider
			providers.Add(new DataProviderSettings(providers)
			{
				Name = "OpenAccessPalettesDataProvider",
				Description = "A provider that stores palettes data in database using OpenAccess ORM.",
				ProviderType = typeof(OpenAccessPalettesDataProvider),
				Parameters = new NameValueCollection() { { "applicationName", "/Palettes" } }
			});
		}

		/// <summary>
		/// Initializes the default backend and frontend views.
		/// </summary>
		/// <param name="contentViewControls"></param>
		protected override void InitializeDefaultViews(ConfigElementDictionary<string, ContentViewControlElement> contentViewControls)
		{
			// add backend views to configuration
			contentViewControls.Add(PalettesDefinitions.DefinePalettesBackendContentView(contentViewControls));

			// add frontend views to configuration
			//contentViewControls.Add(PalettesDefinitions.DefinePalettesFrontendContentView(contentViewControls));
		}

		/// <summary>
		/// Gets or sets the name of the default data provider that is used to manage security.
		/// </summary>
		[ConfigurationProperty("defaultProvider", DefaultValue = "OpenAccessPalettesDataProvider")]
		public override string DefaultProvider
		{
			get { return (string)this["defaultProvider"]; }
			set { this["defaultProvider"] = value; }
		}
	}
}
