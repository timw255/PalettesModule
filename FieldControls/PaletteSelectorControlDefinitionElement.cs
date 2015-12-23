using System;
using System.Configuration;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.Fields.Config;

namespace PaletteModule.FieldControls
{
    public class PaletteSelectorControlDefinitionElement : FieldControlDefinitionElement, IPaletteSelectorControlDefinition
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="PaletteSelectorControlDefinitionElement" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public PaletteSelectorControlDefinitionElement(ConfigElement parent)
            : base(parent)
        {
        }
        #endregion

        #region FieldControlDefinitionElement members
        public override DefinitionBase GetDefinition()
        {
            return new PaletteSelectorControlDefinition(this);
        }
        #endregion

        #region IFieldDefinition members
        public override Type DefaultFieldType
        {
            get
            {
                return typeof(PaletteSelectorControl);
            }
        }
        #endregion

        #region IPaletteSelectorControlDefinition
        /// <summary>
        /// Gets or sets the sample text.
        /// </summary>
        [ConfigurationProperty("SampleText")]
        public string SampleText
        {
            get
            {
                return (string)this["SampleText"];
            }
            set
            {
                this["SampleText"] = value;
            }
        }
        #endregion
    }
}