using System;

namespace DUR.Api.Entities.Kool;

public class Reservation
{
    public DateTime Date { get; set; }
    public string Start { get; set; }
    public string End { get; set; }
    public string Rooms { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Mail { get; set; }
}