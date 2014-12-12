using System;
using System.Linq;
using Telerik.Sitefinity.Data;
using PaletteModule.Models;

namespace PaletteModule
{
    public abstract class PaletteModuleDataProvider : DataProviderBase
    {
        #region Public and overriden methods
        /// <summary>
        /// Gets the known types.
        /// </summary>
        public override Type[] GetKnownTypes()
        {
            if (knownTypes == null)
            {
                knownTypes = new Type[]
                {
                    typeof(PaletteItem)
                };
            }
            return knownTypes;
        }

        /// <summary>
        /// Gets the root key.
        /// </summary>
        /// <value>The root key.</value>
        public override string RootKey
        {
            get
            {
                return "PaletteModuleDataProvider";
            }
        }
        #endregion

        #region Abstract methods
        /// <summary>
        /// Creates a new PaletteItem and returns it.
        /// </summary>
        /// <returns>The new PaletteItem.</returns>
        public abstract PaletteItem CreatePaletteItem();

        /// <summary>
        /// Gets a PaletteItem by a specified ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>The PaletteItem.</returns>
        public abstract PaletteItem GetPaletteItem(Guid id);

        /// <summary>
        /// Gets a query of all the PaletteItem items.
        /// </summary>
        /// <returns>The PaletteItem items.</returns>
        public abstract IQueryable<PaletteItem> GetPaletteItems();

        /// <summary>
        /// Updates the PaletteItem.
        /// </summary>
        /// <param name="entity">The PaletteItem entity.</param>
        public abstract void UpdatePaletteItem(PaletteItem entity);

        /// <summary>
        /// Deletes the PaletteItem.
        /// </summary>
        /// <param name="entity">The PaletteItem entity.</param>
        public abstract void DeletePaletteItem(PaletteItem entity);
        #endregion

        #region Private fields and constants
        private static Type[] knownTypes;
        #endregion
    }
}