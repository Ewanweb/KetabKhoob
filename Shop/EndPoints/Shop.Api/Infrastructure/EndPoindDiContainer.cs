namespace Shop.Api.Infrastructure
{
    public static class EndPointDiContainer
    {
        public static IServiceCollection Init(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfile).Assembly);
            return services;
        }
    }
}
