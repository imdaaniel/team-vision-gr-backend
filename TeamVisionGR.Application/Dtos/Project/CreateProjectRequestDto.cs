namespace TeamVisionGR.Application.Dtos.Project
{
    public class CreateProjectRequestDto
    {
        public string Name { get; set; }
        public bool Active { get; set; } = true;
    }
}