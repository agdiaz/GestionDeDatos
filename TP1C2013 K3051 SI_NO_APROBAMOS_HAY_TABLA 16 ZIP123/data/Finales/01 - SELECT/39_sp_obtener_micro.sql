CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_micro
	@p_id int
AS
BEGIN
	SELECT TOP 1 [id_micros]
      ,[fecha_alta]
      ,[nro_micro]
      ,[modelo]
      ,[patente]
      ,[id_marca]
      ,[id_servicio]
      ,[baja_vida_util]
      ,[fec_baja_vida_util]
      ,[capacidad_kg]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
  WHERE id_micros = @p_id
END
GO
