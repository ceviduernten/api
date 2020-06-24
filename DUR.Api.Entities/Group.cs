using System;
using System.Collections.Generic;
using DUR.Api.Entities.Default;

namespace DUR.Api.Entities
{
    public class Group : Base
    {
        public Guid IdGroup { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Leaders { get; set; }
        public string Mail { get; set; }
        public string MailLeaders { get; set; }
        public string NumberNotification { get; set; }

        public List<Appointment> Appointments { get; set; }
    }
}
