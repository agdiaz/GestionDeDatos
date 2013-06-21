CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_recorrido
(
	@id_recorrido int,
	@id_ciudad_origen int,
	@id_ciudad_destino int,
	@pre_base_kg numeric(18,2),
	@pre_base_pasaje numeric(18,2),
	@id_servicio int,
	@baja bit
)
AS
BEGIN
	INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido]
           ([id_recorrido]
           ,[id_ciudad_origen]
           ,[id_ciudad_destino]
           ,[pre_base_kg]
           ,[pre_base_pasaje]
           ,[id_servicio]
           ,[baja])
	VALUES
           (@id_recorrido,
           @id_ciudad_origen,
           @id_ciudad_destino,
           @pre_base_kg,
           @pre_base_pasaje,
           @id_servicio,
           @baja)
END