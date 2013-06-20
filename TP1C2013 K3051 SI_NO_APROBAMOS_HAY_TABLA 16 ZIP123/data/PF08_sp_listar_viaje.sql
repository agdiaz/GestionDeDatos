
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_viaje
	AS
BEGIN
	SELECT [id_viaje]
      ,[id_recorrido]
      ,[id_micro]
      ,[fecha_salida]
      ,[fecha_arribo_estimada]
      ,[fecha_arribo]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje]
END

