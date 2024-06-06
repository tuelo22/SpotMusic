using IdentityServer4;
using IdentityServer4.Models;

namespace SpotMusic.STS
{
    public class IdentityServerConfiguration
    {
        public static IEnumerable<IdentityResource> GetIdentityResource()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId() {},
                new IdentityResources.Profile() {},
            };
        }

        public static IEnumerable<ApiResource> GetApiResource()
        {
            return new List<ApiResource>()
            {
                new ApiResource("SpotMusic", "SpotMusic", new string[] { "SpotMusic" })
                {
                    ApiSecrets =
                    {
                        new Secret("SpotMusic".Sha256())
                    },
                    Scopes =
                    {
                        "SpotMusicScope"
                    }
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>() 
            {
                new ApiScope()
                {
                    Name = "SpotMusicScope",
                    DisplayName = "SpotMusicScope API",
                    UserClaims = { "SpotMusicScope" }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client() 
                {
                    ClientId = "client-angular-spotmusic",
                    ClientName = "Acesso do fronte as apis",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("SpotMusicScope".Sha256())
                        {

                        }                        
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "SpotMusicScope"
                    }
                }
            };
        }
    }
}
