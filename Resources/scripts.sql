create database [AFP-Crecer]
go

use [AFP-Crecer]
go

create table [dbo].[Especialidad]
(
	[Id] int not null identity(1, 1),
	[Nombre] nvarchar(50) not null
)
go

create table [dbo].[Medico]
(
	[Id] int not null identity(1, 1),
	[IdEspecialidad] int not null,
	[NombreCompleto] nvarchar(150) not null
)
go

create table [dbo].[Paciente]
(
	[Id] int not null identity(1, 1),
	[NombreCompleto] nvarchar(150) not null,
	[DocumentoIdentidad] nvarchar(9) not null,
	[Telefono] nvarchar(8) not null
)
go

create table [dbo].[CuadroClinico]
(
	[Id] int not null identity(1, 1),
	[IdPaciente] int not null,
	[Estatura] decimal not null,
	[Peso] decimal not null,
	[Enfermedad] nvarchar(50) not null,
	[Diagnostico] nvarchar(max) not null,
	[Tratamiento] nvarchar(max) not null
)
go

create table [dbo].[Cita]
(
	[Id] int not null identity(1, 1),
	[IdMedico] int not null,
	[IdPaciente] int not null,
	[Fecha] datetime not null,
	[Hora] datetime not null
)
go

alter table [dbo].[Especialidad] add constraint [PK_dbo_Especialidad]
	primary key ([Id])
go

alter table [dbo].[Especialidad] add constraint [UQ_dbo_Especialidad_Nombre]
	unique ([Nombre])
go

alter table [dbo].[Medico] add constraint [PK_dbo_Medico]
	primary key ([Id])
go

alter table [dbo].[Medico] add constraint [FK_dbo_Medico_IdEspecialidad_dbo_Especialidad]
	foreign key ([IdEspecialidad]) references [dbo].[Especialidad]
go

alter table [dbo].[Paciente] add constraint [PK_dbo_Paciente]
	primary key ([Id])
go

alter table [dbo].[CuadroClinico] add constraint [PK_dbo_CuadroClinico]
	primary key ([Id])
go

alter table [dbo].[CuadroClinico] add constraint [UQ_dbo_CuadroClinico_IdPaciente]
	unique ([IdPaciente])
go

alter table [dbo].[CuadroClinico] add constraint [FK_dbo_CuadroClinico_IdPaciente_dbo_Paciente]
	foreign key ([IdPaciente]) references [dbo].[Paciente]
go

alter table [dbo].[Cita] add constraint [PK_dbo_Cita]
	primary key ([Id])
go

alter table [dbo].[Cita] add constraint [FK_dbo_Cita_IdMedico_dbo_Medico]
	foreign key ([IdMedico]) references [dbo].[Medico]
go

alter table [dbo].[Cita] add constraint [FK_dbo_Cita_IdPaciente_dbo_Paciente]
	foreign key ([IdPaciente]) references [dbo].[Paciente]
go