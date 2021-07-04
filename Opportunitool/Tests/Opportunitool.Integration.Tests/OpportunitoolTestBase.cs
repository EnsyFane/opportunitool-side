using Opportunitool.Integration.Tests.TestInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Opportunitool.Integration.Tests
{
    public abstract class OpportunitoolTestBase : BaseIntegrationTest, IAsyncLifetime
    {
        private const string RootEndpoint = "/opportunitool";
        private const string V1Route = "/opportunitool/v1";
        private const string Register = "/opportunitool/auth/register";
        private const string LogOut = "/opportunitool/auth/log-out";
        private const string LogIn = "/opportunitool/auth/log-in";
        private const string GetOpportunityById = "/opportunitool/opportunities/{0}";
        private const string QueryOpportunities = "/opportunitool/opportunities/query-opportunities";
        private const string GetOpportunitiesByIds = "/opportunitool/opportunities/get-opportunities-by-ids";
        private const string CreateOpportunities = "/opportunitool/opportunities/create-opportunities";
        private const string UpdateOpportunities = "/opportunitool/opportunities/update-opportunities";
        private const string DeleteOpportunities = "/opportunitool/opportunities/delete-opportunities";
        private const string GetLocations = "/opportunitool/opportunities/locations";

        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public async Task<T> PostAsync<T>(string postRoute, object request) where T : class
        {
            var jsonBody = Serialize(request);
            var response = await PostAsync(postRoute, jsonBody).ConfigureAwait(false);
            var body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return Deserialize<T>(body);
        }

        public Task<HttpResponseMessage> PostAsync(string route, string jsonBody)
        {
            return CallAsync(HttpMethod.Post, route, jsonBody);
        }

        public async Task<T> PutAsync<T>(string putRoute, object request) where T : class
        {
            var jsonBody = Serialize(request);
            var response = await PutAsync(putRoute, jsonBody).ConfigureAwait(false);
            var body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return Deserialize<T>(body);
        }

        public Task<HttpResponseMessage> PutAsync(string route, string jsonBody)
        {
            return CallAsync(HttpMethod.Put, route, jsonBody);
        }

        public async Task<HttpResponseMessage> CallAsync(HttpMethod method, string route, string jsonBody)
        {
            using var requestMessage = new HttpRequestMessage(method, route);
            using var stringContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            requestMessage.Content = stringContent;
            return await _client.SendAsync(requestMessage).ConfigureAwait(false);
        }

        public async Task<T> GetAsync<T>(string getRoute) where T : class
        {
            var response = await GetAsync(getRoute).ConfigureAwait(false);
            var body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return Deserialize<T>(body);
        }

        public async Task<HttpResponseMessage> GetAsync(string route)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, route);
            return await _client.SendAsync(requestMessage).ConfigureAwait(false);
        }

        public async Task<T> DeleteAsync<T>(string deleteRoute) where T : class
        {
            var response = await DeleteAsync(deleteRoute).ConfigureAwait(false);
            var body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return Deserialize<T>(body);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string route)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Delete, route);
            return await _client.SendAsync(requestMessage).ConfigureAwait(false);
        }

        public static string Serialize(object obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public static T Deserialize<T>(string json) where T : class
        {
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            return JsonSerializer.Deserialize<T>(json);
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}