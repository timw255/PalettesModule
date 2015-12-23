using System;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.UI.Fields.Definitions;

namespace PaletteModule.FieldControls
{
    public class PaletteSelectorControlDefinition : FieldControlDefinition, IPaletteSelectorControlDefinition
    {
        #region Constuctors
        /// <summary>
        /// Initializes a new instance of the <see cref="PaletteSelectorControlDefinition" /> class.
        /// </summary>
        public PaletteSelectorControlDefinition()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaletteSelectorControlDefinition" /> class.
        /// </summary>
        /// <param name="configDefinition">The config definition.</param>
        public PaletteSelectorControlDefinition(ConfigElement configDefinition)
            : base(configDefinition)
        {
        }
        #endregion

        #region IPaletteSelectorControlDefinition members
        /// <summary>
        /// Gets or sets the sample text.
        /// </summary>
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