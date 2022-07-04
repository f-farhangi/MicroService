using Duende.IdentityServer.Models;
using System.Collections.Generic;

namespace Mango.Services.Identity
{
    public static class SD
    {
        #region Constant

        public const string Admin = "Admin";
        public const string Customer = "Customer";

        #endregion

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope(name:"Mango",displayName:"Mango Server"),
                new ApiScope(name:"Read",displayName:"Read Your Data"),
                new ApiScope(name:"Write",displayName:"Write Your Data"),
                new ApiScope(name:"Delete",displayName:"Delete Your Data")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId="client",
                    ClientSecrets={new Secret("secret".Sha256()) },
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes={"Read","Write","Profile"}
                },
            };
    }
}
