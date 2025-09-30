using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities.Entity
{
    public class Ingredient
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [StringLength(250)]
        public string Name { get; set; } = string.Empty;

        public double Calorie { get; set; }
        [NotMapped]
        public virtual ICollection<Meal>? Meals { get; set; }
        [NotMapped]
        public virtual ICollection<IngredientsAmount>? IngredientsAmounts { get; set; }

    }
}
