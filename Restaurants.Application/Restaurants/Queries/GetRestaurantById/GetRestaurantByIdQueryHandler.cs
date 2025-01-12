using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using Restaurants.Application.Restaurants.Dtos.RestaurantDtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQueryHandler(ILogger<GetRestaurantByIdQueryHandler> logger,
        IMapper mapper, IRestaurantRepository restaurantRepository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto?>
    {
        public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Get restaurant {request.Id}");
            Restaurant restaurant = await restaurantRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException("Restaurant", request.Id.ToString());

            return mapper.Map<RestaurantDto>(restaurant);
        }
    }
}
