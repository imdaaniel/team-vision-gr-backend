using TeamVisionGR.Domain.Entities;

namespace TeamVisionGR.Application.Services
{
    public interface IUserActivationService
    {
        Task<UserActivation> CreateAsync(User user);
        Task<bool> SendActivationEmailAsync(UserActivation userActivation);
        Task<ResponseService<object>> ActivateUser(Guid activationId);
    }
}