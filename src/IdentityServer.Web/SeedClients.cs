using System;
using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Web
{
    public class SeedClients : ISeedClients
    {
        public IEnumerable<Client> GetClients() => new List<Client>
        {
            new Client
            {
                ClientId = "spaService",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("hardtoguess".Sha256())
                },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "myapi.access"
                },
            },
            new Client
            {
                ClientId = "spaWeb",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets =
                {
                    new Secret("hardtoguess".Sha256())
                },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "myapi.access"
                },
                AllowOfflineAccess = true, // this to allow SPA,
                AlwaysSendClientClaims = true,
                AlwaysIncludeUserClaimsInIdToken = true,
                // this will generate reference tokens instead of access tokens
                AccessTokenType = AccessTokenType.Reference
            }
        };
    }
}