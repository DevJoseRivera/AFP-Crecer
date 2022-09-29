using Api.Common.IntegrationTests;

namespace Api.MedicalCenter.IntegrationTests
{
    public class ApiTests : FeatureTests
    {
        private const string _baseUrl = "http://localhost:5094/api/v1/";
        
        public ApiTests(string featureName)
            : base(_baseUrl)
        {
            FeatureName = featureName;
        }
    }
}
