CREATE PROCEDURE sp_baja_logica_micro
(
	@id_micro int
)
AS
BEGIN
	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
	SET Micros.baja = 1
	WHERE Micros.id_micros = @id_micro
END

