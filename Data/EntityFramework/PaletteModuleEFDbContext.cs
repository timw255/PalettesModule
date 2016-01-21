using System;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using PaletteModule.Data.EntityFramework.EntityConfigurations;
using PaletteModule.Models;

namespace PaletteModule.Data.EntityFramework
{
    public class PaletteModuleEFDbContext : DbContext, IPaletteModuleEFDbContext
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PaletteModuleEFDbContext" /> class.
        /// </summary>
        public PaletteModuleEFDbContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaletteModuleEFDbContext" /> class.
        /// </summary>
        /// <param name="dbConnectionString">The db connection string.</param>
        public PaletteModuleEFDbContext(string dbConnectionString)
            : base(dbConnectionString)
        {
        }
        #endregion

        #region Properties

        private DbContextTransaction Transaction { get; set; }

        #endregion

        #region IPaletteModuleEFDbContext

        public DbContextTransaction BeginTransaction()
        {
            if (this.Transaction != null)
            {
                this.Transaction.Dispose();
                this.Transaction = null;
            }
            this.Transaction = this.Database.BeginTransaction();
            return this.Transaction;
        }

        public void RollbackTransaction()
        {
            if (this.Transaction != null)
            {
                try
                {
                    this.Transaction.Rollback();
                }
                finally
                {
                    this.Transaction.Dispose();
                    this.Transaction = null;
                }
            }
        }

        public void CommitTransaction()
        {
            if (this.Transaction != null)
                this.Transaction.Commit();
        }
        #endregion

        #region Entities
        /// <summary>
        /// Gets or sets the PaletteItems.
        /// </summary>
        /// <value>The PaletteItems.</value>
        public DbSet<PaletteItem> PaletteItems { get; set; }
        #endregion

        #region DbContext method overrides
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PaletteItemTypeConfiguration());
        }

        protected override void Dispose(bool disposing)
        {
            if (this.Transaction != null)
            {
                this.Transaction.Dispose();
                this.Transaction = null;
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}