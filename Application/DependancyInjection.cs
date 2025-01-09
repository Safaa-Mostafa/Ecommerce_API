using System.Reflection;
using Application.Mappings;
using Application.Modules.Categories.Queries;
using Microsoft.Extensions.DependencyInjection;
namespace Application
{
    public static class DependancyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(GeneralProfile).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllCategoriesWithProducts).Assembly));





        }
    }
}

