using System;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using PaletteModule.Configuration;
using PaletteModule.Models;

namespace PaletteModule
{
    public class PaletteModuleManager : ManagerBase<PaletteModuleDataProvider>
    {
        #region Construction
        /// <summary>
        /// Initializes a new instance of the <see cref="PaletteModuleManager" /> class.
        /// </summary>
        public PaletteModuleManager()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaletteModuleManager" /> class.
        /// </summary>
        /// <param name="providerName">Name of the provider.</param>
        public PaletteModuleManager(string providerName)
            : base(providerName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaletteModuleManager" /> class.
        /// </summary>
        /// <param name="providerName">Name of the provider.</param>
        /// <param name="transactionName">Name of the transaction.</param>
        public PaletteModuleManager(string providerName, string transactionName)
            : base(providerName, transactionName)
        {
        }
        #endregion

        #region Public and overriden methods
        /// <summary>
        /// Gets the default provider delegate.
        /// </summary>
        /// <value>The default provider delegate.</value>
        protected override GetDefaultProvider DefaultProviderDelegate
        {
            get
            {
                return () => Config.Get<PaletteModuleConfig>().DefaultProvider;
            }
        }

        /// <summary>
        /// Gets the name of the module.
        /// </summary>
        /// <value>The name of the module.</value>
        public override string ModuleName
        {
            get
            {
                return PaletteModuleClass.ModuleName;
            }
        }

        /// <summary>
        /// Gets the providers settings.
        /// </summary>
        /// <value>The providers settings.</value>
        protected override ConfigElementDictionary<string, DataProviderSettings> ProvidersSettings
        {
            get
            {
                return Config.Get<PaletteModuleConfig>().Providers;
            }
        }

        /// <summary>
        /// Get an instance of the PaletteModule manager using the default provider.
        /// </summary>
        /// <returns>Instance of the PaletteModule manager</returns>
        public static PaletteModuleManager GetManager()
        {
            return ManagerBase<PaletteModuleDataProvider>.GetManager<PaletteModuleManager>();
        }

        /// <summary>
        /// Get an instance of the PaletteModule manager by explicitly specifying the required provider to use
        /// </summary>
        /// <param name="providerName">Name of the provider to use, or null/empty string to use the default provider.</param>
        /// <returns>Instance of the PaletteModule manager</returns>
        public static PaletteModuleManager GetManager(string providerName)
        {
            return ManagerBase<PaletteModuleDataProvider>.GetManager<PaletteModuleManager>(providerName);
        }

        /// <summary>
        /// Get an instance of the PaletteModule manager by explicitly specifying the required provider to use
        /// </summary>
        /// <param name="providerName">Name of the provider to use, or null/empty string to use the default provider.</param>
        /// <param name="transactionName">Name of the transaction.</param>
        /// <returns>Instance of the PaletteModule manager</returns>
        public static PaletteModuleManager GetManager(string providerName, string transactionName)
        {
            return ManagerBase<PaletteModuleDataProvider>.GetManager<PaletteModuleManager>(providerName, transactionName);
        }

        /// <summary>
        /// Creates a PaletteItem.
        /// </summary>
        /// <returns>The created PaletteItem.</returns>
        public PaletteItem CreatePaletteItem()
        {
            return this.Provider.CreatePaletteItem();
        }

        /// <summary>
        /// Updates the PaletteItem.
        /// </summary>
        /// <param name="entity">The PaletteItem entity.</param>
        public void UpdatePaletteItem(PaletteItem entity)
        {
            this.Provider.UpdatePaletteItem(entity);
        }

        /// <summary>
        /// Deletes the PaletteItem.
        /// </summary>
        /// <param name="entity">The PaletteItem entity.</param>
        public void DeletePaletteItem(PaletteItem entity)
        {
            this.Provider.DeletePaletteItem(entity);
        }

        /// <summary>
        /// Gets the PaletteItem by a specified ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>The PaletteItem.</returns>
        public PaletteItem GetPaletteItem(Guid id)
        {
            return this.Provider.GetPaletteItem(id);
        }

        /// <summary>
        /// Gets a query of all the PaletteItem items.
        /// </summary>
        /// <returns>The PaletteItem items.</returns>
        public IQueryable<PaletteItem> GetPaletteItems()
        {
            return this.Provider.GetPaletteItems();
        }
        #endregion
    }
}