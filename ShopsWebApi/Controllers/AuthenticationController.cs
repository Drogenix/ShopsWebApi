using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopsWebApi.Data;
using ShopsWebApi.Dependencies.Interfaces;
using ShopsWebApi.Models;

namespace ShopsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        private readonly ITokenService _tokenService;
        
        public AuthenticationController(ApplicationDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login([FromForm]AuthUser user)
        {
            if (ModelState.IsValid)
            {
                var validUser = _context.Users.First(item => item.Login == user.Login && item.Password == user.Password);

                if (validUser != null)
                {
                    var token = _tokenService.GenerateToken(validUser);

                    return Ok(token);
                }
            }

            return Unauthorized();
        }

    }
}
