using TeamVisionGR.Domain.Entities;

namespace TeamVisionGR.Application.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<bool> EmailExistsAsync(string email);
        Task<User?> GetUserByEmailAsync(string email);
        Task<int> UpdateUserAsync(User user);
        Task<User?> GetUserByIdAsync(Guid userId);
    }
}