using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DUR.Api.Entities.Admin;
using Microsoft.AspNetCore.Authorization;

namespace DUR.Api.Web.Auth
{
    public class AuthorizationHandler : AuthorizationHandler<AuthorizationRequirement>
    {
        public override Task HandleAsync(AuthorizationHandlerContext context)
        {
            return base.HandleAsync(context);
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizationRequirement requirement)
        {
            var isEnumValue = Enum.IsDefined(typeof(Role), context.User.Claims.First(c => c.Type == ClaimTypes.Role).Value);
            var currentRole = (Role)Enum.Parse(typeof(Role), context.User.Claims.First(c => c.Type == ClaimTypes.Role).Value);
            if (requirement.Permission == "All")
            {
                if (isEnumValue) context.Succeed(requirement);
                return Task.CompletedTask;
            }
            else if (requirement.Permission == "Admin")
            {
                if (isEnumValue && (currentRole == Role.ADMIN)) context.Succeed(requirement);
                return Task.CompletedTask;
            }
            else if (requirement.Permission == "Stuff")
            {
                if (isEnumValue && (currentRole == Role.ADMIN || currentRole == Role.STUFF_LEADER)) context.Succeed(requirement);
                return Task.CompletedTask;
            }
            else if (requirement.Permission == "Scouting")
            {
                if (isEnumValue && (currentRole == Role.ADMIN || currentRole == Role.STUFF_LEADER || currentRole == Role.SCOUTING_LEADER)) context.Succeed(requirement);
                return Task.CompletedTask;
            } else
            {
                return Task.CompletedTask;
            }
        }
    }
}
