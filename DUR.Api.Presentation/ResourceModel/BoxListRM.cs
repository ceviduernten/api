using System;
using System.Collections.Generic;

namespace DUR.Api.Presentation.ResourceModel
{
    public class BoxListRM : BaseRM
    {
        public Guid IdBox { get; set; }
        public string Description { get; set; }
        public bool InUse { get; set; }
        public bool WithCover { get; set; }
        public bool Stackable { get; set; }
        public string BoxType { get; set; }
        public string Producer { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Location { get; set; }
    }
}
