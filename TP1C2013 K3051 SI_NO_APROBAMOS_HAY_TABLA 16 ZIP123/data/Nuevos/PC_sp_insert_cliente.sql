CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_cliente
(
	@p_dni numeric(18,0),
	@p_nombre nvarchar(255),
	@p_apellido nvarchar(255),
	@p_direccion nvarchar(255),
	@p_telefono numeric(18,0),
	@p_mail nvarchar(255),
	@p_fecha_nacimiento datetime,
	@p_es_discapacitado char(1),
	@p_sexo varchar(50)
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
           (@p_dni
           ,@p_nombre
           ,@p_apellido
           ,@p_direccion
           ,@p_telefono
           ,@p_mail
           ,@p_fecha_nacimiento
           ,@p_es_discapacitado
           ,@p_sexo)
END
