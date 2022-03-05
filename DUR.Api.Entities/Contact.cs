using System;
using DUR.Api.Entities.Contacts;
using DUR.Api.Entities.Default;

namespace DUR.Api.Entities;

public class Contact : Base
{
    public Guid IdContact { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Vulgo { get; set; }
    public string Street { get; set; }
    public string Zip { get; set; }
    public string City { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }

    public ContactType Type { get; set; }
}