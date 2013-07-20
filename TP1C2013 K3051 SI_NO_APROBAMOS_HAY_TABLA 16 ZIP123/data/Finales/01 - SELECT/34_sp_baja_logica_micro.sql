CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_baja_logica_micro
(
	@id_micro int
)
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION baja_logica_micro
				
	DECLARE @idCompraAct int

	DECLARE cur_compras CURSOR LOCAL for
	SELECT DISTINCT c.id_compra
	FROM SI_NO_APROBAMOS_HAY_TABLA.Viaje v
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
		ON p.id_viaje = v.id_viaje
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Encomienda e
		ON e.id_viaje = v.id_viaje
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Compra c
		ON p.id_compra = c.id_compra
		OR e.id_compra = c.id_compra
	WHERE v.id_micro = @id_micro
	AND v.baja = 0
	AND p.baja = 0
	AND p.fecha_cancel is null
	AND e.baja = 0
	AND e.fecha_cancel is null

	open cur_compras

	fetch next from cur_compras into @idCompraAct

	while @@FETCH_STATUS = 0 
	BEGIN
		exec SI_NO_APROBAMOS_HAY_TABLA.sp_cancelar_compra @idCompraAct, 'Baja de micro' 
		fetch next from cur_compras into @idCompraAct 
	END

		
		
		
		UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
		SET Micros.baja = 1
		WHERE Micros.id_micros = @id_micro
		
		UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Butaca]
		SET Butaca.baja = 1
		WHERE Butaca.id_micro = @id_micro
		
	COMMIT TRANSACTION baja_logica_micro
END

