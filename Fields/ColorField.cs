using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.Fields;
using Telerik.Sitefinity.Web.UI.Fields.Contracts;
using Telerik.Web.UI;
using System.Drawing;

namespace PalettesModule.Fields
{
    [FieldDefinitionElement(typeof(ColorFieldDefinitionElement))]
    public class ColorField : FieldControl
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorField" /> class.
        /// </summary>
        public ColorField()
        {
            this.LayoutTemplatePath = ColorField.layoutTemplatePath;
        }

        #endregion

        #region Properties

        protected override WebControl TitleControl
        {
            get
            {
                return this.TitleLabel;
            }
        }

        protected override WebControl DescriptionControl
        {
            get
            {
                return this.DescriptionLabel;
            }
        }

        protected override WebControl ExampleControl
        {
            get
            {
                return this.ExampleLabel;
            }
        }

        protected override string LayoutTemplateName
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the reference to the label control that represents the title of the field control.
        /// </summary>
        /// <remarks>
        /// This control is mandatory only in write mode.
        /// </remarks>
        protected internal virtual Label TitleLabel
        {
            get
            {
                return this.Container.GetControl<Label>("titleLabel", true);
            }
        }

        /// <summary>
        /// Gets the reference to the label control that represents the description of the field control.
        /// </summary>
        /// <remarks>
        /// This control is mandatory only in write mode.
        /// </remarks>
        protected internal virtual Label DescriptionLabel
        {
            get
            {
                return Container.GetControl<Label>("descriptionLabel", true);
            }
        }

        /// <summary>
        /// Gets the reference to the label control that displays the example for this
        /// field control.
        /// </summary>
        /// <remarks>
        /// This control is mandatory only in the write mode.
        /// </remarks>
        protected internal virtual Label ExampleLabel
        {
            get
            {
                return this.Container.GetControl<Label>("exampleLabel", true);
            }
        }

        /// <summary>
        /// Gets the color picker control.
        /// </summary>
        /// <value>The color picker control.</value>
        protected virtual RadColorPicker ColorPickerControl
        {
            get
            {
                return this.Container.GetControl<RadColorPicker>("fieldColor", true);
            }
        }

        [TypeConverter(typeof(ObjectStringConverter))]
        public override object Value
        {
            get
            {
                return ColorTranslator.ToHtml(this.ColorPickerControl.SelectedColor);
            }
            set
            {
                this.ColorPickerControl.SelectedColor = ColorTranslator.FromHtml(value as string);
            }
        }

        public Color Color { get; set; }

        #endregion

        #region Methods
        protected override void InitializeControls(GenericContainer container)
        {
            this.TitleLabel.Text = this.Title;
            this.ExampleLabel.Text = this.Example;
            this.DescriptionLabel.Text = this.Description;

            this.ColorPickerControl.SelectedColor = this.Color;
        }

        public override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            List<ScriptDescriptor> descriptors = new List<ScriptDescriptor>();

            ScriptControlDescriptor descriptor = base.GetScriptDescriptors().Last() as ScriptControlDescriptor;

            if (this.ColorPickerControl != null)
            {
                descriptor.AddComponentProperty("colorPickerElement", this.ColorPickerControl.ClientID);
            }

            descriptors.Add(descriptor);

            return descriptors.ToArray();
        }

        public override IEnumerable<ScriptReference> GetScriptReferences()
        {
            List<ScriptReference> scripts = new List<ScriptReference>(base.GetScriptReferences());

            scripts.Add(new ScriptReference(ColorField.ScriptReference, typeof(ColorField).Assembly.FullName));

            return scripts;
        }

        public override void Configure(IFieldDefinition definition)
        {
            base.Configure(definition);

            IColorFieldDefinition fieldDefinition = definition as IColorFieldDefinition;

            if (fieldDefinition != null)
            {
                if (!string.IsNullOrEmpty(fieldDefinition.SampleText))
                {
                    this.Color = ColorTranslator.FromHtml(fieldDefinition.SampleText);
                }
            }
        }

        #endregion

        #region Private members
        public static readonly string layoutTemplatePath = "~/PaletteTemplates/" + typeof(ColorField).Namespace + ".ColorField.ascx";
        public static readonly string ScriptReference = typeof(ColorField).Namespace + ".ColorField.js";
        #endregion
    }
}