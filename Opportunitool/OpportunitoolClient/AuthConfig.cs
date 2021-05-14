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
            cfg.ClientId = configuration.GetValue<string>("ADD:ClientId");
            cfg.ClientSecret = configuration.GetValue<string>("ADD:ClientSecret");
            cfg.ResourceId = configuration.GetValue<string>("ADD:ResourceId");
            cfg.TenantId = configuration.GetValue<string>("ADD:TenantId");
            return cfg;
        }
    }
}