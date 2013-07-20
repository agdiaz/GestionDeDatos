CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_cliente
	@p_dni numeric(18,0)
AS
BEGIN
	SELECT TOP 1 [dni]
      ,[nombre]
      ,[apellido]
      ,[direccion]
      ,[telefono]
      ,[mail]
      ,[fecha_nacimiento]
      ,[es_discapacitado]
      ,[sexo]
      ,[inhabilitado]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
	WHERE Cliente.dni = @p_dni
END

