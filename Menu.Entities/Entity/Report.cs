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
        public string Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(300)]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public string Author { get; set; } = string.Empty;

    }
}
