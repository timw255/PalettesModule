using System;
using System.Linq;
using System.Reflection;
using Telerik.OpenAccess.Metadata;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Data.Linq;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.GenericContent;
using System.Collections;
using System.Collections.Generic;
using Telerik.Sitefinity.GenericContent.Model;
using System.Globalization;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Modules.GenericContent.Data;
using PaletteModule.Models;


namespace PaletteModule.Data.OpenAccess
{
	 [ContentProviderDecorator(typeof(OpenAccessContentDecorator))]
	public class PaletteOpenAccessDataProvider : ContentDataProviderBase, IOpenAccessDataProvider
	{
		/// <summary>
		/// Gets the meta data source.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <returns>The meta data source</returns>
		public MetadataSource GetMetaDataSource(IDatabaseMappingContext context)
		{
			return new PaletteStorageMetadataSource(context);
		}

		#region Properties
		/// <summary>
		/// Gets or sets the context.
		/// </summary>
		/// <value>The context.</value>
		public OpenAccessProviderContext Context { get; set; }
		#endregion

		#region Methods
		/// <summary>
		/// Gets a query of all the Dealer items.
		/// </summary>
		/// <returns>The Dealer items.</returns>
		public IQueryable<PaletteItem> GetPaletteItems()
		{
			var appName = this.ApplicationName;

			var query =
				SitefinityQuery
				.Get<PaletteItem>(this, MethodBase.GetCurrentMethod())
				.Where(b => b.ApplicationName == appName);

			return query;
		}

		/// <summary>
		/// Gets a Dealer by a specified ID.
		/// </summary>
		/// <param name="id">The ID.</param>
		/// <returns>The Dealer.</returns>
		public PaletteItem GetPaletteItem(Guid id)
		{
			if (id == Guid.Empty)
				throw new ArgumentException("Id cannot be Empty Guid");

			return this.GetContext().GetItemById<PaletteItem>(id.ToString());
		}

		/// <summary>
		/// Creates a new Dealer and returns it.
		/// </summary>
		/// <returns>The new Dealer.</returns>
		public PaletteItem CreatePaletteItem()
		{
			return CreatePaletteItem(Guid.NewGuid());
		}

		public PaletteItem CreatePaletteItem(Guid id)
		{
			var paletteItem = new PaletteItem();
			paletteItem.Id = id;
			paletteItem.ApplicationName = this.ApplicationName;
			paletteItem.Owner = SecurityManager.GetCurrentUserId();
			var dateValue = DateTime.UtcNow;
			paletteItem.DateCreated = dateValue;
			paletteItem.PublicationDate = dateValue;
			((IDataItem)paletteItem).Provider = this;

			// items with empty GUID are used in the UI to get a "blank" data item
			// -> that is, to fill a data item with default values
			// if this is the case, leave the item out of the transaction
			if (id != Guid.Empty)
			{
				this.GetContext().Add(paletteItem);
			}
			return paletteItem;
		}

		/// <summary>
		/// Updates the Dealer.
		/// </summary>
		/// <param name="entity">The Dealer entity.</param>
		public void UpdatePaletteItem(PaletteItem entity)
		{
			entity.LastModified = DateTime.UtcNow;
		}

		/// <summary>
		/// Deletes the Dealer.
		/// </summary>
		/// <param name="entity">The Dealer entity.</param>
		public void DeletePaletteItem(PaletteItem entity)
		{
			var scope = this.GetContext();

			//this.ClearLifecycle(location, this.GetDealers());
			if (scope != null)
			{
				scope.Remove(entity);
			}
		}
		#endregion

		#region Overriden methods

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

		public override IDataItem GetItemFromUrl(Type itemType, string url, bool published, out string redirectUrl)
		{
			if (itemType == null)
				throw new ArgumentNullException("itemType");
			if (String.IsNullOrEmpty(url))
				throw new ArgumentNullException("Url");

			var urlType = this.GetUrlTypeFor(itemType);

			var urlData = this.GetUrls(urlType).Where(u => u.Url == url).FirstOrDefault();

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

		public override Type GetParentTypeFor(Type contentType)
		{
			return null;
		}

		public override Type GetUrlTypeFor(Type itemType)
		{
			if (itemType == typeof(PaletteItem)) return typeof(PaletteItemUrlData);

			throw GetInvalidItemTypeException(itemType, this.GetKnownTypes());
		}

		public override string GetUrlFormat(ILocatable item)
		{
			if (item.GetType() == typeof(PaletteItem))
			{
				return "/[UrlName]";
			}

			return base.GetUrlFormat(item);
		}

		public override Type[] GetKnownTypes()
		{
			return new[] { typeof(PaletteItem) };
		}

		public override string RootKey
		{
			get { return "PaletteItemDataProvider"; }
		}

		public override object GetItemOrDefault(Type itemType, Guid id)
		{
			if (itemType == typeof(Comment))
			{
				return this.GetComments().Where(c => c.Id == id).FirstOrDefault();
			}

			if (itemType == typeof(PaletteItem))
				return this.GetPaletteItems().Where(n => n.Id == id).FirstOrDefault();

			return base.GetItemOrDefault(itemType, id);
		}

		public override object CreateItem(Type itemType, Guid id)
		{
			if (itemType == null)
				throw new ArgumentNullException("itemType");

			if (itemType == typeof(PaletteItem))
			{
				return this.CreatePaletteItem(id);
			}

			throw GetInvalidItemTypeException(itemType, this.GetKnownTypes());
		}

		public override object GetItem(Type itemType, Guid id)
		{
			if (itemType == null)
				throw new ArgumentNullException("itemType");

			if (itemType == typeof(PaletteItem))
				return this.GetPaletteItem(id);

			return base.GetItem(itemType, id);
		}

		public override IEnumerable GetItems(Type itemType, string filterExpression, string orderExpression, int skip, int take, ref int? totalCount)
		{
			if (itemType == null)
				throw new ArgumentNullException("itemType");

			if (itemType == typeof(PaletteItem))
			{
				return SetExpressions(this.GetPaletteItems(), filterExpression, orderExpression, skip, take, ref totalCount);
			}

			if (itemType == typeof(Comment))
			{
				return SetExpressions(this.GetComments(), filterExpression, orderExpression, skip, take, ref totalCount);
			}

			throw GetInvalidItemTypeException(itemType, this.GetKnownTypes());
		}

		public override void DeleteItem(object item)
		{
			this.DeletePaletteItem((PaletteItem)item);
		}

		#endregion
	}
}