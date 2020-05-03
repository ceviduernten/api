using System;

namespace DUR.Api.Presentation.ResourceModel
{
    public class ItemListRM : BaseRM
    {
        public Guid IdItem { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string QuantityType { get; set; }
        public double Price { get; set; }
        public string Location { get; set; }
        public string Box { get; set; }
    }
}
