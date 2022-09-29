using Api.Common.UnitTests.Helpers;
using Domain.Core.MedicalCenter.Models;
using Microsoft.EntityFrameworkCore;
using Services;
using System.Threading.Tasks;
using Xunit;

namespace Api.MedicalCenter.UnitTests
{
    public class EspecialidadTests
    {
        [Fact]
        public async Task GetEspecialidadesAsync()
        {
            // Arrange
            var service = new EspecialidadService(DbContextMock.GetDsolutionsDbContext());

            // Act
            var result = await service.GetItemsAsync();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CreateEspecialidadAsync()
        {
            // Arrange
            var service = new EspecialidadService(DbContextMock.GetDsolutionsDbContext());

            var trainingType = new Especialidad
            {
                Nombre = "UT - Create Data"
            };

            // Act
            var result = await service.SaveItemAsync(trainingType);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Id > 0);
        }

        [Fact]
        public async Task CreateEspecialidadWithInvalidDataAsync()
        {
            // Arrange
            var repository = new EspecialidadService(DbContextMock.GetDsolutionsDbContext());

            var trainingType = new Especialidad
            {
                Nombre = "Unit Test Data - With Invalid Length ........................................................................................................"
            };

            // Act + Assert
            await Assert.ThrowsAsync<DbUpdateException>(() => repository.SaveItemAsync(trainingType));
        }
    }
}