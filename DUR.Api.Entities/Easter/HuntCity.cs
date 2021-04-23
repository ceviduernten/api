using System;
using System.Collections.Generic;
using DUR.Api.Entities.Default;

namespace DUR.Api.Entities.Easter
{
    public class HuntCity : Base
    {
        public Guid IdHuntCity { get; set; }
        public string Name { get; set; }
        public string Zip { get; set; }
        public string StartLocationLat { get; set; }
        public string StartLocationLong { get; set; }
        public ICollection<HuntLocation> Locations { get; set; }
        public int ZoomLevel { get; set; }
    }
}
