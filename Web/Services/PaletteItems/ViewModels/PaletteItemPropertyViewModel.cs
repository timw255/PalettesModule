using System;
using System.Linq;
using System.Runtime.Serialization;

namespace PaletteModule.Web.Services.PaletteItems.ViewModels
{
    /// <summary>
    /// A view model for the paletteItem properties.
    /// This view model is used by the services.
    /// </summary>
    [DataContract]
    public class PaletteItemPropertyViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember]
        public string Name
        {
            get;
            set;
        }
    }
}
