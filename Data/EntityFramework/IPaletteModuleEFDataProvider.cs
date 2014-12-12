using System;
using System.Linq;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Data.Decorators;
using PaletteModule.Data.EntityFramework.Decorators;

namespace PaletteModule.Data.EntityFramework
{
    [DataProviderDecorator(typeof(PaletteModuleEFDataProviderDecorator))]
    public interface IPaletteModuleEFDataProvider : IDataProviderBase
    {
        #region Methods
        /// <summary>
        /// Gets or sets the provider context.
        /// </summary>
        /// <value>The provider context.</value>
        PaletteModuleEFDataProviderContext ProviderContext { get; set; }

        /// <summary>
        /// Gets the db context.
        /// </summary>
        /// <value>The db context.</value>
        PaletteModuleEFDbContext Context { get; }
        #endregion
    }
}
