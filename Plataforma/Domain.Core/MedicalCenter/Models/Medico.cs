using System.Collections.ObjectModel;

namespace Domain.Core.MedicalCenter.Models
{
    public class Medico : IEntity
    {
		public Medico()
		{
		}

		public Medico(int? id)
		{
			Id = id;
		}

		public int? Id { get; set; }

		public int? IdEspecialidad { get; set; }

		public string NombreCompleto { get; set; }

		public virtual Especialidad EspecialidadFk { get; set; }

		public virtual Collection<Cita> CitaList { get; set; }
	}
}
