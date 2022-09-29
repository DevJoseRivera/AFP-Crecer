using Domain.Core.MedicalCenter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Core.MedicalCenter.Configurations
{
	internal class CuadroClinicoConfiguration : IEntityTypeConfiguration<CuadroClinico>
	{
		public void Configure(EntityTypeBuilder<CuadroClinico> builder)
		{
			// Set configuration for entity
			builder.ToTable("CuadroClinico", "dbo");

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
				.Property(p => p.IdPaciente)
				.HasColumnType("int")
				.IsRequired()
				;

			builder
				.Property(p => p.Estatura)
				.HasColumnType("decimal(0, 0)")
				.IsRequired()
				;

			builder
				.Property(p => p.Peso)
				.HasColumnType("decimal(0, 0)")
				.IsRequired()
				;

			builder
				.Property(p => p.Enfermedad)
				.HasColumnType("nvarchar")
				.HasMaxLength(50)
				.IsRequired()
				;

			builder
				.Property(p => p.Diagnostico)
				.HasColumnType("nvarchar(max)")
				.IsRequired()
				;

			builder
				.Property(p => p.Tratamiento)
				.HasColumnType("nvarchar(max)")
				.IsRequired()
				;

			// Add configuration for uniques

			builder
				.HasIndex(p => p.IdPaciente)
				.IsUnique()
				.HasDatabaseName("UQ_dbo_CuadroClinico_IdPaciente");

			// Add configuration for foreign keys

			builder
				.HasOne(p => p.PacienteFk)
				.WithMany(b => b.CuadroClinicoList)
				.HasForeignKey(p => p.IdPaciente)
				.HasConstraintName("FK_dbo_CuadroClinico_IdPaciente_dbo_Paciente");

		}
	}
}
