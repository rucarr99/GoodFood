using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WADProject.Models;

namespace WADProject.Repositories
{
    public class RestaurantRepository : RepositoryBase<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(RestaurantContext restaurantContext)
            : base(restaurantContext)
        {
        }

        public Restaurant GetFirstRestaurant()
        {
            return RestaurantContext.Restaurants.FirstOrDefault();
        }

        
    }
}
