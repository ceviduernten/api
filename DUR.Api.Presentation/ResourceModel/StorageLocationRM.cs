using System;
using System.Collections.Generic;

namespace DUR.Api.Presentation.ResourceModel;

public class StorageLocationRM : BaseRM
{
    public Guid IdStorageLocation { get; set; }
    public string ShortName { get; set; }
    public string Description { get; set; }
    public string City { get; set; }
    public int Zip { get; set; }
    public string Address { get; set; }

    public ICollection<ItemRM> Items { get; set; }
    public ICollection<BoxRM> Boxes { get; set; }
}