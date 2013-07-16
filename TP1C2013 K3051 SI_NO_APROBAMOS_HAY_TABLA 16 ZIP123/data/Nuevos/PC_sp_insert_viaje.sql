CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_viaje
(
	@p_id_recorrido numeric(18,0),
	@p_id_micro int,
	@p_fecha_salida datetime,
	@p_fecha_arribo_estimada datetime,
	@p_fecha_arribo datetime,
	@p_id int output
)
AS
BEGIN

	IF (@p_fecha_salida > GETDATE())
	BEGIN
	INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje]
           ([id_recorrido]
           ,[id_micro]
           ,[fecha_salida]
           ,[fecha_arribo_estimada]
           ,[fecha_arribo]
          )
	VALUES
           (@p_id_recorrido,
           @p_id_micro,
           @p_fecha_salida,
           @p_fecha_arribo_estimada,
           @p_fecha_arribo
           )
           
	SET @p_id = SCOPE_IDENTITY()
	END
END
