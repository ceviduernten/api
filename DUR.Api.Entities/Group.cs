using System;
using DUR.Api.Entities.Default;

namespace DUR.Api.Entities
{
    public class Group : Base
    {
        public Guid IdGroup { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Leaders { get; set; }
    }
}
