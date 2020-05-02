using System;
using System.Collections.Generic;
using DUR.Api.Entities.Admin;

namespace DUR.Api.Presentation.ResourceModel
{
    public class UserRM : BaseRM
    {
        public Guid IdUser { get; set; }
        public string LoginName { get; set; }
        public string FullName { get; set; }
        public string Vulgo { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public Role Role { get; set; }
        public string RoleString
        {
            get
            {
                return Role.ToString();
            }
        }
    }
}
