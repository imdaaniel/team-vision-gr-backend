namespace TeamVisionGR.Domain.Entities
{
    public class Collaborator
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public List<Project> Projects { get; } = new();
    }
}