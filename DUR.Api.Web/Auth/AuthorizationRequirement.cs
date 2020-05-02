using System;
using Microsoft.AspNetCore.Authorization;

namespace DUR.Api.Web.Auth
{
    public class AuthorizationRequirement : IAuthorizationRequirement
    {
        public string Permission { get; private set; }
        public AuthorizationRequirement(string permission)
        {
            this.Permission = permission;
        }
    }
}
