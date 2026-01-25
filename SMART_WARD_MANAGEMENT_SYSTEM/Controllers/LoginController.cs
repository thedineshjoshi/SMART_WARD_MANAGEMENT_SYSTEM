using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Infrastructure.Persistence;
using Application.DTOS;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMART_WARD_MANAGEMENT_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        private readonly IConfiguration _config;

        public LoginController(ApplicationDbContext db, IConfiguration _config)
        {
            this.db = db;
            this._config = _config;
        }

        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public ActionResult<string> Login([FromBody] UserLoginDTO req)
        {
            var user = db.Users.FirstOrDefault(s => s.Username == req.Username);

            if (user == null)
            {
                return BadRequest(new { message = "Invalid Username" });
            }

            var passwordVerificationResult = new PasswordHasher<SignUp>().VerifyHashedPassword(user, user.PasswordHash, req.Password);
            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return BadRequest(new { message = "Invalid Password" });
            }
            var isEmailVerified = user.IsEmailConfirmed;
            if(isEmailVerified==false)
            {
                return BadRequest(new { message = "Please Verify Email First" });
            }

            var userId = user.Id;
            var authClaims = new List<Claim>
                 {
                     new Claim("UserName",user.Username),
                     new Claim("UserId",userId.ToString()),
                     new Claim("Role",user.Role)
                 };
            var secret = _config["JWT:Secret"];
            if (string.IsNullOrEmpty(secret))
            {
                return BadRequest(new { message = "JWT Secret is not configured properly." });
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:ValidIssuer"],
                audience: _config["Jwt:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
