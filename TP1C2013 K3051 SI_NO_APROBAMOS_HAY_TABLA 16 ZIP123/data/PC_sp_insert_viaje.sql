CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_viaje
(
	@id_recorrido numeric(18,0),
	@id_micro int,
	@fecha_salida datetime,
	@fecha_arribo_estimada datetime,
	@fecha_arribo datetime,
	@baja bit
)
AS
BEGIN
	INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje]
           ([id_recorrido]
           ,[id_micro]
           ,[fecha_salida]
           ,[fecha_arribo_estimada]
           ,[fecha_arribo]
           ,[baja])
	VALUES
           (@id_recorrido,
           @id_micro,
           @fecha_salida,
           @fecha_arribo_estimada,
           @fecha_arribo,
           @baja)
END
