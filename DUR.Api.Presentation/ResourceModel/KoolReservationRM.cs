using DUR.Api.Entities.Events;
using System;
using System.Collections.Generic;

namespace DUR.Api.Presentation.ResourceModel
{
    public class KoolReservationRM : BaseRM
    {
        public string Uid { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public KoolType Type { get; set; }
        public string Room { get; set; }
        public string EventType
        {
            get
            {
                return Type.ToString();
            }
        }
    }
}