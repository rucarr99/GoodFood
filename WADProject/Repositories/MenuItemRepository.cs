using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WADProject.Models;

namespace WADProject.Repositories
{
    public class MenuItemRepository : RepositoryBase<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(RestaurantContext restaurantContext)
            : base(restaurantContext)
        {
        }
    }
}
