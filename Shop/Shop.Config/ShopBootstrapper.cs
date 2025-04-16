using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil.Services;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application._Utilities;
using Shop.Application.Categories;
using Shop.Application.Products;
using Shop.Application.Sellers;
using Shop.Domain.CategoryAgg.Services;
using Shop.Domain.ProductAgg.ProductDomainService;
using Shop.Domain.SellerAgg.Services;
using Shop.Domain.UserAgg.Services;
using Shop.Infrastructure;
using Shop.Presentation.Facade;
using Shop.Query.Categories.DTOs;

namespace Shop.Config
{
    public static class ShopBootstrapper
    {
        public static IServiceCollection RegisterShopDependencies(this IServiceCollection services, IConfiguration config)
        {
            // ConnectionString
            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new Exception("کانکش استریگ نمیتونه نال باشه");

            // Infrastructure Registrations
            InfrastructureBootstrapper.Init(services, connectionString);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Directories).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CategoryDto).Assembly));

            services.AddScoped<IProductDomainService, ProductDomainService>();
            services.AddScoped<IUserDomainService, UserDomainService>();
            services.AddScoped<ICategoryDomainService, CategoryDomainService>();
            services.AddScoped<ISellerDomainService, SellerDomainService>();
            services.AddScoped<IFileService, FileService>();


            services.AddValidatorsFromAssembly(typeof(Directories).Assembly);

            services.InitFacadeDependency();

            return services;
        }
    }
}
