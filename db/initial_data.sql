USE [db_intelutions]
GO
SET IDENTITY_INSERT [dbo].[TipoPermiso] ON 
GO
INSERT [dbo].[TipoPermiso] ([Id], [Descripcion]) VALUES (1, N'Enfermedad')
GO
INSERT [dbo].[TipoPermiso] ([Id], [Descripcion]) VALUES (2, N'Diligencias personales')
GO
INSERT [dbo].[TipoPermiso] ([Id], [Descripcion]) VALUES (3, N'Cita médica')
GO
INSERT [dbo].[TipoPermiso] ([Id], [Descripcion]) VALUES (4, N'Compensatorio')
GO
SET IDENTITY_INSERT [dbo].[TipoPermiso] OFF
GO
