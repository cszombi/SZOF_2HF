using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class Meal
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty ;

        List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        List<Ingredient> IngredientsAmount { get; set; } = new List<Ingredient>();

    }
}
