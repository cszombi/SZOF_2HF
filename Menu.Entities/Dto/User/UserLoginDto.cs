using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.Entities.Dto.User
{
    public class UserLoginDto
    {
        public required string Email { get; set; } = string.Empty;

        public required string Password { get; set; } = string.Empty;

    }
}
