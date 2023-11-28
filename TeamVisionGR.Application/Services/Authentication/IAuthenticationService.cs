using TeamVisionGR.Application.Dtos.Authentication;
using TeamVisionGR.Domain.Entities;

namespace TeamVisionGR.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<ResponseService<User>> CreateUserAsync(SignUpRequestDto request);
        Task<ResponseService<Object>> AuthenticateUserAsync(SignInRequestDto request);
    }    
}