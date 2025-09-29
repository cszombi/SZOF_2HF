using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities.Dto
{
    public class MealCreateUpdateDto
    {
        public required string Name { get; set; } = "";

        public required string Category { get; set; } = "";
    }
}
