using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data.Metadata;
using Telerik.Sitefinity.Metadata.Model;
using Telerik.Sitefinity.ModuleEditor.Web.Services.Model;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.Web.UI.ContentUI.Config;
using Telerik.Sitefinity.Web.UI.ContentUI.Views.Backend.Detail;
using Telerik.Sitefinity.Web.UI.ContentUI.Views.Backend.Master.Config;
using Telerik.Sitefinity.Web.UI.Fields.Config;

namespace PaletteModule
{
    public class ModuleHelper
    {
        public static void RegisterGuidArrayFieldSelectorForPages<C>(string fieldName) where C : FieldControlDefinitionElement
        {
            RegisterPageNodeDynamicData();
            string itemType = typeof(PageNode).FullName;
            var fieldExists = GetMetaFieldsForType(itemType).Where(f => f.FieldName == fieldName).SingleOrDefault() != null;
            if (!fieldExists)
            {
                var metaManager = MetadataManager.GetManager(); 
                var field = metaManager.CreateMetafield(fieldName); 
                field.FieldName = fieldName; 
                field.Title = fieldName; 
                field.Hidden = false;
                field.DBType = "VARCHAR(3000)";
                field.ClrType = typeof(System.Guid[]).FullName; 
                var metaType2 = metaManager.GetMetaType(typeof(PageNode)); 
                metaType2.Fields.Add(field); 
                metaManager.SaveChanges();
                var manager = ConfigManager.GetManager(); 
                manager.Provider.SuppressSecurityChecks = true;
                var section = manager.GetSection<ContentViewConfig>(); 
                var backendSection = section.ContentViewControls[PagesDefinitions.BackendPagesDefinitionName]; 
                var views = backendSection.ViewsConfig.Values.Where(v => v.ViewType == typeof(DetailFormView));
                foreach (DetailFormViewElement view in views)
                {
                    var sectionToInsert = CustomFieldsContext.GetSection(view, CustomFieldsContext.customFieldsSectionName, itemType);
                    var fieldConfigElementType = TypeResolutionService.ResolveType(typeof(C).FullName); 
                    C newElement; 
                    newElement = Activator.CreateInstance(fieldConfigElementType, new object[] { sectionToInsert.Fields }) as C;
                    newElement.DataFieldName = "CustomFields." + fieldName;//newElement.DataFieldName = "Attributes." + fieldName; // Use this line instead if its Sitefinity 6.3. newElement.FieldName = fieldName; newElement.Title = fieldName; newElement.DisplayMode = FieldDisplayMode.Write; newElement.Hidden = false;
                    sectionToInsert.Fields.Add(newElement);
                }
                var frontendSection = section.ContentViewControls[PagesDefinitions.FrontendPagesDefinitionName]; 
                views = frontendSection.ViewsConfig.Values.Where(v => v.ViewType == typeof(DetailFormView));
                foreach (DetailFormViewElement view in views)
                {
                    var sectionToInsert = CustomFieldsContext.GetSection(view, CustomFieldsContext.customFieldsSectionName, itemType);
                    var fieldConfigElementType = TypeResolutionService.ResolveType(typeof(C).FullName); 
                    C newElement; 
                    newElement = Activator.CreateInstance(fieldConfigElementType, new object[] { sectionToInsert.Fields }) as C;
                    newElement.DataFieldName = "CustomFields." + fieldName;
                    //newElement.DataFieldName = "Attributes." + fieldName; // Use this line instead if its Sitefinity 6.3. newElement.FieldName = fieldName; newElement.Title = fieldName; newElement.DisplayMode = FieldDisplayMode.Write; newElement.Hidden = false;
                    sectionToInsert.Fields.Add(newElement);
                }
                manager.SaveSection(section); 
                manager.Provider.SuppressSecurityChecks = false;
                RestartApplication();
            }
        }

        private static void RegisterPageNodeDynamicData()
        {
            var pageNodeType = App.WorkWith().DynamicData().Types().Where(s => s.ClassName == "PageNode").Get().FirstOrDefault();
            if (pageNodeType != null)
                return;
            App.WorkWith().DynamicData().Type().CreateNew("PageNode", "Telerik.Sitefinity.Pages.Model").Do(dt => dt.DatabaseInheritance = DatabaseInheritanceType.vertical).SaveChanges(true);
        }

        private static IList<MetaField> GetMetaFieldsForType(string type)
        {
            var existingType = TypeResolutionService.ResolveType(type); 
            var existingClassName = existingType.Name; 
            var existingNamespace = existingType.Namespace; 
            var mgr = MetadataManager.GetManager();
            var types = mgr.GetMetaTypes().FirstOrDefault(dt => dt.ClassName == existingClassName && dt.Namespace == existingNamespace);
            var fields = types != null ? types.Fields : new List<MetaField>();
            return fields;
        }

        private static void RestartApplication()
        {
            if (SystemManager.Initializing)
                return;
            SystemManager.RestartApplication(true, true);
        }
    }
}
