using System;

namespace DUR.Api.Presentation.ResourceModel;

public class HuntLocationListRM : BaseRM
{
    public Guid IdHuntLocation { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public bool IsFound { get; set; }

    public string IsActiveString => IsActive ? "JA" : "NEIN";

    public string IsFoundString => IsFound ? "JA" : "NEIN";

    public string City { get; set; }
    public string Description { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
}