using Menu.Entities.Helper;
using ReportApp.Entities.Dto.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.Entities.Entity
{
    public class Report : IIdEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(300)]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        [NotMapped]
        public virtual required UserCreateDto Reporter { get; set; }

    }
}
