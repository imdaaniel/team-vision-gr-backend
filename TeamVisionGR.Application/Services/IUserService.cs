using TeamVisionGR.Domain.Entities;

namespace TeamVisionGR.Application.Services
{
    public interface IUserService
    {
        // Task<ResponseService<User>> EditUserNameAsync(UserEditNameRequestDto userEditNameRequestDto);
        Task<ResponseService<User>> GetUserByIdAsync(Guid userId);
        string GetUserFullName(User user);
    }    
}