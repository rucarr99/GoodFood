using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WADProject.Models
{
    public class Menu
    {
        public int MenuId { get; set; }

        public ICollection<MenuItem> Items { get; set; }

    }
}
