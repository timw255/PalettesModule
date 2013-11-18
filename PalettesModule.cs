using Telerik.Sitefinity.Configuration;
using System;
using System.Linq;
using Telerik.Sitefinity.Modules.GenericContent;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Abstractions;
using PalettesModule.Data;
using PalettesModule.Configuration;
using PalettesModule.Model;
using PalettesModule.Web.Services;
using PalettesModule.Web.UI;
using Telerik.Sitefinity.Abstractions.VirtualPath.Configuration;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Abstractions.VirtualPath;
using Telerik.Sitefinity;

namespace PalettesModule
{
	public class PalettesModule : ContentModuleBase
	{
		/// <summary>
		/// Initializes the service with specified settings.
		/// </summary>
		/// <param name="settings">The settings.</param>
		public override void Initialize(ModuleSettings settings)
		{
			base.Initialize(settings);

            // initialize configuration file
            App.WorkWith()
                .Module(settings.Name)
                .Initialize()
                    .Configuration<PalettesConfig>()
                    .WebService<PalettesBackendService>("Sitefinity/Services/Content/Palettes.svc");

		}

		/// <summary>
		/// Installs this module in Sitefinity system for the first time.
		/// </summary>
		/// <param name="initializer">The Site Initializer. A helper class for installing Sitefinity modules.</param>
		public override void Install(SiteInitializer initializer)
		{
			base.Install(initializer);

			// register module ?
			IModule palettesModule;
			SystemManager.ApplicationModules.TryGetValue(PalettesModule.ModuleName, out palettesModule);

			initializer.Context.SaveMetaData(true);
            this.InstallCustomVirtualPaths(initializer);
		}

        private void InstallCustomVirtualPaths(SiteInitializer initializer)
        {
            var virtualPathConfig = initializer.Context.GetConfig<VirtualPathSettingsConfig>();
            ConfigManager.Executed += new EventHandler<ExecutedEventArgs>(ConfigManager_Executed);
            var palettesModuleVirtualPathConfig = new VirtualPathElement(virtualPathConfig.VirtualPaths)
            {
                VirtualPath = "~/PaletteTemplates/*",
                ResolverName = "EmbeddedResourceResolver",
                ResourceLocation = "PalettesModule"
            };
            if (!virtualPathConfig.VirtualPaths.ContainsKey("~/PaletteTemplates/*"))
                virtualPathConfig.VirtualPaths.Add(palettesModuleVirtualPathConfig);
        }

        private void ConfigManager_Executed(object sender, Telerik.Sitefinity.Data.ExecutedEventArgs args)
        {
            if (args.CommandName == "SaveSection")
            {
                var section = args.CommandArguments as VirtualPathSettingsConfig;
                if (section != null)
                {
                    // Reset the VirtualPathManager whenever we save the VirtualPathConfig section.
                    // This is needed so that our prefixes for the widget templates in the module assembly are taken into account.
                    VirtualPathManager.Reset();
                }
            }
        }

		/// <summary>
		/// Installs the pages.
		/// </summary>
		/// <param name="initializer">The initializer.</param>
		protected override void InstallPages(SiteInitializer initializer)
		{
            initializer.Installer
                .CreateModuleGroupPage(PalettesPageGroupID, "Palettes")
                    .PlaceUnder(SiteInitializer.ModulesNodeId)
                    .SetOrdinal(1)
                    .SetTitle("Palettes")
                    .SetUrlName("Palettes")
                    .SetDescription("Module for managing a collection of Palettes")
                    .AddChildPage(LandingPageId, "Palettes")
                        .SetTitle("Palettes")
                        .SetHtmlTitle("Palettes")
                        .SetUrlName("Palettes")
                        .SetDescription("Module for managing a collection of Palettes")
                        .AddContentView(b =>
                        {
                            b.ControlDefinitionName = PalettesDefinitions.BackendDefinitionName;
                        })
                        .Done();
		}

		public override void Upgrade(SiteInitializer initializer, Version upgradeFrom)
		{
			// not needed
		}

		/// <summary>
		/// Registers the module data item type into the taxonomy system
		/// </summary>
		/// <param name="initializer">The initializer.</param>
		protected override void InstallTaxonomies(SiteInitializer initializer)
		{
			this.InstallTaxonomy(initializer, typeof(PaletteItem));
		}

		/// <summary>
		/// Gets the module config.
		/// </summary>
		/// <returns></returns>
		protected override ConfigSection GetModuleConfig()
		{
			// code to return Module configuration
			return Config.Get<PalettesConfig>();
		}

		/// <summary>
		/// Installs module's toolbox configuration.
		/// </summary>
		/// <param name="initializer">The initializer.</param>
		protected override void InstallConfiguration(SiteInitializer initializer)
		{
            // Module widget is installed on Bootstrapper_Initialized
            //initializer.Installer
            //    .PageToolbox()
            //        .LoadOrAddSection("Palettes")
            //            .LoadOrAddWidget<PalettesView>("PalettesView")
            //                .SetTitle("PalettesViewTitle")
            //                .SetDescription("PalettesViewDescription")
            //                .Done()
            //            .Done()
            //        .Done();
		}

		#region Public Properties

		/// <summary>
		/// Gets the landing page id for each module inherit from <see cref="T:Telerik.Sitefinity.Services.SecuredModuleBase"/> class.
		/// </summary>
		/// <value>
		/// The landing page id.
		/// </value>
		public override Guid LandingPageId
		{
			get { return PalettesModuleLandingPage; }
		}

		public override Type[] Managers
		{
			get { return new[] { typeof(PalettesManager) }; }
		}

		#endregion


		#region Constants

		/// <summary>
		/// The name of the Palettes Module
		/// </summary>
		public const string ModuleName = "Palettes";

		// Page IDs
        public static readonly Guid PalettesPageGroupID = new Guid("f3fcc4e8-ea46-48e0-8fa4-74f16e6a739e");
        public static readonly Guid PalettesModuleLandingPage = new Guid("2906ba06-9ee5-494e-a611-53d535ede6f3");

		#endregion
	}
}