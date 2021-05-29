using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WADProject.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string Name { get; set; }
        public int StaffRoleId { get; set; }
        public StaffRole StaffRole { get; set; }

    }
}
