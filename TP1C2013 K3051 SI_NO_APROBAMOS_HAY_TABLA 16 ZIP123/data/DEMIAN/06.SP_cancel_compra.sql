CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_cancelar_compra
	@id_compra	int,
	@motivo		nvarchar(200)
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION cancel 
	DECLARE @id_cancel int
	
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Cancelacion
	  (motivo_cancel)
	VALUES (@motivo)
	
	SET @id_cancel = SCOPE_IDENTITY()
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Compra
	SET id_cancelacion = @id_cancel
	WHERE id_compra = @id_compra
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Compra
	SET baja = 1
	WHERE id_compra = @id_compra
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Encomienda
	SET id_cancelacion = @id_cancel
	WHERE id_compra = @id_compra
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Encomienda
	SET baja = 1
	WHERE id_compra = @id_compra
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Pasaje
	SET id_cancelacion = @id_cancel
	WHERE id_compra = @id_compra
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Pasaje
	SET baja = 1
	WHERE id_compra = @id_compra
	
	COMMIT TRANSACTION cancel
END