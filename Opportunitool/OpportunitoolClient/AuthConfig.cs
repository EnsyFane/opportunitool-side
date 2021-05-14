using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.IO;

namespace OpportunitoolClient
{
    public class AuthConfig
    {
        public string Instance { get; set; }

        public string TenantId { get; set; }

        public string ClientId { get; set; }

        public string Authority
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, Instance, TenantId);
            }
        }

        public string ClientSecret { get; set; }

        public string BaseAddress { get; set; }

        public string ResourceId { get; set; }

        public static AuthConfig ReadJsonFromFile(string path)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path)
                .AddUserSecrets("4b3160fc-e717-4bde-bea7-75121bc3e547")
                .Build();

            var cfg = configuration.Get<AuthConfig>();
            cfg.ClientId = configuration.GetValue<string>("AAD:ClientId");
            cfg.ClientSecret = configuration.GetValue<string>("AAD:ClientSecret");
            cfg.ResourceId = configuration.GetValue<string>("AAD:ResourceId");
            cfg.TenantId = configuration.GetValue<string>("AAD:TenantId");
            return cfg;
        }
    }
}