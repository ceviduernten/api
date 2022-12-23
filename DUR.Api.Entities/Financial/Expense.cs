using System;
using DUR.Api.Entities.Default;

namespace DUR.Api.Entities.Financial;

public class Expense : Base
{
    public Guid Id { get; set; }
    public string Mail { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Street { get; set; }
    public string Place { get; set; }
    public string NameOfBank { get; set; }
    public string Iban { get; set; }
    public string Owner { get; set; }
    public string Section { get; set; }
    public string Amount { get; set; }
    public string Description { get; set; }
}