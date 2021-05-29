using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WADProject.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string Name { get; set; }
        public int NumberOfPersons { get; set; }
        public DateTime DateApplied { get; set; }
        public DateTime DateOfSchedule { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

    }
}
