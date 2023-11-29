using Microsoft.AspNetCore.Mvc;

using TeamVisionGR.API.Models.Collaborator;
using TeamVisionGR.Application.Dtos.Collaborator;
using TeamVisionGR.Application.Services;

namespace TeamVisionGR.API.Controllers
{
    [Route("[controller]")]
    public class CollaboratorController : TeamVisionGRController
    {
        private readonly ICollaboratorService _collaboratorService;

        public CollaboratorController(ICollaboratorService collaboratorService)
        {
            _collaboratorService = collaboratorService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCollaboratorsList([FromQuery] GetCollaboratorListRequestModel model)
        {
            var dto = new GetCollaboratorListRequestDto()
            {
                Name = model.Name,
                Active = model.Active,
            };

            var response = await _collaboratorService.GetAllAsync(dto);

            return Response(response);
        }

        [HttpGet("{collaboratorId}")]
        public async Task<IActionResult> GetCollaborator(Guid collaboratorId)
        {
            var response = await _collaboratorService.GetByIdAsync(collaboratorId);

            return Response(response);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateCollaborator(CreateCollaboratorRequestModel model)
        {
            var dto = new CreateCollaboratorRequestDto()
            {
                Name = model.Name,
            };

            var response = await _collaboratorService.CreateAsync(dto);

            return Response(response);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateCollaborator([FromBody] UpdateCollaboratorRequestModel model)
        {
            var dto = new UpdateCollaboratorRequestDto()
            {
                Id = model.CollaboratorId,
                Name = model.Name,
                Active = model.Active
            };

            var response = await _collaboratorService.UpdateAsync(dto);

            return Response(response);
        }

        [HttpDelete("{collaboratorId}")]
        public async Task<IActionResult> DeleteCollaborator(Guid collaboratorId)
        {
            var response = await _collaboratorService.DeleteAsync(collaboratorId);

            return Response(response);
        }
    }
}