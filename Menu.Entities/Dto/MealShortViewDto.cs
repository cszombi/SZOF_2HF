using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities.Dto
{
    public class MealShortViewDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Calorie { get; set; }
        public IEnumerable<IngredientShortViewDto> Ingredients { get; set; }
        public IEnumerable<IngredientsAmountShortViewDto> IngredientQuantities { get; set; }

    }
}
