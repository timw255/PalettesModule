using System;
using System.Linq;
using PaletteModule.Models;

namespace PaletteModule.Web.Services.PaletteItems.ViewModels
{
    /// <summary>
    /// Provides methods for translating view models to models and vice versa for the PaletteModule module.
    /// </summary>
    public static class PaletteItemsViewModelTranslator
    {
        #region PaletteItem
        /// <summary>
        /// Translates PaletteItem view model to PaletteItem model.
        /// </summary>
        /// <param name="source">
        /// An instance of the <see cref="PaletteItemViewModel"/>.
        /// </param>
        /// <param name="target">
        /// An instance of the <see cref="PaletteItem"/>.
        /// </param>
        public static void ToModel(PaletteItemViewModel source, PaletteItem target, PaletteModuleManager manager)
        {
            target.Title = source.Title;
            target.Dark1 = source.Dark1;
            target.Dark2 = source.Dark2;
            target.Light1 = source.Light1;
            target.Light2 = source.Light2;
            target.Accent1 = source.Accent1;
            target.Accent2 = source.Accent2;
            target.Accent3 = source.Accent3;
            target.Accent4 = source.Accent4;
            target.Accent5 = source.Accent5;
            target.Accent6 = source.Accent6;
            target.Hyperlink = source.Hyperlink;
            target.FollowedHyperlink = source.FollowedHyperlink;
        }

        /// <summary>
        /// Translates PaletteItem to PaletteItem view model.
        /// </summary>
        /// <param name="source">
        /// An instance of the <see cref="PaletteItem"/>.
        /// </param>
        /// <param name="target">
        /// An instance of the <see cref="PaletteItemViewModel"/>.
        /// </param>
        public static void ToViewModel(PaletteItem source, PaletteItemViewModel target, PaletteModuleManager manager)
        {
            target.Id = source.Id;
            target.LastModified = source.LastModified;
            target.DateCreated = source.DateCreated;

            target.Title = source.Title;
            target.Dark1 = source.Dark1;
            target.Dark2 = source.Dark2;
            target.Light1 = source.Light1;
            target.Light2 = source.Light2;
            target.Accent1 = source.Accent1;
            target.Accent2 = source.Accent2;
            target.Accent3 = source.Accent3;
            target.Accent4 = source.Accent4;
            target.Accent5 = source.Accent5;
            target.Accent6 = source.Accent6;
            target.Hyperlink = source.Hyperlink;
            target.FollowedHyperlink = source.FollowedHyperlink;
        }
        #endregion
    }
}
