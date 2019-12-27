using System;
using DUR.Api.Entities.Events;

namespace DUR.Api.Presentation.ResourceModel
{
    public class GroupRM : BaseRM
    {
        public Guid IdGroup { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Leaders { get; set; }
    }
}
