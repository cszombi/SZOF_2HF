using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities.Dto
{
    public class IngredientsAmountShortViewDto
    {
        public string Id { get; set; }
        public string MealId { get; set; }
        public string IngredientID { get; set; }
        public double Amount { get; set; }
        public IEnumerable<IngredientShortViewDto> Ingredients { get; set; }
        public IEnumerable<IngredientsAmountShortViewDto> IngredientQuantities { get; set; }
    }
}
