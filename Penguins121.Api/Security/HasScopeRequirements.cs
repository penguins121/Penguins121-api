using Microsoft.AspNetCore.Authorization;

namespace Penguins121.Api.Security
{
    public class HasSvopeRequirements : IAuthorizationRequirement
    {
        public string Issuer { get;}
        public string Scope {get;}

        public HasScopeRequirements(string scope, string issuer)
        {
            Scope = scope ?? throw new ArgumentNullException(nameof(scope));
            Issuer = issuer ?? throw new ArguementNullExeption(nameof(issuer));
        }
    }
}