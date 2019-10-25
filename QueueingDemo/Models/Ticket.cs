using System;
using System.Collections.Generic;

namespace QueueingDemo.Models
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Prefix { get; set; }
        public int ServiceProvidersId { get; set; }
        public TimeSpan CreationTime { get; set; }
        public TimeSpan? FinishTime { get; set; }

        public virtual ServiceProviders ServiceProviders { get; set; }
    }
}
