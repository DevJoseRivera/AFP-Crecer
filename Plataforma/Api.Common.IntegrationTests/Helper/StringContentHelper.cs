using System.Net.Http;
using System.Text;

namespace Api.Common.IntegrationTests.Helper
{
    public static class StringContentHelper
    {
        public static StringContent Create(string json)
            => new StringContent(json, Encoding.Default, "application/json");
    }
}
