using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants
{
    public interface IRestaurantService
    {
        Task<RestaurantDto?> GetById(int id);

        Task<IEnumerable<RestaurantDto>> GetRestaurants();
    }
}