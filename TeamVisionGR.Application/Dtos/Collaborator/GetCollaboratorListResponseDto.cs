using ProjectEntity = TeamVisionGR.Domain.Entities.Project;

namespace TeamVisionGR.Application.Dtos.Collaborator
{
    public class GetCollaboratorListResponseDto
    {
        public string Name { get; set; } = null!;
        public List<ProjectEntity>? Projects { get; set; }
    }
}