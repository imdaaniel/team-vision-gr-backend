using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamVisionGR.Domain.Entities
{
    public class UserActivation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime SendingMoment { get; set; }
        public DateTime? ActivationMoment { get; set; }
        public bool Expired { get; set; } = false;
        public bool Activated { get; set; } = false;
        public User User { get; set; }
    }
}