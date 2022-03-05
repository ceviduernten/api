using System;
using DUR.Api.Entities.Contacts;

namespace DUR.Api.Presentation.ResourceModel;

public class ContactRM : BaseRM
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

    public string ContactType => Type.ToString();
}