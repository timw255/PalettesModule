using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Sitefinity.GenericContent.Model;
using PalettesModule.Model;
using Telerik.Sitefinity.Modules.GenericContent;
using Telerik.Sitefinity.Modules;

namespace PalettesModule.Web.Services.Data
{
	public class PaletteItemViewModel : ContentViewModelBase
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="PaletteItemViewModel"/> class.
		/// </summary>
		public PaletteItemViewModel() : base() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="PaletteItemViewModel"/> class.
		/// </summary>
		/// <param name="palette">The palette item.</param>
		/// <param name="provider">The provider.</param>
		public PaletteItemViewModel(PaletteItem palette, ContentDataProviderBase provider)
			: base(palette, provider)
		{
            this.Dark1 = palette.Dark1;
		    this.Light1 = palette.Light1;
		    this.Dark2 = palette.Dark2;
		    this.Light2 = palette.Light2;
		    this.Accent1 = palette.Accent1;
            this.Accent2 = palette.Accent2;
            this.Accent3 = palette.Accent3;
            this.Accent4 = palette.Accent4;
            this.Accent5 = palette.Accent5;
            this.Accent6 = palette.Accent6;
            this.Hyperlink = palette.Hyperlink;
            this.FollowedHyperlink = palette.FollowedHyperlink;
		}

		#endregion

		#region Public Methods and Overrides

		/// <summary>
		/// Get live version of this.ContentItem using this.provider
		/// </summary>
		/// <returns>
		/// Live version of this.ContentItem
		/// </returns>
		protected override Content GetLive()
		{
			return this.provider.GetLiveBase<PaletteItem>((PaletteItem)this.ContentItem);
		}

		/// <summary>
		/// Get temp version of this.ContentItem using this.provider
		/// </summary>
		/// <returns>
		/// Temp version of this.ContentItem
		/// </returns>
		protected override Content GetTemp()
		{
			return this.provider.GetTempBase<PaletteItem>((PaletteItem)this.ContentItem);
		}

		#endregion

		#region Public Properties

		public string Dark1 { get; set; }
		public string Light1 { get; set; }
		public string Dark2 { get; set; }
        public string Light2 { get; set; }
		public string Accent1 { get; set; }
        public string Accent2 { get; set; }
        public string Accent3 { get; set; }
        public string Accent4 { get; set; }
        public string Accent5 { get; set; }
        public string Accent6 { get; set; }
        public string Hyperlink { get; set; }
        public string FollowedHyperlink { get; set; }

		#endregion
	}
}
