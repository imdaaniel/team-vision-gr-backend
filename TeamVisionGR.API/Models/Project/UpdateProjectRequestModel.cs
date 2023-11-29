using System.ComponentModel.DataAnnotations;

namespace TeamVisionGR.API.Models.Project
{
    public class UpdateProjectRequestModel
    {
        [Required(ErrorMessage = "O atributo ProjectId é obrigatório")]
        public Guid ProjectId { get; set; }

        [MaxLength(100, ErrorMessage = "O atributo Name não pode ter mais de 100 caracteres")]
        public string? Name { get; set; }
        
        public bool? Active { get; set; }
    }
}