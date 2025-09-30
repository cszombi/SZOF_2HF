using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities.Entity
{
    public class Meal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = Guid.NewGuid().GetHashCode();

        [StringLength(250)]
        public string Name { get; set; } = string.Empty;

        [NotMapped]
        public double Calorie { get; set; } 

        [NotMapped]
        public virtual ICollection<Ingredient> Ingredients { get; set; }

        [NotMapped]
        public virtual ICollection<IngredientsAmount> IngredientsAmounts { get; set; } 

    }
}
