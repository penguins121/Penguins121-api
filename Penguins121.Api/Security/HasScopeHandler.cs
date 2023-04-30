using System.Linq;
using System.Threading.Tasks;
using Micorsoft.AspNetCore.Authorization;

namespace Penguins121.Api.Security
{
    public class HasScopeHandler : AuthroizationHandler<HasScopeRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            HasScopeRequirement requirement)
        {
            // If user does not have the scope claim, get out of here.

            if (!context.User.HasClaim(c => c.type == "scope" && c.Issuer == requirement.Issuer))
                return Task.CompletedTask;

            // Split the scopes strign into an array
            var scopes = context.User
                .FindFirst(c => c.type == "scope" && c.Issuer == requirement.Issuer)
                .Value.Split(' ');
            
            //Succeed if the scope array contains the required scops
            if(scopes.Any(s => s == requirement.Scope))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}