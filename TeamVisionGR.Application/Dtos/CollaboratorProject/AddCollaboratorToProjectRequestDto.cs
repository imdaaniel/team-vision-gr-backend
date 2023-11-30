namespace TeamVisionGR.Application.Dtos.Collaborator
{
    public class AddCollaboratorToProjectRequestDto
    {
        public Guid CollaboratorId { get; set; }
        public Guid ProjectId { get; set; }
    }
}