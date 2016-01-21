using System;
using System.Linq;

namespace PaletteModule.Data.EntityFramework
{
    public class PaletteModuleEFDataProviderContext
    {
        #region Properties
        /// <summary>
        /// Gets or sets the provider key.
        /// </summary>
        /// <value>The provider key.</value>
        public string ProviderKey { get; set; }

        /// <summary>
        /// Gets or sets the connection id.
        /// </summary>
        /// <value>The connection id.</value>
        public string ConnectionId { get; set; }
        #endregion
    }
}
