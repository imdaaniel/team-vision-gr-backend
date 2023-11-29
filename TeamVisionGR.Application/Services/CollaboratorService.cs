using TeamVisionGR.Application.Dtos.Collaborator;
using TeamVisionGR.Application.Repositories;
using TeamVisionGR.Domain.Entities;

namespace TeamVisionGR.Application.Services
{
    public class CollaboratorService : ICollaboratorService
    {
        private readonly ICollaboratorRepository _collaboratorRepository;

        public CollaboratorService(ICollaboratorRepository collaboratorRepository)
        {
            _collaboratorRepository = collaboratorRepository;
        }

        public async Task<ResponseService<Collaborator>> CreateAsync(CreateCollaboratorRequestDto dto)
        {
            var response = new ResponseService<Collaborator>();

            Collaborator collaborator = new()
            {
                Name = dto.Name,
                Active = dto.Active,
            };

            try
            {
                response.Data = await _collaboratorRepository.CreateAsync(collaborator);
            }
            catch (Exception)
            {
                response.AddError("Ocorreu um erro ao salvar o colaborador", System.Net.HttpStatusCode.InternalServerError);
            }

            return response;
        }

        public async Task<ResponseService<Collaborator>> GetByIdAsync(Guid collaboratorId)
        {
            var response = new ResponseService<Collaborator>();

            Collaborator? collaborator = await _collaboratorRepository.FindById(collaboratorId);

            if (collaborator == null)
            {
                response.AddError("Colaborador não encontrado");
                return response;
            }

            response.Data = collaborator;
            return response;
        }

        public async Task<ResponseService<Collaborator>> UpdateAsync(UpdateCollaboratorRequestDto dto)
        {
            var response = new ResponseService<Collaborator>();

            Collaborator? collaborator = await _collaboratorRepository.FindById(dto.Id);

            if (collaborator == null)
            {
                response.AddError("Colaborador não encontrado");
                return response;
            }

            collaborator = GetCollaboratorChanges(collaborator, dto);

            await _collaboratorRepository.UpdateAsync(collaborator);

            response.Data = collaborator;
            return response;
        }

        private static Collaborator GetCollaboratorChanges(Collaborator currentCollaborator, UpdateCollaboratorRequestDto changedCollaborator)
        {
            if (changedCollaborator.Name != null)
            {
                currentCollaborator.Name = changedCollaborator.Name;
            }

            if (changedCollaborator.Active != null)
            {
                currentCollaborator.Active = (bool)changedCollaborator.Active;
            }

            return currentCollaborator;
        }

        public async Task<ResponseService<List<Collaborator>>> GetAllAsync(GetCollaboratorListRequestDto dto)
        {
            var response = new ResponseService<List<Collaborator>>();

            IQueryable<Collaborator> collaboratorQuery = _collaboratorRepository.GetQueryable();

            if (dto.Name != null)
            {
                collaboratorQuery = collaboratorQuery.Where(p => p.Name.Contains(dto.Name, StringComparison.OrdinalIgnoreCase));
            }
            if (dto.Active != null)
            {
                collaboratorQuery = collaboratorQuery.Where(p => p.Active == dto.Active);
            }

            List<Collaborator>? collaboratorList = collaboratorQuery.ToList();

            response.Data = collaboratorList;
            return response;
        }

        public async Task<ResponseService> DeleteAsync(Guid collaboratorId)
        {
            var response = new ResponseService();

            Collaborator? collaborator = await _collaboratorRepository.FindById(collaboratorId);

            if (collaborator == null)
            {
                response.AddError("Colaborador não encontrado");
                return response;
            }

            try
            {
                await _collaboratorRepository.DeleteAsnyc(collaborator);
                response.SetStatusCode(System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception)
            {
                response.AddError("Ocorreu um erro ao excluir o colaborador");
            }

            return response;
        }
    }
}