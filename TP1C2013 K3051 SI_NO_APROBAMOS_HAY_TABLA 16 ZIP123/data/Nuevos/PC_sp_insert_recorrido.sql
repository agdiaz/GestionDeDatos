CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_recorrido
(
	@p_id int output,
	@p_id_ciudad_origen int,
	@p_id_ciudad_destino int,
	@p_pre_base_kg numeric(18,2),
	@p_pre_base_pasaje numeric(18,2),
	@p_id_servicio int
)
AS
BEGIN
	INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido]
           ([id_ciudad_origen]
           ,[id_ciudad_destino]
           ,[pre_base_kg]
           ,[pre_base_pasaje]
           ,[id_servicio])
	VALUES
           (@p_id_ciudad_origen,
           @p_id_ciudad_destino,
           @p_pre_base_kg,
           @p_pre_base_pasaje,
           @p_id_servicio)
           
	  SET @p_id = SCOPE_IDENTITY()
END