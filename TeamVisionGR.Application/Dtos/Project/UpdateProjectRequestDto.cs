namespace TeamVisionGR.Application.Dtos.Project
{
    public class UpdateProjectRequestDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool? Active { get; set; }
    }
}