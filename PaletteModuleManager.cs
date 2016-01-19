using System;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using PaletteModule.Configuration;
using PaletteModule.Models;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Modules.GenericContent;
using Telerik.Sitefinity.GenericContent.Model;
using PaletteModule.Data.OpenAccess;


namespace PaletteModule
{
	public class PaletteModuleManager : ContentManagerBase<PaletteOpenAccessDataProvider>, IContentLifecycleManager<PaletteItem>
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

		#region Public methods

		public static PaletteModuleManager GetManager()
		{
			return ManagerBase<PaletteOpenAccessDataProvider>.GetManager<PaletteModuleManager>();
		}

		public static PaletteModuleManager GetManager(string providerName)
		{
			return ManagerBase<PaletteOpenAccessDataProvider>.GetManager<PaletteModuleManager>(providerName);
		}

		public static PaletteModuleManager GetManager(string providerName, string transactionName)
		{
			return ManagerBase<PaletteOpenAccessDataProvider>.GetManager<PaletteModuleManager>(providerName, transactionName);
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

		#region overrides
		public override IQueryable<TItem> GetItems<TItem>()
		{
			if (typeof(PaletteItem).IsAssignableFrom(typeof(TItem)))
				return this.GetPaletteItems() as IQueryable<TItem>;
			if (typeof(TItem) == typeof(UrlData) || typeof(TItem) == typeof(PaletteItemUrlData))
				return this.GetUrls<PaletteItemUrlData>() as IQueryable<TItem>;
			throw new NotSupportedException();
		}

		protected override GetDefaultProvider DefaultProviderDelegate
		{
			get { return () => Config.Get<PaletteModuleConfig>().DefaultProvider; }
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
		#endregion

		#region Not Implemented
		public PaletteItem CheckIn(PaletteItem item)
		{
			throw new NotImplementedException();
		}

		public PaletteItem CheckOut(PaletteItem item)
		{
			throw new NotImplementedException();
		}

		public void Copy(PaletteItem source, PaletteItem destination)
		{
			throw new NotImplementedException();
		}

		public PaletteItem Edit(PaletteItem item)
		{
			throw new NotImplementedException();
		}

		public Guid GetCheckedOutBy(PaletteItem item)
		{
			throw new NotImplementedException();
		}

		public PaletteItem GetLive(PaletteItem cnt)
		{
			throw new NotImplementedException();
		}

		public PaletteItem GetMaster(PaletteItem cnt)
		{
			throw new NotImplementedException();
		}

		public PaletteItem GetTemp(PaletteItem cnt)
		{
			throw new NotImplementedException();
		}

		public bool IsCheckedOut(PaletteItem item)
		{
			throw new NotImplementedException();
		}

		public bool IsCheckedOutBy(PaletteItem item, Guid userId)
		{
			throw new NotImplementedException();
		}

		public Content CheckIn(Content item)
		{
			throw new NotImplementedException();
		}

		public Content CheckOut(Content item)
		{
			throw new NotImplementedException();
		}

		public void Copy(Content source, Content destination)
		{
			throw new NotImplementedException();
		}

		public Content Edit(Content item)
		{
			throw new NotImplementedException();
		}

		public Guid GetCheckedOutBy(Content item)
		{
			throw new NotImplementedException();
		}

		public Content GetLive(Content cnt)
		{
			throw new NotImplementedException();
		}

		public Content GetMaster(Content cnt)
		{
			throw new NotImplementedException();
		}

		public Content GetTemp(Content cnt)
		{
			throw new NotImplementedException();
		}

		public bool IsCheckedOut(Content item)
		{
			throw new NotImplementedException();
		}

		public bool IsCheckedOutBy(Content item, Guid userId)
		{
			throw new NotImplementedException();
		}

		public Content Publish(Content item)
		{
			throw new NotImplementedException();
		}

		public Content Schedule(Content item, DateTime publicationDate, DateTime? expirationDate)
		{
			throw new NotImplementedException();
		}

		public Content Unpublish(Content item)
		{
			throw new NotImplementedException();
		}
		public PaletteItem Publish(PaletteItem item)
		{
			throw new NotImplementedException();
		}

		public PaletteItem Schedule(PaletteItem item, DateTime publicationDate, DateTime? expirationDate)
		{
			throw new NotImplementedException();
		}

		public PaletteItem Unpublish(PaletteItem item)
		{
			throw new NotImplementedException();
		}
		#endregion

	}
}