
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_viajes
	AS
BEGIN
SELECT [id_viaje]
      ,[id_recorrido]
      ,[id_micro]
      ,[fecha_salida]
      ,[fecha_arribo_estimada]
      ,[fecha_arribo]
  FROM [SI_NO_APROBAMOS_HAY_TABLA].[Viaje]
  WHERE [baja] = 0

END

