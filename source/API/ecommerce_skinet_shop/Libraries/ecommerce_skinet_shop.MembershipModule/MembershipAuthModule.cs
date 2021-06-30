using Autofac;
using ecommerce_skinet_shop.MembershipModule.Contexts;
using System;

namespace ecommerce_skinet_shop.MembershipModule
{
    public class MembershipAuthModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public MembershipAuthModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();
            //builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<ProductWithBrandsAndTypesSpecification>().AsSelf();
            //builder.RegisterType<ProductTypeRepository>().As<IProductTypeRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<ProductBrandRepository>().As<IProductBrandRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<StoreUnitOfWork>().As<IStoreUnitOfWork>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
