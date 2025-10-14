using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.Entities.Dto.User
{
    public class LoginResult
    {
        public string Token { get; set; } = string.Empty;

        public DateTime AccessTokenExpiration { get; set; }

    }
}
