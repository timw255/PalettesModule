using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Model;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using PalettesModule.Model;
using Telerik.OpenAccess;

namespace PalettesModule.Data.OpenAccess
{
	public class PalettesFluentMapping : OpenAccessFluentMappingBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PalettesFluentMapping"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public PalettesFluentMapping(IDatabaseMappingContext context) : base(context) { }

		/// <summary>
		/// Creates and returns a collection of OpenAccess mappings
		/// </summary>
		public override IList<MappingConfiguration> GetMapping()
		{
			// initialize and return mappings
			var mappings = new List<MappingConfiguration>();
			MapItem(mappings);
			MapUrlData(mappings);
			return mappings;
		}

		/// <summary>
		/// Maps the PaletteItem class.
		/// </summary>
		/// <param name="mappings">The PaletteItem class mappings.</param>
		private void MapItem(IList<MappingConfiguration> mappings)
		{
			// initialize mapping
			var itemMapping = new MappingConfiguration<PaletteItem>();
			itemMapping.HasProperty(p => p.Id).IsIdentity();
			itemMapping.MapType(p => new { }).ToTable("sf_palettes");

            // add properties
            itemMapping.HasProperty(p => p.Dark1).HasLength(255).IsNotNullable();
            itemMapping.HasProperty(p => p.Light1).HasLength(255).IsNotNullable();
            itemMapping.HasProperty(p => p.Dark2).HasLength(255).IsNotNullable();
            itemMapping.HasProperty(p => p.Light2).HasLength(255).IsNotNullable();
            itemMapping.HasProperty(p => p.Accent1).HasLength(255).IsNotNullable();
            itemMapping.HasProperty(p => p.Accent2).HasLength(255).IsNotNullable();
            itemMapping.HasProperty(p => p.Accent3).HasLength(255).IsNotNullable();
            itemMapping.HasProperty(p => p.Accent4).HasLength(255).IsNotNullable();
            itemMapping.HasProperty(p => p.Accent5).HasLength(255).IsNotNullable();
            itemMapping.HasProperty(p => p.Accent6).HasLength(255).IsNotNullable();
            itemMapping.HasProperty(p => p.Hyperlink).HasLength(255).IsNotNullable();
            itemMapping.HasProperty(p => p.FollowedHyperlink).HasLength(255).IsNotNullable();

			// map urls table association
			itemMapping.HasAssociation(p => p.Urls).WithOppositeMember("parent", "Parent").ToColumn("content_id").IsDependent().IsManaged();
			mappings.Add(itemMapping);
		}

		/// <summary>
		/// Maps the PaletteItemUrlData class
		/// </summary>
		/// <param name="mappings">The LocatoinItemUrlData class mappings.</param>
		private void MapUrlData(IList<MappingConfiguration> mappings)
		{
			// map the Url data type
			var urlDataMapping = new MappingConfiguration<PaletteItemUrlData>();
			urlDataMapping.MapType(p => new { }).Inheritance(InheritanceStrategy.Flat).ToTable("sf_url_data");
			mappings.Add(urlDataMapping);
		}
	}
}
