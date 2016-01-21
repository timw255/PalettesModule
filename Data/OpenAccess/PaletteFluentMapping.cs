using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Model;
using PaletteModule.Models;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;

namespace PaletteModule.Data.OpenAccess
{
	public class PaletteFluentMapping : OpenAccessFluentMappingBase
	{
		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="DealersFluentMapping" /> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public PaletteFluentMapping(IDatabaseMappingContext context)
			: base(context)
		{
		}
		#endregion

		#region Public and overriden methods
		/// <summary>
		/// Gets the list of mapping configurations.
		/// </summary>
		/// <inheritdoc />
		/// <returns></returns>
		public override IList<MappingConfiguration> GetMapping()
		{
			var mappings = new List<MappingConfiguration>();

			this.MapPalette(mappings);
			this.MapUrlData(mappings);
			return mappings;
		}
		#endregion

		#region Private methods
		/// <summary>
		/// Maps the Dealer items.
		/// </summary>
		/// <param name="mappings">The mappings.</param>
		private void MapPalette(List<MappingConfiguration> mappings)
		{
			var mapping = new MappingConfiguration<PaletteItem>();

			mapping.HasProperty(p => p.Id).IsIdentity().IsNotNullable();
			mapping.MapType(p => new { }).SetTableName("Palette_PaletteItems", this.Context);

			//mapping.HasProperty(p => p.Title).IsNotNullable().IsText(this.Context, 255);
			mapping.HasProperty(p => p.Accent1).IsText(this.Context, 255);
			mapping.HasProperty(p => p.Accent2).IsText(this.Context, 255);
			mapping.HasProperty(p => p.Accent3).IsText(this.Context, 255);
			mapping.HasProperty(p => p.Accent4).IsText(this.Context, 255);
			mapping.HasProperty(p => p.Accent5).IsText(this.Context, 255);
			mapping.HasProperty(p => p.Accent6).IsText(this.Context, 255);

			mapping.HasProperty(p => p.Dark1).IsText(this.Context, 255);
			mapping.HasProperty(p => p.Dark2).IsText(this.Context, 255);

			mapping.HasProperty(p => p.Light1).IsText(this.Context, 255);
			mapping.HasProperty(p => p.Light2).IsText(this.Context, 255);

			mapping.HasProperty(p => p.Hyperlink).IsText(this.Context, 255);
			mapping.HasProperty(p => p.FollowedHyperlink).IsText(this.Context, 255);

			mapping.HasAssociation(p => p.Urls).WithOppositeMember("parent", "Parent").ToColumn("content_id").IsDependent().IsManaged();
			mappings.Add(mapping);
		}

		private void MapUrlData(IList<MappingConfiguration> mappings)
		{
			// map the Url data type
			var urlDataMapping = new MappingConfiguration<PaletteItemUrlData>();
			urlDataMapping.MapType(p => new { }).Inheritance(InheritanceStrategy.Flat).ToTable("sf_url_data");
			mappings.Add(urlDataMapping);
		}
		#endregion
	}
}