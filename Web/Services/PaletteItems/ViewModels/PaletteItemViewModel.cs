using System;
using System.Runtime.Serialization;
using Telerik.Sitefinity.Localization;

namespace PaletteModule.Web.Services.PaletteItems.ViewModels
{
    /// <summary>
    /// A view model for the PaletteItem class.
    /// This view model is used by the services.
    /// </summary>
    [DataContract]
    public class PaletteItemViewModel
    {
        #region Properties
        /// <summary>
        /// Gets the unique identity of the data item.
        /// </summary>
        /// <value>The id.</value>
        [DataMember]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the last modified.
        /// </summary>
        /// <value>The last modified.</value>
        [DataMember]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>The date created.</value>
        [DataMember]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Dark1.
        /// </summary>
        [DataMember]
        public string Dark1 { get; set; }

        /// <summary>
        /// Gets or sets the Dark2.
        /// </summary>
        [DataMember]
        public string Dark2 { get; set; }

        /// <summary>
        /// Gets or sets the Light1.
        /// </summary>
        [DataMember]
        public string Light1 { get; set; }

        /// <summary>
        /// Gets or sets the Light2.
        /// </summary>
        [DataMember]
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

        #endregion

        #region Labels and messages
        /// <summary>
        /// Gets the localized text for "actions" label
        /// </summary>
        [DataMember]
        public string ActionsLabel
        {
            get
            {
                return Res.Get<PaletteModuleResources>().ActionsLabel;
            }
            set
            {
                // do nothing; serializer requirement
            }
        }

        /// <summary>
        /// Gets the localized text for the "delete" label
        /// </summary>
        [DataMember]
        public string DeleteLabel
        {
            get
            {
                return Res.Get<PaletteModuleResources>().DeleteLabel;
            }
            set
            {
                // do nothing; serializer requirement
            }
        }
        #endregion
    }
}