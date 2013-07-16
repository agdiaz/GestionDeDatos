CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_update_cliente
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
UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
SET [nombre]=@p_nombre
           ,[apellido]=@p_apellido
           ,[direccion]=@p_direccion
           ,[telefono]=@p_telefono
           ,[mail]=@p_mail
           ,[fecha_nacimiento]=@p_fecha_nacimiento
           ,[es_discapacitado]=@p_es_discapacitado
           ,[sexo]=@p_sexo
WHERE [dni]=@p_dni
END

