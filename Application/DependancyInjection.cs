using System.Reflection;
using Application.Interfaces;
using Application.Mappings;
using Application.Modules.Categories.Queries;
using Application.services;
using Microsoft.Extensions.DependencyInjection;
namespace Application
{
    public static class DependancyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // إضافة MediatR مرة واحدة فقط
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // إضافة AutoMapper مرة واحدة فقط
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // أو لو كنت محدد Assembly معين لملفات الـ Profiles:
            // services.AddAutoMapper(typeof(GeneralProfile).Assembly);

            // تسجيل الخدمات الأخرى
            services.AddScoped<ICategoryService, CategoryService>();

        }

    }
}

