CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_update_viaje]
	@p_Fecha_Salida datetime,
	@p_Fecha_Arribo_Estimada datetime,
	@p_id_micro int,
	@p_id_recorrido int,
	@p_id int
AS
BEGIN
UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje]
   SET [id_recorrido] = @p_id_recorrido
      ,[id_micro] = @p_id_micro
      ,[fecha_salida] = @p_Fecha_Salida
      ,[fecha_arribo_estimada] = @p_Fecha_Arribo_Estimada 
 WHERE id_viaje = @p_id
END

