using System;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Data.Decorators;
using PaletteModule.Data.EntityFramework.Decorators;
using PaletteModule.Models;


namespace PaletteModule.Data.EntityFramework
{
    public class PaletteModuleEFDataProvider : PaletteModuleDataProvider, IPaletteModuleEFDataProvider
    {
        #region PaletteModuleDataProvider
        protected override void Initialize(string providerName, NameValueCollection config, Type managerType, bool initializeDecorator)
        {
            if (!ObjectFactory.IsTypeRegistered(typeof(PaletteModuleEFDataProviderDecorator)))
                ObjectFactory.Container.RegisterType<IDataProviderDecorator, PaletteModuleEFDataProviderDecorator>(typeof(PaletteModuleEFDataProviderDecorator).FullName);

            base.Initialize(providerName, config, managerType, initializeDecorator);
        }

        public override IQueryable<PaletteItem> GetPaletteItems()
        {
            return this.Context.PaletteItems.Where(p => p.ApplicationName == this.ApplicationName);
        }

        public override PaletteItem GetPaletteItem(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id cannot be Empty Guid");

            return this.Context.PaletteItems.Find(id);
        }

        public override PaletteItem CreatePaletteItem()
        {
            Guid id = Guid.NewGuid();
            var item = new PaletteItem(id, this.ApplicationName);

            return this.Context.PaletteItems.Add(item);
        }

        public override void UpdatePaletteItem(PaletteItem entity)
        {
            var context = this.Context;

            if (context.Entry(entity).State == EntityState.Detached)
                context.PaletteItems.Attach(entity);

            context.Entry(entity).State = EntityState.Modified;
            entity.LastModified = DateTime.UtcNow;
        }

        public override void DeletePaletteItem(PaletteItem entity)
        {
            var context = this.Context;

            if (context.Entry(entity).State == EntityState.Detached)
                context.PaletteItems.Attach(entity);

            context.PaletteItems.Remove(entity);
        }
        #endregion

        #region IPaletteModuleEFDataProvider
        public PaletteModuleEFDataProviderContext ProviderContext { get; set; }

        public PaletteModuleEFDbContext Context
        {
            get
            {
                return (PaletteModuleEFDbContext)this.GetTransaction();
            }
        }
        #endregion
    }
}