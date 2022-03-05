using System;
using DUR.Api.Entities.Default;

namespace DUR.Api.Entities.Easter;

public class HuntLocation : Base
{
    public Guid IdHuntLocation { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public bool IsFound { get; set; }
    public HuntCity HuntCity { get; set; }
    public string Description { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
}