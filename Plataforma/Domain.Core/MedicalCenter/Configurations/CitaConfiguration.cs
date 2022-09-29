using Domain.Core.MedicalCenter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Core.MedicalCenter.Configurations
{
    internal class CitaConfiguration : IEntityTypeConfiguration<Cita>
	{
		public void Configure(EntityTypeBuilder<Cita> builder)
		{
			// Set configuration for entity
			builder.ToTable("Cita", "dbo");

			// Set key for entity
			builder.HasKey(p => p.Id);

			// Set identity for entity (auto increment)
			builder.Property(p => p.Id).UseIdentityColumn();

			// Set configuration for columns
			builder
				.Property(p => p.Id)
				.HasColumnType("int")
				.IsRequired()
				;

			builder
				.Property(p => p.IdMedico)
				.HasColumnType("int")
				.IsRequired()
				;

			builder
				.Property(p => p.IdPaciente)
				.HasColumnType("int")
				.IsRequired()
				;

			builder
				.Property(p => p.Fecha)
				.HasColumnType("datetime")
				.IsRequired()
				;

			builder
				.Property(p => p.Hora)
				.HasColumnType("datetime")
				.IsRequired()
				;

			// Add configuration for foreign keys

			builder
				.HasOne(p => p.MedicoFk)
				.WithMany(b => b.CitaList)
				.HasForeignKey(p => p.IdMedico)
				.HasConstraintName("FK_dbo_Cita_IdMedico_dbo_Medico");

			builder
				.HasOne(p => p.PacienteFk)
				.WithMany(b => b.CitaList)
				.HasForeignKey(p => p.IdPaciente)
				.HasConstraintName("FK_dbo_Cita_IdPaciente_dbo_Paciente");

		}
	}
}
