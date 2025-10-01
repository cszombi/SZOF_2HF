using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities.Dto
{
    public class IngredientsAmountCreateUpdateDto
    {
        public string MealID { get; set; }
        public string IngredientID { get; set; }
        public double Amount { get; set; }
        public string IngridientName { get; set; }
    }
}
