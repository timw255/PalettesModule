using System;
using System.Linq;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace PaletteModule
{
    /// <summary>
    /// Localizable strings for the PaletteModule module
    /// </summary>
    /// <remarks>
    /// You can use Sitefinity Thunder to edit this file.
    /// To do this, open the file's context menu and select Edit with Thunder.
    /// 
    /// If you wish to install this as a part of a custom module,
    /// add this to the module's Initialize method:
    /// App.WorkWith()
    ///     .Module(ModuleName)
    ///     .Initialize()
    ///         .Localization<PaletteModuleResources>();
    /// </remarks>
    /// <see cref="http://www.sitefinity.com/documentation/documentationarticles/developers-guide/how-to/how-to-import-events-from-facebook/creating-the-resources-class"/>
    [ObjectInfo("PaletteModuleResources", ResourceClassId = "PaletteModuleResources", Title = "PaletteModuleResourcesTitle", TitlePlural = "PaletteModuleResourcesTitlePlural", Description = "PaletteModuleResourcesDescription")]
    public class PaletteModuleResources : Resource
    {
        #region Construction
        /// <summary>
        /// Initializes new instance of <see cref="PaletteModuleResources"/> class with the default <see cref="ResourceDataProvider"/>.
        /// </summary>
        public PaletteModuleResources()
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="PaletteModuleResources"/> class with the provided <see cref="ResourceDataProvider"/>.
        /// </summary>
        /// <param name="dataProvider"><see cref="ResourceDataProvider"/></param>
        public PaletteModuleResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }
        #endregion

        #region Class Description
        /// <summary>
        /// PaletteModule Resources
        /// </summary>
        [ResourceEntry("PaletteModuleResourcesTitle",
            Value = "PaletteModule module labels",
            Description = "The title of this class.",
            LastModified = "2014/08/04")]
        public string PaletteModuleResourcesTitle
        {
            get
            {
                return this["PaletteModuleResourcesTitle"];
            }
        }

        /// <summary>
        /// PaletteModule Resources Title plural
        /// </summary>
        [ResourceEntry("PaletteModuleResourcesTitlePlural",
            Value = "PaletteModule module labels",
            Description = "The title plural of this class.",
            LastModified = "2014/08/04")]
        public string PaletteModuleResourcesTitlePlural
        {
            get
            {
                return this["PaletteModuleResourcesTitlePlural"];
            }
        }

        /// <summary>
        /// Contains localizable resources for PaletteModule module.
        /// </summary>
        [ResourceEntry("PaletteModuleResourcesDescription",
            Value = "Contains localizable resources for PaletteModule module.",
            Description = "The description of this class.",
            LastModified = "2014/08/04")]
        public string PaletteModuleResourcesDescription
        {
            get
            {
                return this["PaletteModuleResourcesDescription"];
            }
        }
        #endregion

        #region Labels
        /// <summary>
        /// word: Actions
        /// </summary>
        [ResourceEntry("ActionsLabel",
            Value = "Actions",
            Description = "word: Actions",
            LastModified = "2014/08/04")]
        public string ActionsLabel
        {
            get
            {
                return this["ActionsLabel"];
            }
        }

        /// <summary>
        /// Title of the link for closing the dialog and going back to the PaletteModule module
        /// </summary>
        [ResourceEntry("BackToLabel",
            Value = "Go Back",
            Description = "Title of the link for closing the dialog and going back",
            LastModified = "2014/08/04")]
        public string BackToLabel
        {
            get
            {
                return this["BackToLabel"];
            }
        }

        /// <summary>
        /// word: Cancel
        /// </summary>
        [ResourceEntry("CancelLabel",
            Value = "Cancel",
            Description = "word: Cancel",
            LastModified = "2014/08/04")]
        public string CancelLabel
        {
            get
            {
                return this["CancelLabel"];
            }
        }

        /// <summary>
        /// word: Save
        /// </summary>
        /// <value>Save</value>
        [ResourceEntry("SaveLabel",
            Value = "Save",
            Description = "word: Save",
            LastModified = "2014/08/04")]
        public string SaveLabel
        {
            get
            {
                return this["SaveLabel"];
            }
        }

        /// <summary>
        /// phrase: Save changes
        /// </summary>
        [ResourceEntry("SaveChangesLabel",
            Value = "Save changes",
            Description = "phrase: Save changes",
            LastModified = "2014/08/04")]
        public string SaveChangesLabel
        {
            get
            {
                return this["SaveChangesLabel"];
            }
        }

        /// <summary>
        /// word: Delete
        /// </summary>
        [ResourceEntry("DeleteLabel",
            Value = "Delete",
            Description = "word: Delete",
            LastModified = "2014/08/04")]
        public string DeleteLabel
        {
            get
            {
                return this["DeleteLabel"];
            }
        }

        /// <summary>
        /// Phrase: Yes, delete these items
        /// </summary>
        /// <value>Yes, delete these items</value>
        [ResourceEntry("YesDeleteTheseItemsButton",
            Value = "Yes, delete these items",
            Description = "Phrase: Yes, delete these items",
            LastModified = "2014/08/04")]
        public string YesDeleteTheseItemsButton
        {
            get
            {
                return this["YesDeleteTheseItemsButton"];
            }
        }

        /// <summary>
        /// Text of the button that confirms deletion of an item.
        /// </summary>
        /// <value>Yes, delete this item</value>
        [ResourceEntry("YesDeleteThisItemButton",
            Value = "Yes, delete this item",
            Description = "Text of the button that confirms deletion of an item.",
            LastModified = "2014/08/04")]
        public string YesDeleteThisItemButton
        {
            get
            {
                return this["YesDeleteThisItemButton"];
            }
        }

        /// <summary>
        /// Phrase: items are about to be deleted. Continue?
        /// </summary>
        /// <value>items are about to be deleted. Continue?</value>
        [ResourceEntry("BatchDeleteConfirmationMessage",
            Value = "items are about to be deleted. Continue?",
            Description = "Phrase: items are about to be deleted. Continue?",
            LastModified = "2014/08/04")]
        public string BatchDeleteConfirmationMessage
        {
            get
            {
                return this["BatchDeleteConfirmationMessage"];
            }
        }

        /// <summary>
        /// word: Sort
        /// </summary>
        /// <value>Sort</value>
        [ResourceEntry("SortLabel",
            Value = "Sort",
            Description = "word: Sort",
            LastModified = "2014/08/04")]
        public string SortLabel
        {
            get
            {
                return this["SortLabel"];
            }
        }

        /// <summary>
        /// Phrase: Custom sorting
        /// </summary>
        /// <value>Custom sorting</value>
        [ResourceEntry("CustomSortingDialogHeader",
            Value = "Custom sorting",
            Description = "Phrase: Custom sorting",
            LastModified = "2014/08/04")]
        public string CustomSortingDialogHeader
        {
            get
            {
                return this["CustomSortingDialogHeader"];
            }
        }

        /// <summary>
        /// word: or
        /// </summary>
        /// <value>or</value>
        [ResourceEntry("OrLabel",
            Value = "or",
            Description = "word: or",
            LastModified = "2014/08/04")]
        public string OrLabel
        {
            get
            {
                return this["OrLabel"];
            }
        }

        /// <summary>
        /// Phrase: Sort by
        /// </summary>
        /// <value>Sort by</value>
        [ResourceEntry("SortByLabel",
            Value = "Sort by",
            Description = "Phrase: Sort by",
            LastModified = "2014/08/04")]
        public string SortByLabel
        {
            get
            {
                return this["SortByLabel"];
            }
        }

        /// <summary>
        /// word: Yes
        /// </summary>
        /// <value>Yes</value>
        [ResourceEntry("YesLabel",
            Value = "Yes",
            Description = "word: Yes",
            LastModified = "2013/06/26")]
        public string YesLabel
        {
            get
            {
                return this["YesLabel"];
            }
        }

        /// <summary>
        /// word: No
        /// </summary>
        /// <value>No</value>
        [ResourceEntry("NoLabel",
            Value = "No",
            Description = "word: No",
            LastModified = "2013/06/26")]
        public string NoLabel
        {
            get
            {
                return this["NoLabel"];
            }
        }
        #endregion

        #region PaletteItems
        /// <summary>
        /// Messsage: PageTitle
        /// </summary>
        /// <value>Title for the PaletteItem's page.</value>
        [ResourceEntry("PaletteItemGroupPageTitle",
            Value = "PaletteItem",
            Description = "The title of PaletteItem's page.",
            LastModified = "2014/08/04")]
        public string PaletteItemGroupPageTitle
        {
            get
            {
                return this["PaletteItemGroupPageTitle"];
            }
        }

        /// <summary>
        /// Messsage: PageDescription
        /// </summary>
        /// <value>Description for the PaletteItem's page.</value>
        [ResourceEntry("PaletteItemGroupPageDescription",
            Value = "PaletteItem",
            Description = "The description of PaletteItem's page.",
            LastModified = "2014/08/04")]
        public string PaletteItemGroupPageDescription
        {
            get
            {
                return this["PaletteItemGroupPageDescription"];
            }
        }

        /// <summary>
        /// The URL name of PaletteItem's page.
        /// </summary>
        [ResourceEntry("PaletteItemGroupPageUrlName",
            Value = "PaletteModule-PaletteItem",
            Description = "The URL name of PaletteItem's page.",
            LastModified = "2014/08/04")]
        public string PaletteItemGroupPageUrlName
        {
            get
            {
                return this["PaletteItemGroupPageUrlName"];
            }
        }

        /// <summary>
        /// Message displayed to user when no paletteItems exist in the system
        /// </summary>
        /// <value>No paletteItems have been created yet</value>
        [ResourceEntry("NoPaletteItemsCreatedMessage",
            Value = "No paletteItems have been created yet",
            Description = "Message displayed to user when no paletteItems exist in the system",
            LastModified = "2014/08/04")]
        public string NoPaletteItemsCreatedMessage
        {
            get
            {
                return this["NoPaletteItemsCreatedMessage"];
            }
        }

        /// <summary>
        /// Title of the button for creating a new paletteItem
        /// </summary>
        /// <value>Create a paletteItem</value>
        [ResourceEntry("CreateAPaletteItem",
            Value = "Create a paletteItem",
            Description = "Title of the button for creating a new paletteItem",
            LastModified = "2014/08/04")]
        public string CreateAPaletteItem
        {
            get
            {
                return this["CreateAPaletteItem"];
            }
        }

        /// <summary>
        /// Label for editing a new paletteItem
        /// </summary>
        /// <value>Create a paletteItem</value>
        [ResourceEntry("EditAPaletteItem",
            Value = "Edit a paletteItem",
            Description = "Label for editing a new paletteItem",
            LastModified = "2014/08/04")]
        public string EditAPaletteItem
        {
            get
            {
                return this["EditAPaletteItem"];
            }
        }

        /// <summary>
        /// PaletteItem Title.
        /// </summary>
        /// <value>Title</value>
        [ResourceEntry("PaletteItemTitleLabel",
            Value = "Title",
            Description = "PaletteItem Title.",
            LastModified = "2014/08/04")]
        public string PaletteItemTitleLabel
        {
            get
            {
                return this["PaletteItemTitleLabel"];
            }
        }

        /// <summary>
        /// PaletteItem Title description.
        /// </summary>
        /// <value>Enter the item's title (required)</value>
        [ResourceEntry("PaletteItemTitleDescription",
            Value = "Enter the item's title (required)",
            Description = "PaletteItem Title description.",
            LastModified = "2014/08/04")]
        public string PaletteItemTitleDescription
        {
            get
            {
                return this["PaletteItemTitleDescription"];
            }
        }

        /// <summary>
        /// Error message displayed if the user does not enter paletteItem Title.
        /// </summary>
        [ResourceEntry("PaletteItemTitleCannotBeEmpty",
            Value = "The Title of the paletteItem cannot be empty.",
            Description = "Error message displayed if the user does not enter paletteItem Title.",
            LastModified = "2014/08/04")]
        public string PaletteItemTitleCannotBeEmpty
        {
            get
            {
                return this["PaletteItemTitleCannotBeEmpty"];
            }
        }

        /// <summary>
        /// Error message displayed if the user enters too long Title.
        /// </summary>
        /// <value>Title value is too long. Maximum allowed is 255 characters.</value>
        [ResourceEntry("PaletteItemTitleInvalidLength",
            Value = "Title value is too long. Maximum allowed is 255 characters.",
            Description = "Error message displayed if the user enters too long Title.",
            LastModified = "2014/08/04")]
        public string PaletteItemTitleInvalidLength
        {
            get
            {
                return this["PaletteItemTitleInvalidLength"];
            }
        }

        /// <summary>
        /// PaletteItem Dark1.
        /// </summary>
        /// <value>Dark1</value>
        [ResourceEntry("PaletteItemDark1Label",
            Value = "Dark1",
            Description = "PaletteItem Dark1.",
            LastModified = "2014/08/04")]
        public string PaletteItemDark1Label
        {
            get
            {
                return this["PaletteItemDark1Label"];
            }
        }

        /// <summary>
        /// Error message displayed if the user enters too long Dark1.
        /// </summary>
        /// <value>Dark1 value is too long. Maximum allowed is 255 characters.</value>
        [ResourceEntry("PaletteItemDark1InvalidLength",
            Value = "Dark1 value is too long. Maximum allowed is 255 characters.",
            Description = "Error message displayed if the user enters too long Dark1.",
            LastModified = "2014/08/04")]
        public string PaletteItemDark1InvalidLength
        {
            get
            {
                return this["PaletteItemDark1InvalidLength"];
            }
        }

        /// <summary>
        /// PaletteItem Dark2.
        /// </summary>
        /// <value>Dark2</value>
        [ResourceEntry("PaletteItemDark2Label",
            Value = "Dark2",
            Description = "PaletteItem Dark2.",
            LastModified = "2014/08/04")]
        public string PaletteItemDark2Label
        {
            get
            {
                return this["PaletteItemDark2Label"];
            }
        }

        /// <summary>
        /// Error message displayed if the user enters too long Dark2.
        /// </summary>
        /// <value>Dark2 value is too long. Maximum allowed is 255 characters.</value>
        [ResourceEntry("PaletteItemDark2InvalidLength",
            Value = "Dark2 value is too long. Maximum allowed is 255 characters.",
            Description = "Error message displayed if the user enters too long Dark2.",
            LastModified = "2014/08/04")]
        public string PaletteItemDark2InvalidLength
        {
            get
            {
                return this["PaletteItemDark2InvalidLength"];
            }
        }

        /// <summary>
        /// PaletteItem Light1.
        /// </summary>
        /// <value>Light1</value>
        [ResourceEntry("PaletteItemLight1Label",
            Value = "Light1",
            Description = "PaletteItem Light1.",
            LastModified = "2014/08/04")]
        public string PaletteItemLight1Label
        {
            get
            {
                return this["PaletteItemLight1Label"];
            }
        }

        /// <summary>
        /// Error message displayed if the user enters too long Light1.
        /// </summary>
        /// <value>Light1 value is too long. Maximum allowed is 255 characters.</value>
        [ResourceEntry("PaletteItemLight1InvalidLength",
            Value = "Light1 value is too long. Maximum allowed is 255 characters.",
            Description = "Error message displayed if the user enters too long Light1.",
            LastModified = "2014/08/04")]
        public string PaletteItemLight1InvalidLength
        {
            get
            {
                return this["PaletteItemLight1InvalidLength"];
            }
        }

        /// <summary>
        /// PaletteItem Light2.
        /// </summary>
        /// <value>Light2</value>
        [ResourceEntry("PaletteItemLight2Label",
            Value = "Light2",
            Description = "PaletteItem Light2.",
            LastModified = "2014/08/04")]
        public string PaletteItemLight2Label
        {
            get
            {
                return this["PaletteItemLight2Label"];
            }
        }

        /// <summary>
        /// Error message displayed if the user enters too long Light2.
        /// </summary>
        /// <value>Light2 value is too long. Maximum allowed is 255 characters.</value>
        [ResourceEntry("PaletteItemLight2InvalidLength",
            Value = "Light2 value is too long. Maximum allowed is 255 characters.",
            Description = "Error message displayed if the user enters too long Light2.",
            LastModified = "2014/08/04")]
        public string PaletteItemLight2InvalidLength
        {
            get
            {
                return this["PaletteItemLight2InvalidLength"];
            }
        }

        /// <summary>
        /// PaletteItem Accent1.
        /// </summary>
        /// <value>Accent1</value>
        [ResourceEntry("PaletteItemAccent1Label",
            Value = "Accent1",
            Description = "PaletteItem Accent1.",
            LastModified = "2014/08/04")]
        public string PaletteItemAccent1Label
        {
            get
            {
                return this["PaletteItemAccent1Label"];
            }
        }

        /// <summary>
        /// Error message displayed if the user enters too long Accent1.
        /// </summary>
        /// <value>Accent1 value is too long. Maximum allowed is 255 characters.</value>
        [ResourceEntry("PaletteItemAccent1InvalidLength",
            Value = "Accent1 value is too long. Maximum allowed is 255 characters.",
            Description = "Error message displayed if the user enters too long Accent1.",
            LastModified = "2014/08/04")]
        public string PaletteItemAccent1InvalidLength
        {
            get
            {
                return this["PaletteItemAccent1InvalidLength"];
            }
        }

        /// <summary>
        /// PaletteItem Accent2.
        /// </summary>
        /// <value>Accent2</value>
        [ResourceEntry("PaletteItemAccent2Label",
            Value = "Accent2",
            Description = "PaletteItem Accent2.",
            LastModified = "2014/08/04")]
        public string PaletteItemAccent2Label
        {
            get
            {
                return this["PaletteItemAccent2Label"];
            }
        }

        /// <summary>
        /// Error message displayed if the user enters too long Accent2.
        /// </summary>
        /// <value>Accent2 value is too long. Maximum allowed is 255 characters.</value>
        [ResourceEntry("PaletteItemAccent2InvalidLength",
            Value = "Accent2 value is too long. Maximum allowed is 255 characters.",
            Description = "Error message displayed if the user enters too long Accent2.",
            LastModified = "2014/08/04")]
        public string PaletteItemAccent2InvalidLength
        {
            get
            {
                return this["PaletteItemAccent2InvalidLength"];
            }
        }

        /// <summary>
        /// PaletteItem Accent3.
        /// </summary>
        /// <value>Accent3</value>
        [ResourceEntry("PaletteItemAccent3Label",
            Value = "Accent3",
            Description = "PaletteItem Accent3.",
            LastModified = "2014/08/04")]
        public string PaletteItemAccent3Label
        {
            get
            {
                return this["PaletteItemAccent3Label"];
            }
        }

        /// <summary>
        /// Error message displayed if the user enters too long Accent3.
        /// </summary>
        /// <value>Accent3 value is too long. Maximum allowed is 255 characters.</value>
        [ResourceEntry("PaletteItemAccent3InvalidLength",
            Value = "Accent3 value is too long. Maximum allowed is 255 characters.",
            Description = "Error message displayed if the user enters too long Accent3.",
            LastModified = "2014/08/04")]
        public string PaletteItemAccent3InvalidLength
        {
            get
            {
                return this["PaletteItemAccent3InvalidLength"];
            }
        }

        /// <summary>
        /// PaletteItem Accent4.
        /// </summary>
        /// <value>Accent4</value>
        [ResourceEntry("PaletteItemAccent4Label",
            Value = "Accent4",
            Description = "PaletteItem Accent4.",
            LastModified = "2014/08/04")]
        public string PaletteItemAccent4Label
        {
            get
            {
                return this["PaletteItemAccent4Label"];
            }
        }

        /// <summary>
        /// Error message displayed if the user enters too long Accent4.
        /// </summary>
        /// <value>Accent4 value is too long. Maximum allowed is 255 characters.</value>
        [ResourceEntry("PaletteItemAccent4InvalidLength",
            Value = "Accent4 value is too long. Maximum allowed is 255 characters.",
            Description = "Error message displayed if the user enters too long Accent4.",
            LastModified = "2014/08/04")]
        public string PaletteItemAccent4InvalidLength
        {
            get
            {
                return this["PaletteItemAccent4InvalidLength"];
            }
        }

        /// <summary>
        /// PaletteItem Accent5.
        /// </summary>
        /// <value>Accent5</value>
        [ResourceEntry("PaletteItemAccent5Label",
            Value = "Accent5",
            Description = "PaletteItem Accent5.",
            LastModified = "2014/08/04")]
        public string PaletteItemAccent5Label
        {
            get
            {
                return this["PaletteItemAccent5Label"];
            }
        }

        /// <summary>
        /// Error message displayed if the user enters too long Accent5.
        /// </summary>
        /// <value>Accent5 value is too long. Maximum allowed is 255 characters.</value>
        [ResourceEntry("PaletteItemAccent5InvalidLength",
            Value = "Accent5 value is too long. Maximum allowed is 255 characters.",
            Description = "Error message displayed if the user enters too long Accent5.",
            LastModified = "2014/08/04")]
        public string PaletteItemAccent5InvalidLength
        {
            get
            {
                return this["PaletteItemAccent5InvalidLength"];
            }
        }

        /// <summary>
        /// PaletteItem Accent6.
        /// </summary>
        /// <value>Accent6</value>
        [ResourceEntry("PaletteItemAccent6Label",
            Value = "Accent6",
            Description = "PaletteItem Accent6.",
            LastModified = "2014/08/04")]
        public string PaletteItemAccent6Label
        {
            get
            {
                return this["PaletteItemAccent6Label"];
            }
        }

        /// <summary>
        /// Error message displayed if the user enters too long Accent6.
        /// </summary>
        /// <value>Accent6 value is too long. Maximum allowed is 255 characters.</value>
        [ResourceEntry("PaletteItemAccent6InvalidLength",
            Value = "Accent6 value is too long. Maximum allowed is 255 characters.",
            Description = "Error message displayed if the user enters too long Accent6.",
            LastModified = "2014/08/04")]
        public string PaletteItemAccent6InvalidLength
        {
            get
            {
                return this["PaletteItemAccent6InvalidLength"];
            }
        }

        /// <summary>
        /// PaletteItem Hyperlink.
        /// </summary>
        /// <value>Hyperlink</value>
        [ResourceEntry("PaletteItemHyperlinkLabel",
            Value = "Hyperlink",
            Description = "PaletteItem Hyperlink.",
            LastModified = "2014/08/04")]
        public string PaletteItemHyperlinkLabel
        {
            get
            {
                return this["PaletteItemHyperlinkLabel"];
            }
        }

        /// <summary>
        /// Error message displayed if the user enters too long Hyperlink.
        /// </summary>
        /// <value>Hyperlink value is too long. Maximum allowed is 255 characters.</value>
        [ResourceEntry("PaletteItemHyperlinkInvalidLength",
            Value = "Hyperlink value is too long. Maximum allowed is 255 characters.",
            Description = "Error message displayed if the user enters too long Hyperlink.",
            LastModified = "2014/08/04")]
        public string PaletteItemHyperlinkInvalidLength
        {
            get
            {
                return this["PaletteItemHyperlinkInvalidLength"];
            }
        }

        /// <summary>
        /// PaletteItem FollowedHyperlink.
        /// </summary>
        /// <value>FollowedHyperlink</value>
        [ResourceEntry("PaletteItemFollowedHyperlinkLabel",
            Value = "FollowedHyperlink",
            Description = "PaletteItem FollowedHyperlink.",
            LastModified = "2014/08/04")]
        public string PaletteItemFollowedHyperlinkLabel
        {
            get
            {
                return this["PaletteItemFollowedHyperlinkLabel"];
            }
        }

        /// <summary>
        /// Error message displayed if the user enters too long FollowedHyperlink.
        /// </summary>
        /// <value>FollowedHyperlink value is too long. Maximum allowed is 255 characters.</value>
        [ResourceEntry("PaletteItemFollowedHyperlinkInvalidLength",
            Value = "FollowedHyperlink value is too long. Maximum allowed is 255 characters.",
            Description = "Error message displayed if the user enters too long FollowedHyperlink.",
            LastModified = "2014/08/04")]
        public string PaletteItemFollowedHyperlinkInvalidLength
        {
            get
            {
                return this["PaletteItemFollowedHyperlinkInvalidLength"];
            }
        }

        /// <summary>
        /// Message displayed to user when deleting a user paletteItem.
        /// </summary>
        [ResourceEntry("DeletePaletteItemConfirmationMessage",
            Value = "Are you sure you want to delete this paletteItem?",
            Description = "Message displayed to user when deleting a user paletteItem.",
            LastModified = "2014/08/04")]
        public string DeletePaletteItemConfirmationMessage
        {
            get
            {
                return this["DeletePaletteItemConfirmationMessage"];
            }
        }

        /// <summary>
        /// phrase: Create this paletteItem
        /// </summary>
        [ResourceEntry("CreateThisPaletteItemButton",
            Value = "Create this paletteItem",
            Description = "phrase: Create this paletteItem",
            LastModified = "2014/08/04")]
        public string CreateThisPaletteItemButton
        {
            get
            {
                return this["CreateThisPaletteItemButton"];
            }
        }

        /// <summary>
        /// The URL name of PaletteItem's page.
        /// </summary>
        /// <value>PaletteItemMasterPageUrl</value>
        [ResourceEntry("PaletteItemMasterPageUrl",
            Value = "PaletteItemMasterPageUrl",
            Description = "The URL name of PaletteItem's page.",
            LastModified = "2014/08/04")]
        public string PaletteItemMasterPageUrl
        {
            get
            {
                return this["PaletteItemMasterPageUrl"];
            }
        }
        #endregion
    }
}