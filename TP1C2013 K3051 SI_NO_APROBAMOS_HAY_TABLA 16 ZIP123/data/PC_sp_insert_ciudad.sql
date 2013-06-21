CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_ciudad
(
	@nombre varchar(50)
)
AS
BEGIN

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad]
           ([nombre])
     VALUES
           (@nombre)

END

