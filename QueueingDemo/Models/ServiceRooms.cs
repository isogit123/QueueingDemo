using System;
using System.Collections.Generic;

namespace QueueingDemo.Models
{
    public partial class ServiceRooms
    {
        public int Id { get; set; }
        public string Room { get; set; }
        public int ServiceId { get; set; }
        public DateTime AssignmentDate { get; set; }

        public virtual Service Service { get; set; }
    }
}
