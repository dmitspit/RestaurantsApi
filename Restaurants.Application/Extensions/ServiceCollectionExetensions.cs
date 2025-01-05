using FluentValidation;
using FluentValidation.AspNetCore;

using Microsoft.Extensions.DependencyInjection;

using Restaurants.Application.Restaurants;

namespace Restaurants.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {

            var aplicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
            services.AddScoped<IRestaurantService, RestaurantService>();

            services.AddAutoMapper(aplicationAssembly);

            services.AddValidatorsFromAssembly(aplicationAssembly).AddFluentValidationAutoValidation();
        }
    }
}
