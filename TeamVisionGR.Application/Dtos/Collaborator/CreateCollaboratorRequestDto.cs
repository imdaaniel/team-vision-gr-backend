namespace TeamVisionGR.Application.Dtos.Collaborator
{
    public class CreateCollaboratorRequestDto
    {
        public string Name { get; set; }
        public bool Active { get; set; } = true;
    }
}