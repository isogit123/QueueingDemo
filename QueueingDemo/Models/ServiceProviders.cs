using System;
using System.Collections.Generic;

namespace QueueingDemo.Models
{
    public partial class ServiceProviders
    {
        public ServiceProviders()
        {
            Ticket = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? PhoneNumber { get; set; }
        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
