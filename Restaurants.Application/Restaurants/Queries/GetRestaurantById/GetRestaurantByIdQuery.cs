using MediatR;

using Restaurants.Application.Restaurants.Dtos.RestaurantDtos;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQuery : IRequest<RestaurantDto>
    {
        public GetRestaurantByIdQuery(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
