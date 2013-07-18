CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_canjear_recompensa
(
	@p_dni numeric(18,0),
	@p_id_recompensa int,
	@p_cantidad	int
)
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION canje_recompensa
	
	DECLARE @puntos_costo int
	DECLARE @puntos_act int
	DECLARE @puntos_usados_act int
	
	SELECT @puntos_costo = (r.puntos_costo * @p_cantidad)
	FROM [SI_NO_APROBAMOS_HAY_TABLA].Recompensa r
	WHERE id_recompensa = @p_id_recompensa
	
	UPDATE [SI_NO_APROBAMOS_HAY_TABLA].Recompensa
	SET stock = stock - @p_cantidad
	WHERE id_recompensa = @p_id_recompensa

	DECLARE CUR_PUNTAJE CURSOR FOR
		SELECT p.puntos, p.puntos_usados
		FROM [SI_NO_APROBAMOS_HAY_TABLA].Puntaje p
		WHERE p.dni = @p_dni
		AND DATEDIFF(year, p.fecha_otorgado, GETDATE()) < 1
		AND (p.puntos -  p.puntos_usados) >0 
		AND baja = 0
		ORDER BY p.fecha_otorgado ASC
		FOR UPDATE OF p.puntos_usados
	
	SET NOCOUNT ON	
	OPEN CUR_PUNTAJE
	FETCH NEXT FROM CUR_PUNTAJE 
	INTO @puntos_act, @puntos_usados_act
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF (@puntos_act - @puntos_usados_act) > @puntos_costo
		BEGIN
			--Hay puntos suficientes aca
			UPDATE [SI_NO_APROBAMOS_HAY_TABLA].Puntaje 
			SET puntos_usados = puntos_usados + @puntos_costo
			WHERE CURRENT OF CUR_PUNTAJE
			SET @puntos_costo = 0
			BREAK 
		END
		ELSE
		BEGIN
			--todavia no hay puntos suficientes en esta linea
			SET @puntos_costo = @puntos_costo - (@puntos_act - @puntos_usados_act)
			UPDATE [SI_NO_APROBAMOS_HAY_TABLA].Puntaje 
			SET puntos_usados = puntos
			WHERE CURRENT OF CUR_PUNTAJE
		END
		
		FETCH NEXT FROM CUR_PUNTAJE 
		INTO @puntos_act, @puntos_usados_act
	END	
	
	IF @puntos_costo = 0
	BEGIN
		COMMIT TRANSACTION canje_recompensa
	END
	ELSE
	BEGIN
		ROLLBACK TRANSACTION canje_recompensa
		RAISERROR('No hay suficientes puntos', 12, 2)
	END
	
	CLOSE CUR_PUNTAJE
	DEALLOCATE CUR_PUNTAJE
END
GO

