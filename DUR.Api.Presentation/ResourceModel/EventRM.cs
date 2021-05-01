using DUR.Api.Entities.Events;
using System;

namespace DUR.Api.Presentation.ResourceModel
{
    public class EventRM : BaseRM
    {
        public string Uid { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Summary { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public EventType Type { get; set; }
        public string EventType
        {
            get
            {
                return Type.ToString();
            }
        }
    }
}
