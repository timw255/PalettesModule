using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Telerik.Sitefinity.Data.Linq.Dynamic;
using Telerik.Sitefinity.Web.Services;
using PaletteModule.Models;
using PaletteModule.Web.Services.PaletteItems.ViewModels;

namespace PaletteModule.Web.Services.PaletteItems
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class PaletteItemsService : IPaletteItemsService
    {
        #region IPaletteItems
        /// <inheritdoc/>
        public CollectionContext<PaletteItemViewModel> GetPaletteItems(string provider, string sortExpression, int skip, int take, string filter)
        {
            ServiceUtility.DisableCache();
            return this.GetPaletteItemsInternal(provider, sortExpression, skip, take, filter);
        }

        /// <inheritdoc/>
        public CollectionContext<PaletteItemViewModel> GetPaletteItemsInXml(string provider, string sortExpression, int skip, int take, string filter)
        {
            ServiceUtility.DisableCache();
            return this.GetPaletteItemsInternal(provider, sortExpression, skip, take, filter);
        }

        /// <inheritdoc/>
        public ItemContext<PaletteItemViewModel> SavePaletteItem(ItemContext<PaletteItemViewModel> context, string paletteItemId, string provider)
        {
            ServiceUtility.DisableCache();
            return this.SavePaletteItemInternal(context, paletteItemId, provider);
        }

        /// <inheritdoc/>
        public ItemContext<PaletteItemViewModel> SavePaletteItemInXml(ItemContext<PaletteItemViewModel> context, string paletteItemId, string provider)
        {
            ServiceUtility.DisableCache();
            return this.SavePaletteItemInternal(context, paletteItemId, provider);
        }

        /// <inheritdoc/>
        public bool DeletePaletteItem(string paletteItemId, string provider)
        {
            ServiceUtility.DisableCache();
            return this.DeletePaletteItemInternal(paletteItemId, provider);
        }

        /// <inheritdoc/>
        public bool DeletePaletteItemInXml(string paletteItemId, string provider)
        {
            ServiceUtility.DisableCache();
            return this.DeletePaletteItemInternal(paletteItemId, provider);
        }

        /// <inheritdoc/>
        public bool BatchDeletePaletteItems(string[] ids, string provider)
        {
            ServiceUtility.DisableCache();
            return this.BatchDeletePaletteItemsInternal(ids, provider);
        }

        /// <inheritdoc/>
        public bool BatchDeletePaletteItemsInXml(string[] ids, string provider)
        {
            ServiceUtility.DisableCache();
            return this.BatchDeletePaletteItemsInternal(ids, provider);
        }

        /// <inheritdoc/>
        public ItemContext<PaletteItemViewModel> GetPaletteItem(string paletteItemId)
        {
            ServiceUtility.DisableCache();
            return this.GetPaletteItemInternal(paletteItemId);
        }

        /// <inheritdoc/>
        public ItemContext<PaletteItemViewModel> GetPaletteItemInXml(string paletteItemId)
        {
            ServiceUtility.DisableCache();
            return this.GetPaletteItemInternal(paletteItemId);
        }

        /// <inheritdoc/>
        public CollectionContext<PaletteItemPropertyViewModel> GetProperties()
        {
            ServiceUtility.DisableCache();
            return this.GetPropertiesInternal();
        }
        #endregion

        #region Non-public methods
        /// <summary>
        /// Gets the paletteItems internal.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="sortExpression">The sort expression.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="take">The take.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        private CollectionContext<PaletteItemViewModel> GetPaletteItemsInternal(string provider, string sortExpression, int skip, int take, string filter)
        {
            var manager = PaletteModuleManager.GetManager(provider);
            var paletteItems = manager.GetPaletteItems();

            var totalCount = paletteItems.Count();

            if (!string.IsNullOrEmpty(sortExpression))
                paletteItems = paletteItems.OrderBy(sortExpression);

            if (!string.IsNullOrEmpty(filter))
                paletteItems = paletteItems.Where(filter);

            if (skip > 0)
                paletteItems = paletteItems.Skip(skip);

            if (take > 0)
                paletteItems = paletteItems.Take(take);

            var paletteItemsList = new List<PaletteItemViewModel>();

            foreach (var paletteItem in paletteItems)
            {
                var paletteItemViewModel = new PaletteItemViewModel();
                PaletteItemsViewModelTranslator.ToViewModel(paletteItem, paletteItemViewModel, manager);
                paletteItemsList.Add(paletteItemViewModel);
            }

            return new CollectionContext<PaletteItemViewModel>(paletteItemsList) { TotalCount = totalCount };
        }

        /// <summary>
        /// Saves the paletteItem internal.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="paletteItemId">The paletteItem id.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        private ItemContext<PaletteItemViewModel> SavePaletteItemInternal(ItemContext<PaletteItemViewModel> context, string paletteItemId, string provider)
        {
            var manager = PaletteModuleManager.GetManager(provider);
            var id = new Guid(paletteItemId);

            PaletteItem paletteItem = null;

            if (id == Guid.Empty)
                paletteItem = manager.CreatePaletteItem();
            else
                paletteItem = manager.GetPaletteItem(id);

            PaletteItemsViewModelTranslator.ToModel(context.Item, paletteItem, manager);

            if (id != Guid.Empty)
                manager.UpdatePaletteItem(paletteItem);

            manager.SaveChanges();
            PaletteItemsViewModelTranslator.ToViewModel(paletteItem, context.Item, manager);
            return context;
        }

        /// <summary>
        /// Deletes the paletteItem internal.
        /// </summary>
        /// <param name="paletteItemId">The paletteItem id.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        private bool DeletePaletteItemInternal(string paletteItemId, string provider)
        {
            var manager = PaletteModuleManager.GetManager(provider);
            manager.DeletePaletteItem(manager.GetPaletteItem(new Guid(paletteItemId)));
            manager.SaveChanges();

            return true;
        }

        /// <summary>
        /// Batches the delete paletteItems internal.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        private bool BatchDeletePaletteItemsInternal(string[] ids, string provider)
        {
            var manager = PaletteModuleManager.GetManager(provider);
            foreach (var stringId in ids)
            {
                var paletteItemId = new Guid(stringId);
                manager.DeletePaletteItem(manager.GetPaletteItem(paletteItemId));
            }
            manager.SaveChanges();

            return true;
        }

        /// <summary>
        /// Gets the paletteItem internal.
        /// </summary>
        /// <param name="paletteItemId">The paletteItem id.</param>
        /// <returns></returns>
        private ItemContext<PaletteItemViewModel> GetPaletteItemInternal(string paletteItemId)
        {
            var paletteItemIdGuid = new Guid(paletteItemId);
            var manager = PaletteModuleManager.GetManager();

            var paletteItem = manager.GetPaletteItem(paletteItemIdGuid);
            var paletteItemViewModel = new PaletteItemViewModel();
            PaletteItemsViewModelTranslator.ToViewModel(paletteItem, paletteItemViewModel, manager);

            return new ItemContext<PaletteItemViewModel>()
            {
                Item = paletteItemViewModel
            };
        }

        /// <summary>
        /// Gets the properties internal.
        /// </summary>
        /// <returns></returns>
        private CollectionContext<PaletteItemPropertyViewModel> GetPropertiesInternal()
        {
            List<PaletteItemPropertyViewModel> properties = new List<PaletteItemPropertyViewModel>();
            foreach (var property in typeof(PaletteModule.Models.PaletteItem).GetProperties())
            {
                if (!this.systemProperties.Contains(property.Name))
                {
                    properties.Add(new PaletteItemPropertyViewModel() { Name = property.Name });
                }
            }
            return new CollectionContext<PaletteItemPropertyViewModel>(properties) { TotalCount = properties.Count() };
        }
        #endregion

        #region Non-public Fields
        private readonly IEnumerable<string> systemProperties = new List<string>()
        {
            "Id", "Transaction", "ApplicationName", "Provider",
        };
        #endregion
    }
}