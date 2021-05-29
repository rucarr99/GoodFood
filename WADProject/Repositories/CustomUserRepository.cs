using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WADProject.Models;

namespace WADProject.Repositories
{
    public class CustomUserRepository : RepositoryBase<CustomUser>, ICustomUserRepository
    {
        public CustomUserRepository(RestaurantContext restaurantContext) 
            : base(restaurantContext)
        {
        }
    }
}
