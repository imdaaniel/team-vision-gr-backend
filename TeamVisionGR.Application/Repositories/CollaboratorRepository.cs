using Microsoft.EntityFrameworkCore;

using TeamVisionGR.Domain.Entities;
using TeamVisionGR.Infra.Data.Context;

namespace TeamVisionGR.Application.Repositories
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CollaboratorRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Collaborator> CreateAsync(Collaborator collaborator)
        {
            _dbContext.Collaborator.Add(collaborator);
            await _dbContext.SaveChangesAsync();

            return collaborator;
        }

        public async Task<bool> DeleteAsnyc(Collaborator collaborator)
        {
            _dbContext.Collaborator.Remove(collaborator);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Collaborator?> FindById(Guid collaboratorId)
        {
            return await _dbContext.Collaborator.FirstOrDefaultAsync(u => u.Id == collaboratorId);
        }

        public IQueryable<Collaborator> GetQueryable()
        {
            return _dbContext.Collaborator.AsQueryable<Collaborator>();
        }

        public async Task<Collaborator> UpdateAsync(Collaborator collaborator)
        {
            _dbContext.Collaborator.Update(collaborator);
            await _dbContext.SaveChangesAsync();

            return collaborator;
        }
    }
}