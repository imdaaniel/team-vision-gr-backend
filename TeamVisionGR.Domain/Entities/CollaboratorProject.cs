using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamVisionGR.Domain.Entities
{
    public class CollaboratorProject
    {
        // [Key, Column(Order = 0)]
        public Guid CollaboratorId { get; set; }
        
        // [Key, Column(Order = 1)]
        public Guid ProjectId { get; set; }
        
        public DateTime EntryDate { get; set; }
        
        public DateTime? LeavingDate { get; set; }

        [ForeignKey("CollaboratorId")]
        public Collaborator Collaborator { get; set; }
        
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}