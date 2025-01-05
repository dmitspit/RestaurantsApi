using Microsoft.AspNetCore.Mvc;

using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Dtos.RestaurantDtos;

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
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var restaurants = await restaurantService.GetById(id);

            if (restaurants is null)
            {
                return NotFound();
            }

            return Ok(restaurants);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto restaurantDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int id = await restaurantService.Create(restaurantDto);
            return CreatedAtAction(nameof(GetById), new { id}, null);
        }
    }
}
