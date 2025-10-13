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
    public class Report : IIdEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [StringLength(250)]
        public string Name { get; set; } = string.Empty;


        public double Calories => IngredientsAmounts?.Sum(i => (i.ingredient?.Calorie ?? 0) * i.Amount / 100) ?? 0;

        [NotMapped]
        public virtual ICollection<User>? Ingredients { get; set; }

        [NotMapped]
        public virtual ICollection<IngredientsAmount>? IngredientsAmounts { get; set; } 

    }
}
