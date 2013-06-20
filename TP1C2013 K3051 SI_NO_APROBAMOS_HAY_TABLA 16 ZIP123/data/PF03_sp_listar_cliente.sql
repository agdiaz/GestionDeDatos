CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_cliente
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
END
