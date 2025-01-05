using Microsoft.EntityFrameworkCore;

using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories
{
    internal class RestaurantRepository(RestaurantDbContext dbContext) : IRestaurantRepository
    {
        public  async Task<int> Create(Restaurant restaurant)
        {
            dbContext.Restaurants.Add(restaurant);
            await dbContext.SaveChangesAsync();

            return restaurant.Id;
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            return await dbContext.Restaurants.ToListAsync();
        }

        public async Task<Restaurant?> GetByIdAsync(int id)
        {
            return await dbContext.Restaurants
                .Include(r=> r.Dishes)
                .SingleOrDefaultAsync(r => r.Id == id);
        }
    }
}
