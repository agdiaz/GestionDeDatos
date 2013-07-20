CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_butaca
(

	@p_nro_butaca numeric(18,0),
	@p_id_micro int,
	@p_tipo_butaca nvarchar(50),
	@p_piso numeric(18,0),
	@p_id int output
)

AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Butaca]
           ([nro_butaca]
           ,[id_micro]
           ,[tipo_butaca]
           ,[piso])
     VALUES
           (@p_nro_butaca
           ,@p_id_micro
           ,@p_tipo_butaca
           ,@p_piso)

SET @p_id = SCOPE_IDENTITY()

END
