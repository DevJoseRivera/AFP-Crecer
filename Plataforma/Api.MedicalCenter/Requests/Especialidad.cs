using Domain.Core.MedicalCenter.Models;
using Library.Clients.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Api.MedicalCenter.Requests
{
    public interface IEspecialidadRequest : IRequest
    {
        string? Nombre { get; set; }
    }

    public class EspecialidadRequest : IEspecialidadRequest
    {
        [Required]
        [MaxLength(50)]
        public string? Nombre { get; set; }

        public string ToJson()
            => JsonSerializer.Serialize(this);
    }

    public static class RequestExtensions
    {
        public static Especialidad ToEntity(this EspecialidadRequest request)
            => new Especialidad
            {
                Nombre = request.Nombre
            };
    }
}
