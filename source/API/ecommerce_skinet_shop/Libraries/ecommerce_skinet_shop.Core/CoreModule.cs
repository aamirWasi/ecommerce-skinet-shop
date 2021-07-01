using Autofac;
using ecommerce_skinet_shop.Core.Contexts;
using ecommerce_skinet_shop.Core.Repositories;
using ecommerce_skinet_shop.Core.Specifications;
using ecommerce_skinet_shop.Core.UnitOfWorks;
using System;

namespace ecommerce_skinet_shop.Core
{
    public class CoreModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public CoreModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StoreContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
            builder.RegisterType<BasketRepository>().As<IBasketRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductWithBrandsAndTypesSpecification>().AsSelf();
            builder.RegisterType<ProductTypeRepository>().As<IProductTypeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductBrandRepository>().As<IProductBrandRepository>().InstancePerLifetimeScope();
            builder.RegisterType<StoreUnitOfWork>().As<IStoreUnitOfWork>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
