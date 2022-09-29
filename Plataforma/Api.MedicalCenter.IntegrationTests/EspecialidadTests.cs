using Api.Common.IntegrationTests.Helper;
using Api.MedicalCenter.Requests;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Api.MedicalCenter.IntegrationTests
{
    public class EspecialidadTests : ApiTests
    {
        public EspecialidadTests() :
            base("Especialidad")
        {
        }

        [Fact]
        public async Task GetEspecialidadesAsync()
        {
            // Arrange
            var client = HttpClientHelper.CreateClient(BaseUrl);

            var request = new
            {
                Url = "especialidad"
            };

            // Act
            var response = await client.GetAsync(request.Url);
            
            // Assert
            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }

        [Fact]
        public async Task SaveEspecialidadAsync()
        {
            // Arrange
            var client = HttpClientHelper.CreateClient(BaseUrl);

            var request = new
            {
                Url = "crear-especialidad",
                Body = new EspecialidadRequest
                {
                    Nombre = "IT - Create Data"
                }
            };

            // Act
            var response = await client.PostAsync(request.Url, StringContentHelper.Create(request.Body.ToJson()));

            // Assert
            Assert.True(response.StatusCode == HttpStatusCode.Created);
        }

        [Fact]
        public async Task SaveTrainingTypeWithBadRequestAsync()
        {
            // Arrange
            var client = HttpClientHelper.CreateClient(BaseUrl);

            var request = new
            {
                Url = "crear-especialidad",
                Body = new EspecialidadRequest()
            };

            // Act
            var response = await client.PostAsync(request.Url, StringContentHelper.Create(request.Body.ToJson()));
            
            // Assert
            Assert.True(response.StatusCode == HttpStatusCode.BadRequest);
        }
    }
}
