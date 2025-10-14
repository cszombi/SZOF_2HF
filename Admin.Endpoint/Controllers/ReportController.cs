using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ReportApp.Entities.Dto.Report;
using ReportApp.Entities.Dto.User;
using ReportApp.Logic;
using ReportApp.Repository.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReportApp.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        ReportLogic logic;
        UserManager<AppUser> userManager;

        public ReportController(ReportLogic logic, UserManager<AppUser> userManager)
        {
            this.logic = logic;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<ReportViewDto> Get()
        {
            return logic.Read();
        }
        [HttpPost]
        [Authorize]
        public async Task Post(ReportCreateDto dto)
        {
            var user = await userManager.GetUserAsync(User);
            await logic.Create(dto, user.FirstName + " " + user.LastName);
        }
    }
}
