using System;
using System.Collections.Generic;

namespace QueueingDemo.Models
{
    public partial class Service
    {
        public Service()
        {
            ServiceProviders = new HashSet<ServiceProviders>();
            ServiceRooms = new HashSet<ServiceRooms>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ServiceProviders> ServiceProviders { get; set; }
        public virtual ICollection<ServiceRooms> ServiceRooms { get; set; }
    }
}
