using TeamVisionGR.Application.Dtos.Project;
using TeamVisionGR.Domain.Entities;

namespace TeamVisionGR.Application.Services
{
    public interface IProjectService
    {
        Task<ResponseService<Project>> CreateAsync(CreateProjectRequestDto dto);
        Task<ResponseService<Project>> GetByIdAsync(Guid projectId);
        Task<ResponseService<List<Project>?>> GetAllAsync(GetProjectListRequestDto dto);
        Task<ResponseService<Project>> UpdateAsync(UpdateProjectRequestDto dto);
        Task<ResponseService> DeleteAsync(Guid projectId);
    }
}