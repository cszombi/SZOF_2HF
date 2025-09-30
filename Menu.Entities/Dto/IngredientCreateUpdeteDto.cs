using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities.Dto
{
    public class IngredientCreateUpdeteDto
    {
        public required string Name { get; set; } = string.Empty;
        public required double Calorie { get; set; }
    }
}
