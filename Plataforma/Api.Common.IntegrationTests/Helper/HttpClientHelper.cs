using System;
using System.Net.Http;

namespace Api.Common.IntegrationTests.Helper
{
    public class HttpClientHelper
    {
        public static HttpClient CreateClient(string baseUrl)
            => new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
    }
}
