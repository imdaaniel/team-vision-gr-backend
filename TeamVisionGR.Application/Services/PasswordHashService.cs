using BCryptNet = BCrypt.Net.BCrypt;

namespace TeamVisionGR.Application.Services
{
    public class PasswordHashService : IPasswordHashService
    {
        public string HashPassword(string password)
        {
            return BCryptNet.HashPassword(password);
        }

        public bool VerifyPassword(string providedPassword, string hashedPassword)
        {
            return BCryptNet.Verify(providedPassword, hashedPassword);
        }
    }
}