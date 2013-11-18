using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalettesModule.Model;
using PalettesModule.Data;
using PalettesModule.Web.Services.Data;
using Telerik.Sitefinity.Modules.GenericContent;
using Telerik.Sitefinity.Modules;

namespace PalettesModule.Web.Services
{
	public class PalettesBackendService : ContentServiceBase<PaletteItem, PaletteItemViewModel, PalettesManager>
	{
		/// <summary>
		/// Gets the content items.
		/// </summary>
		/// <param name="providerName">Name of the provider.</param>
		/// <returns></returns>
		public override IQueryable<PaletteItem> GetContentItems(string providerName)
		{
			return this.GetManager(providerName).GetPalettes();
		}

		/// <summary>
		/// Gets the child content items.
		/// </summary>
		/// <param name="parentId">The parent id.</param>
		/// <param name="providerName">Name of the provider.</param>
		/// <returns></returns>
		public override IQueryable<PaletteItem> GetChildContentItems(Guid parentId, string providerName)
		{
			// TODO: Implement this method
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the content item.
		/// </summary>
		/// <param name="id">The id.</param>
		/// <param name="providerName">Name of the provider.</param>
		/// <returns></returns>
		public override PaletteItem GetContentItem(Guid id, string providerName)
		{
			return this.GetManager(providerName).GetPalette(id);
		}

		/// <summary>
		/// Gets the parent content item.
		/// </summary>
		/// <param name="id">The id.</param>
		/// <param name="providerName">Name of the provider.</param>
		/// <returns></returns>
		public override PaletteItem GetParentContentItem(Guid id, string providerName)
		{
			// TODO: Implement this method
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the manager.
		/// </summary>
		/// <param name="providerName">Name of the provider.</param>
		/// <returns></returns>
		public override PalettesManager GetManager(string providerName)
		{
			return PalettesManager.GetManager(providerName);
		}

		/// <summary>
		/// Gets the view model list.
		/// </summary>
		/// <param name="contentList">The content list.</param>
		/// <param name="dataProvider">The data provider.</param>
		/// <returns></returns>
		public override IEnumerable<PaletteItemViewModel> GetViewModelList(IEnumerable<PaletteItem> contentList, ContentDataProviderBase dataProvider)
		{
			var list = new List<PaletteItemViewModel>();

			foreach (var palette in contentList)
				list.Add(new PaletteItemViewModel(palette, dataProvider));

			return list;
		}
	}
}
