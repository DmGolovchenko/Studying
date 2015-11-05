namespace StudyingWebAPI.Providers
{    
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.Owin.Security.OAuth;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;
    using StudyingWebData;

    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly StudyingEntities _repo;

        public SimpleAuthorizationServerProvider()
        {             
            _repo = new StudyingEntities();
            _repo.Configuration.LazyLoadingEnabled = true;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            IdentityUser user = await new Authentication { }.FindUser(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }            

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);

        }
    }
}