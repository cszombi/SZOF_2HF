using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReportApp.Entities.Dto.User;
using ReportApp.Repository.Helpers;

namespace ReportApp.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private UserManager<AppUser> userManager;
        private RoleManager<IdentityRole> roleManager;

        public ReportController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpPost("register")]
        public async Task Register(UserCreateDto dto)
        {
            var user = new AppUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                EmailConfirmed = true,
                
            };
        }
    }
}
