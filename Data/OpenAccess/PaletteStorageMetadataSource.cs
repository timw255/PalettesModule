using PaletteModule.Data.OpenAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Telerik.Sitefinity.Data.OA;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.GenericContent.Data;

namespace PaletteModule.Data.OpenAccess
{
	public class PaletteStorageMetadataSource : ContentBaseMetadataSource
	{
		#region Construction
		/// <summary>
		/// Initializes a new instance of the <see cref="DealersStorageMetadataSource" /> class.
		/// </summary>
		public PaletteStorageMetadataSource()
			: base(null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DealersStorageMetadataSource" /> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public PaletteStorageMetadataSource(IDatabaseMappingContext context)
			: base(context)
		{
		}
		#endregion

		#region Public and overriden methods
		/// <summary>
		/// Builds the custom mappings.
		/// </summary>
		/// <returns>The custom mappings.</returns>
		protected override IList<IOpenAccessFluentMapping> BuildCustomMappings()
		{
			var sitefinityMappings = base.BuildCustomMappings();
			sitefinityMappings.Add(new PaletteFluentMapping(this.Context));
			return sitefinityMappings;
		}
		#endregion
	}
}