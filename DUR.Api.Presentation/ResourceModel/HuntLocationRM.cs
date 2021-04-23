using System;
using System.Collections.Generic;

namespace DUR.Api.Presentation.ResourceModel
{
    public class HuntLocationRM : BaseRM
    {
        public Guid IdHuntLocation { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsFound { get; set; }
        public HuntCityRM HuntCity { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
