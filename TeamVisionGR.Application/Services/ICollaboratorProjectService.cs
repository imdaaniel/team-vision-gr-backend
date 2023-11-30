using TeamVisionGR.Application.Dtos.Collaborator;
using TeamVisionGR.Domain.Entities;

namespace TeamVisionGR.Application.Services
{
    public interface ICollaboratorProjectService
    {
        Task<ResponseService<Object>> AddCollaboratorToProject(AddCollaboratorToProjectRequestDto dto);
        Task<ResponseService<Object>> RemoveCollaboratorFromProject(RemoveCollaboratorFromProjectRequestDto dto);
    }
}