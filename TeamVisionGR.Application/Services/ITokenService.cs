using System.Security.Claims;

using TeamVisionGR.Domain.Entities;

namespace TeamVisionGR.Application.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}