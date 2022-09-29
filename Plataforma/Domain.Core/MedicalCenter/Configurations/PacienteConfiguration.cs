using Domain.Core.MedicalCenter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Core.MedicalCenter.Configurations
{
	internal class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
	{
		public void Configure(EntityTypeBuilder<Paciente> builder)
		{
			// Set configuration for entity
			builder.ToTable("Paciente", "dbo");

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
				.Property(p => p.NombreCompleto)
				.HasColumnType("nvarchar")
				.HasMaxLength(150)
				.IsRequired()
				;

			builder
				.Property(p => p.DocumentoIdentidad)
				.HasColumnType("nvarchar")
				.HasMaxLength(9)
				.IsRequired()
				;

			builder
				.Property(p => p.Telefono)
				.HasColumnType("nvarchar")
				.HasMaxLength(8)
				.IsRequired()
				;

		}
	}
}
