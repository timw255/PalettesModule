using System;
using System.Collections.Generic;
using System.Linq;
using PalettesModule.Data.OpenAccess;
using PalettesModule.Model;
using PalettesModule.Configuration;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules;
using Telerik.Sitefinity.Modules.GenericContent;

namespace PalettesModule.Data
{
	public class PalettesManager : ContentManagerBase<OpenAccessPalettesDataProvider>, IContentLifecycleManager<PaletteItem>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="PalettesManager"/> class.
		/// </summary>
		public PalettesManager() : this(null) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="PalettesManager"/> class.
		/// </summary>
		/// <param name="providerName">Name of the provider.</param>
		public PalettesManager(string providerName) : base(providerName) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="PalettesManager"/> class.
		/// </summary>
		/// <param name="providerName">Name of the provider.</param>
		/// <param name="transactionName">Name of the transaction.</param>
		public PalettesManager(string providerName, string transactionName) : base(providerName, transactionName) { }

		#endregion

		#region GetManager Methods

		/// <summary>
		/// Gets the default manager.
		/// </summary>
		/// <returns></returns>
		public static PalettesManager GetManager() { return ManagerBase<OpenAccessPalettesDataProvider>.GetManager<PalettesManager>(); }

		/// <summary>
		/// Gets the default manager.
		/// </summary>
		/// <param name="providerName">Name of the provider.</param>
		/// <returns></returns>
		public static PalettesManager GetManager(string providerName) { return ManagerBase<OpenAccessPalettesDataProvider>.GetManager<PalettesManager>(providerName); }


		/// <summary>
		/// Gets the manager.
		/// </summary>
		/// <param name="providerName">Name of the provider.</param>
		/// <param name="transactionName">Name of the transaction.</param>
		/// <returns></returns>
		public static PalettesManager GetManager(string providerName, string transactionName) { return ManagerBase<OpenAccessPalettesDataProvider>.GetManager<PalettesManager>(providerName, transactionName); }

		#endregion

		#region ContentManagerBase Overrides

		/// <summary>
		/// Gets the name of the module.
		/// </summary>
		/// <value>
		/// The name of the module.
		/// </value>
		public override string ModuleName
		{
			get { return PalettesModule.ModuleName; }
		}

		/// <summary>
		/// Gets the providers settings.
		/// </summary>
		protected override ConfigElementDictionary<string, DataProviderSettings> ProvidersSettings
		{
			get { return Config.Get<PalettesConfig>().Providers; }
		}

		/// <summary>
		/// Gets the default provider delegate.
		/// </summary>
		protected override GetDefaultProvider DefaultProviderDelegate
		{
			get { return () => Config.Get<PalettesConfig>().DefaultProvider; }
		}

		/// <summary>
		/// Get items by type
		/// </summary>
		/// <typeparam name="TItem">The type of the item.</typeparam>
		/// <returns>IQueryable</returns>
		public override IQueryable<TItem> GetItems<TItem>()
		{
			if (typeof(PaletteItem).IsAssignableFrom(typeof(TItem)))
				return this.GetPalettes() as IQueryable<TItem>;
			if (typeof(TItem) == typeof(UrlData) || typeof(TItem) == typeof(PaletteItemUrlData))
				return this.GetUrls<PaletteItemUrlData>() as IQueryable<TItem>;
			throw new NotSupportedException();
		}

		#endregion

		#region CRUD Methods

		/// <summary>
		/// Creates a new palette item.
		/// </summary>
		/// <returns></returns>
		public PaletteItem CreatePalette() { return this.Provider.CreatePalette(); }

		/// <summary>
		/// Creates a new palette item with the specified id.
		/// </summary>
		/// <param name="id">The palette item id.</param>
		/// <param name="applicationName">Name of the application.</param>
		/// <returns></returns>
		public PaletteItem CreatePalette(Guid id) { return this.Provider.CreatePalette(id); }

		/// <summary>
		/// Gets the palette item with the specified id.
		/// </summary>
		/// <param name="id">The palette item id.</param>
		/// <returns></returns>
		public PaletteItem GetPalette(Guid id) { return this.Provider.GetPalette(id); }

		/// <summary>
		/// Gets the full list of palette items.
		/// </summary>
		/// <returns></returns>
		public IQueryable<PaletteItem> GetPalettes() { return this.Provider.GetPalettes(); }

		/// <summary>
		/// Deletes the specified palette item.
		/// </summary>
		/// <param name="palette">The palette item.</param>
		public void DeletePalette(PaletteItem palette) { this.Provider.DeletePalette(palette); }

		/// <summary>
		/// Deletes palette item with the specified id.
		/// </summary>
		/// <param name="id">The id.</param>
		public void DeletePalette(Guid id) { this.Provider.DeletePalette(this.Provider.GetPalette(id)); }

		#endregion

        #region IContentLifecycleManager

        #region PaletteItem

        /// <summary>
        /// Checks in the content in the temp state. Content becomes master after the check in.
        /// </summary>
        /// <param name="item">Content in temp state that is to be checked in.</param>
        /// <returns>An item in master state.</returns>
        public PaletteItem CheckIn(PaletteItem item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks out the content in master state. Content becomes temp after the check out.
        /// </summary>
        /// <param name="item">Content in master state that is to be checked out.</param>
        /// <returns>A content that was checked out in temp state.</returns>
        public PaletteItem CheckOut(PaletteItem item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Copy one Palette item to another for the uses of content lifecycle management
        /// </summary>
        /// <param name="source">Palette item to copy from</param>
        /// <param name="destination">Palette item to copy to</param>
        public void Copy(PaletteItem source, PaletteItem destination)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edits the content in live state. Content becomes master after the edit.
        /// </summary>
        /// <param name="item">Content in live state that is to be edited.</param>
        /// <returns>A content that was edited in master state.</returns>
        public PaletteItem Edit(PaletteItem item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns ID of the user that checked out the item, or Guid.Empty if it is not checked out
        /// </summary>
        /// <param name="item">Item to get the user ID it is locked by</param>      
        /// <returns>ID of the user that checked out the item or Guid.Empty if the item is not checked out.</returns>
        public Guid GetCheckedOutBy(PaletteItem item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the public (live) version of <paramref name="cnt"/>, if it exists
        /// </summary>
        /// <param name="cnt">Type of the content item</param>        
        /// <returns>Public (live) version of <paramref name="cnt"/>, if it exists</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="cnt"/> is <c>null</c>.</exception>
        public PaletteItem GetLive(PaletteItem cnt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Accepts a content item and returns an item in master state
        /// </summary>        
        /// <param name="cnt">Content item whose master to get</param>        
        /// <returns>
        /// If <paramref name="cnt"/> is master itself, returns cnt.
        /// Otherwise, looks up the master associated with <paramref name="cnt"/> and returns it.
        /// When there is no master, an exception will be thrown.
        /// </returns>
        /// <exception cref="InvalidOperationException">When no master can be found for <paramref name="cnt"/>.</exception>
        /// <exception cref="ArgumentNullException">When <paramref name="cnt"/> is <c>null</c>.</exception>
        public PaletteItem GetMaster(PaletteItem cnt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a temp for <paramref name="cnt"/>, if it exists.
        /// </summary>        
        /// <param name="cnt">Content item to get a temp for</param>        
        /// <returns>Temp version of <paramref name="cnt"/>, if it exists.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="cnt"/> is <c>null</c>.</exception>
        public PaletteItem GetTemp(PaletteItem cnt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true or false, depending on whether the <paramref name="item"/> is checked out or not
        /// </summary>
        /// <param name="item">Item to test</param>        
        /// <returns>True if the item is checked out, false otherwise.</returns>
        public bool IsCheckedOut(PaletteItem item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if <paramref name="item"/> is checked out by user with a specified id
        /// </summary>
        /// <param name="item">Item to test</param>
        /// <param name="userId">Id of the user to check if he/she checked out <paramref name="item"/></param>        
        /// <returns>True if it was checked out by a user with the specified id, false otherwise</returns>
        public bool IsCheckedOutBy(PaletteItem item, Guid userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Publishes the content in master state. Content becomes live after the publish.
        /// </summary>
        /// <param name="item">Content in master state that is to be published.</param>
        /// <returns>the published item</returns>
        public PaletteItem Publish(PaletteItem item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Schedule a content item - to be published from one date to another
        /// </summary>
        /// <param name="item">Content item in master state</param>
        /// <param name="publicationDate">Point in time at which the item will be visible on the public side</param>
        /// <param name="expirationDate">Point in time at which the item will no longer be visible on the public side or null if the item should never expire</param>
        /// <returns>the scheduled item</returns>
        public PaletteItem Schedule(PaletteItem item, DateTime publicationDate, DateTime? expirationDate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unpublish a content item in live state.
        /// </summary>
        /// <param name="item">Live item to unpublish.</param>
        /// <returns>Master (draft) state.</returns>
        public PaletteItem Unpublish(PaletteItem item)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Generic

        /// <summary>
        /// Checks in the content in the temp state. Content becomes master after the check in.
        /// </summary>
        /// <param name="item">Content in temp state that is to be checked in.</param>
        /// <returns>An item in master state.</returns>
        public Telerik.Sitefinity.GenericContent.Model.Content CheckIn(Telerik.Sitefinity.GenericContent.Model.Content item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks out the content in master state. Content becomes temp after the check out.
        /// </summary>
        /// <param name="item">Content in master state that is to be checked out.</param>
        /// <returns>A content that was checked out in temp state.</returns>
        public Telerik.Sitefinity.GenericContent.Model.Content CheckOut(Telerik.Sitefinity.GenericContent.Model.Content item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Copy one item to another for the uses of content lifecycle management
        /// </summary>
        /// <param name="source">Item to copy from</param>
        /// <param name="destination">Item to copy to</param>
        public void Copy(Telerik.Sitefinity.GenericContent.Model.Content source, Telerik.Sitefinity.GenericContent.Model.Content destination)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edits the content in live state. Content becomes master after the edit.
        /// </summary>
        /// <param name="item">Content in live state that is to be edited.</param>
        /// <returns>A content that was edited in master state.</returns>
        public Telerik.Sitefinity.GenericContent.Model.Content Edit(Telerik.Sitefinity.GenericContent.Model.Content item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns ID of the user that checked out the item, or Guid.Empty if it is not checked out
        /// </summary>
        /// <param name="item">Item to get the user ID it is locked by</param>        
        /// <returns>ID of the user that checked out the item or Guid.Empty if the item is not checked out.</returns>
        public Guid GetCheckedOutBy(Telerik.Sitefinity.GenericContent.Model.Content item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the public (live) version of <paramref name="cnt"/>, if it exists
        /// </summary>
        /// <param name="cnt">Type of the content item</param>        
        /// <returns>Public (live) version of <paramref name="cnt"/>, if it exists</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="cnt"/> is <c>null</c>.</exception>
        public Telerik.Sitefinity.GenericContent.Model.Content GetLive(Telerik.Sitefinity.GenericContent.Model.Content cnt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Accepts a content item and returns an item in master state
        /// </summary>        
        /// <param name="cnt">Content item whose master to get</param>        
        /// <returns>
        /// If <paramref name="cnt"/> is master itself, returns cnt.
        /// Otherwise, looks up the master associated with <paramref name="cnt"/> and returns it.
        /// When there is no master, an exception will be thrown.
        /// </returns>
        /// <exception cref="InvalidOperationException">When no master can be found for <paramref name="cnt"/>.</exception>
        /// <exception cref="ArgumentNullException">When <paramref name="cnt"/> is <c>null</c>.</exception>
        public Telerik.Sitefinity.GenericContent.Model.Content GetMaster(Telerik.Sitefinity.GenericContent.Model.Content cnt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a temp for <paramref name="cnt"/>, if it exists.
        /// </summary>        
        /// <param name="cnt">Content item to get a temp for</param>        
        /// <returns>Temp version of <paramref name="cnt"/>, if it exists.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="cnt"/> is <c>null</c>.</exception>
        public Telerik.Sitefinity.GenericContent.Model.Content GetTemp(Telerik.Sitefinity.GenericContent.Model.Content cnt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true or false, depending on whether the <paramref name="item"/> is checked out or not
        /// </summary>
        /// <param name="item">Item to test</param>        
        /// <returns>True if the item is checked out, false otherwise.</returns>
        public bool IsCheckedOut(Telerik.Sitefinity.GenericContent.Model.Content item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if <paramref name="item"/> is checked out by user with a specified id
        /// </summary>
        /// <param name="item">Item to test</param>
        /// <param name="userId">Id of the user to check if he/she checked out <paramref name="item"/></param>        
        /// <returns>True if it was checked out by a user with the specified id, false otherwise</returns>
        public bool IsCheckedOutBy(Telerik.Sitefinity.GenericContent.Model.Content item, Guid userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Publishes the content in master state. Content becomes live after the publish.
        /// </summary>
        /// <param name="item">Content in master state that is to be published.</param>
        /// <returns>Published content item</returns>
        public Telerik.Sitefinity.GenericContent.Model.Content Publish(Telerik.Sitefinity.GenericContent.Model.Content item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Schedule a content item - to be published from one date to another
        /// </summary>
        /// <param name="item">Content item in master state</param>
        /// <param name="publicationDate">Point in time at which the item will be visible on the public side</param>
        /// <param name="expirationDate">Point in time at which the item will no longer be visible on the public side or null if the item should never expire</param>
        /// <returns>Scheduled content item</returns>
        public Telerik.Sitefinity.GenericContent.Model.Content Schedule(Telerik.Sitefinity.GenericContent.Model.Content item, DateTime publicationDate, DateTime? expirationDate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unpublish a content item in live state.
        /// </summary>
        /// <param name="item">Live item to unpublish.</param>
        /// <returns>Master (draft) state.</returns>
        public Telerik.Sitefinity.GenericContent.Model.Content Unpublish(Telerik.Sitefinity.GenericContent.Model.Content item)
        {
            throw new NotImplementedException();
        }

        #endregion


        #endregion
	}
}
