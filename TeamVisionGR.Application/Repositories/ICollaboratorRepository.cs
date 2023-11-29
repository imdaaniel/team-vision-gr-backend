using TeamVisionGR.Domain.Entities;

namespace TeamVisionGR.Application.Repositories
{
    public interface ICollaboratorRepository
    {
        Task<Collaborator> CreateAsync(Collaborator collaborator);
        Task<Collaborator?> FindById(Guid collaboratorId);
        IQueryable<Collaborator> GetQueryable();
        Task<Collaborator> UpdateAsync(Collaborator collaborator);
        Task<bool> DeleteAsnyc(Collaborator collaborator);
    }
}