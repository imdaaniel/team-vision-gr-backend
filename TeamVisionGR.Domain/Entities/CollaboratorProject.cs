using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamVisionGR.Domain.Entities
{
    public class CollaboratorProject
    {
        public Guid CollaboratorId { get; set; }

        public Guid ProjectId { get; set; }
        
        public DateTime EntryDate { get; set; }
        
        public DateTime? LeavingDate { get; set; }
        
        // public Collaborator Collaborator { get; set; } = null!;
        
        // public Project Project { get; set; } = null!;
    }
}