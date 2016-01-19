using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using PaletteModule;
using PaletteModule.Web.UI.PaletteItems;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("PaletteModule")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("PaletteModule")]
[assembly: AssemblyCopyright("Copyright ©  2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Registers PaletteModuleInstaller.PreApplicationStart() to be executed prior to the application start
[assembly: PreApplicationStartMethod(typeof(PaletteModuleInstaller), "PreApplicationStart")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("eb7375d4-8d18-4afe-a69e-17060bf7972d")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.5.0.0")]
[assembly: AssemblyFileVersion("1.5.0.0")]

[assembly: WebResource(PaletteItemsPage.PaletteItemsPageScript, "application/x-javascript")]
[assembly: WebResource(PaletteItemsPage.PaletteItemsMasterScript, "application/x-javascript")]
[assembly: WebResource(PaletteItemsPage.PaletteItemsDetailScript, "application/x-javascript")]

[assembly: WebResource("PaletteModule.Web.Resources.CustomStylesKendoUIView.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("PaletteModule.Web.Resources.paging.png", "image/gif")]
