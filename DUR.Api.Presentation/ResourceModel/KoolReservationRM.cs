using System;
using DUR.Api.Entities.Events;

namespace DUR.Api.Presentation.ResourceModel;

public class KoolReservationRM : BaseRM
{
    public string Uid { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public KoolType Type { get; set; }
    public string Room { get; set; }

    public string EventType => Type.ToString();
}