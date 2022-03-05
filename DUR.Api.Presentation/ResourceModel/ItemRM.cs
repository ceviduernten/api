using System;
using DUR.Api.Entities.Stuff;

namespace DUR.Api.Presentation.ResourceModel;

public class ItemRM : BaseRM
{
    public Guid IdItem { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public QuantityType QuantityType { get; set; }

    public string QuantityTypeString => QuantityType.ToString();

    public double Price { get; set; }
    public StorageLocationRM Location { get; set; }
    public BoxRM Box { get; set; }
}