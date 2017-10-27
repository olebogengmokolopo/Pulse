using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Common.Sensors;
using Newtonsoft.Json;
using System.Configuration;

namespace Stethoscope
{
    [Serializable]
    internal struct Jwt
    {
        [JsonProperty("access_token")]
        internal string AccessToken;
        [JsonProperty("token_type")]
        internal string TokenType;
        [JsonProperty("expires_in")]
        internal int ExpiresIn;
    }

    public class PulseReporter : IReporter
    {
        private readonly string _tenantName;
        private readonly string _pulseServerAddress;
        private static readonly HttpClient HttpClient = new HttpClient();

        private string authToken;
        private DateTime tokenExpiresAt;

        public PulseReporter(string pulseServerAddress)
        {
            HttpClient.BaseAddress = new Uri(pulseServerAddress + $@"api");
            RefreshAuthenticationToken();
        }

        public void Report<T>(T reading) where T : ISensorReading
        {
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpClient.DefaultRequestHeaders.Authorization = GetAuthenticationHeader();

            var readingTarget = reading.GetSensorTarget();
            var response = HttpClient.PostAsJsonAsync(readingTarget, reading).Result;

            response.EnsureSuccessStatusCode();
        }

        private void RefreshAuthenticationToken()
        {
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            var username = ConfigurationManager.AppSettings["TenantUsername"];
            var password = ConfigurationManager.AppSettings["TenantPassword"];

            var formUrlEncodedContent = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password)
                });

            var response = HttpClient.PostAsync("/api/oauth/token", formUrlEncodedContent).Result;
            var resultJson = response.Content.ReadAsStringAsync().Result;
            response.EnsureSuccessStatusCode();
            var deserializedJwt = JsonConvert.DeserializeObject<Jwt>(resultJson);
            authToken = deserializedJwt.AccessToken;
            tokenExpiresAt = DateTime.Now.AddSeconds(deserializedJwt.ExpiresIn);
            
        }

        private AuthenticationHeaderValue GetAuthenticationHeader()
        {
            if (tokenExpiresAt < DateTime.Now)
            {
                RefreshAuthenticationToken();
            }

            return new AuthenticationHeaderValue("Bearer", authToken);
        }
    }
}
