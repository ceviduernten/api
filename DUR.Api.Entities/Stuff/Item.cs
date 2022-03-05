using System;
using DUR.Api.Entities.Default;

namespace DUR.Api.Entities.Stuff;

public class Item : Base
{
    public Guid IdItem { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public QuantityType QuantityType { get; set; }
    public double Price { get; set; }
    public StorageLocation Location { get; set; }
    public Box Box { get; set; }
}