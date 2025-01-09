﻿using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger,
        IRestaurantRepository restaurantRepository, IMapper mapper) : IRequestHandler<UpdateRestaurantCommand, bool>
    {
        public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Update restaurant {request.Id}");

            Restaurant? restaurant = await restaurantRepository.GetByIdAsync(request.Id);

            if (restaurant == null)
            {
                return false;
            }

            mapper.Map(request, restaurant);
            await restaurantRepository.SaveChanges();

            return true;
        }
    }
}
