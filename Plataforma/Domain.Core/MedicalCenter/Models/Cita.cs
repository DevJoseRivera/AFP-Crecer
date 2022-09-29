namespace Domain.Core.MedicalCenter.Models
{
    public class Cita : IEntity
    {
		public Cita()
		{
		}

		public Cita(int? id)
		{
			Id = id;
		}

		public int? Id { get; set; }

		public int? IdMedico { get; set; }

		public int? IdPaciente { get; set; }

		public DateTime? Fecha { get; set; }

		public DateTime? Hora { get; set; }

		public virtual Medico MedicoFk { get; set; }

		public virtual Paciente PacienteFk { get; set; }
	}
}
