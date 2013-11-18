using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Telerik.Sitefinity;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Versioning.Serialization.Attributes;

namespace PalettesModule.Model
{
	/// <summary>
	/// Palette Data Item class
	/// </summary>
	[DataContract(Namespace = "http://sitefinity.com/samples/palettesmodule", Name = "PaletteItem")]
	[ManagerType("PalettesModule.Data.PalettesManager, PalettesModule")]
	public class PaletteItem : Content, ILocatable
	{
		#region Overrides

		/// <summary>
		/// Indicate whether content lifecycle is supported or not
		/// </summary>
		public override bool SupportsContentLifecycle
		{
			get { return false; }
		}

		#endregion

		#region Palette Properties

		/// <summary>
		/// Palette Dark1
		/// </summary>
		[DataMember]
		public string Dark1
		{
			get { return this.dark1; }
			set { this.dark1 = value; }
		}

        /// <summary>
        /// Palette Light1
        /// </summary>
        [DataMember]
        public string Light1
        {
            get { return this.light1; }
            set { this.light1 = value; }
        }

        /// <summary>
        /// Palette Dark2
        /// </summary>
        [DataMember]
        public string Dark2
        {
            get { return this.dark2; }
            set { this.dark2 = value; }
        }

        /// <summary>
        /// Palette Light2
        /// </summary>
        [DataMember]
        public string Light2
        {
            get { return this.light2; }
            set { this.light2 = value; }
        }

        /// <summary>
        /// Palette Accent1
        /// </summary>
        [DataMember]
        public string Accent1
        {
            get { return this.accent1; }
            set { this.accent1 = value; }
        }

        /// <summary>
        /// Palette Accent2
        /// </summary>
        [DataMember]
        public string Accent2
        {
            get { return this.accent2; }
            set { this.accent2 = value; }
        }

        /// <summary>
        /// Palette Accent3
        /// </summary>
        [DataMember]
        public string Accent3
        {
            get { return this.accent3; }
            set { this.accent3 = value; }
        }

        /// <summary>
        /// Palette Accent4
        /// </summary>
        [DataMember]
        public string Accent4
        {
            get { return this.accent4; }
            set { this.accent4 = value; }
        }

        /// <summary>
        /// Palette Accent5
        /// </summary>
        [DataMember]
        public string Accent5
        {
            get { return this.accent5; }
            set { this.accent5 = value; }
        }

        /// <summary>
        /// Palette Accent6
        /// </summary>
        [DataMember]
        public string Accent6
        {
            get { return this.accent6; }
            set { this.accent6 = value; }
        }

        /// <summary>
        /// Palette Hyperlink
        /// </summary>
        [DataMember]
        public string Hyperlink
        {
            get { return this.hyperlink; }
            set { this.hyperlink = value; }
        }

        /// <summary>
        /// Palette FollowedHyperlink
        /// </summary>
        [DataMember]
        public string FollowedHyperlink
        {
            get { return this.followedHyperlink; }
            set { this.followedHyperlink = value; }
        }

		#endregion

		#region ILocatable

		/// <summary>
		/// Gets or sets a value indicating whether to auto generate an unique URL.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if to auto generate an unique URL otherwise, <c>false</c>.
		/// </value>
		[NonSerializableProperty]
		public bool AutoGenerateUniqueUrl
		{
			get { return false; }
		}

		/// <summary>
		/// Gets a collection of URL data for this item.
		/// </summary>
		/// <value> The collection of URL data.</value>
		[NonSerializableProperty]
		public virtual IList<PaletteItemUrlData> Urls
		{
			get
			{
				if (this.urls == null)
					this.urls = new ProviderTrackedList<PaletteItemUrlData>(this, "Urls");
				this.urls.SetCollectionParent(this);
				return this.urls;
			}
		}

		/// <summary>
		/// Gets a collection of URL data for this item.
		/// </summary>
		/// <value>The collection of URL data.</value>
		[NonSerializableProperty]
		IEnumerable<UrlData> ILocatable.Urls
		{
			get
			{
				return this.Urls.Cast<UrlData>();
			}
		}

		/// <summary>
		/// Clears the Urls collection for this item.
		/// </summary>
		/// <param name="excludeDefault">if set to <c>true</c> default urls will not be cleared.</param>
		public void ClearUrls(bool excludeDefault)
		{
			if (this.urls != null)
				this.urls.ClearUrls(excludeDefault);
		}

		/// <summary>
		/// Removes all urls that satisfy the condition that is checked in the predicate function.
		/// </summary>
		/// <param name="predicate">A function to test each element for a condition.</param>
		public void RemoveUrls(Func<UrlData, bool> predicate)
		{
			if (this.urls != null)
				this.urls.RemoveUrls(predicate);
		}

		#endregion

		#region Private Properties

		private string dark1;
		private string light1;
		private string dark2;
		private string light2;
		private string accent1;
        private string accent2;
        private string accent3;
        private string accent4;
        private string accent5;
        private string accent6;
        private string hyperlink;
        private string followedHyperlink;

		// ILocatable
		private ProviderTrackedList<PaletteItemUrlData> urls;

		#endregion
	}
}
