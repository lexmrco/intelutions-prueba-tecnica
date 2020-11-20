/****** Object:  Database [db_intelutions]    Script Date: 20/11/2020 3:28:55 p. m. ******/
CREATE DATABASE [db_intelutions]
GO
USE [db_intelutions]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 20/11/2020 3:28:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreEmpleado] [varchar](255) NOT NULL,
	[ApellidosEmpleado] [varchar](255) NOT NULL,
	[TipoPermisoId] [int] NOT NULL,
	[FechaPermiso] [datetime] NOT NULL,
 CONSTRAINT [PK_Permiso] PRIMARY KEY 
(
	[Id] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPermiso]    Script Date: 20/11/2020 3:28:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPermiso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](255) NOT NULL,
 CONSTRAINT [PK_TipoPermiso] PRIMARY KEY 
(
	[Id] ASC
)
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Permiso]  WITH CHECK ADD  CONSTRAINT [FK_Permiso_TipoPermiso] FOREIGN KEY([TipoPermisoId])
REFERENCES [dbo].[TipoPermiso] ([Id])
GO
ALTER TABLE [dbo].[Permiso] CHECK CONSTRAINT [FK_Permiso_TipoPermiso]
GO
