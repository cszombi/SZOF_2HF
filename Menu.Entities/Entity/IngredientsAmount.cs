using Menu.Entities.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities.Entity
{
    public class IngredientsAmount : IIdEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string MealID { get; set; }
        public string IngredientID { get; set; }
        public double Amount { get; set; }
        [NotMapped]
        public virtual Ingredient ingredient { get; set; }
        [NotMapped]
        public virtual Meal meal { get; set; }
    }
}
