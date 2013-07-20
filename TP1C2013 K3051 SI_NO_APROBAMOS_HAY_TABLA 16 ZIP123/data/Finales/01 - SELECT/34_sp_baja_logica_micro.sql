CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_baja_logica_micro
(
	@id_micro int
)
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION baja_logica_micro
		UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
		SET Micros.baja = 1
		WHERE Micros.id_micros = @id_micro
		
		UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Butaca]
		SET Butaca.baja = 1
		WHERE Butaca.id_micro = @id_micro
		
	COMMIT TRANSACTION baja_logica_micro
END

