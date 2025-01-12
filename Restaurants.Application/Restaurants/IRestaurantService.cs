using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Dtos.RestaurantDtos;

namespace Restaurants.Application.Restaurants
{
    public interface IRestaurantService
    {
        Task<RestaurantDto?> GetById(int id);

        Task<IEnumerable<RestaurantDto>> GetRestaurants();

        Task<int> Create(CreateRestaurantCommand restaurantDto);
    }
}