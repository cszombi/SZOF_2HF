using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ReportApp.Entities.Dto.User;
using ReportApp.Repository.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReportApp.Endpoint.Controllers
{
    public class UserController
    {
        [ApiController]
        [Route("[controller]")]
        public class AuthController : ControllerBase
        {
            private UserManager<AppUser> userManager;
            private RoleManager<IdentityRole> roleManager;

            public AuthController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
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
                    FirstName = dto.FirstName,
                    LastName = dto.LastName
                };
                await userManager.CreateAsync(user, dto.Password);

                if (userManager.Users.Count() == 1)
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                    await userManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    await roleManager.CreateAsync(new IdentityRole("Worker"));
                    await userManager.AddToRoleAsync(user, "Worker");
                }
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login(UserLoginDto dto)
            {
                var user = await userManager.FindByEmailAsync(dto.Email);
                if (user != null)
                {
                    var result = await userManager.CheckPasswordAsync(user, dto.Password);
                    if (result)
                    {
                        //van ilyen user és jó a jelszava
                        //todo: generate token
                        var claim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName!),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    };

                        foreach (var role in await userManager.GetRolesAsync(user))
                        {
                            claim.Add(new Claim(ClaimTypes.Role, role));
                        }

                        int expiryInMinutes = 24 * 60;
                        var token = GenerateAccessToken(claim, expiryInMinutes);

                        return Ok(new LoginResultDto()
                        {
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            AccessTokenExpiration = DateTime.Now.AddMinutes(expiryInMinutes)
                        });
                    }
                    else
                    {
                        //throw new ArgumentException("Nem jó a jelszó");
                        return BadRequest("Nem jó a jelszó");
                    }
                }
                else
                {
                    //throw new ArgumentException("Nincs ilyen user");
                    return BadRequest("Nincs ilyen user");
                }

            }

            private JwtSecurityToken GenerateAccessToken(IEnumerable<Claim>? claims, int expiryInMinutes)
            {
                var signinKey = new SymmetricSecurityKey(
                      Encoding.UTF8.GetBytes("NagyonhosszútitkosítókulcsNagyonhosszútitkosítókulcsNagyonhosszútitkosítókulcsNagyonhosszútitkosítókulcsNagyonhosszútitkosítókulcsNagyonhosszútitkosítókulcs"));

                return new JwtSecurityToken(
                      issuer: "szerdaharom.com",
                      audience: "szerdaharom.com",
                      claims: claims?.ToArray(),
                      expires: DateTime.Now.AddMinutes(expiryInMinutes),
                      signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                    );
            }
        }

    }
}
