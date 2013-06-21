CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_micro
(
	@fecha_alta datetime2(7),
	@nro_micro int,
	@modelo nvarchar(50),
	@patente nvarchar(50),
	@id_marca int,
	@id_servicio int,
	@baja_fuera_servicio bit,
	@baja_vida_util bit,
	@fec_fuera_servicio datetime,
	@fec_reinicio_servicio datetime,
	@fec_baja_vida_util datetime,
	@capacidad_kg numeric(18,2),
	@baja bit
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
           ,[baja_fuera_servicio]
           ,[baja_vida_util]
           ,[fec_fuera_servicio]
           ,[fec_reinicio_servicio]
           ,[fec_baja_vida_util]
           ,[capacidad_kg]
           ,[baja])
     VALUES
           (@fecha_alta,
           @nro_micro,
           @modelo,
           @patente,
           @id_marca,
           @id_servicio,
           @baja_fuera_servicio,
           @baja_vida_util,
           @fec_fuera_servicio,
           @fec_reinicio_servicio,
           @fec_baja_vida_util,
           @capacidad_kg,
           @baja)
END