using System;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using PaletteModule.Models;

namespace PaletteModule.Data.EntityFramework.EntityConfigurations
{
    public class PaletteItemTypeConfiguration : EntityTypeConfiguration<PaletteItem>
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PaletteItemTypeConfiguration" /> class.
        /// </summary>
        public PaletteItemTypeConfiguration()
        {
            this.ToTable("PaletteModule_PaletteItems");
            this.HasKey(x => x.Id);
            this.Property(x => x.Title).IsRequired().HasMaxLength(255);
            this.Property(x => x.Dark1).HasMaxLength(255);
            this.Property(x => x.Dark2).HasMaxLength(255);
            this.Property(x => x.Light1).HasMaxLength(255);
            this.Property(x => x.Light2).HasMaxLength(255);
            this.Property(x => x.Accent1).HasMaxLength(255);
            this.Property(x => x.Accent2).HasMaxLength(255);
            this.Property(x => x.Accent3).HasMaxLength(255);
            this.Property(x => x.Accent4).HasMaxLength(255);
            this.Property(x => x.Accent5).HasMaxLength(255);
            this.Property(x => x.Accent6).HasMaxLength(255);
            this.Property(x => x.Hyperlink).HasMaxLength(255);
            this.Property(x => x.FollowedHyperlink).HasMaxLength(255);
            this.Property(x => x.LastModified);
            this.Property(x => x.DateCreated);
            this.Property(x => x.ApplicationName);
        }
        #endregion
    }
}