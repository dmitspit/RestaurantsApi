using MediatR;

using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger, IRestaurantRepository restaurantRepository)
        : IRequestHandler<DeleteRestaurantCommand>
    {
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Delete restaurant {request.Id}");

            var restaurant = await restaurantRepository.GetByIdAsync(request.Id);

            if (restaurant == null)
            {
                throw new NotFoundException("Restaurant", request.Id.ToString());
            }

            await restaurantRepository.Delete(restaurant);
        }
    }
}
