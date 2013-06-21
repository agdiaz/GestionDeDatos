CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_ciudad]
(
	@nombre varchar(50),
	@p_id int output
)
AS
BEGIN

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad]
           ([nombre])
     VALUES
           (@nombre)

SET @p_id = SCOPE_IDENTITY()

END

