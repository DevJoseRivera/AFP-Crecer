using System.Collections.ObjectModel;

namespace Domain.Core.MedicalCenter.Models
{
    public class Paciente : IEntity
    {
		public Paciente()
		{
		}

		public Paciente(int? id)
		{
			Id = id;
		}

		public int? Id { get; set; }

		public string NombreCompleto { get; set; }

		public string DocumentoIdentidad { get; set; }

		public string Telefono { get; set; }

		public virtual Collection<CuadroClinico> CuadroClinicoList { get; set; }

		public virtual Collection<Cita> CitaList { get; set; }
	}
}
