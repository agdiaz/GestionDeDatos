CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_cliente
	@p_dni numeric(18,0) = NULL,
	@p_nombre nvarchar(255) = NULL,
	@p_apellido nvarchar(255) = NULL
AS
BEGIN
	SELECT [dni]
      ,[nombre]
      ,[apellido]
      ,[direccion]
      ,[telefono]
      ,[mail]
      ,[fecha_nacimiento]
      ,[es_discapacitado]
      ,[sexo]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
	where ((@p_dni IS NULL) OR (@p_dni = dni))
	and ((@p_nombre IS NULL) OR (@p_nombre = nombre))
	and ((@p_apellido IS NULL) OR (@p_apellido = apellido))
END
