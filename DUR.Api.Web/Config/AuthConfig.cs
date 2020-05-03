using DUR.Api.Web.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace DUR.Api.Web.Config
{
    public static class AuthConfig
    {
        public static IServiceCollection AddApiAuthorization(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    policy.Requirements.Add(new AuthorizationRequirement("Admin"));
                });
                options.AddPolicy("Stuff", policy =>
                {
                    policy.Requirements.Add(new AuthorizationRequirement("Stuff"));
                });
                options.AddPolicy("Scouting", policy =>
                {
                    policy.Requirements.Add(new AuthorizationRequirement("Scouting"));
                });
                options.AddPolicy("All", policy =>
                {
                    policy.Requirements.Add(new AuthorizationRequirement("All"));
                });
            });
            return serviceCollection;
        }
    }
}
