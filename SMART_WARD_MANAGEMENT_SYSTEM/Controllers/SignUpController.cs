using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Persistence;
using Application.DTOS;
using Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JSMART_WARD_MANAGEMENT_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public SignUpController(ApplicationDbContext db)
        {
            this.db = db;
        }

        private async Task SendEmailAsync(string toEmail, string otp)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("dineshjoshi0025@gmail.com", "jhzcuiigttvriohy"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("noreply@smartwardmanagementsystem.com"),
                Subject = "Your One-Time Password (OTP) for Secure Login",
                Body = $@"
        <html>
            <body>
                <p>Hello,</p>
                <p>Your OTP code is: <strong>{otp}</strong></p>
                <p>This code is valid for 10 minutes.</p>
                <p>If you did not request this, please ignore this email.</p>
                <br/>
                <p>Thank you,<br/>JOB Portal System</p>
            </body>
        </html>",
                IsBodyHtml = true,
            };

            mailMessage.To.Add(toEmail);

            await smtpClient.SendMailAsync(mailMessage);
        }

        // GET: api/<RecruiterSignUpController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RecruiterSignUpController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RecruiterSignUpController>
        
        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] SignUpDto req)
        {
            var Email = db.Users.FirstOrDefault(s => s.Email == req.Email);
            var UserDetails = db.Users.FirstOrDefault(s=>s.Username==req.Username);
            if (Email != null)
            {
                return BadRequest(new { message = "Email Already exist" });
            }
            if (UserDetails != null)
            {
                return BadRequest(new { message = "Username Already exist" });
            }
            var user = new SignUp();
            var hashedPassword = new PasswordHasher<SignUp>().HashPassword(user, req.Password);
            user.Id = Guid.NewGuid();
            user.Username = req.Username;
            user.PasswordHash = hashedPassword;
            user.Role = req.Role;
            user.Email = req.Email;
            user.IsEmailConfirmed = false;
            user.IsSignedInWithGoogle = false;
            user.IsProfileComplete = false;
            var otp = new Random().Next(100000, 999999).ToString();
            user.OtpCode = otp;
            user.OtpExpiryTime = DateTime.UtcNow.AddMinutes(10); 
            db.Users.Add(user);
            db.SaveChanges();
            await SendEmailAsync(user.Email, otp);
            return Ok(new { message = "Registered successfully. Please check your email for OTP to confirm your account.", userId = user.Id });
        }

        [HttpPost("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail([FromBody] OtpVerificationDto req)
        {
            var user = await db.Users.FindAsync(req.UserId);

            if (user == null)
                return NotFound(new { message = "User not found" });

            if (user.IsEmailConfirmed)
                return BadRequest(new { message = "Email already confirmed." });

            if (user.OtpExpiryTime < DateTime.UtcNow)
                return BadRequest(new { message = "OTP expired. Please request a new one." });

            if (user.OtpCode != req.OtpCode)
                return BadRequest(new { message = "Invalid OTP." });

            // OTP correct
            user.IsEmailConfirmed = true;
            user.OtpCode = null; // clear OTP
            user.OtpExpiryTime = null; // clear expiry

            await db.SaveChangesAsync();

            return Ok(new { message = "Email verified successfully!" });
        }

        // PUT api/<RecruiterSignUpController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecruiterSignUpController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
