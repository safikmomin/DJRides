using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjRidesAuth
{
    public class Config
    {
        // scopes define the resources in your system
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("MainApi1", "My API")
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "MainApi1" }
                },

                // resource owner password grant client
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    RequireConsent = false,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "MainApi1"
                    },
                    AllowOfflineAccess = true
                },

                // OpenID Connect hybrid flow and client credentials client (MVC)
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    
                    AllowedGrantTypes = GrantTypes.Code ,

                    RequireConsent = false,
                    RequireClientSecret = true,
                    //RequirePkce = true,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    //RedirectUris = { "http://localhost:55994/signin-oidc" },
                    //PostLogoutRedirectUris = { "http://localhost:55994/signout-callback-oidc" },

                    RedirectUris = { "http://localhost:44375/Account/Login" },
                    PostLogoutRedirectUris = { "http://localhost:44375/" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "MainApi1"
                    },
                    AllowOfflineAccess = true
                }
            };
        }
    }
}
