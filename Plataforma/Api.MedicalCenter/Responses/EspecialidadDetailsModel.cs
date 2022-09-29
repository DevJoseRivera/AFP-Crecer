using Domain.Core.MedicalCenter.Models;
using System.ComponentModel.DataAnnotations;

namespace Api.MedicalCenter.Responses
{
    public class EspecialidadDetailsModel
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
    }

    public static class ResponseExtensions
    {
        public static IEnumerable<EspecialidadDetailsModel> ToDetailsModel(this IEnumerable<Especialidad> entityItems)
        {
            var items = new List<EspecialidadDetailsModel>();

            foreach (var item in entityItems)
            {
                items.Add(new EspecialidadDetailsModel
                {
                    Id = item.Id,
                    Nombre = item.Nombre
                });
            }

            return items;
        }

        public static EspecialidadDetailsModel ToDetailsModel(this Especialidad entity)
            => new EspecialidadDetailsModel
            {
                Id = entity.Id,
                Nombre = entity.Nombre
            };
    }
}
