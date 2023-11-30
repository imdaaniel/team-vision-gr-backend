namespace TeamVisionGR.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; } = true;
        // public List<Collaborator>? Collaborators { get; } = new();
        public List<CollaboratorProject>? CollaboratorProjects { get; set; }
    }
}