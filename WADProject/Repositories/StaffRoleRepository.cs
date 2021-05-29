using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WADProject.Models;

namespace WADProject.Repositories
{
    public class StaffRoleRepository : RepositoryBase<StaffRole>, IStaffRoleRepository
    { 
        public StaffRoleRepository(RestaurantContext restaurantContext)
            : base(restaurantContext)
        {
        }
    }
}
