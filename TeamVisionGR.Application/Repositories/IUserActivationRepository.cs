using TeamVisionGR.Domain.Entities;

namespace TeamVisionGR.Application.Repositories
{
    public interface IUserActivationRepository
    {
        Task<UserActivation> CreateAsync(UserActivation userActivation);
        Task<UserActivation?> FindById(Guid activationId);
        Task<UserActivation?> FindValidUserActivation(Guid userId);
        Task<UserActivation> UpdateAsync(UserActivation userActivation);
        Task<bool> InvalidateAllUserActivations(Guid userId);
    }
}