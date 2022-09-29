using Domain.Core.MedicalCenter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Core.MedicalCenter.Configurations
{
    internal class MedicoConfiguration : IEntityTypeConfiguration<Medico>
	{
		public void Configure(EntityTypeBuilder<Medico> builder)
		{
			// Set configuration for entity
			builder.ToTable("Medico", "dbo");

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
				.Property(p => p.IdEspecialidad)
				.HasColumnType("int")
				.IsRequired()
				;

			builder
				.Property(p => p.NombreCompleto)
				.HasColumnType("nvarchar")
				.HasMaxLength(150)
				.IsRequired()
				;

			// Add configuration for foreign keys

			builder
				.HasOne(p => p.EspecialidadFk)
				.WithMany(b => b.MedicoList)
				.HasForeignKey(p => p.IdEspecialidad)
				.HasConstraintName("FK_dbo_Medico_IdEspecialidad_dbo_Especialidad");

		}
	}
}
