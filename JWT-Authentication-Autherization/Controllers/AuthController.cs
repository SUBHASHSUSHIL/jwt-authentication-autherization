using JWT_Authentication_Autherization.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_Authentication_Autherization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly autherizationContext autherizationContext;

        public AuthController(IConfiguration configuration, autherizationContext autherizationContext)
        {
            this.configuration = configuration;
            this.autherizationContext = autherizationContext;
        }

        [HttpPost]
        public IActionResult LoginData([FromBody] Login user)
        {
            if(user is null)
            {
                return BadRequest("Invalid user request!!!");
            }

            var rData = autherizationContext.Logins.Where(x => x.EmailId == user.Username && x.Password == user.Password)?.FirstOrDefault();

            if(rData is null)
            {
                return Unauthorized();
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(issuer: configuration["JwtSettings:Issuer"], audience: configuration["JwtSettings:Audience"],
            claims: new List<Claim>(), expires: DateTime.Now.AddDays(30), signingCredentials: signinCredentials);
            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return Ok(new
            {
                Token = tokenString,
                login = "Login Successfully...",
                email = rData.EmailId,
                mobileNo = rData.MobileNo,
                name = rData.Name,
                password = rData.Password
            });
        }

        public class Login
        {
            public string? Username
            {
                get;
                set;
            }
            public string? Password
            {
                get;
                set;
            }
        }
        public class JWTTokenResponse
        {
            public string? Token
            {
                get;
                set;
            }
        }
    }
}
