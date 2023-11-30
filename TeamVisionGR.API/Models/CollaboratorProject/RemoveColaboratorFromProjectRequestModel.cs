using System.ComponentModel.DataAnnotations;

namespace TeamVisionGR.API.Models.CollaboratorProject
{
    public class RemoveColaboratorFromProjectRequestModel
    {
        [Required(ErrorMessage = "O atributo CollaboratorId é obrigatório")]
        public Guid CollaboratorId { get; set; }

        [Required(ErrorMessage = "O atributo ProjectId é obrigatório")]
        public Guid ProjectId { get; set; }
    }
}