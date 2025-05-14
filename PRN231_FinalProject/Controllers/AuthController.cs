using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PRN231_FinalProject.Dtos;
using PRN231_FinalProject.Models;
using System.Diagnostics.SymbolStore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace PRN231_FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly FeedbackSystemContext _feedbackSystemContext;
        public AuthController(FeedbackSystemContext feedbackSystemContext)
        {
            _feedbackSystemContext = feedbackSystemContext;
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("vuhongson02082003secretkey123456789"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
            issuer: "https://localhost:7078",
            audience: "https://localhost:7022",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credentials
           );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = _feedbackSystemContext.Users.FirstOrDefault(u => u.Email == model.Email);
                if ((user == null) || (model.Password != user.PasswordHash)) 
                {
                    return Unauthorized("Invalid email or password");
                }
                var token = GenerateJwtToken(user);
                return Ok(new
                {
                    Token = token,
                    Role = user.Role,
                    UserId = user.UserId,
                    fullName = user.FullName
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getUserById/{id}")]
        public IActionResult getUser(int id)
        {
            try
            {
                var data = _feedbackSystemContext.Users.FirstOrDefault(x => x.UserId == id);
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(data);
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
