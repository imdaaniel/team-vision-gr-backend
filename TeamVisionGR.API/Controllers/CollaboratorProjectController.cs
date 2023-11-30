using Microsoft.AspNetCore.Mvc;

using TeamVisionGR.API.Models.Collaborator;
using TeamVisionGR.API.Models.CollaboratorProject;
using TeamVisionGR.Application.Dtos.Collaborator;
using TeamVisionGR.Application.Services;

namespace TeamVisionGR.API.Controllers
{
    [Route("[controller]")]
    public class CollaboratorProjectController : TeamVisionGRController
    {
        private readonly ICollaboratorProjectService _collaboratorProjectService;

        public CollaboratorProjectController(ICollaboratorProjectService collaboratorProjectService)
        {
            _collaboratorProjectService = collaboratorProjectService;
        }

        [HttpPost()]
        public async Task<IActionResult> AddCollaboratorToProject([FromBody] AddColaboratorToProjectRequestModel model)
        {
            var dto = new AddCollaboratorToProjectRequestDto()
            {
                CollaboratorId = model.CollaboratorId,
                ProjectId = model.ProjectId
            };

            var response = await _collaboratorProjectService.AddCollaboratorToProject(dto);

            return Response(response);
        }

        [HttpDelete()]
        public async Task<IActionResult> RemoveCollaboratorFromProject([FromBody] RemoveColaboratorFromProjectRequestModel model)
        {
            var dto = new RemoveCollaboratorFromProjectRequestDto()
            {
                CollaboratorId = model.CollaboratorId,
                ProjectId = model.ProjectId
            };

            var response = await _collaboratorProjectService.RemoveCollaboratorFromProject(dto);

            return Response(response);
        }
    }
}