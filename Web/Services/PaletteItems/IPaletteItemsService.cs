using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using Telerik.Sitefinity.Utilities.MS.ServiceModel.Web;
using Telerik.Sitefinity.Web.Services;
using PaletteModule.Web.Services.PaletteItems.ViewModels;

namespace PaletteModule.Web.Services.PaletteItems
{
    /// <summary>
    /// Provides contracts for loading and manipulating PaletteModule data items (e.g. paletteItems)
    /// </summary>
    [ServiceContract]
    public interface IPaletteItemsService
    {
        /// <summary>
        /// Gets all paletteItems for the given provider. The results are returned in JSON format.
        /// </summary>
        /// <param name="provider">Name of the provider from which the paletteItems ought to be retrieved.</param>
        /// <param name="sortExpression">Sort expression used to order the paletteItems.</param>
        /// <param name="skip">Number of paletteItems to skip in result set. (used for paging)</param>
        /// <param name="take">Number of paletteItems to take in the result set. (used for paging)</param>
        /// <param name="filter">Dynamic LINQ expression used to filter the wanted result set.</param>
        /// <returns>
        /// Collection context object of <see cref="PaletteItemViewModel"/> objects.
        /// </returns>
        [WebHelp(Comment = "Gets all paletteItems of the PaletteModule module for the given provider. The results are returned in JSON format.")]
        [WebGet(UriTemplate = "/?provider={provider}&sortExpression={sortExpression}&skip={skip}&take={take}&filter={filter}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        CollectionContext<PaletteItemViewModel> GetPaletteItems(string provider, string sortExpression, int skip, int take, string filter);

        /// <summary>
        /// Gets all paletteItems for the given provider. The results are returned in XML format.
        /// </summary>
        /// <param name="provider">Name of the provider from which the paletteItems ought to be retrieved.</param>
        /// <param name="sortExpression">Sort expression used to order the paletteItems.</param>
        /// <param name="skip">Number of paletteItems to skip in result set. (used for paging)</param>
        /// <param name="take">Number of paletteItems to take in the result set. (used for paging)</param>
        /// <param name="filter">Dynamic LINQ expression used to filter the wanted result set.</param>
        /// <returns>
        /// Collection context object of <see cref="PaletteItemViewModel"/> objects.
        /// </returns>
        [WebHelp(Comment = "Gets all paletteItems of the PaletteModule module for the given provider. The results are returned in XML format.")]
        [WebGet(UriTemplate = "/xml/?provider={provider}&sortExpression={sortExpression}&skip={skip}&take={take}&filter={filter}", ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        CollectionContext<PaletteItemViewModel> GetPaletteItemsInXml(string provider, string sortExpression, int skip, int take, string filter);

        /// <summary>
        /// Gets the paletteItem by it's id. The results are returned in JSON format.
        /// </summary>
        /// <param name="paletteItemId">Id of the paletteItem to be retrieved.</param>
        /// <returns>
        /// Item context object of <see cref="PaletteItemViewModel"/> objects.
        /// </returns>
        [WebHelp(Comment = "Gets the paletteItem by it's id. The results are returned in JSON format.")]
        [WebGet(UriTemplate = "/{paletteItemId}/", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        ItemContext<PaletteItemViewModel> GetPaletteItem(string paletteItemId);

        /// <summary>
        /// Gets the paletteItem by it's id. The results are returned in JSON format.
        /// </summary>
        /// <param name="paletteItemId">Id of the paletteItem to be retrieved.</param>
        /// <returns>
        /// Item context object of <see cref="PaletteItemViewModel"/> objects.
        /// </returns>
        [WebHelp(Comment = "Gets the paletteItem by it's id. The results are returned in JSON format.")]
        [WebGet(UriTemplate = "/xml/{paletteItemId}/", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        ItemContext<PaletteItemViewModel> GetPaletteItemInXml(string paletteItemId);

        /// <summary>
        /// Saves a paletteItem. If the paletteItem with specified id exists that paletteItem will be updated; otherwise new paletteItem will be created.
        /// The saved paletteItem is returned in JSON format.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="paletteItemId">The paletteItem id.</param>
        /// <param name="provider">The provider name through which the paletteItem ought to be saved.</param>
        /// <returns>The saved paletteItem.</returns>
        [WebHelp(Comment = "Saves a paletteItem. If the paletteItem with specified id exists that paletteItem will be updated; otherwise new paletteItem will be created. The saved paletteItem is returned in JSON format.")]
        [WebInvoke(Method = "PUT", UriTemplate = "/{paletteItemId}/?provider={provider}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        ItemContext<PaletteItemViewModel> SavePaletteItem(ItemContext<PaletteItemViewModel> context, string paletteItemId, string provider);

        /// <summary>
        /// Saves a paletteItem. If the paletteItem with specified id exists that paletteItem will be updated; otherwise new paletteItem will be created.
        /// The saved paletteItem is returned in XML format.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="paletteItemId">The paletteItem id.</param>
        /// <param name="provider">The provider name through which the paletteItem ought to be saved.</param>
        /// <returns>The saved paletteItem.</returns>
        [WebHelp(Comment = "Saves a paletteItem. If the paletteItem with specified id exists that paletteItem will be updated; otherwise new paletteItem will be created. The saved paletteItem is returned in XML format.")]
        [WebInvoke(Method = "PUT", UriTemplate = "/xml/{paletteItemId}/?provider={provider}", ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        ItemContext<PaletteItemViewModel> SavePaletteItemInXml(ItemContext<PaletteItemViewModel> context, string paletteItemId, string provider);

        /// <summary>
        /// Deletes the paletteItem.
        /// </summary>
        /// <param name="paletteItemId">The paletteItem id.</param>
        /// <param name="provider">The provider.</param>
        [WebHelp(Comment = "Deletes the paletteItem.")]
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/{paletteItemId}/?provider={provider}", ResponseFormat = WebMessageFormat.Json)]
        bool DeletePaletteItem(string paletteItemId, string provider);

        /// <summary>
        /// Deletes the paletteItem.
        /// </summary>
        /// <param name="paletteItemId">The paletteItem id.</param>
        /// <param name="provider">The provider.</param>
        [WebHelp(Comment = "Deletes the paletteItem.")]
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/xml/{paletteItemId}/?provider={provider}", ResponseFormat = WebMessageFormat.Xml)]
        bool DeletePaletteItemInXml(string paletteItemId, string provider);

        /// <summary>
        /// Deletes a collection of paletteItems. Result is returned in JSON format.
        /// </summary>
        /// <param name="ids">An array of the ids of the paletteItems to delete.</param>
        /// <param name="provider">The name of the paletteItems provider.</param>
        /// <returns>True if all paletteItems have been deleted; otherwise false.</returns>
        [WebHelp(Comment = "Deletes multiple paletteItems.")]
        [WebInvoke(Method = "POST", UriTemplate = "/batch/?provider={provider}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        bool BatchDeletePaletteItems(string[] ids, string provider);

        /// <summary>
        /// Deletes a collection of paletteItems. Result is returned in XML format.
        /// </summary>
        /// <param name="ids">An array of the ids of the paletteItems to delete.</param>
        /// <param name="provider">The name of the paletteItems provider.</param>
        /// <returns>True if all paletteItems have been deleted; otherwise false.</returns>
        [WebHelp(Comment = "Deletes multiple paletteItems.")]
        [WebInvoke(Method = "POST", UriTemplate = "/xml/batch/?provider={provider}", ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        bool BatchDeletePaletteItemsInXml(string[] ids, string provider);

        /// <summary>
        /// Gets the properties for the model. The results are returned in JSON format.
        /// </summary>
        /// <returns>
        /// Collection context object of <see cref="PaletteItemPropertyViewModel"/> objects.
        /// </returns>
        [WebHelp(Comment = "Get paletteItem properties.")]
        [WebGet(UriTemplate = "/model/properties/", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        CollectionContext<PaletteItemPropertyViewModel> GetProperties();

    }
}