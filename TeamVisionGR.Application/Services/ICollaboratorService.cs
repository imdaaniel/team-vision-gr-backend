using TeamVisionGR.Application.Dtos.Collaborator;
using TeamVisionGR.Domain.Entities;

namespace TeamVisionGR.Application.Services
{
    public interface ICollaboratorService
    {
        Task<ResponseService<Collaborator>> CreateAsync(CreateCollaboratorRequestDto dto);
        Task<ResponseService<Collaborator>> GetByIdAsync(Guid collaboratorId);
        Task<ResponseService<List<Collaborator>?>> GetAllAsync(GetCollaboratorListRequestDto dto);
        Task<ResponseService<Collaborator>> UpdateAsync(UpdateCollaboratorRequestDto dto);
        Task<ResponseService> DeleteAsync(Guid collaboratorId);
    }
}