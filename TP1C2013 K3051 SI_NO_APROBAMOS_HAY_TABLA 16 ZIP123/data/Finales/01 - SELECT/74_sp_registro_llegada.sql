CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_registro_llegada]
(
	@p_id_viaje int,
	@p_fecha_llegada datetime
)
AS
BEGIN
	INSERT INTO [SI_NO_APROBAMOS_HAY_TABLA].[ArribosTemporal]
           ([Id_viaje]
           ,[Fecha_arribo_real])
     VALUES
           (@p_id_viaje, @p_fecha_llegada)
END
