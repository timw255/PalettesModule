using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.Kendo;

namespace PaletteModule.Web.UI.PaletteItems
{
    /// <summary>
    /// Container for all the user interface of the PaletteModule module.
    /// </summary>
    public class PaletteItemsPage : KendoView
    {
        #region Properties
        /// <summary>
        /// Obsolete. Use LayoutTemplatePath instead.
        /// </summary>
        protected override string LayoutTemplateName
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the layout template's relative or virtual path.
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                if (string.IsNullOrEmpty(base.LayoutTemplatePath))
                    base.LayoutTemplatePath = PaletteItemsPage.layoutTemplatePath;
                return base.LayoutTemplatePath;
            }
            set
            {
                base.LayoutTemplatePath = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="T:System.Web.UI.HtmlTextWriterTag" /> value that
        /// corresponds to this Web server control. This property is used primarily by control
        /// developers.
        /// </summary>
        /// <returns>One of the <see cref="T:System.Web.UI.HtmlTextWriterTag" /> enumeration values.</returns>
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                //we use div wrapper tag to make easier common styling
                return HtmlTextWriterTag.Div;
            }
        }
        #endregion

        #region Control references
        #endregion

        #region Public and overriden methods
        /// <summary>
        /// Initializes the controls.
        /// </summary>
        /// <param name="container"></param>
        /// <remarks>
        /// Initialize your controls in this method. Do not override CreateChildControls method.
        /// </remarks>
        protected override void InitializeControls(GenericContainer container)
        {
        }

        /// <summary>
        /// Gets a collection of <see cref="T:System.Web.UI.ScriptReference" /> objects
        /// that define script resources that the control requires.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerable" /> collection of <see cref="T:System.Web.UI.ScriptReference" />
        /// objects.
        /// </returns>
        public override IEnumerable<ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            var assemblyName = typeof(PaletteItemsPage).Assembly.FullName;

            scripts.Add(new ScriptReference(PaletteItemsPage.PaletteItemsDetailScript, assemblyName));
            scripts.Add(new ScriptReference(PaletteItemsPage.PaletteItemsMasterScript, assemblyName));
            scripts.Add(new ScriptReference(PaletteItemsPage.PaletteItemsPageScript, assemblyName));

            return scripts;
        }
        #endregion

        #region Private fields and constants
        private static readonly string layoutTemplatePath = string.Concat(PaletteModuleClass.ModuleVirtualPath, "PaletteModule.Web.UI.PaletteItems.PaletteItemsPage.ascx");

        internal const string PaletteItemsPageScript = "PaletteModule.Web.Scripts.PaletteItems.PaletteItemsPage.js";
        internal const string PaletteItemsMasterScript = "PaletteModule.Web.Scripts.PaletteItems.PaletteItemsMaster.js";
        internal const string PaletteItemsDetailScript = "PaletteModule.Web.Scripts.PaletteItems.PaletteItemsDetail.js";
        #endregion
    }
}
