using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WADProject.Models
{
    public class CustomUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string UsernameLogin { get; set; }

        public string ProfilePicture { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
