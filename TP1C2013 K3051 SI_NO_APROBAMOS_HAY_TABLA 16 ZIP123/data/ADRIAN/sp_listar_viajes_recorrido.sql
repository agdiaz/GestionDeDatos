CREATE PROCEDURE sp_listar_viajes_recorrido
(
	@p_recorrido_id int
)
AS
BEGIN
SELECT [id_viaje]
      ,[id_recorrido]
      ,[id_micro]
      ,[fecha_salida]
      ,[fecha_arribo_estimada]
      ,[fecha_arribo]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje]
  WHERE id_recorrido = @p_recorrido_id
  AND baja = 0
END
GO


