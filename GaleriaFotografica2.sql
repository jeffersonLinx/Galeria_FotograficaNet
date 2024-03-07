create database GaleriaFotografica2;
go
use GaleriaFotografica2;
go

--base de datos para galeria fotografica db2

CREATE TABLE [dbo].[trnPersona](
	[IdPersona] [int] IDENTITY(1,1) PRIMARY KEY,
	[Paterno] [nvarchar](100) NULL,
	[Materno] [nvarchar](100) NULL,
	[Nombres] [nvarchar](150) NULL,
	[NroDocumento] [char](15) NULL,
	[FechaNacimiento] [date] NULL,
	[Celular] [char](10) NULL,
	[CorreoElectronico] [nvarchar](80) NULL,
	[IdTipoPersona] [int] NULL,
	[FechaRegistro] [datetime] NULL,
	[EstadoRegistro] [bit] NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[trnUsuario](
	[IdUsuario] [int] IDENTITY(1,1) PRIMARY KEY,
	[NombreUsuario] [nvarchar](50) NULL,
	[Clave] [nvarchar](100) NULL,
	[Salt] [nvarchar](10) NULL,
	[Telefono] [varchar](20) NULL,
	[Cedula] [varchar](20) NULL,
	[FechaRegistro] [datetime] NULL,
	[EstadoRegistro] [bit] NULL,
	--
	[IdRol] [int] NULL

) ON [PRIMARY]
GO

CREATE TABLE [dbo].[trnRol](
	[IdRol] [int] IDENTITY(1,1) PRIMARY KEY,
	[NombreRol] [nvarchar](50) NULL,
	[FechaRegistro] [datetime] NULL,
	[EstadoRegistro] [bit] NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[trnRolUsuario](
	[IdRolUsuario] [int] IDENTITY(1,1) PRIMARY KEY,
	[IdRol] [int] NULL,
	[IdUsuario] [int] NULL,
	[IdEstadoRolUsuario] [int] NULL,
	[IdUsuarioCreacion] [int] NULL,
	[FechaBaja] [datetime] NULL,
	[FechaRegistro] [datetime] NULL,
	[EstadoRegistro] [bit] NULL,
	FOREIGN KEY ([IdRol]) REFERENCES [dbo].[trnRol]([IdRol]),
	FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[trnUsuario]([IdUsuario])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[trnCategorias](
	[IdCategorias] [int] IDENTITY(1,1) PRIMARY KEY,
	[Categoria] [varchar](50) NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[trnProyectos](
	[IdProyectos] [int] IDENTITY(1,1) PRIMARY KEY,
	[IdCategorias] [int] NULL,
	[descripcion] [text] NULL,
	[imagenPath] [varchar](255) NULL, -- 
	[nombre] [varchar](255) NULL,
	[fotografo] [nvarchar](255) NULL,
	[EstadoRegistro] [bit] NULL,
	FOREIGN KEY ([IdCategorias]) REFERENCES [dbo].[trnCategorias]([IdCategorias])
) ON [PRIMARY]
GO
--
-- PARTE 2 DE LA BD:

--IN.1
INSERT INTO trnUsuario( NombreUsuario, Clave, Salt,FechaRegistro, EstadoRegistro, Telefono, Cedula)
VALUES ('adm', '810f7770259830ff6c2dee6b7412bbac88628787', 123, 01-01-2024, 1,73139654, 919293 );
--IN.1.2
select * from trnUsuario;
--IN.2
INSERT INTO trnCategorias (Categoria) 
VALUES
( 'astrapto');
-- no crear las de avajo
--( 'flora'),
--( 'fauna'),
--( 'paisaje'),
--( 'artistas');
--IN.2.1
select * from trnCategorias;
-- borrar reguistro
delete from trnCategorias where IdCategorias=9;
-- modificar reguistro
update trnCategorias set Categoria='Artistas' where IdCategorias=4;
---------------
--CONSULTAS COMBINADAS
select * from trnProyectos;
--
delete from trnProyectos where IdProyectos=23;
SELECT p.*, c.IdCategorias AS id_cat, c.Categoria
FROM trnProyectos p
INNER JOIN trnCategorias c ON c.IdCategorias = p.IdCategorias
ORDER BY p.IdProyectos DESC;
--
ALTER TABLE trnUsuario ALTER COLUMN Salt NVARCHAR(100); 

/*dato a registrar en la tabla usuario

1
Usuario	
810f7770259830ff6c2dee6b7412bbac88628787
123

(Alejandro)*/
SELECT * FROM trnUsuario WHERE EstadoRegistro = '1';