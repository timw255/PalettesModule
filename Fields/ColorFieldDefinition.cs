using System;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.UI.Fields.Definitions;

namespace PalettesModule.Fields
{
    public class ColorFieldDefinition : FieldControlDefinition, IColorFieldDefinition
    {
        #region Constuctors
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorFieldDefinition" /> class.
        /// </summary>
        public ColorFieldDefinition()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorFieldDefinition" /> class.
        /// </summary>
        /// <param name="configDefinition">The config definition.</param>
        public ColorFieldDefinition(ConfigElement configDefinition)
            : base(configDefinition)
        {
        }

        #endregion

        #region IColorFieldDefinition members
        public string SampleText
        {
            get
            {
                return this.ResolveProperty("SampleText", this.sampleText);
            }
            set
            {
                this.sampleText = value;
            }
        }
        #endregion

        #region Private members
        private string sampleText;
        #endregion
    }
}