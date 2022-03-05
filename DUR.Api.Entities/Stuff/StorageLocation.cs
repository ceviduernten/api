using System;
using System.Collections.Generic;
using DUR.Api.Entities.Default;

namespace DUR.Api.Entities.Stuff;

public class StorageLocation : Base
{
    public Guid IdStorageLocation { get; set; }
    public string ShortName { get; set; }
    public string Description { get; set; }
    public string City { get; set; }
    public int Zip { get; set; }
    public string Address { get; set; }

    public ICollection<Item> Items { get; set; }
    public ICollection<Box> Boxes { get; set; }
}