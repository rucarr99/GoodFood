using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WADProject.Models;

namespace WADProject.Repositories
{
    public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository

    { 
        public ReservationRepository(RestaurantContext restaurantContext)
            : base(restaurantContext)
        {
        }
    }
}
