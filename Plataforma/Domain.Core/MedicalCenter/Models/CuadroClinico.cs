namespace Domain.Core.MedicalCenter.Models
{
    public class CuadroClinico : IEntity
    {
		public CuadroClinico()
		{
		}

		public CuadroClinico(int? id)
		{
			Id = id;
		}

		public int? Id { get; set; }

		public int? IdPaciente { get; set; }

		public decimal? Estatura { get; set; }

		public decimal? Peso { get; set; }

		public string Enfermedad { get; set; }

		public string Diagnostico { get; set; }

		public string Tratamiento { get; set; }

		public virtual Paciente PacienteFk { get; set; }
	}
}
