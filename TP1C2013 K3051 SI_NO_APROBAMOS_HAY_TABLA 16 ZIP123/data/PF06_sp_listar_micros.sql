CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_micros
AS
BEGIN
	SELECT [id_micros]
      ,[fecha_alta]
      ,[nro_micro]
      ,[modelo]
      ,[patente]
      ,[id_marca]
      ,[id_servicio]
      ,[baja_fuera_servicio]
      ,[baja_vida_util]
      ,[fec_fuera_servicio]
      ,[fec_reinicio_servicio]
      ,[fec_baja_vida_util]
      ,[capacidad_kg]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
END
