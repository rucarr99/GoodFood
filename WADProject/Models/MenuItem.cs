using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WADProject.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }

        public int Price { get; set; }

        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        public ICollection<Ingredients> Ingredients { get; set; }

    }
}
