using System;
using DUR.Api.Entities.Default;

namespace DUR.Api.Entities.Admin;

public class User : Base
{
    public Guid IdUser { get; set; }
    public string LoginName { get; set; }
    public string FullName { get; set; }
    public string Vulgo { get; set; }
    public string Password { get; set; }
    public string Mail { get; set; }
    public Role Role { get; set; }
}