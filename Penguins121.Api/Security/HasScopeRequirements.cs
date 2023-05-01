using Microsoft.AspNetCore.Authorization;

namespace Penguins121.Api.Security
{
    public class HasScopeRequirements : IAuthorizationRequirement
    {
        public string Issuer { get; } = null!;
        public string Scope { get; } = null!;

        public HasScopeRequirements(string scope, string issuer)
        {
            Scope = scope ?? throw new ArgumentNullException(nameof(scope));
            Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
        }
    }
}