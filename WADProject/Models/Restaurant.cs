using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WADProject.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Address { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Staff> Staff { get; set; }


    }
}
