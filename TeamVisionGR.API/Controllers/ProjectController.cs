using Microsoft.AspNetCore.Mvc;

using TeamVisionGR.API.Models.Project;
using TeamVisionGR.Application.Dtos.Project;
using TeamVisionGR.Application.Services;

namespace TeamVisionGR.API.Controllers
{
    [Route("[controller]")]
    public class ProjectController : TeamVisionGRController
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetProjectsList([FromQuery] GetProjectListRequestModel model)
        {
            var dto = new GetProjectListRequestDto()
            {
                Name = model.Name,
                Active = model.Active,
            };

            var response = await _projectService.GetAllAsync(dto);

            return Response(response);
        }

        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetProject(Guid projectId)
        {
            var response = await _projectService.GetByIdAsync(projectId);

            return Response(response);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateProject(CreateProjectRequestModel model)
        {
            var dto = new CreateProjectRequestDto()
            {
                Name = model.Name,
            };

            var response = await _projectService.CreateAsync(dto);

            return Response(response);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectRequestModel model)
        {
            var dto = new UpdateProjectRequestDto()
            {
                Id = model.ProjectId,
                Name = model.Name,
                Active = model.Active
            };

            var response = await _projectService.UpdateAsync(dto);

            return Response(response);
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteProject(Guid projectId)
        {
            var response = await _projectService.DeleteAsync(projectId);

            return Response(response);
        }
    }
}