
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_baja_recorrido
	@id_recorrido numeric(18,0) 
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION baja_recorrido
	DECLARE @motivo nvarchar(200)
	SET @motivo = 'Baja de recorrido'
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Recorrido 
	SET baja = 1
	WHERE id_recorrido = @id_recorrido
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Viaje
	SET baja = 1
	WHERE id_recorrido = @id_recorrido
	
	--Doy de baja todas las compras del recorrido
	declare @idCompraAct int

	declare cur CURSOR LOCAL for
		SELECT c.id_compra
		FROM SI_NO_APROBAMOS_HAY_TABLA.Compra c
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
			ON p.id_compra = c.id_compra
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Viaje v
			ON p.id_viaje = v.id_viaje
			AND v.id_recorrido = @id_recorrido
		WHERE c.id_cancelacion IS NULL
		
	open cur

	fetch next from cur into @idCompraAct

	while @@FETCH_STATUS = 0 
	BEGIN
		exec SI_NO_APROBAMOS_HAY_TABLA.sp_cancelar_compra @idCompraAct, @motivo
		fetch next from cur into @idCompraAct 
	END

	close cur
	deallocate cur

	COMMIT TRANSACTION baja_recorrido	
END