CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_servicio
AS
BEGIN
	SELECT [id_servicio]
      ,[tipo_servicio]
      ,[pocent_adic]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Servicio]
END

