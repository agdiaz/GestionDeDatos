CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_recorrido
	AS
BEGIN
	SELECT [id_recorrido]
      ,[id_ciudad_origen]
      ,[id_ciudad_destino]
      ,[pre_base_kg]
      ,[pre_base_pasaje]
      ,[id_servicio]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido]
  WHERE [baja] = 0
END
