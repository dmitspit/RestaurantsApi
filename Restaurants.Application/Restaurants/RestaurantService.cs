using AutoMapper;

using Microsoft.Extensions.Logging;

using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants
{
    internal class RestaurantService(IRestaurantRepository restaurantRepository, ILogger<RestaurantService> logger, IMapper mapper) : IRestaurantService
    {
        public async Task<RestaurantDto?> GetById(int id)
        {
            logger.LogInformation($"Get restaurant {id}");
            Restaurant? restaurant =  await restaurantRepository.GetByIdAsync(id);
            return mapper.Map<RestaurantDto>(restaurant);
        }

        public async Task<IEnumerable<RestaurantDto>> GetRestaurants()
        {
            logger.LogInformation("Get all restaurants");
            
            IEnumerable<Restaurant> restaurants = await restaurantRepository.GetAllAsync();
            IEnumerable<RestaurantDto?> restaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

            return restaurantsDtos!;
        }
    }
}
