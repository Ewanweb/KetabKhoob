using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CommentAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.RoleAgg;

using Shop.Domain.UserAgg.Repository;
using Shop.Infrastructure.Persistent.Ef.CategoryAgg;
using Shop.Infrastructure.Persistent.Ef.CommentAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Infrastructure.Persistent.Ef.OrderAgg;
using Shop.Infrastructure.Persistent.Ef.ProductAgg;
using Shop.Infrastructure.Persistent.Ef.RoleAgg;
using Shop.Infrastructure.Persistent.Ef.SellerAgg;
using Shop.Infrastructure.Persistent.Ef.UserAgg;

using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SiteEntities.Banners;
using Shop.Domain.SiteEntities.Sliders;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef.SiteEntities.Banners;
using Shop.Infrastructure.Persistent.Ef.SiteEntities.Sliders;

namespace Shop.Infrastructure
{
    public class InfrastructureBootstrapper
    {
        public static IServiceCollection Init(IServiceCollection services, string connectionString)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IShippingMethodRepository, ShippingMethodRepository>();

            services.AddScoped(_ => new DapperContext(connectionString));
            services.AddDbContext<ShopContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
