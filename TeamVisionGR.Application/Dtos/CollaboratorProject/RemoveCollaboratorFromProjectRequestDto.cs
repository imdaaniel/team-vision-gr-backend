namespace TeamVisionGR.Application.Dtos.Collaborator
{
    public class RemoveCollaboratorFromProjectRequestDto
    {
        public Guid CollaboratorId { get; set; }
        public Guid ProjectId { get; set; }
    }
}