CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_cancelar_encomienda
	@id_encomienda	numeric(18,0),
	@motivo			nvarchar(200)
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION cancel 
	DECLARE @id_cancel int
	
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Cancelacion
	  (motivo_cancel)
	VALUES (@motivo)
	
	SET @id_cancel = SCOPE_IDENTITY()
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Encomienda
	SET id_cancelacion = @id_cancel
	WHERE id_encomienda= @id_encomienda
	
	COMMIT TRANSACTION cancel
END