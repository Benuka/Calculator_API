using CalculatorApi.Data;
using CalculatorApi.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CalculatorApi.Business.Services;
using Microsoft.IdentityModel.Tokens;

namespace CalculatorApi.Controllers
{
    /// <summary>
    /// Authentication controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Static user object.
        /// </summary>
        public static User user = new User();

        /// <summary>
        /// Configuration interface member.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Auth controller constructor.
        /// </summary>
        /// <param name="configuration"></param>
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Register new user.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>User</returns>
        [HttpPost("register")]
        public ActionResult<User> Register(UserDto request)
        {
            string passwordHash
                = BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.UserName = request.UserName;
            user.PasswordHash = passwordHash;

            return Ok(user);
        }

        /// <summary>
        /// User login.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json web token</returns>
        [HttpPost("login")]
        public ActionResult<User> Login(UserDto request)
        {
            if (user.UserName != request.UserName)
            {
                return BadRequest("User not found.");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Wrong password.");
            }

            string token = GenerateToken(user);

            return Ok(token);
        }

        /// <summary>
        /// Generate token.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Token string</returns>
        private string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
