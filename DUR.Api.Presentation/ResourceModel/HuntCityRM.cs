using System;
using System.Collections.Generic;

namespace DUR.Api.Presentation.ResourceModel;

public class HuntCityRM : BaseRM
{
    public Guid IdHuntCity { get; set; }
    public string Name { get; set; }
    public string Zip { get; set; }
    public string StartLocationLat { get; set; }
    public string StartLocationLong { get; set; }
    public int ZoomLevel { get; set; }


    public ICollection<HuntLocationRM> Locations { get; set; }
}