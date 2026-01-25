
namespace Domain.Entities;

public class SignUp
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public bool IsEmailConfirmed { get; set; } = false;
    public bool IsProfileComplete { get; set; } = false;
    public bool IsSignedInWithGoogle { get; set; } = false;
    public string? OtpCode { get; set; }
    public DateTime? OtpExpiryTime { get; set; }

}
