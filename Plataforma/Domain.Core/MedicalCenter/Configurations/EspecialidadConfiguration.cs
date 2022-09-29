using Domain.Core.MedicalCenter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Core.MedicalCenter.Configurations
{
	internal class EspecialidadConfiguration : IEntityTypeConfiguration<Especialidad>
	{
		public void Configure(EntityTypeBuilder<Especialidad> builder)
		{
			// Set configuration for entity
			builder.ToTable("Especialidad", "dbo");

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
				.Property(p => p.Nombre)
				.HasColumnType("nvarchar")
				.HasMaxLength(50)
				.IsRequired()
				;

			// Add configuration for uniques

			builder
				.HasIndex(p => p.Nombre)
				.IsUnique()
				.HasName("UQ_dbo_Especialidad_Nombre");

		}
	}
}
