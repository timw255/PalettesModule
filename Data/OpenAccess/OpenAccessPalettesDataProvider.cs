using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using PalettesModule.Model;
using Telerik.Sitefinity.Modules.GenericContent.Data;
using Telerik.Sitefinity.Modules.GenericContent;
using Telerik.Sitefinity.Data;
using Telerik.OpenAccess.Metadata;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Data.Linq;
using Telerik.Sitefinity.Data.Linq.Dynamic;
using System.Reflection;
using Telerik.Sitefinity.GenericContent.Model;
using System.Globalization;

namespace PalettesModule.Data.OpenAccess
{
	[ContentProviderDecorator(typeof(OpenAccessContentDecorator))]
	public class OpenAccessPalettesDataProvider : ContentDataProviderBase, IOpenAccessDataProvider
	{
		#region IOpenAccessDataProvider

		/// <summary>
		/// Gets or sets the OpenAccess context. Alternative to Database.
		/// </summary>
		/// <value>
		/// The context.
		/// </value>
		public OpenAccessProviderContext Context { get; set; }

		/// <summary>
		/// Gets the meta data source.
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public MetadataSource GetMetaDataSource(Telerik.Sitefinity.Model.IDatabaseMappingContext context)
		{
			return new PalettesFluentMetadataSource(context);
		}

		#endregion

		#region CRUD Methods

		/// <summary>
		/// Create a palette item with random id
		/// </summary>
		/// <returns>
		/// Newly created agent item in transaction
		/// </returns>
		public PaletteItem CreatePalette()
		{
			return this.CreatePalette(Guid.NewGuid());
		}

		/// <summary>
		/// Create a palette item with specific primary key
		/// </summary>
		/// <param name="id">Primary key</param>
		/// <returns>
		/// Newly created agent item in transaction
		/// </returns>
		public PaletteItem CreatePalette(Guid id)
		{
			var palette = new PaletteItem();
			palette.Id = id;
			palette.ApplicationName = this.ApplicationName;
			palette.Owner = SecurityManager.GetCurrentUserId();
			var dateValue = DateTime.UtcNow;
			palette.DateCreated = dateValue;
			palette.PublicationDate = dateValue;
			((IDataItem)palette).Provider = this;

			// items with empty guid are used in the UI to get a "blank" data item
			// -> i.e. to fill a data item with default values
			// if this is the case, we leave the item out of the transaction
			if (id != Guid.Empty)
			{
				this.GetContext().Add(palette);
			}
			return palette;
		}

		/// <summary>
		/// Get a palette item by primary key
		/// </summary>
		/// <param name="id">Primary key</param>
		/// <returns>
		/// Agent item in transaction
		/// </returns>
		/// <exception cref="T:Telerik.Sitefinity.SitefinityExceptions.ItemNotFoundException">When there is no item with the given primary key</exception>
		public PaletteItem GetPalette(Guid id)
		{
			if (id == Guid.Empty)
				throw new ArgumentException("Id cannot be Empty Guid");

            // Always use this method. Do NOT change it to query. Catch the exception if the Id can be wrong.
            var palette = (PaletteItem)this.GetContext().GetItemById(typeof(PaletteItem), id.ToString());
            ((IDataItem)palette).Provider = this;

            return palette;
		}

		public IQueryable<PaletteItem> GetPalettes()
		{
			var appName = this.ApplicationName;

			var query =
				SitefinityQuery
				.Get<PaletteItem>(this, MethodBase.GetCurrentMethod())
				.Where(b => b.ApplicationName == appName);

			return query;
		}

		public void DeletePalette(PaletteItem palette)
		{
			var scope = this.GetContext();

			//this.ClearLifecycle(palette, this.GetPalettes());
			if (scope != null)
			{
				scope.Remove(palette);
			}
		}

		#endregion

		#region ContentDataProviderBase Overrides

		/// <summary>
		/// Gets a unique key for each data provider base.
		/// </summary>
		public override string RootKey
		{
			get { return "PalettesDataProvider"; }
		}

		/// <summary>
		/// Override this method in order to return the type of the Parent object of the specified content type.
		/// If the type has no parent type, return null.
		/// </summary>
		/// <param name="contentType">Type of the content.</param>
		/// <returns></returns>
		public override Type GetParentTypeFor(Type contentType)
		{
			return null;
		}

		/// <summary>
		/// Gets the actual type of the <see cref="T:Telerik.Sitefinity.GenericContent.Model.UrlData"/> implementation for the specified content type.
		/// </summary>
		/// <param name="itemType">Type of the content item.</param>
		/// <returns></returns>
		public override Type GetUrlTypeFor(Type itemType)
		{
			if (itemType == typeof(PaletteItem)) return typeof(PaletteItemUrlData);

			throw GetInvalidItemTypeException(itemType, this.GetKnownTypes());
		}

		/// <summary>
		/// Gets the url format for the specified data item that implements <see cref="T:Telerik.Sitefinity.GenericContent.Model.ILocatable"/> interface.
		/// </summary>
		/// <param name="item">The locatable item for which the url format should be returned.</param>
		/// <returns>
		/// Regular expression used to format the url.
		/// </returns>
		public override string GetUrlFormat(ILocatable item)
		{
			if (item.GetType() == typeof(PaletteItem))
			{
				return "/[UrlName]";
			}

			return base.GetUrlFormat(item);
		}

		/// <summary>
		/// Get a list of types served by this manager
		/// </summary>
		/// <returns></returns>
		public override Type[] GetKnownTypes()
		{
			return new[] { typeof(PaletteItem) };
		}

		#region Generic Item Methods

		/// <summary>
		/// Creates new data item.
		/// </summary>
		/// <param name="itemType">Type of the item.</param>
		/// <param name="id">The pageId.</param>
		/// <returns></returns>
		public override object CreateItem(Type itemType, Guid id)
		{
			if (itemType == null)
				throw new ArgumentNullException("itemType");

			if (itemType == typeof(PaletteItem))
			{
				return this.CreatePalette(id);
			}

			throw GetInvalidItemTypeException(itemType, this.GetKnownTypes());
		}

		/// <summary>
		/// Gets the data item with the specified ID.
		/// An exception should be thrown if an item with the specified ID does not exist.
		/// </summary>
		/// <param name="itemType">Type of the item.</param>
		/// <param name="id">The ID of the item to return.</param>
		/// <returns></returns>
		public override object GetItem(Type itemType, Guid id)
		{
			if (itemType == null)
				throw new ArgumentNullException("itemType");

			if (itemType == typeof(PaletteItem))
				return this.GetPalette(id);

			return base.GetItem(itemType, id);
		}

		/// <summary>
		/// Gets the items.
		/// </summary>
		/// <param name="itemType">Type of the item.</param>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="orderExpression">The order expression.</param>
		/// <param name="skip">The skip.</param>
		/// <param name="take">The take.</param>
		/// <param name="totalCount">Total count of the items that are filtered by <paramref name="filterExpression"/></param>
		/// <returns></returns>
		public override IEnumerable GetItems(Type itemType, string filterExpression, string orderExpression, int skip, int take, ref int? totalCount)
		{
			if (itemType == null)
				throw new ArgumentNullException("itemType");

			if (itemType == typeof(PaletteItem))
			{
				return SetExpressions(this.GetPalettes(), filterExpression, orderExpression, skip, take, ref totalCount);
			}

            //if (itemType == typeof(Comment))
            //{
            //    return SetExpressions(this.GetComments(), filterExpression, orderExpression, skip, take, ref totalCount);
            //}

			throw GetInvalidItemTypeException(itemType, this.GetKnownTypes());
		}

		/// <summary>
		/// Get item by primary key without throwing exceptions if it doesn't exist
		/// </summary>
		/// <param name="itemType">Type of the item to get</param>
		/// <param name="id">Primary key</param>
		/// <returns>
		/// Item or default value
		/// </returns>
		public override object GetItemOrDefault(Type itemType, Guid id)
		{
            //if (itemType == typeof(Comment))
            //{
            //    return this.GetComments().Where(c => c.Id == id).FirstOrDefault();
            //}

			if (itemType == typeof(PaletteItem))
				return this.GetPalettes().Where(n => n.Id == id).FirstOrDefault();

			return base.GetItemOrDefault(itemType, id);
		}

		/// <summary>
		/// Retrieve a content item by its Url, optionally returning only items that are visible on the public side
		/// </summary>
		/// <param name="itemType">Type of the item to get</param>
		/// <param name="url">Url of the item (relative)</param>
		/// <param name="published">If true, will get only Published/Scheduled items - those that are typically visible on the public side.</param>
		/// <param name="redirectUrl">Url to redirect to if the item's url has been changed</param>
		/// <returns>Data item or null</returns>
		public override IDataItem GetItemFromUrl(Type itemType, string url, bool published, out string redirectUrl)
		{
			if (itemType == null)
				throw new ArgumentNullException("itemType");
			if (String.IsNullOrEmpty(url))
				throw new ArgumentNullException("Url");

			var urlType = this.GetUrlTypeFor(itemType);

			var	urlData = this.GetUrls(urlType).Where(u => u.Url == url).FirstOrDefault();


			if (urlData != null)
			{
				var item = urlData.Parent;

				if (urlData.RedirectToDefault)
					redirectUrl = this.GetItemUrl((ILocatable)item, CultureInfo.GetCultureInfo(urlData.Culture));
				else
					redirectUrl = null;
				if (item != null)
					item.Provider = this;
				return item;
			}
			redirectUrl = null;
			return null;
		}


		/// <summary>
		/// Gets the items by taxon.
		/// </summary>
		/// <param name="taxonId">The taxon id.</param>
		/// <param name="isSingleTaxon">A value indicating if it is a single taxon.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="itemType">Type of the item.</param>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="orderExpression">The order expression.</param>
		/// <param name="skip">Items to skip.</param>
		/// <param name="take">Items to take.</param>
		/// <param name="totalCount">The total count.</param>
		/// <returns></returns>
		public override IEnumerable GetItemsByTaxon(Guid taxonId, bool isSingleTaxon, string propertyName, Type itemType, string filterExpression, string orderExpression, int skip, int take, ref int? totalCount)
		{
            if (itemType == typeof(PaletteItem))
            {
                this.CurrentTaxonomyProperty = propertyName;
                int? internalTotCount = null;
                IQueryable<PaletteItem> query =
                    (IQueryable<PaletteItem>)this.GetItems(itemType, filterExpression, orderExpression, 0, 0, ref internalTotCount);
                if (isSingleTaxon)
                {
                    var query0 = from i in query
                                 where i.GetValue<Guid>(this.CurrentTaxonomyProperty) == taxonId
                                 select i;
                    query = query0;
                }
                else
                {
                    var query1 = from i in query
                                 where (i.GetValue<IList<Guid>>(this.CurrentTaxonomyProperty)).Any(t => t == taxonId)
                                 select i;
                    query = query1;
                }

                if (totalCount.HasValue)
                {
                    totalCount = query.Count();
                }

                if (skip > 0)
                    query = query.Skip(skip);
                if (take > 0)
                    query = query.Take(take);
                return query;
            }
            throw GetInvalidItemTypeException(itemType, this.GetKnownTypes());
		}

        /// <summary>
        /// Marks the provided persistent item for deletion.
        /// The item is deleted form the storage when the transaction is committed.
        /// </summary>
        /// <param name="item">The item to be deleted.</param>
        public override void DeleteItem(object item)
        {
            this.DeletePalette((PaletteItem)item);
        }

		#endregion

		#endregion
	}
}
