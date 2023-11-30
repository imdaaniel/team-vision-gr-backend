using TeamVisionGR.Application.Dtos.Collaborator;
using TeamVisionGR.Application.Repositories;
using TeamVisionGR.Domain.Entities;

namespace TeamVisionGR.Application.Services
{
    public class CollaboratorProjectService : ICollaboratorProjectService
    {
        private readonly ICollaboratorProjectRepository _collaboratorProjectRepository;
        private readonly ICollaboratorRepository _collaboratorRepository;
        private readonly IProjectRepository _projectRepository;

        public CollaboratorProjectService(
            ICollaboratorProjectRepository collaboratorProjectRepository,
            ICollaboratorRepository collaboratorRepository,
            IProjectRepository projectRepository)
        {
            _collaboratorProjectRepository = collaboratorProjectRepository;
            _collaboratorRepository = collaboratorRepository;
            _projectRepository = projectRepository;
        }

        private async Task<bool> CheckIfCollaboratorIsValid(Guid collaboratorId)
        {
            Collaborator? collaborator = await _collaboratorRepository.FindById(collaboratorId);

            return collaborator != null && collaborator.Active;
        }

        private async Task<bool> CheckIfProjectIsValid(Guid projectId)
        {
            Project? project = await _projectRepository.FindById(projectId);

            return project != null && project.Active;
        }

        public async Task<ResponseService<Object>> AddCollaboratorToProject(AddCollaboratorToProjectRequestDto dto)
        {
            var response = new ResponseService<Object>();

            if (!(await CheckIfCollaboratorIsValid(dto.CollaboratorId)))
            {
                response.AddError("O colaborador não foi encontrado");
                return response;
            }

            if (!(await CheckIfProjectIsValid(dto.ProjectId)))
            {
                response.AddError("O projeto não foi encontrado");
                return response;
            }

            var collaboratorIsInTheProject = await _collaboratorProjectRepository.CheckIfCollaboratorIsInTheProject(dto.CollaboratorId, dto.ProjectId);

            if (collaboratorIsInTheProject != null)
            {
                response.AddError("O colaborador já faz parte do projeto");
                return response;
            }

            CollaboratorProject collaboratorProject = new()
            {
                CollaboratorId = dto.CollaboratorId,
                ProjectId = dto.ProjectId,
                EntryDate = DateTime.UtcNow
            };

            await _collaboratorProjectRepository.CreateAsync(collaboratorProject);

            response.Messages.Add("O colaborador foi adicionado com sucesso ao projeto");
            return response;
        }

        public async Task<ResponseService<Object>> RemoveCollaboratorFromProject(RemoveCollaboratorFromProjectRequestDto dto)
        {
            var response = new ResponseService<Object>();

            if (!(await CheckIfCollaboratorIsValid(dto.CollaboratorId)))
            {
                response.AddError("O colaborador não foi encontrado");
                return response;
            }

            if (!(await CheckIfProjectIsValid(dto.ProjectId)))
            {
                response.AddError("O projeto não foi encontrado");
                return response;
            }

            var collaboratorProject = await _collaboratorProjectRepository.CheckIfCollaboratorIsInTheProject(dto.CollaboratorId, dto.ProjectId);

            if (collaboratorProject == null)
            {
                response.AddError("O colaborador não faz parte do projeto");
                return response;
            }

            collaboratorProject.LeavingDate = DateTime.UtcNow;

            await _collaboratorProjectRepository.UpdateAsync(collaboratorProject);

            response.Messages.Add("O colaborador foi removido do projeto com sucesso");
            return response;
        }
    }
}