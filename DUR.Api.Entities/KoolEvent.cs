using DUR.Api.Entities.Events;
using System;

namespace DUR.Api.Entities
{
    public class KoolEvent
    {
        public string Uid { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Summary { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public KoolEventType Type {get; set;}
        public string Room { get; set; }
    }
}
