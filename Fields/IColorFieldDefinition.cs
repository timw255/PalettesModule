using System;
using System.Linq;
using Telerik.Sitefinity.Web.UI.Fields.Contracts;
using System.Drawing;

namespace PalettesModule.Fields
{
    public interface IColorFieldDefinition : IFieldControlDefinition
    {
        /// <summary>
        /// Gets or sets the sample text.
        /// </summary>
        /// <value>The sample text.</value>
        string SampleText { get; set; }
    }
}
