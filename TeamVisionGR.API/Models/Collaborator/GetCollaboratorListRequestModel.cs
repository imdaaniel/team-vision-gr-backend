using System.ComponentModel.DataAnnotations;

namespace TeamVisionGR.API.Models.Collaborator
{
    public class GetCollaboratorListRequestModel
    {
        [MaxLength(100, ErrorMessage = "O atributo Name não pode ter mais de 100 caracteres")]
        public string? Name { get; set; }
        
        public bool? Active { get; set; }
    }
}