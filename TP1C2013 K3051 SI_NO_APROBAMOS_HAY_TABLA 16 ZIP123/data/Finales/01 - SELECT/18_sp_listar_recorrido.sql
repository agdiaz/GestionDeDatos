CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_recorrido
	AS
BEGIN
	SELECT r.[id_recorrido]
      ,r.[id_ciudad_origen]
	  ,co.[nombre] as 'nombreOrigen'
      ,r.[id_ciudad_destino]
      ,cd.[nombre] as 'nombreDestino'
	  ,r.[pre_base_kg]
      ,r.[pre_base_pasaje]
      ,r.[id_servicio]
      ,r.[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] r
  INNER JOIN [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] co
	ON r.id_ciudad_origen = co.id_ciudad
  INNER JOIN [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] cd
	ON r.id_ciudad_destino = cd.id_ciudad
  WHERE r.[baja] = 0
END
