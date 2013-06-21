CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_cliente
(
	@dni numeric(18,0),
	@nombre nvarchar(255),
	@apellido nvarchar(255),
	@direccion nvarchar(255),
	@telefono numeric(18,0),
	@mail nvarchar(255),
	@fecha_nacimiento datetime,
	@es_discapacitado char(1),
	@sexo varchar(50)
)
AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
           ([dni]
           ,[nombre]
           ,[apellido]
           ,[direccion]
           ,[telefono]
           ,[mail]
           ,[fecha_nacimiento]
           ,[es_discapacitado]
           ,[sexo])
     VALUES
           (@dni
           ,@nombre
           ,@apellido
           ,@direccion
           ,@telefono
           ,@mail
           ,@fecha_nacimiento
           ,@es_discapacitado
           ,@sexo)
END
