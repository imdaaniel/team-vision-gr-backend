using TeamVisionGR.Domain.Entities;

namespace TeamVisionGR.Application.Repositories
{
    public interface ICollaboratorProjectRepository
    {
        Task<CollaboratorProject> CreateAsync(CollaboratorProject collaboratorProject);
        Task<bool> UpdateAsync(CollaboratorProject collaboratorProject);
        Task<CollaboratorProject?> CheckIfCollaboratorIsInTheProject(Guid collaboratorId, Guid projectId);
    }
}