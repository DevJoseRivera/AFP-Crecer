using System.Collections.ObjectModel;

namespace Domain.Core.MedicalCenter.Models
{
    public class Especialidad : IEntity
    {
		public Especialidad()
		{
		}

		public Especialidad(int? id)
		{
			Id = id;
		}

		public int? Id { get; set; }

		public string Nombre { get; set; }

		public virtual Collection<Medico> MedicoList { get; set; }

	}
}
