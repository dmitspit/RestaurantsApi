using MediatR;
using Restaurants.Application.Restaurants.Dtos.RestaurantDtos;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
    {

    }
}
