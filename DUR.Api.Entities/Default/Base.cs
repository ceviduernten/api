using System;
namespace DUR.Api.Entities.Default
{
    public abstract class Base
    {
        public DateTime CreateDate { get; set; }
        public DateTime ModDate { get; set; }
        public bool Deleted { get; set; }
    }
}
