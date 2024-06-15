using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TriantaWeb.API.Models.DTO;
using TriantaWeb.API.Repositories;

namespace TriantaWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager,ITokenRepository tokenRepository) 
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }
        //post: /api/auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.UserName,
                Email = registerRequestDto.UserName
            };
            
            
            
            var identityResult = await userManager.CreateAsync(identityUser,registerRequestDto.Password);

            if(identityResult.Succeeded) 
            {
                //Add Roles to this user
                if(registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered Please Login.");
                    }
                }
            }

            return BadRequest("Something went wrong");
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.UserName);

            if(user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    //Get Roles
                    var roles = await userManager.GetRolesAsync(user);
                    
                    if(roles != null)
                    {
                        //Create Token

                        var jwtToken = tokenRepository.CreateJWToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };

                        return Ok(response);

                    }
                }
            }

            return BadRequest("User or Password is incorrect");
        }
    }
}
