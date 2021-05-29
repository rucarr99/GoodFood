using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WADProject.Models
{
    public class Ingredients
    {
        [Key]
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }

        public int? MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
