using Microsoft.EntityFrameworkCore;

using TeamVisionGR.Domain.Entities;
using TeamVisionGR.Infra.Data.Context;

namespace TeamVisionGR.Application.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProjectRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Project> CreateAsync(Project project)
        {
            _dbContext.Project.Add(project);
            await _dbContext.SaveChangesAsync();

            return project;
        }

        public async Task<bool> DeleteAsnyc(Project project)
        {
            _dbContext.Project.Remove(project);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Project?> FindById(Guid projectId)
        {
            return await _dbContext.Project.FirstOrDefaultAsync(u => u.Id == projectId);
        }

        public IQueryable<Project> GetQueryable()
        {
            return _dbContext.Project.AsQueryable<Project>();
        }

        public async Task<Project> UpdateAsync(Project project)
        {
            _dbContext.Project.Update(project);
            await _dbContext.SaveChangesAsync();

            return project;
        }
    }
}