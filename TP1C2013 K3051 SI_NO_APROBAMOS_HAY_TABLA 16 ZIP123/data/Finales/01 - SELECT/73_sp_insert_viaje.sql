USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_viaje]    Script Date: 07/18/2013 21:37:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_viaje]
(
	@p_id_recorrido numeric(18,0),
	@p_id_micro int,
	@p_fecha_salida datetime,
	@p_fecha_arribo_estimada datetime,
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
          )
	VALUES
           (@p_id_recorrido,
           @p_id_micro,
           @p_fecha_salida,
           @p_fecha_arribo_estimada
           )
           
	SET @p_id = SCOPE_IDENTITY()
	END
END
