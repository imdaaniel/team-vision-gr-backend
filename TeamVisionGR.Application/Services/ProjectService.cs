using TeamVisionGR.Application.Dtos.Project;
using TeamVisionGR.Application.Repositories;
using TeamVisionGR.Domain.Entities;

namespace TeamVisionGR.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ResponseService<Project>> CreateAsync(CreateProjectRequestDto dto)
        {
            var response = new ResponseService<Project>();

            Project project = new()
            {
                Name = dto.Name,
                Active = dto.Active,
            };

            try
            {
                response.Data = await _projectRepository.CreateAsync(project);
            }
            catch (Exception)
            {
                response.AddError("Ocorreu um erro ao salvar o projeto", System.Net.HttpStatusCode.InternalServerError);
            }

            return response;
        }

        public async Task<ResponseService<Project>> GetByIdAsync(Guid projectId)
        {
            var response = new ResponseService<Project>();

            Project? project = await _projectRepository.FindById(projectId);

            if (project == null)
            {
                response.AddError("Projeto não encontrado");
                return response;
            }

            response.Data = project;
            return response;
        }

        public async Task<ResponseService<Project>> UpdateAsync(UpdateProjectRequestDto dto)
        {
            var response = new ResponseService<Project>();

            Project? project = await _projectRepository.FindById(dto.Id);

            if (project == null)
            {
                response.AddError("Projeto não encontrado");
                return response;
            }

            project = GetProjectChanges(project, dto);

            await _projectRepository.UpdateAsync(project);

            response.Data = project;
            return response;
        }

        private static Project GetProjectChanges(Project currentProject, UpdateProjectRequestDto changedProject)
        {
            if (changedProject.Name != null)
            {
                currentProject.Name = changedProject.Name;
            }

            if (changedProject.Active != null)
            {
                currentProject.Active = (bool)changedProject.Active;
            }

            return currentProject;
        }

        public async Task<ResponseService<List<Project>>> GetAllAsync(GetProjectListRequestDto dto)
        {
            var response = new ResponseService<List<Project>>();

            IQueryable<Project> projectQuery = _projectRepository.GetQueryable();

            if (dto.Name != null)
            {
                projectQuery = projectQuery.Where(p => p.Name.Contains(dto.Name, StringComparison.OrdinalIgnoreCase));
            }
            if (dto.Active != null)
            {
                projectQuery = projectQuery.Where(p => p.Active == dto.Active);
            }

            List<Project>? projectList = projectQuery.ToList();

            response.Data = projectList;
            return response;
        }

        public async Task<ResponseService> DeleteAsync(Guid projectId)
        {
            var response = new ResponseService();

            Project? project = await _projectRepository.FindById(projectId);

            if (project == null)
            {
                response.AddError("Projeto não encontrado");
                return response;
            }

            try
            {
                await _projectRepository.DeleteAsnyc(project);
                response.SetStatusCode(System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception)
            {
                response.AddError("Ocorreu um erro ao excluir o projeto");
            }

            return response;
        }
    }
}