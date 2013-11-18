using System;
using System.Configuration;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.Fields.Config;
using System.Drawing;

namespace PalettesModule.Fields
{
    public class ColorFieldDefinitionElement : FieldControlDefinitionElement, IColorFieldDefinition
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorFieldDefinitionElement" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public ColorFieldDefinitionElement(ConfigElement parent)
            : base(parent)
        {
        }

        #endregion

        #region FieldControlDefinitionElement members

        public override DefinitionBase GetDefinition()
        {
            return new ColorFieldDefinition(this);
        }

        #endregion

        #region IFieldDefinition members

        public override Type DefaultFieldType
        {
            get
            {
                return typeof(ColorField);
            }
        }

        #endregion

        #region IColorFieldDefinition
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
