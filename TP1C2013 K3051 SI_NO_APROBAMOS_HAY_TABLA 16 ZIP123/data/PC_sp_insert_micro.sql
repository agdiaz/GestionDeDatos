CREATE ALTER PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_micro
(
	@p_fecha_alta datetime2(7),
	@p_nro_micro int,
	@p_modelo nvarchar(50),
	@p_patente nvarchar(50),
	@p_id_marca int,
	@p_id_servicio int,
	@p_baja_vida_util bit,
	@p_fec_baja_vida_util datetime = NULL,
	@p_capacidad_kg numeric(18,2),
	@p_id int output
)
AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
           ([fecha_alta]
           ,[nro_micro]
           ,[modelo]
           ,[patente]
           ,[id_marca]
           ,[id_servicio]
           ,[baja_vida_util]
           ,[fec_baja_vida_util]
           ,[capacidad_kg]
           ,[baja])
     VALUES
           (@p_fecha_alta
           ,@p_nro_micro
           ,@p_modelo
           ,@p_patente
           ,@p_id_marca
           ,@p_id_servicio
           ,@p_baja_vida_util
           ,@p_fec_baja_vida_util
           ,@p_capacidad_kg
           ,0)
	SET @p_id = SCOPE_IDENTITY()
END