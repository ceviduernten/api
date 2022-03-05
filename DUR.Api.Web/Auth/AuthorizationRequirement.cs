using Microsoft.AspNetCore.Authorization;

namespace DUR.Api.Web.Auth;

public class AuthorizationRequirement : IAuthorizationRequirement
{
    public AuthorizationRequirement(string permission)
    {
        Permission = permission;
    }

    public string Permission { get; }
}