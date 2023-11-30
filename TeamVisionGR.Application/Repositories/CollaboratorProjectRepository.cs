using Microsoft.EntityFrameworkCore;

using TeamVisionGR.Domain.Entities;
using TeamVisionGR.Infra.Data.Context;

namespace TeamVisionGR.Application.Repositories
{
    public class CollaboratorProjectRepository : ICollaboratorProjectRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CollaboratorProjectRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<CollaboratorProject?> CheckIfCollaboratorIsInTheProject(Guid collaboratorId, Guid projectId)
        {
            return await _dbContext.CollaboratorProject.FirstOrDefaultAsync(e => e.CollaboratorId == collaboratorId && e.ProjectId == projectId && e.LeavingDate == null);
        }

        public async Task<CollaboratorProject> CreateAsync(CollaboratorProject collaboratorProject)
        {
            _dbContext.CollaboratorProject.Add(collaboratorProject);
            await _dbContext.SaveChangesAsync();

            return collaboratorProject;
        }

        public async Task<bool> UpdateAsync(CollaboratorProject collaboratorProject)
        {
            try
            {
                _dbContext.CollaboratorProject.Update(collaboratorProject);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}