﻿using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger,
        IRestaurantRepository restaurantRepository, IMapper mapper) : IRequestHandler<UpdateRestaurantCommand>
    {
        public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Update restaurant {request.Id}");

            Restaurant? restaurant = await restaurantRepository.GetByIdAsync(request.Id);

            if (restaurant == null)
            {
                throw new NotFoundException("Restaurant", request.Id.ToString());
            }

            mapper.Map(request, restaurant);
            await restaurantRepository.SaveChanges();
        }
    }
}
