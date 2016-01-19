using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Telerik.OpenAccess;
using Telerik.Sitefinity;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Versioning.Serialization.Attributes;

namespace PaletteModule.Models
{
	[DataContract(Namespace = "http://sitefinity.com/samples/palettemoduleclass", Name = "Palette")]
	[ManagerType("PaletteModule.PaletteModuleManager, PaletteModule")]
    public class PaletteItem : Content, ILocatable
    {
        #region Construction
        /// <summary>
        /// Initializes a new instance of the <see cref="PaletteItem" /> class.
        /// </summary>
        public PaletteItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaletteItem" /> class.
        /// </summary>
        /// <param name="id">The PaletteItem ID.</param>
        /// <param name="applicationName">Name of the application.</param>
        public PaletteItem(Guid id, string applicationName)
        {
            this.Id = id;
            this.ApplicationName = applicationName;
            this.DateCreated = DateTime.UtcNow;
            this.LastModified = DateTime.UtcNow;
        }
        #endregion

        #region Properties
		//[DataMember]
		//public Lstring Title { get; set; }

        /// <summary>
        /// Gets or sets the Dark1.
        /// </summary>
		/// 
		[DataMember]
        public string Dark1 { get; set; }

        /// <summary>
        /// Gets or sets the Dark2.
        /// </summary>
		/// 
		[DataMember]
        public string Dark2 { get; set; }

        /// <summary>
        /// Gets or sets the Light1.
        /// </summary>
        public string Light1 { get; set; }

        /// <summary>
        /// Gets or sets the Light2.
        /// </summary>
        public string Light2 { get; set; }

        /// <summary>
        /// Gets or sets the Accent1.
        /// </summary>
		[DataMember]
		public string Accent1 { get; set; }

        /// <summary>
        /// Gets or sets the Accent2.
        /// </summary>
		[DataMember]
		public string Accent2 { get; set; }

        /// <summary>
        /// Gets or sets the Accent3.
        /// </summary>
		[DataMember]
		public string Accent3 { get; set; }

        /// <summary>
        /// Gets or sets the Accent4.
        /// </summary>
		[DataMember]
		public string Accent4 { get; set; }

        /// <summary>
        /// Gets or sets the Accent5.
        /// </summary>
		[DataMember]
		public string Accent5 { get; set; }

        /// <summary>
        /// Gets or sets the Accent6.
        /// </summary>
		[DataMember]
		public string Accent6 { get; set; }

        /// <summary>
        /// Gets or sets the Hyperlink.
        /// </summary>
		[DataMember]
		public string Hyperlink { get; set; }

        /// <summary>
        /// Gets or sets the FollowedHyperlink.
        /// </summary>
		[DataMember]
		public string FollowedHyperlink { get; set; }

		public override bool SupportsContentLifecycle
		{
			get
			{
				return false;
			}
		}

        #endregion

		#region ILocatable

		private ProviderTrackedList<PaletteItemUrlData> urls;

		/// <summary>
		/// Gets or sets a value indicating whether to auto generate an unique URL.
		/// </summary>
		/// <value>
		///     <c>true</c> if to auto generate an unique URL otherwise, <c>false</c>.
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
    }
}