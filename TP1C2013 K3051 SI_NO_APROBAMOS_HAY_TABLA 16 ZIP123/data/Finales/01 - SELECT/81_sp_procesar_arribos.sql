CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_procesar_arribos
AS
BEGIN
	DECLARE @id_viaje int
	DECLARE @fecha_arribo_real datetime
	
	DECLARE Cursor_arribos Cursor FOR
		SELECT Id_viaje, Fecha_arribo_real
		FROM SI_NO_APROBAMOS_HAY_TABLA.ArribosTemporal
	BEGIN TRY
		BEGIN TRAN
			OPEN Cursor_arribos
			Fetch NEXT FROM Cursor_arribos INTO @id_viaje, @fecha_arribo_real
			While (@@FETCH_STATUS <> -1)
			BEGIN
				UPDATE SI_NO_APROBAMOS_HAY_TABLA.Viaje
				SET fecha_arribo = @fecha_arribo_real
				WHERE id_viaje = @id_viaje	
			END 
		COMMIT
	END TRY
	BEGIN CATCH 
		ROLLBACK
	END CATCH	
END