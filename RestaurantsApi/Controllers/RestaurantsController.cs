﻿using Microsoft.AspNetCore.Mvc;

using Restaurants.Application.Restaurants;

namespace RestaurantsApi.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController(IRestaurantService restaurantService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await restaurantService.GetRestaurants();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var restaurants = await restaurantService.GetById(id);
            
            if (restaurants is null)
            {
                return NotFound();
            }

            return Ok(restaurants);
        }
    }
}
