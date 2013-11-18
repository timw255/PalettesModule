using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web.UI.ContentUI.Config;
using Telerik.Sitefinity.Configuration;
using PalettesModule.Model;
using Telerik.Sitefinity.Web.UI.ContentUI.Views.Backend.Master.Config;
using Telerik.Sitefinity.Web.UI.Backend.Elements.Config;
using Telerik.Sitefinity.Web.UI.Backend.Elements.Enums;
using Telerik.Sitefinity.Modules;
using Telerik.Sitefinity.Web.UI.Backend.Elements.Widgets;
using Telerik.Sitefinity.Web.UI.ContentUI.Views.Backend.Detail;
using Telerik.Sitefinity.Web.UI.Fields.Enums;
using System.Web.UI;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Web.UI.Fields.Config;
using Telerik.Sitefinity.Web.UI.Validation.Config;
using Telerik.Web.UI;
using Telerik.Sitefinity.Web.UI.ContentUI.Views.Backend.Master;
using PalettesModule.Fields;

namespace PalettesModule.Web.UI
{
	public class PalettesDefinitions
	{
		#region Constructors

		/// <summary>
		/// Static constructor that makes it impossible to use the definitions
		/// without the module 
		/// </summary>
		static PalettesDefinitions()
		{
			SystemManager.GetApplicationModule(PalettesModule.ModuleName);
		}

		#endregion

		#region Backend ContentView

		/// <summary>
		/// Defines the palettes backend content view (control panel and views).
		/// </summary>
		/// <param name="parent">The parent element hosting the backend content view.</param>
		/// <returns></returns>
		public static ContentViewControlElement DefinePalettesBackendContentView(ConfigElement parent)
		{
			// initialize the content view; this is the element that will be returned to the page and holds all views of the admin panel
			var backendContentView = new ContentViewControlElement(parent)
			{
				ControlDefinitionName = BackendDefinitionName,
				ContentType = typeof(PaletteItem),
				UseWorkflow = false
			};

			// GridView element serves as the "List View" for the item list. Grid columns are defined later
			var palettesGridView = new MasterGridViewElement(backendContentView.ViewsConfig)
			{
				ViewName = PalettesDefinitions.BackendListViewName,
				ViewType = typeof(MasterGridView),
				AllowPaging = true,
				DisplayMode = FieldDisplayMode.Read,
				ItemsPerPage = 50,
				SearchFields = "Title",
				SortExpression = "Title ASC",
				Title = "Palettes",
				WebServiceBaseUrl = "~/Sitefinity/Services/Content/Palettes.svc/"
			};
			backendContentView.ViewsConfig.Add(palettesGridView);

			#region Module Main Toolbar definition

			// Toolbar is the top menu with action buttons such as Create, Delete, Search, etc.
			var masterViewToolbarSection = new WidgetBarSectionElement(palettesGridView.ToolbarConfig.Sections)
			{
				Name = "Toolbar"
			};

			// "Create" Button for Toolbar
			var createPalettesWidget = new CommandWidgetElement(masterViewToolbarSection.Items)
			{
				Name = "CreatePalettesCommandWidget",
				ButtonType = CommandButtonType.Create,
				CommandName = DefinitionsHelper.CreateCommandName,
				Text = "Create Palette",
				CssClass = "sfMainAction",
				WidgetType = typeof(CommandWidget)
			};
			masterViewToolbarSection.Items.Add(createPalettesWidget);

			// "Delete" button for Toolbar
			var deletePalettesWidget = new CommandWidgetElement(masterViewToolbarSection.Items)
			{
				Name = "DeletePalettesCommandWidget",
				ButtonType = CommandButtonType.Standard,
				CommandName = DefinitionsHelper.GroupDeleteCommandName,
				Text = "Delete",
				WidgetType = typeof(CommandWidget),
				CssClass = "sfGroupBtn"
			};
			masterViewToolbarSection.Items.Add(deletePalettesWidget);

			// "Search" button for toolbar
			masterViewToolbarSection.Items.Add(DefinitionsHelper.CreateSearchButtonWidget(masterViewToolbarSection.Items, typeof(PaletteItem)));
			palettesGridView.ToolbarConfig.Sections.Add(masterViewToolbarSection);

			#endregion

			#region Palettes Grid (List View)

			// Define GridView mode
			var gridMode = new GridViewModeElement(palettesGridView.ViewModesConfig)
			{
				Name = "Grid"
			};
			palettesGridView.ViewModesConfig.Add(gridMode);

			#region Palettes Grid Columns

			// Title column
			DataColumnElement titleColumn = new DataColumnElement(gridMode.ColumnsConfig)
			{
				Name = "Title",
				HeaderText = "Title",
				HeaderCssClass = "sfTitleCol",
				ItemCssClass = "sfTitleCol",
				ClientTemplate = @"<a sys:href='javascript:void(0);' sys:class=""{{ 'sf_binderCommand_edit sfItemTitle sfpublished"">
					<strong>{{Title}}</strong></a>"
			};
			gridMode.ColumnsConfig.Add(titleColumn);

			ActionMenuColumnElement actionsColumn = new ActionMenuColumnElement(gridMode.ColumnsConfig)
			{
				Name = "Actions",
				HeaderText = "Actions",
				HeaderCssClass = "sfMoreActions",
				ItemCssClass = "sfMoreActions"
			};
			actionsColumn.MenuItems.Add(DefinitionsHelper.CreateActionMenuCommand(actionsColumn.MenuItems, "Delete", HtmlTextWriterTag.Li, "delete", "Delete", string.Empty));

			gridMode.ColumnsConfig.Add(actionsColumn);

			#endregion

			#endregion

			#region Dialog Window definitions

			#region Insert Item Dialog

			// Insert Item Parameters
			var parameters = string.Concat(
				"?ControlDefinitionName=",
				PalettesDefinitions.BackendDefinitionName,
				"&ViewName=",
				PalettesDefinitions.BackendInsertViewName);

			// Insert Item Dialog
			DialogElement createDialogElement = DefinitionsHelper.CreateDialogElement(
				palettesGridView.DialogsConfig,
				DefinitionsHelper.CreateCommandName,
				"ContentViewInsertDialog",
				parameters);

			// add dialog to Backend
			palettesGridView.DialogsConfig.Add(createDialogElement);

			#endregion

			#region Edit Item Dialog

			// "Edit Item" Parameters
			parameters = string.Concat(
				"?ControlDefinitionName=",
				PalettesDefinitions.BackendDefinitionName,
				"&ViewName=",
				PalettesDefinitions.BackendEditViewName);

			// "Edit Item" Dialog
			DialogElement editDialogElement = DefinitionsHelper.CreateDialogElement(
				palettesGridView.DialogsConfig,
				DefinitionsHelper.EditCommandName,
				"ContentViewEditDialog",
				parameters);

			// Add Dialog to Backend
			palettesGridView.DialogsConfig.Add(editDialogElement);

			#endregion

			#region Preview Item Dialog

            //// "Preview Item" parameters
            //parameters = string.Concat(
            //    "?ControlDefinitionName=",
            //    PalettesDefinitions.BackendDefinitionName,
            //    "&ViewName=",
            //    PalettesDefinitions.BackendPreviewName,
            //    "&backLabelText=", "BacktoItems", "&SuppressBackToButtonLabelModify=true");

            //// Preview Item Dialog
            //DialogElement previewDialogElement = DefinitionsHelper.CreateDialogElement(
            //    palettesGridView.DialogsConfig,
            //    DefinitionsHelper.PreviewCommandName,
            //    "ContentViewEditDialog",
            //    parameters);

            //// Add Dialog to Backend
            //palettesGridView.DialogsConfig.Add(previewDialogElement);

			#endregion

			#endregion

			#region Admin Forms Views

			#region Create Item Form View

			// bind create item view to web service
			var palettesInsertDetailView = new DetailFormViewElement(backendContentView.ViewsConfig)
			{
				Title = "Create Palette",
				ViewName = PalettesDefinitions.BackendInsertViewName,
				ViewType = typeof(DetailFormView),
				ShowSections = true,
				DisplayMode = FieldDisplayMode.Write,
				ShowTopToolbar = true,
				WebServiceBaseUrl = "~/Sitefinity/Services/Content/palettes.svc/",
				IsToRenderTranslationView = false,
				UseWorkflow = false
			};

			backendContentView.ViewsConfig.Add(palettesInsertDetailView);

			#endregion

			#region Edit Item Form View

			// bind Edit item form to web service
			var palettesEditDetailView = new DetailFormViewElement(backendContentView.ViewsConfig)
			{
				Title = "Edit Palette",
				ViewName = PalettesDefinitions.BackendEditViewName,
				ViewType = typeof(DetailFormView),
				ShowSections = true,
				DisplayMode = FieldDisplayMode.Write,
				ShowTopToolbar = true,
				WebServiceBaseUrl = "~/Sitefinity/Services/Content/Palettes.svc/",
				IsToRenderTranslationView = false,
				UseWorkflow = false
			};

			backendContentView.ViewsConfig.Add(palettesEditDetailView);

			#endregion

			#region Preview Item Form View

            //// bind Preview Form to web service
            //var palettesPreviewDetailView = new DetailFormViewElement(backendContentView.ViewsConfig)
            //{
            //    Title = "Palette Preview",
            //    ViewName = PalettesDefinitions.BackendPreviewName,
            //    ViewType = typeof(DetailFormView),
            //    ShowSections = true,
            //    DisplayMode = FieldDisplayMode.Read,
            //    ShowTopToolbar = true,
            //    ShowNavigation = true,
            //    WebServiceBaseUrl = "~/Sitefinity/Services/Content/Palettes.svc/",
            //    UseWorkflow = false
            //};

            //backendContentView.ViewsConfig.Add(palettesPreviewDetailView);

			#endregion

			#endregion

			#region Palettes Backend Forms Definition

			#region Insert Form

			PalettesDefinitions.CreateBackendSections(palettesInsertDetailView, FieldDisplayMode.Write);
			PalettesDefinitions.CreateBackendFormToolbar(palettesInsertDetailView, true, false);

			#endregion

			#region Edit Form

			PalettesDefinitions.CreateBackendSections(palettesEditDetailView, FieldDisplayMode.Write);
			PalettesDefinitions.CreateBackendFormToolbar(palettesEditDetailView, false, false);

			#endregion

			#region Preview Form

			//CreateBackendSections(palettesPreviewDetailView, FieldDisplayMode.Read);

			#endregion

			#endregion

			return backendContentView;
		}

		#region Backend Form Toolbar

		/// <summary>
		/// Creates the backend form toolbar.
		/// </summary>
		/// <param name="detailView">The detail view.</param>
		/// <param name="resourceClassId">The resource class id.</param>
		/// <param name="isCreateMode">if set to <c>true</c> [is create mode].</param>
		/// <param name="itemName">Name of the item.</param>
		/// <param name="addRevisionHistory">if set to <c>true</c> [add revision history].</param>
		/// <param name="showPreview">if set to <c>true</c> [show preview].</param>
		/// <param name="backToItems">The back to items.</param>
		private static void CreateBackendFormToolbar(DetailFormViewElement detailView, bool isCreateMode, bool showPreview)
		{
			// create toolbar
			var toolbarSectionElement = new WidgetBarSectionElement(detailView.Toolbar.Sections)
			{
				Name = "BackendForm",
				WrapperTagKey = HtmlTextWriterTag.Div,
				CssClass = "sfWorkflowMenuWrp"
			};

			// Create / Save Command
			toolbarSectionElement.Items.Add(new CommandWidgetElement(toolbarSectionElement.Items)
			{
				Name = "SaveChangesWidgetElement",
				ButtonType = CommandButtonType.Save,
				CommandName = DefinitionsHelper.SaveCommandName,
				Text = (isCreateMode) ? String.Concat("Create Palette") : "Save Changes",
				WrapperTagKey = HtmlTextWriterTag.Span,
				WidgetType = typeof(CommandWidget)
			});

            //// Preview
            //if (showPreview == true)
            //{
            //    toolbarSectionElement.Items.Add(new CommandWidgetElement(toolbarSectionElement.Items)
            //    {
            //        Name = "PreviewWidgetElement",
            //        ButtonType = CommandButtonType.Standard,
            //        CommandName = DefinitionsHelper.PreviewCommandName,
            //        Text = "Preview",
            //        ResourceClassId = typeof(Labels).Name,
            //        WrapperTagKey = HtmlTextWriterTag.Span,
            //        WidgetType = typeof(CommandWidget)
            //    });
            //}

			// show Actions menu
			if (!isCreateMode)
			{
				var actionsMenuWidget = new ActionMenuWidgetElement(toolbarSectionElement.Items)
				{
					Name = "moreActions",
					Text = Res.Get<Labels>().MoreActionsLink,
					WrapperTagKey = HtmlTextWriterTag.Div,
					WidgetType = typeof(ActionMenuWidget),
					CssClass = "sfInlineBlock sfAlignMiddle"
				};
				actionsMenuWidget.MenuItems.Add(new CommandWidgetElement(actionsMenuWidget.MenuItems)
				{
					Name = "DeleteCommand",
					Text = "Delete",
					CommandName = DefinitionsHelper.DeleteCommandName,
					WidgetType = typeof(CommandWidget),
					CssClass = "sfDeleteItm"
				});

				toolbarSectionElement.Items.Add(actionsMenuWidget);
			}

			// Cancel button
			toolbarSectionElement.Items.Add(new CommandWidgetElement(toolbarSectionElement.Items)
			{
				Name = "CancelWidgetElement",
				ButtonType = CommandButtonType.Cancel,
				CommandName = DefinitionsHelper.CancelCommandName,
				Text = "Back to Palettes List",
				WrapperTagKey = HtmlTextWriterTag.Span,
				WidgetType = typeof(CommandWidget)
			});


			detailView.Toolbar.Sections.Add(toolbarSectionElement);
		}

		#endregion

		#region Backend Section Forms

		/// <summary>
		/// Creates the backend sections. Adds edit/preview controls to the detailView
		/// </summary>
		/// <param name="detailView">The detail view.</param>
		/// <param name="displayMode">The display mode.</param>
		private static void CreateBackendSections(DetailFormViewElement detailView, FieldDisplayMode displayMode)
		{
			// define main content section
			var mainSection = new ContentViewSectionElement(detailView.Sections)
			{
				Name = "MainSection",
				CssClass = "sfFirstForm"
			};

			#region Title Field

			// define title field element
			var titleField = new TextFieldDefinitionElement(mainSection.Fields)
			{
				ID = "titleFieldControl",
				DataFieldName = displayMode == FieldDisplayMode.Write ? "Title.PersistedValue" : "Title",
				DisplayMode = displayMode,
				Title = "Title",
				CssClass = "sfTitleField",
				WrapperTag = HtmlTextWriterTag.Li,
			};

			// add validation
			titleField.ValidatorConfig = new ValidatorDefinitionElement(titleField)
			{
				Required = true,
				MessageCssClass = "sfError",
				RequiredViolationMessage = "Title field is required"
			};

			// add field to section
			mainSection.Fields.Add(titleField);

			#endregion

			#region Color fields

            var dark1Field = new ColorFieldDefinitionElement(mainSection.Fields)
            {
                ID = "dark1FieldControl",
                DataFieldName = "Dark1",
                DisplayMode = displayMode,
                Title = "Text/Background - Dark 1",
                CssClass = "sfColorField",
                WrapperTag = HtmlTextWriterTag.Li
            };
            dark1Field.ValidatorConfig = new ValidatorDefinitionElement(dark1Field)
            {
                Required = true,
                MessageCssClass = "sfError",
                RequiredViolationMessage = "Text/Background - Dark 1 is required"
            };
            mainSection.Fields.Add(dark1Field);

            var light1Field = new ColorFieldDefinitionElement(mainSection.Fields)
            {
                ID = "light1FieldControl",
                DataFieldName = "Light1",
                DisplayMode = displayMode,
                Title = "Text/Background - Light 1",
                CssClass = "sfColorField",
                WrapperTag = HtmlTextWriterTag.Li
            };
            light1Field.ValidatorConfig = new ValidatorDefinitionElement(light1Field)
            {
                Required = true,
                MessageCssClass = "sfError",
                RequiredViolationMessage = "Text/Background - Light 1 is required"
            };
            mainSection.Fields.Add(light1Field);

            var dark2Field = new ColorFieldDefinitionElement(mainSection.Fields)
            {
                ID = "dark2FieldControl",
                DataFieldName = "Dark2",
                DisplayMode = displayMode,
                Title = "Text/Background - Dark 2",
                CssClass = "sfColorField",
                WrapperTag = HtmlTextWriterTag.Li
            };
            dark2Field.ValidatorConfig = new ValidatorDefinitionElement(dark2Field)
            {
                Required = true,
                MessageCssClass = "sfError",
                RequiredViolationMessage = "Text/Background - Dark 2 is required"
            };
            mainSection.Fields.Add(dark2Field);

            var light2Field = new ColorFieldDefinitionElement(mainSection.Fields)
            {
                ID = "light2FieldControl",
                DataFieldName = "Light2",
                DisplayMode = displayMode,
                Title = "Text/Background - Light 2",
                CssClass = "sfColorField",
                WrapperTag = HtmlTextWriterTag.Li
            };
            light2Field.ValidatorConfig = new ValidatorDefinitionElement(light2Field)
            {
                Required = true,
                MessageCssClass = "sfError",
                RequiredViolationMessage = "Text/Background - Light 2 is required"
            };
            mainSection.Fields.Add(light2Field);

            // accent colors

            var accent1Field = new ColorFieldDefinitionElement(mainSection.Fields)
            {
                ID = "accent1FieldControl",
                DataFieldName = "Accent1",
                DisplayMode = displayMode,
                Title = "Accent 1",
                CssClass = "sfColorField",
                WrapperTag = HtmlTextWriterTag.Li
            };
            accent1Field.ValidatorConfig = new ValidatorDefinitionElement(accent1Field)
            {
                Required = true,
                MessageCssClass = "sfError",
                RequiredViolationMessage = "Accent 1 is required"
            };
            mainSection.Fields.Add(accent1Field);

            var accent2Field = new ColorFieldDefinitionElement(mainSection.Fields)
            {
                ID = "accent2FieldControl",
                DataFieldName = "Accent2",
                DisplayMode = displayMode,
                Title = "Accent 2",
                CssClass = "sfColorField",
                WrapperTag = HtmlTextWriterTag.Li
            };
            accent2Field.ValidatorConfig = new ValidatorDefinitionElement(accent2Field)
            {
                Required = true,
                MessageCssClass = "sfError",
                RequiredViolationMessage = "Accent 2 is required"
            };
            mainSection.Fields.Add(accent2Field);

            var accent3Field = new ColorFieldDefinitionElement(mainSection.Fields)
            {
                ID = "accent3FieldControl",
                DataFieldName = "Accent3",
                DisplayMode = displayMode,
                Title = "Accent 3",
                CssClass = "sfColorField",
                WrapperTag = HtmlTextWriterTag.Li
            };
            accent3Field.ValidatorConfig = new ValidatorDefinitionElement(accent3Field)
            {
                Required = true,
                MessageCssClass = "sfError",
                RequiredViolationMessage = "Accent 3 is required"
            };
            mainSection.Fields.Add(accent3Field);

            var accent4Field = new ColorFieldDefinitionElement(mainSection.Fields)
            {
                ID = "accent4FieldControl",
                DataFieldName = "Accent4",
                DisplayMode = displayMode,
                Title = "Accent 4",
                CssClass = "sfColorField",
                WrapperTag = HtmlTextWriterTag.Li
            };
            accent4Field.ValidatorConfig = new ValidatorDefinitionElement(accent4Field)
            {
                Required = true,
                MessageCssClass = "sfError",
                RequiredViolationMessage = "Accent 4 is required"
            };
            mainSection.Fields.Add(accent4Field);

            var accent5Field = new ColorFieldDefinitionElement(mainSection.Fields)
            {
                ID = "accent5FieldControl",
                DataFieldName = "Accent5",
                DisplayMode = displayMode,
                Title = "Accent 5",
                CssClass = "sfColorField",
                WrapperTag = HtmlTextWriterTag.Li
            };
            accent5Field.ValidatorConfig = new ValidatorDefinitionElement(accent5Field)
            {
                Required = true,
                MessageCssClass = "sfError",
                RequiredViolationMessage = "Accent 5 is required"
            };
            mainSection.Fields.Add(accent5Field);

            var accent6Field = new ColorFieldDefinitionElement(mainSection.Fields)
            {
                ID = "accent6FieldControl",
                DataFieldName = "Accent6",
                DisplayMode = displayMode,
                Title = "Accent 6",
                CssClass = "sfColorField",
                WrapperTag = HtmlTextWriterTag.Li
            };
            accent6Field.ValidatorConfig = new ValidatorDefinitionElement(accent6Field)
            {
                Required = true,
                MessageCssClass = "sfError",
                RequiredViolationMessage = "Accent 6 is required"
            };
            mainSection.Fields.Add(accent6Field);

            var hyperlinkField = new ColorFieldDefinitionElement(mainSection.Fields)
            {
                ID = "hyperlinkFieldControl",
                DataFieldName = "Hyperlink",
                DisplayMode = displayMode,
                Title = "Hyperlink",
                CssClass = "sfColorField",
                WrapperTag = HtmlTextWriterTag.Li
            };
            hyperlinkField.ValidatorConfig = new ValidatorDefinitionElement(hyperlinkField)
            {
                Required = true,
                MessageCssClass = "sfError",
                RequiredViolationMessage = "Hyperlink is required"
            };
            mainSection.Fields.Add(hyperlinkField);

            var followedHyperlinkField = new ColorFieldDefinitionElement(mainSection.Fields)
            {
                ID = "followedHyperlinkFieldControl",
                DataFieldName = "FollowedHyperlink",
                DisplayMode = displayMode,
                Title = "Followed Hyperlink",
                CssClass = "sfColorField",
                WrapperTag = HtmlTextWriterTag.Li
            };
            followedHyperlinkField.ValidatorConfig = new ValidatorDefinitionElement(followedHyperlinkField)
            {
                Required = true,
                MessageCssClass = "sfError",
                RequiredViolationMessage = "Followed Hyperlink is required"
            };
            mainSection.Fields.Add(followedHyperlinkField);

			// add section to view
			detailView.Sections.Add(mainSection);

			#endregion
		}

		#endregion

		#endregion

		#region Frontend ContentView

		/// <summary>
		/// Defines the ContentView control for News on the frontend
		/// </summary>
		/// <param name="parent">The parent configuration element.</param>
		/// <returns>A configured instance of <see cref="ContentViewControlElement"/>.</returns>
        //internal static ContentViewControlElement DefinePalettesFrontendContentView(ConfigElement parent)
        //{
        //    // define content view control
        //    var controlDefinition = new ContentViewControlElement(parent)
        //    {
        //        ControlDefinitionName = PalettesDefinitions.FrontendDefinitionName,
        //        ContentType = typeof(PaletteItem),
        //        UseWorkflow = false
        //    };

        //    // *** define views ***

        //    #region Palettes List View

        //    // define element
        //    var palettesListView = new ContentViewMasterElement(controlDefinition.ViewsConfig)
        //    {
        //        ViewName = PalettesDefinitions.FrontendListViewName,
        //        ViewType = typeof(MasterListView),
        //        AllowPaging = true,
        //        DisplayMode = FieldDisplayMode.Read,
        //        ItemsPerPage = 4,
        //        FilterExpression = DefinitionsHelper.NotPublishedDraftsFilterExpression,
        //        SortExpression = "Title ASC",
        //        UseWorkflow = false
        //    };

        //    // add to content view
        //    controlDefinition.ViewsConfig.Add(palettesListView);

        //    #endregion

        //    #region Palettes Details View

        //    // Initialize View
        //    var palettesDetailsView = new ContentViewDetailElement(controlDefinition.ViewsConfig)
        //    {
        //        ViewName = PalettesDefinitions.FrontendDetailViewName,
        //        ViewType = typeof(DetailsView),
        //        ShowSections = false,
        //        DisplayMode = FieldDisplayMode.Read
        //    };

        //    // add to ContentView
        //    controlDefinition.ViewsConfig.Add(palettesDetailsView);

        //    #endregion

        //    // return content view control
        //    return controlDefinition;
        //}

		#endregion

		#region Constants

		public const string BackendDefinitionName = "PalettesBackend";
		public const string BackendListViewName = "PalettesBackendListView";
		public const string BackendInsertViewName = "PalettesBackendInsertView";
		public const string BackendEditViewName = "PalettesBackendEditView";
		public const string BackendPreviewName = "PalettesBackendPreview";

		//public const string FrontendDefinitionName = "PalettesFrontend";
		//public const string FrontendListViewName = "PalettesFrontendListView";
		//public const string FrontendDetailViewName = "PalettesDetailView";

		/// <summary>
		/// Name of the view that displays only titles
		/// </summary>
		//public const string FrontendDefaultListViewName = "List palettes";
		//public const string FrontendDefaultDetailViewName = "Full palette";

		#endregion
	}
}
