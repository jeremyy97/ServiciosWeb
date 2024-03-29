USE [master]
GO
/****** Object:  Database [BCientificas]    Script Date: 14/07/2019 21:23:50 ******/
CREATE DATABASE [BCientificas]
 GO
ALTER DATABASE [BCientificas] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BCientificas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BCientificas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BCientificas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BCientificas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BCientificas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BCientificas] SET ARITHABORT OFF 
GO
ALTER DATABASE [BCientificas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BCientificas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BCientificas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BCientificas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BCientificas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BCientificas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BCientificas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BCientificas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BCientificas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BCientificas] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BCientificas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BCientificas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BCientificas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BCientificas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BCientificas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BCientificas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BCientificas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BCientificas] SET RECOVERY FULL 
GO
ALTER DATABASE [BCientificas] SET  MULTI_USER 
GO
ALTER DATABASE [BCientificas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BCientificas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BCientificas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BCientificas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BCientificas] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BCientificas', N'ON'
GO
ALTER DATABASE [BCientificas] SET QUERY_STORE = OFF
GO
USE [BCientificas]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 14/07/2019 21:23:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[Bitacora_id] [varchar](10) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Tipo] [varchar](100) NOT NULL,
	[Descripcion] [varchar](800) NOT NULL,
	[RegistroDetallado] [varchar](1600) NOT NULL,
	[Usuario_Id] [varchar](10) NOT NULL,
 CONSTRAINT [bitacora_pk] PRIMARY KEY CLUSTERED 
(
	[Bitacora_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BitacoraExperimental]    Script Date: 14/07/2019 21:23:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BitacoraExperimental](
	[Experimento_id] [varchar](10) NOT NULL,
	[Nombre] [varchar](400) NOT NULL,
	[FechaInicio] [varchar](100) NOT NULL,
	[FechaFin] [varchar](100) NOT NULL,
	[urlMuestra1] [varchar](800) NULL,
	[urlMuestra2] [varchar](800) NULL,
	[urlMuestra3] [varchar](800) NULL,
	[urlMuestra4] [varchar](800) NULL,
	[urlMuestra5] [varchar](800) NULL,
	[Detalle1] [varchar](8000) NOT NULL,
	[Detalle2] [varchar](8000) NOT NULL,
	[Usuario_Crea] [varchar](10) NOT NULL,
	[Usuario_Testigo] [varchar](10) NOT NULL,
	[Proyecto_Id] [varchar](10) NOT NULL,
 CONSTRAINT [bitacoraexperimental_pk] PRIMARY KEY CLUSTERED 
(
	[Experimento_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consecutivo]    Script Date: 14/07/2019 21:23:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consecutivo](
	[Consecutivo_id] [int] NOT NULL,
	[nombre] [varchar](400) NOT NULL,
	[Consecutivo] [varchar](100) NOT NULL,
	[PoseePrefijo] [varchar](100) NOT NULL,
	[Prefijo] [varchar](100) NOT NULL,
	[PoseeRanGO] [varchar](100) NOT NULL,
	[Inicio] [varchar](100) NOT NULL,
	[Fin] [varchar](100) NOT NULL,
	[TipoConsecutivo_Id] [int] NOT NULL,
 CONSTRAINT [consecutivo_pk] PRIMARY KEY CLUSTERED 
(
	[Consecutivo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Error]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Error](
	[Error_id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Tabla] [varchar](100) NOT NULL,
	[Descripcion] [varchar](800) NOT NULL,
	[Usuario_Id] [varchar](10) NOT NULL,
 CONSTRAINT [error_pk] PRIMARY KEY CLUSTERED 
(
	[Error_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NivelAcademico]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NivelAcademico](
	[NivelAcademico_id] [varchar](10) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[Detalle] [varchar](800) NOT NULL,
	[Completo] [varchar](100) NOT NULL,
 CONSTRAINT [nivelacademico_pk] PRIMARY KEY CLUSTERED 
(
	[NivelAcademico_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proyecto]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proyecto](
	[Proyecto_id] [varchar](10) NOT NULL,
	[Nombre] [varchar](400) NOT NULL,
	[RamaCientifica_Id] [varchar](10) NOT NULL,
	[Precio] [varchar](400) NOT NULL,
	[Idioma] [varchar](100) NOT NULL,
 CONSTRAINT [proyecto_pk] PRIMARY KEY CLUSTERED 
(
	[Proyecto_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puesto]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puesto](
	[Puesto_id] [varchar](10) NOT NULL,
	[Nombre] [varchar](400) NOT NULL,
	[RolLaboratorio_Id] [varchar](10) NOT NULL,
 CONSTRAINT [puesto_pk] PRIMARY KEY CLUSTERED 
(
	[Puesto_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RamaCientifica]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RamaCientifica](
	[RamaCientifica_id] [varchar](10) NOT NULL,
	[Nombre] [varchar](400) NOT NULL,
 CONSTRAINT [ramacientifica_pk] PRIMARY KEY CLUSTERED 
(
	[RamaCientifica_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolLaboratorio]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolLaboratorio](
	[RolLaboratorio_id] [varchar](10) NOT NULL,
	[Nombre] [varchar](400) NOT NULL,
	[detalle] [varchar](600) NULL,
 CONSTRAINT [rollaboratorio_pk] PRIMARY KEY CLUSTERED 
(
	[RolLaboratorio_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolUsuario]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolUsuario](
	[RolUsuario_id] [int] NOT NULL,
	[nombre] [varchar](200) NOT NULL,
	[descripcion] [varchar](400) NULL,
 CONSTRAINT [rolusuario_pk] PRIMARY KEY CLUSTERED 
(
	[RolUsuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rolusuario_Usuarios]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rolusuario_Usuarios](
	[Rolusuario_id] [int] NOT NULL,
	[Usuario_id] [varchar](10) NOT NULL,
 CONSTRAINT [rolusuario_usuarios_pk] PRIMARY KEY CLUSTERED 
(
	[Rolusuario_id] ASC,
	[Usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoConsecutivo]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoConsecutivo](
	[TipoConsecutivo_id] [int] NOT NULL,
	[nombre] [varchar](200) NOT NULL,
 CONSTRAINT [tipoconsecutivo_pk] PRIMARY KEY CLUSTERED 
(
	[TipoConsecutivo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Usuario_id] [varchar](10) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[Primer_Apellido] [varchar](200) NOT NULL,
	[Segundo_Apellido] [varchar](200) NOT NULL,
	[Celular] [varchar](100) NOT NULL,
	[urlFirma] [varchar](1600) NOT NULL,
	[urlFoto] [varchar](1600) NOT NULL,
	[Usuario] [varchar](200) NOT NULL,
	[Password] [varchar](400) NOT NULL,
	[Puesto_Id] [varchar](10) NOT NULL,
	[NivelAcademico_Id] [varchar](10) NOT NULL,
 CONSTRAINT [usuario_pk] PRIMARY KEY CLUSTERED 
(
	[Usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [consecutivo__idx]    Script Date: 14/07/2019 21:23:51 ******/
CREATE UNIQUE NONCLUSTERED INDEX [consecutivo__idx] ON [dbo].[Consecutivo]
(
	[TipoConsecutivo_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD  CONSTRAINT [bitacora_usuario_fk] FOREIGN KEY([Usuario_Id])
REFERENCES [dbo].[Usuario] ([Usuario_id])
GO
ALTER TABLE [dbo].[Bitacora] CHECK CONSTRAINT [bitacora_usuario_fk]
GO
ALTER TABLE [dbo].[BitacoraExperimental]  WITH CHECK ADD  CONSTRAINT [bitacoraexperimental_proyecto_fk] FOREIGN KEY([Proyecto_Id])
REFERENCES [dbo].[Proyecto] ([Proyecto_id])
GO
ALTER TABLE [dbo].[BitacoraExperimental] CHECK CONSTRAINT [bitacoraexperimental_proyecto_fk]
GO
ALTER TABLE [dbo].[BitacoraExperimental]  WITH CHECK ADD  CONSTRAINT [bitacoraexperimental_usuario_fk] FOREIGN KEY([Usuario_Crea])
REFERENCES [dbo].[Usuario] ([Usuario_id])
GO
ALTER TABLE [dbo].[BitacoraExperimental] CHECK CONSTRAINT [bitacoraexperimental_usuario_fk]
GO
ALTER TABLE [dbo].[BitacoraExperimental]  WITH CHECK ADD  CONSTRAINT [bitacoraexperimental_usuario_fkv2] FOREIGN KEY([Usuario_Testigo])
REFERENCES [dbo].[Usuario] ([Usuario_id])
GO
ALTER TABLE [dbo].[BitacoraExperimental] CHECK CONSTRAINT [bitacoraexperimental_usuario_fkv2]
GO
ALTER TABLE [dbo].[Consecutivo]  WITH CHECK ADD  CONSTRAINT [consecutivo_tipoconsecutivo_fk] FOREIGN KEY([TipoConsecutivo_Id])
REFERENCES [dbo].[TipoConsecutivo] ([TipoConsecutivo_id])
GO
ALTER TABLE [dbo].[Consecutivo] CHECK CONSTRAINT [consecutivo_tipoconsecutivo_fk]
GO
ALTER TABLE [dbo].[Error]  WITH CHECK ADD  CONSTRAINT [error_usuario_fk] FOREIGN KEY([Usuario_Id])
REFERENCES [dbo].[Usuario] ([Usuario_id])
GO
ALTER TABLE [dbo].[Error] CHECK CONSTRAINT [error_usuario_fk]
GO
ALTER TABLE [dbo].[Proyecto]  WITH CHECK ADD  CONSTRAINT [proyecto_ramacientifica_fk] FOREIGN KEY([RamaCientifica_Id])
REFERENCES [dbo].[RamaCientifica] ([RamaCientifica_id])
GO
ALTER TABLE [dbo].[Proyecto] CHECK CONSTRAINT [proyecto_ramacientifica_fk]
GO
ALTER TABLE [dbo].[Puesto]  WITH CHECK ADD  CONSTRAINT [puesto_rollaboratorio_fk] FOREIGN KEY([RolLaboratorio_Id])
REFERENCES [dbo].[RolLaboratorio] ([RolLaboratorio_id])
GO
ALTER TABLE [dbo].[Puesto] CHECK CONSTRAINT [puesto_rollaboratorio_fk]
GO
ALTER TABLE [dbo].[Rolusuario_Usuarios]  WITH CHECK ADD  CONSTRAINT [rolusuario_usuarios_rolusuario_fk] FOREIGN KEY([Rolusuario_id])
REFERENCES [dbo].[RolUsuario] ([RolUsuario_id])
GO
ALTER TABLE [dbo].[Rolusuario_Usuarios] CHECK CONSTRAINT [rolusuario_usuarios_rolusuario_fk]
GO
ALTER TABLE [dbo].[Rolusuario_Usuarios]  WITH CHECK ADD  CONSTRAINT [rolusuario_usuarios_usuario_fk] FOREIGN KEY([Usuario_id])
REFERENCES [dbo].[Usuario] ([Usuario_id])
GO
ALTER TABLE [dbo].[Rolusuario_Usuarios] CHECK CONSTRAINT [rolusuario_usuarios_usuario_fk]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [usuario_nivelacademico_fk] FOREIGN KEY([NivelAcademico_Id])
REFERENCES [dbo].[NivelAcademico] ([NivelAcademico_id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [usuario_nivelacademico_fk]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [usuario_puesto_fk] FOREIGN KEY([Puesto_Id])
REFERENCES [dbo].[Puesto] ([Puesto_id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [usuario_puesto_fk]
GO
/****** Object:  StoredProcedure [dbo].[sp_Actualiza_BitacoraExperimental]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Actualiza_BitacoraExperimental]

	@Experimento_id varchar(10),
	@Nombre varchar(400),
	@FechaInicio varchar(100),
	@FechaFin varchar(100),
	@urlMuestra1 varchar(800),
	@urlMuestra2 varchar(800),
	@urlMuestra3 varchar(800),
	@urlMuestra4 varchar(800),
	@urlMuestra5 varchar(800),
	@Detalle1 varchar(8000),
	@Detalle2 varchar(8000),
	@Usuario_Crea varchar(10),
	@Usuario_Testigo varchar(10),
	@Proyecto_Id varchar(10),
	@Password varchar(200)

AS
BEGIN
	
	SET NOCOUNT ON;

	UPDATE BitacoraExperimental
	SET	Nombre = ENCRYPTBYPASSPHRASE(@Password,@Nombre),
		FechaInicio = ENCRYPTBYPASSPHRASE(@Password,@FechaInicio),
		FechaFin = ENCRYPTBYPASSPHRASE(@Password,@FechaFin),
		urlMuestra1 = ENCRYPTBYPASSPHRASE(@Password,@urlMuestra1),
		urlMuestra2 = ENCRYPTBYPASSPHRASE(@Password,@urlMuestra2),
		urlMuestra3 = ENCRYPTBYPASSPHRASE(@Password,@urlMuestra3),
		urlMuestra4 = ENCRYPTBYPASSPHRASE(@Password,@urlMuestra4),
		urlMuestra5 = ENCRYPTBYPASSPHRASE(@Password,@urlMuestra5),
		Detalle1 = ENCRYPTBYPASSPHRASE(@Password,@Detalle1),
		Detalle2 = ENCRYPTBYPASSPHRASE(@Password,@Detalle2),
		Usuario_Crea = @Usuario_Crea,
		Usuario_Testigo = @Usuario_Testigo,
		Proyecto_Id = @Proyecto_Id
	WHERE Experimento_id = @Experimento_id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Actualiza_Consecutivo]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Actualiza_Consecutivo]

	@Consecutivo_id int,
	@nombre varchar(400),
	@Consecutivo varchar(100),
	@PoseePrefijo varchar(100),
	@Prefijo varchar(100),
	@PoseeRanGO varchar(100),
	@Inicio varchar(100),
	@Fin varchar(100),
	@TipoConsecutivo_Id int,
	@Password varchar(200)

AS
BEGIN
	
	SET NOCOUNT ON;

	UPDATE Consecutivo
	SET nombre = ENCRYPTBYPASSPHRASE(@Password,@nombre),
		Consecutivo = ENCRYPTBYPASSPHRASE(@Password,@Consecutivo),
		PoseePrefijo = ENCRYPTBYPASSPHRASE(@Password,@PoseePrefijo),
		Prefijo = ENCRYPTBYPASSPHRASE(@Password,@Prefijo),
		PoseeRanGO = ENCRYPTBYPASSPHRASE(@Password,@PoseeRanGO),
		Inicio = ENCRYPTBYPASSPHRASE(@Password,@Inicio),
		Fin = ENCRYPTBYPASSPHRASE(@Password,@Fin),
		TipoConsecutivo_Id = @TipoConsecutivo_Id
	WHERE Consecutivo_id = @Consecutivo_id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Actualiza_NivelAcademico]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Actualiza_NivelAcademico]

	@NivelAcademico_id varchar(10),
	@Nombre varchar(400),
	@Detalle varchar(800),
	@Completo varchar(100),
	@Password varchar(200)

AS
BEGIN
	
	SET NOCOUNT ON;

	UPDATE NivelAcademico
	SET Nombre = ENCRYPTBYPASSPHRASE(@Password,@Nombre),

		Detalle = ENCRYPTBYPASSPHRASE(@Password,@Detalle),
		Completo = ENCRYPTBYPASSPHRASE(@Password,@Completo)

	WHERE NivelAcademico_id = @NivelAcademico_id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Actualiza_Proyecto]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Actualiza_Proyecto]

	@Proyecto_id varchar(10),
	@Nombre varchar(400),
	@RamaCientifica_Id varchar(10),
	@Precio varchar(400),
	@Idioma varchar(100),
	@Password varchar(200)

AS
BEGIN
	
	SET NOCOUNT ON;

	UPDATE Proyecto
	SET Nombre = ENCRYPTBYPASSPHRASE(@Password,@Nombre),
RamaCientifica_Id = @RamaCientifica_Id,
Precio = ENCRYPTBYPASSPHRASE(@Password,@Precio),
Idioma = ENCRYPTBYPASSPHRASE(@Password,@Idioma)

	WHERE Proyecto_id = @Proyecto_id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Actualiza_Puesto]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Actualiza_Puesto]

	@Puesto_id varchar(10),
	@Nombre varchar(400),
	@RolLaboratorio_Id varchar(10),

	@Password varchar(200)

AS
BEGIN
	
	SET NOCOUNT ON;

	UPDATE Puesto
	SET Nombre = ENCRYPTBYPASSPHRASE(@Password,@Nombre),
RolLaboratorio_Id = @RolLaboratorio_Id


	WHERE Puesto_id = @Puesto_id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Actualiza_RamaCientifica]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Actualiza_RamaCientifica]


	@RamaCientifica_id varchar(10),
	@Nombre varchar(400),
	@Password varchar(200)

AS
BEGIN
	
	SET NOCOUNT ON;

	UPDATE RamaCientifica
	SET Nombre = ENCRYPTBYPASSPHRASE(@Password,@Nombre)

	WHERE RamaCientifica_id = @RamaCientifica_id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Actualiza_RolLaboratorio]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Actualiza_RolLaboratorio]

	@RolLaboratorio_id varchar(10),
	@Nombre varchar(400),
	@detalle varchar(600),
	@Password varchar(200)

AS
BEGIN
	
	SET NOCOUNT ON;

	UPDATE RolLaboratorio
	SET Nombre = ENCRYPTBYPASSPHRASE(@Password,@Nombre),
		detalle = ENCRYPTBYPASSPHRASE(@Password,@detalle)

	WHERE RolLaboratorio_id = @RolLaboratorio_id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Actualiza_RolUsuario]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Actualiza_RolUsuario]

	@RolUsuario_id int,
	@nombre varchar(200),
	@descripcion varchar(400),
	@Password varchar(200)

AS
BEGIN
	
	SET NOCOUNT ON;

	UPDATE RolUsuario
	SET nombre = ENCRYPTBYPASSPHRASE(@Password,@nombre),
		descripcion = ENCRYPTBYPASSPHRASE(@Password,@descripcion)


	WHERE RolUsuario_id = @RolUsuario_id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Actualiza_TipoConsecutivo]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Actualiza_TipoConsecutivo]

	@TipoConsecutivo_id int,
	@nombre varchar(200),
	@Password varchar(200)

AS
BEGIN
	
	SET NOCOUNT ON;

	UPDATE TipoConsecutivo
	SET nombre = ENCRYPTBYPASSPHRASE(@Password,@nombre)

	WHERE TipoConsecutivo_id = @TipoConsecutivo_id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Actualiza_Usuario]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Actualiza_Usuario]

	@Usuario_id varchar(10),
	@Nombre varchar(200),
	@Primer_Apellido varchar(200),
	@Segundo_Apellido varchar(200),
	@Celular varchar(100),
	@urlFirma varchar(1600),
	@urlFoto varchar(1600),
	@Usuario varchar(200),
	@Password varchar(400),
	@Puesto_Id varchar(10),
	@NivelAcademico_Id varchar(10),
	@PasswordE varchar(200)

AS
BEGIN
	
	SET NOCOUNT ON;

	UPDATE Usuario
	SET Nombre = ENCRYPTBYPASSPHRASE(@PasswordE,@Nombre),
		Primer_Apellido = ENCRYPTBYPASSPHRASE(@PasswordE,@Primer_Apellido),
		Segundo_Apellido = ENCRYPTBYPASSPHRASE(@PasswordE,@Segundo_Apellido),
		Celular = ENCRYPTBYPASSPHRASE(@PasswordE,@Celular),
		urlFirma = ENCRYPTBYPASSPHRASE(@PasswordE,@urlFirma),
		urlFoto = ENCRYPTBYPASSPHRASE(@PasswordE,@urlFoto),
		Usuario = @Usuario,
		Password = ENCRYPTBYPASSPHRASE(@PasswordE,@Password),
		Puesto_Id = @Puesto_Id,
		NivelAcademico_Id = @NivelAcademico_Id


	WHERE Usuario_id = @Usuario_id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Carga_Bitacora]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Carga_Bitacora]

	@Password varchar(200),
	@Bitacora_id varchar(10)

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT   Bitacora_id
			,Fecha
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Tipo)) AS 'Tipo'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Descripcion)) AS 'Descripcion'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,RegistroDetallado)) AS 'RegistroDetallado'
			,Usuario_Id
	FROM Bitacora
	WHERE Bitacora_id=@Bitacora_id
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Carga_BitacoraExperimental]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Carga_BitacoraExperimental]

	@Password varchar(200),
	@Experimento_id varchar(10)

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT  Experimento_id
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Nombre)) AS 'Nombre'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,FechaInicio)) AS 'FechaInicio'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,FechaFin)) AS 'FechaFin'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,urlMuestra1)) AS 'urlMuestra1'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,urlMuestra2)) AS 'urlMuestra2'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,urlMuestra3)) AS 'urlMuestra3'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,urlMuestra4)) AS 'urlMuestra4'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,urlMuestra5)) AS 'urlMuestra5'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Detalle1)) AS 'Detalle1'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Detalle2)) AS 'Detalle2'
			,Usuario_Crea
			,Usuario_Testigo
			,Proyecto_Id

	FROM BitacoraExperimental
	WHERE Experimento_id = @Experimento_id
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Carga_Consecutivo]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Carga_Consecutivo]

	@Password varchar(200),
	@Consecutivo_id int

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT  Consecutivo_id
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,nombre)) AS 'nombre'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Consecutivo)) AS 'Consecutivo'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,PoseePrefijo)) AS 'PoseePrefijo'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Prefijo)) AS 'Prefijo'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,PoseeRanGO)) AS 'PoseeRanGO'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Inicio)) AS 'Inicio'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Fin)) AS 'Fin'
			,TipoConsecutivo_Id


	FROM Consecutivo
	WHERE Consecutivo_id = @Consecutivo_id
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Carga_Error]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Carga_Error]

	@Password varchar(200),
	@Error_id int

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT  Error_id
			Fecha
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Tabla)) AS 'Tabla'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Descripcion)) AS 'Descripcion'
			,Usuario_Id
	FROM Error
	WHERE Error_id = @Error_id
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Carga_NivelAcademico]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Carga_NivelAcademico]

	@Password varchar(200),
	@NivelAcademico_id varchar(10)

AS
BEGIN
	
	SET NOCOUNT ON;

		SELECT  NivelAcademico_id
		,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Nombre)) AS 'Nombre'
		,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Detalle)) AS 'Detalle'
		,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Completo)) AS 'Completo'


	FROM NivelAcademico
	WHERE NivelAcademico_id = @NivelAcademico_id
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Carga_Proyecto]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Carga_Proyecto]

	@Password varchar(200),
	@Proyecto_id varchar(10)

AS
BEGIN
	
	SET NOCOUNT ON;

			SELECT Proyecto_id
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Nombre)) AS 'Nombre'
,RamaCientifica_Id
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Precio)) AS 'Precio'
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Idioma)) AS 'Idioma'

	FROM Proyecto
	WHERE Proyecto_id = @Proyecto_id
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Carga_Puesto]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Carga_Puesto]

	@Password varchar(200),
	@Puesto_id varchar(10)

AS
BEGIN
	
	SET NOCOUNT ON;

			SELECT Puesto_id
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Nombre)) AS 'Nombre'
,RolLaboratorio_Id


	FROM Puesto
	WHERE Puesto_id = @Puesto_id
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Carga_RamaCientifica]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Carga_RamaCientifica]

	@Password varchar(200),
	@RamaCientifica_id varchar(10)

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT RamaCientifica_id
		  ,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Nombre)) AS 'Nombre'

	FROM RamaCientifica
	WHERE RamaCientifica_id = @RamaCientifica_id
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Carga_RolLaboratorio]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Carga_RolLaboratorio]

	@Password varchar(200),
	@RolLaboratorio_id varchar(10)

AS
BEGIN
	
	SET NOCOUNT ON;

		SELECT RolLaboratorio_id
		,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Nombre)) AS 'Nombre'
		,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,detalle)) AS 'detalle'

	FROM RolLaboratorio
	WHERE RolLaboratorio_id = @RolLaboratorio_id
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Carga_RolUsuario]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Carga_RolUsuario]

	@Password varchar(200),
	@RolUsuario_id int

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT RolUsuario_id
	,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,nombre)) AS 'nombre'
	,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,descripcion)) AS 'descripcion'

	FROM RolUsuario
	WHERE RolUsuario_id = @RolUsuario_id
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Carga_RolUsuario_Usuario]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Carga_RolUsuario_Usuario]

	@Password varchar(200),
	@Usuario_id varchar(10)

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT *

	FROM Rolusuario_Usuarios
	WHERE Usuario_id = @Usuario_id
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Carga_TipoConsecutivo]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Carga_TipoConsecutivo]

	@Password varchar(200),
	@TipoConsecutivo_id int

AS
BEGIN
	
	SET NOCOUNT ON;

		SELECT TipoConsecutivo_id
		,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,nombre)) AS 'nombre'

	FROM TipoConsecutivo
	WHERE TipoConsecutivo_id = @TipoConsecutivo_id
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Carga_Usuario]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Carga_Usuario]

	@Password varchar(200),
	@Usuario_id varchar(10)

AS
BEGIN
	
	SET NOCOUNT ON;

			SELECT Usuario_id
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Nombre)) AS 'Nombre'
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Primer_Apellido)) AS 'Primer_Apellido'
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Segundo_Apellido)) AS 'Segundo_Apellido'
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Celular)) AS 'Celular'
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,urlFirma)) AS 'urlFirma'
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,urlFoto)) AS 'urlFoto'
,Usuario
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Password)) AS 'Password'
,Puesto_Id
,NivelAcademico_Id


	FROM Usuario
	WHERE Usuario_id = @Usuario_id
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Elimina_BitacoraExperimental]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Elimina_BitacoraExperimental]

	@Experimento_id varchar(10)

AS
BEGIN
	
	SET NOCOUNT ON;

	DELETE FROM BitacoraExperimental
	WHERE Experimento_id = @Experimento_id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Elimina_Consecutivo]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Elimina_Consecutivo]

	@Consecutivo_id int

AS
BEGIN
	
	SET NOCOUNT ON;

	DELETE FROM Consecutivo
	WHERE Consecutivo_id = @Consecutivo_id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Elimina_NivelAcademico]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Elimina_NivelAcademico]

	@NivelAcademico_id varchar(10)

AS
BEGIN
	
	SET NOCOUNT ON;

	DELETE FROM NivelAcademico
	WHERE NivelAcademico_id = @NivelAcademico_id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Elimina_Proyecto]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Elimina_Proyecto]

	@Proyecto_id varchar(10)

AS
BEGIN
	
	SET NOCOUNT ON;

	DELETE FROM Proyecto
	WHERE Proyecto_id = @Proyecto_id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Elimina_Puesto]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Elimina_Puesto]

	@Puesto_id varchar(10)

AS
BEGIN
	
	SET NOCOUNT ON;

	DELETE FROM Puesto
	WHERE Puesto_id = @Puesto_id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Elimina_RamaCientifica]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Elimina_RamaCientifica]

	@RamaCientifica_id varchar(10)

AS
BEGIN
	
	SET NOCOUNT ON;

	DELETE FROM RamaCientifica
	WHERE RamaCientifica_id = @RamaCientifica_id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Elimina_RolLaboratorio]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Elimina_RolLaboratorio]

	@RolLaboratorio_id varchar(10)

AS
BEGIN
	
	SET NOCOUNT ON;

	DELETE FROM RolLaboratorio
	WHERE RolLaboratorio_id = @RolLaboratorio_id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Elimina_RolUsuario]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Elimina_RolUsuario]

	@RolUsuario_id int

AS
BEGIN
	
	SET NOCOUNT ON;

	DELETE FROM RolUsuario
	WHERE RolUsuario_id = @RolUsuario_id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Elimina_RolUsuario_Usuario]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Elimina_RolUsuario_Usuario]

	@Rolusuario_id int,
	@Usuario_id varchar(10)

AS
BEGIN
	
	SET NOCOUNT ON;

	DELETE FROM Rolusuario_Usuarios
	WHERE RolUsuario_id = @RolUsuario_id AND Usuario_id = @Usuario_id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Elimina_TipoConsecutivo]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Elimina_TipoConsecutivo]

	@TipoConsecutivo_id int

AS
BEGIN
	
	SET NOCOUNT ON;

	DELETE FROM TipoConsecutivo
	WHERE TipoConsecutivo_id = @TipoConsecutivo_id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Elimina_Usuario]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Elimina_Usuario]

	@Usuario_id varchar(10)

AS
BEGIN
	
	SET NOCOUNT ON;

	DELETE FROM Usuario
	WHERE Usuario_id = @Usuario_id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Inserta_Bitacora]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Inserta_Bitacora]
	
	@Bitacora_id varchar(10),
	@Fecha datetime,
	@Tipo varchar(100),
	@Descripcion varchar(800),
	@RegistroDetallado varchar(1600),
	@Usuario_Id varchar(10),
	@Password varchar(200)

AS
BEGIN

SET NOCOUNT ON;

INSERT INTO Bitacora ([Bitacora_id], [Fecha], [Tipo], [Descripcion], [RegistroDetallado], [Usuario_Id])
VALUES(
@Bitacora_id,
@Fecha,
ENCRYPTBYPASSPHRASE(@Password,@Tipo),
ENCRYPTBYPASSPHRASE(@Password,@Descripcion),
ENCRYPTBYPASSPHRASE(@Password,@RegistroDetallado),
@Usuario_Id

)	

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Inserta_BitacoraExperimental]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Inserta_BitacoraExperimental]
	
	@Experimento_id varchar(10),
	@Nombre varchar(400),
	@FechaInicio varchar(100),
	@FechaFin varchar(100),
	@urlMuestra1 varchar(800),
	@urlMuestra2 varchar(800),
	@urlMuestra3 varchar(800),
	@urlMuestra4 varchar(800),
	@urlMuestra5 varchar(800),
	@Detalle1 varchar(8000),
	@Detalle2 varchar(8000),
	@Usuario_Crea varchar(10),
	@Usuario_Testigo varchar(10),
	@Proyecto_Id varchar(10),
	@Password varchar(200)

AS
BEGIN

SET NOCOUNT ON;

INSERT INTO BitacoraExperimental([Experimento_id], [Nombre], [FechaInicio], [FechaFin], [urlMuestra1], [urlMuestra2], [urlMuestra3], [urlMuestra4], [urlMuestra5], [Detalle1], [Detalle2], [Usuario_Crea], [Usuario_Testigo], [Proyecto_Id])
VALUES(
@Experimento_id,
ENCRYPTBYPASSPHRASE(@Password,@Nombre),
ENCRYPTBYPASSPHRASE(@Password,@FechaInicio),
ENCRYPTBYPASSPHRASE(@Password,@FechaFin),
ENCRYPTBYPASSPHRASE(@Password,@urlMuestra1),
ENCRYPTBYPASSPHRASE(@Password,@urlMuestra2),
ENCRYPTBYPASSPHRASE(@Password,@urlMuestra3),
ENCRYPTBYPASSPHRASE(@Password,@urlMuestra4),
ENCRYPTBYPASSPHRASE(@Password,@urlMuestra5),
ENCRYPTBYPASSPHRASE(@Password,@Detalle1),
ENCRYPTBYPASSPHRASE(@Password,@Detalle2),
@Usuario_Crea,
@Usuario_Testigo,
@Proyecto_Id
)	

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Inserta_Consecutivo]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Inserta_Consecutivo]
	
	@Consecutivo_id int,
	@nombre varchar(400),
	@Consecutivo varchar(100),
	@PoseePrefijo varchar(100),
	@Prefijo varchar(100),
	@PoseeRanGO varchar(100),
	@Inicio varchar(100),
	@Fin varchar(100),
	@TipoConsecutivo_Id int,
	@Password varchar(200)

AS
BEGIN

SET NOCOUNT ON;

INSERT INTO Consecutivo([Consecutivo_id], [nombre], [Consecutivo], [PoseePrefijo], [Prefijo], [PoseeRanGO], [Inicio], [Fin], [TipoConsecutivo_Id])
VALUES(
@Consecutivo_id,
ENCRYPTBYPASSPHRASE(@Password,@nombre),
ENCRYPTBYPASSPHRASE(@Password,@Consecutivo),
ENCRYPTBYPASSPHRASE(@Password,@PoseePrefijo),
ENCRYPTBYPASSPHRASE(@Password,@Prefijo),
ENCRYPTBYPASSPHRASE(@Password,@PoseeRanGO),
ENCRYPTBYPASSPHRASE(@Password,@Inicio),
ENCRYPTBYPASSPHRASE(@Password,@Fin),
@TipoConsecutivo_Id
)	

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Inserta_Error]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Inserta_Error]
	

	@Fecha datetime,
	@Tabla varchar(100),
	@Descripcion varchar(800),
	@Usuario_Id varchar(10),
	@Password varchar(200)

AS
BEGIN

SET NOCOUNT ON;

INSERT INTO Error([Fecha], [Tabla], [Descripcion], [Usuario_Id])
VALUES(
@Fecha,
ENCRYPTBYPASSPHRASE(@Password,@Tabla),
ENCRYPTBYPASSPHRASE(@Password,@Descripcion),
@Usuario_Id
)	

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Inserta_NivelAcademico]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Inserta_NivelAcademico]
	

	@NivelAcademico_id varchar(10),
	@Nombre varchar(400),
	@Detalle varchar(800),
	@Completo varchar(100),
	@Password varchar(200)

AS
BEGIN

SET NOCOUNT ON;

INSERT INTO NivelAcademico([NivelAcademico_id], [Nombre], [Detalle], [Completo])
VALUES(
@NivelAcademico_id,
ENCRYPTBYPASSPHRASE(@Password,@Nombre),
ENCRYPTBYPASSPHRASE(@Password,@Detalle),
ENCRYPTBYPASSPHRASE(@Password,@Completo)
)	

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Inserta_Proyecto]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Inserta_Proyecto]
	

	@Proyecto_id varchar(10),
	@Nombre varchar(400),
	@RamaCientifica_Id varchar(10),
	@Precio varchar(400),
	@Idioma varchar(100),
	@Password varchar(200)

AS
BEGIN

SET NOCOUNT ON;

INSERT INTO Proyecto([Proyecto_id], [Nombre], [RamaCientifica_Id], [Precio], [Idioma])
VALUES(
@Proyecto_id,
ENCRYPTBYPASSPHRASE(@Password,@Nombre),
@RamaCientifica_Id,
ENCRYPTBYPASSPHRASE(@Password,@Precio),
ENCRYPTBYPASSPHRASE(@Password,@Idioma)
)	

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Inserta_Puesto]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Inserta_Puesto]
	

	@Puesto_id varchar(10),
	@Nombre varchar(400),
	@RolLaboratorio_Id varchar(10),
	@Password varchar(200)

AS
BEGIN

SET NOCOUNT ON;

INSERT INTO Puesto([Puesto_id], [Nombre], [RolLaboratorio_Id])
VALUES(
@Puesto_id,
ENCRYPTBYPASSPHRASE(@Password,@Nombre),
@RolLaboratorio_Id
)	

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Inserta_RamaCientifica]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Inserta_RamaCientifica]
	

	@RamaCientifica_id varchar(10),
	@Nombre varchar(400),
	@Password varchar(200)

AS
BEGIN

SET NOCOUNT ON;

INSERT INTO RamaCientifica([RamaCientifica_id], [Nombre])
VALUES(
@RamaCientifica_id,
ENCRYPTBYPASSPHRASE(@Password,@Nombre)
)	

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Inserta_RolLaboratorio]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Inserta_RolLaboratorio]
	

	@RolLaboratorio_id varchar(10),
	@Nombre varchar(400),
	@detalle varchar(600),
	@Password varchar(200)

AS
BEGIN

SET NOCOUNT ON;

INSERT INTO RolLaboratorio([RolLaboratorio_id], [Nombre], [detalle])
VALUES(
@RolLaboratorio_id,
ENCRYPTBYPASSPHRASE(@Password,@Nombre),
ENCRYPTBYPASSPHRASE(@Password,@detalle)
)	

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Inserta_RolUsuario]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Inserta_RolUsuario]
	

	@RolUsuario_id int,
	@nombre varchar(200),
	@descripcion varchar(400),
	@Password varchar(200)

AS
BEGIN

SET NOCOUNT ON;

INSERT INTO RolUsuario([RolUsuario_id], [nombre], [descripcion])
VALUES(
@RolUsuario_id,
ENCRYPTBYPASSPHRASE(@Password,@nombre),
ENCRYPTBYPASSPHRASE(@Password,@descripcion)
)	

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Inserta_RolUsuario_Usuarios]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Inserta_RolUsuario_Usuarios]
	

	@Rolusuario_id int,
	@Usuario_id varchar(10)
	--@Password varchar(200)
AS
BEGIN

SET NOCOUNT ON;

INSERT INTO Rolusuario_Usuarios([Rolusuario_id], [Usuario_id])
VALUES(
@Rolusuario_id,
@Usuario_id
)	

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Inserta_TipoConsecutivo]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Inserta_TipoConsecutivo]
	

	@TipoConsecutivo_id int,
	@nombre varchar(200),
	@Password varchar(200)

AS
BEGIN

SET NOCOUNT ON;

INSERT INTO TipoConsecutivo([TipoConsecutivo_id], [nombre])
VALUES(
@TipoConsecutivo_id,
ENCRYPTBYPASSPHRASE(@Password,@nombre)
)	

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Inserta_Usuario]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Inserta_Usuario]
	

	@Usuario_id varchar(10),
	@Nombre varchar(200),
	@Primer_Apellido varchar(200),
	@Segundo_Apellido varchar(200),
	@Celular varchar(100),
	@urlFirma varchar(1600),
	@urlFoto varchar(1600),
	@Usuario varchar(200),
	@Password varchar(400),
	@Puesto_Id varchar(10),
	@NivelAcademico_Id varchar(10),
	@PasswordE varchar(200)

AS
BEGIN

SET NOCOUNT ON;

INSERT INTO Usuario([Usuario_id], [Nombre], [Primer_Apellido], [Segundo_Apellido], [Celular], [urlFirma], [urlFoto], [Usuario], [Password], [Puesto_Id], [NivelAcademico_Id])
VALUES(
@Usuario_id,
ENCRYPTBYPASSPHRASE(@PasswordE,@Nombre),
ENCRYPTBYPASSPHRASE(@PasswordE,@Primer_Apellido),
ENCRYPTBYPASSPHRASE(@PasswordE,@Segundo_Apellido),
ENCRYPTBYPASSPHRASE(@PasswordE,@Celular),
ENCRYPTBYPASSPHRASE(@PasswordE,@urlFirma),
ENCRYPTBYPASSPHRASE(@PasswordE,@urlFoto),
@Usuario,
ENCRYPTBYPASSPHRASE(@PasswordE,@Password),
@Puesto_Id,
@NivelAcademico_Id
)	

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lista_Bitacora]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Lista_Bitacora]

	@Password varchar(200)
	
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT   Bitacora_id
			,Fecha
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Tipo)) AS 'Tipo'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Descripcion)) AS 'Descripcion'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,RegistroDetallado)) AS 'RegistroDetallado'
			,Usuario_Id
	FROM Bitacora
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lista_Bitacora_Fechas]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Lista_Bitacora_Fechas]

	@Password varchar(200),
	@FechaInicio datetime,
	@FechaFin datetime

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT   Bitacora_id
			,Fecha
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Tipo)) AS 'Tipo'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Descripcion)) AS 'Descripcion'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,RegistroDetallado)) AS 'RegistroDetallado'
			,Usuario_Id
	FROM Bitacora
	WHERE Fecha >= @FechaInicio AND Fecha<= @FechaFin
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lista_Bitacora_Usuario]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Lista_Bitacora_Usuario]

	@Password varchar(200),
	@Usuario_Id varchar(10)

	
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT   Bitacora_id
			,Fecha
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Tipo)) AS 'Tipo'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Descripcion)) AS 'Descripcion'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,RegistroDetallado)) AS 'RegistroDetallado'
			,Usuario_Id
	FROM Bitacora
	WHERE Usuario_Id = @Usuario_Id
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lista_BitacoraExperimental]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Lista_BitacoraExperimental]

	@Password varchar(200)
	
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT  Experimento_id
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Nombre)) AS 'Nombre'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,FechaInicio)) AS 'FechaInicio'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,FechaFin)) AS 'FechaFin'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,urlMuestra1)) AS 'urlMuestra1'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,urlMuestra2)) AS 'urlMuestra2'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,urlMuestra3)) AS 'urlMuestra3'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,urlMuestra4)) AS 'urlMuestra4'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,urlMuestra5)) AS 'urlMuestra5'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Detalle1)) AS 'Detalle1'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Detalle2)) AS 'Detalle2'
			,Usuario_Crea
			,Usuario_Testigo
			,Proyecto_Id

	FROM BitacoraExperimental
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lista_Consecutivo]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Lista_Consecutivo]

	@Password varchar(200)
	
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT  Consecutivo_id
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,nombre)) AS 'nombre'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Consecutivo)) AS 'Consecutivo'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,PoseePrefijo)) AS 'PoseePrefijo'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Prefijo)) AS 'Prefijo'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,PoseeRanGO)) AS 'PoseeRanGO'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Inicio)) AS 'Inicio'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Fin)) AS 'Fin'
			,TipoConsecutivo_Id


	FROM Consecutivo
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lista_Error]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Lista_Error]

	@Password varchar(200)
	
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT  Error_id
			Fecha
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Tabla)) AS 'Tabla'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Descripcion)) AS 'Descripcion'
			,Usuario_Id



	FROM Error
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lista_Error_Fechas]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Lista_Error_Fechas]

	@Password varchar(200),
	@FechaInicio datetime,
	@FechaFin datetime
	
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT  Error_id
			Fecha
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Tabla)) AS 'Tabla'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Descripcion)) AS 'Descripcion'
			,Usuario_Id



	FROM Error
    WHERE Fecha >= @FechaInicio AND Fecha <= @FechaFin
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lista_Error_Usuario]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Lista_Error_Usuario]

	@Password varchar(200),
	@Usuario_id varchar(10)
	
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT  Error_id
			Fecha
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Tabla)) AS 'Tabla'
			,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Descripcion)) AS 'Descripcion'
			,Usuario_Id



	FROM Error
    WHERE Usuario_Id = @Usuario_id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lista_NivelAcademico]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Lista_NivelAcademico]

	@Password varchar(200)

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT  NivelAcademico_id
		,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Nombre)) AS 'Nombre'
		,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Detalle)) AS 'Detalle'
		,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Completo)) AS 'Completo'


	FROM NivelAcademico

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lista_Proyecto]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Lista_Proyecto]

	@Password varchar(200)

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT Proyecto_id
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Nombre)) AS 'Nombre'
,RamaCientifica_Id
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Precio)) AS 'Precio'
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Idioma)) AS 'Idioma'

	FROM Proyecto

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lista_Puesto]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Lista_Puesto]

	@Password varchar(200)

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT Puesto_id
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Nombre)) AS 'Nombre'
,RolLaboratorio_Id


	FROM Puesto

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lista_RamaCientifica]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Lista_RamaCientifica]

	@Password varchar(200)

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT RamaCientifica_id
		  ,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Nombre)) AS 'Nombre'

	FROM RamaCientifica

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lista_RolLaboratorio]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Lista_RolLaboratorio]

	@Password varchar(200)

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT RolLaboratorio_id
		,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Nombre)) AS 'Nombre'
		,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,detalle)) AS 'detalle'

	FROM RolLaboratorio

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lista_RolUsuario]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Lista_RolUsuario]

	@Password varchar(200)

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT RolUsuario_id
	,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,nombre)) AS 'nombre'
	,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,descripcion)) AS 'descripcion'

	FROM RolUsuario

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lista_RolUsuario_Usuarios]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Lista_RolUsuario_Usuarios]

	--@Password varchar(200)

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT *

	FROM Rolusuario_Usuarios

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lista_TipoConsecutivo]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Lista_TipoConsecutivo]

	@Password varchar(200)

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT TipoConsecutivo_id
		,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,nombre)) AS 'nombre'

	FROM TipoConsecutivo

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lista_Usuario]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Lista_Usuario]

	@Password varchar(200)

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT Usuario_id
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Nombre)) AS 'Nombre'
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Primer_Apellido)) AS 'Primer_Apellido'
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Segundo_Apellido)) AS 'Segundo_Apellido'
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Celular)) AS 'Celular'
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,urlFirma)) AS 'urlFirma'
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,urlFoto)) AS 'urlFoto'
,Usuario
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Password)) AS 'Password'
,Puesto_Id
,NivelAcademico_Id


	FROM Usuario

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Login]    Script Date: 14/07/2019 21:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Login]

	@Password varchar(200),
	@Usuario varchar(200)

AS
BEGIN
	
	SET NOCOUNT ON;

			SELECT Usuario_id
,Usuario
,CONVERT(VARCHAR, DECRYPTBYPASSPHRASE(@Password,Password)) AS 'Password'


	FROM Usuario
	WHERE Usuario = @Usuario
    
END
GO
USE [master]
GO
ALTER DATABASE [BCientificas] SET  READ_WRITE 
GO
