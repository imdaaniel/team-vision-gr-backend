using TeamVisionGR.Domain.Entities;

namespace TeamVisionGR.Application.Repositories
{
    public interface IProjectRepository
    {
        Task<Project> CreateAsync(Project project);
        Task<Project?> FindById(Guid projectId);
        IQueryable<Project> GetQueryable();
        Task<Project> UpdateAsync(Project project);
        Task<bool> DeleteAsnyc(Project project);
    }
}