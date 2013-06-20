CREATE PROCEDURE sp_baja_fisica_micro
(
	@id_micro
)
AS
BEGIN
	DELETE FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
	WHERE Micros.id_micros=@id_micro
END
