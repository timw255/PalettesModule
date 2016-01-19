using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Versioning.Serialization.Attributes;

namespace PaletteModule.Models
{
	public class PaletteItemUrlData : UrlData
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LocationItemUrlData" /> class.
		/// </summary>
		public PaletteItemUrlData() : base() { this.Id = Guid.NewGuid(); }

		/// <summary>
		/// Gets or sets the parent product item
		/// </summary>
		/// <value>The product item</value>
		[NonSerializableProperty]
		public override IDataItem Parent
		{
			get
			{
				if (this.parent != null)
					((IDataItem)this.parent).Provider = ((IDataItem)this).Provider;
				return this.parent;
			}
			set { this.parent = (PaletteItem)value; }
		}

		private PaletteItem parent;
	}
}
