namespace TeamVisionGR.Application.Dtos.Collaborator
{
    public class UpdateCollaboratorRequestDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool? Active { get; set; }
    }
}