using Domain.Core.MedicalCenter.Configurations;
using Domain.Core.MedicalCenter.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Core
{
    public partial class AfpCrecerDbContext : DbContext
    {
		public DbSet<Especialidad> Especialidad { get; set; }

		public DbSet<Medico> Medico { get; set; }

		public DbSet<Paciente> Paciente { get; set; }

		public DbSet<CuadroClinico> CuadroClinico { get; set; }

		public DbSet<Cita> Cita { get; set; }

		private static void ApplyMedicalCenterConfigurations(ModelBuilder modelBuilder)
		{
			modelBuilder
				.ApplyConfiguration(new EspecialidadConfiguration())
				.ApplyConfiguration(new MedicoConfiguration())
				.ApplyConfiguration(new PacienteConfiguration())
				.ApplyConfiguration(new CuadroClinicoConfiguration())
				.ApplyConfiguration(new CitaConfiguration())
			;
		}
	}
}
