
CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].func_puede_reemplazar_desde
(
	@id_micro_candidato int,
	@fechaInic datetime
)
RETURNS bit 
BEGIN
	IF (
		SELECT COUNT(v.id_viaje) 
		FROM SI_NO_APROBAMOS_HAY_TABLA.Micros m
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Viaje v
			ON m.id_micros = v.id_micro
		WHERE m.id_micros = @id_micro_candidato
		AND v.fecha_salida >= @fechaInic
	) > 0
	BEGIN
		RETURN 0
	END
	RETURN 1
END

GO

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_reemplazar_futuros_por_otro_micro
(
	@id_micro int,
	@id_micro_nuevo int output
)
AS
BEGIN
	DECLARE @modelo nvarchar(50)
	DECLARE @idMarca int
	DECLARE @microElegido int
	
	SELECT @modelo=m.modelo, @idMarca=m.id_marca
	FROM SI_NO_APROBAMOS_HAY_TABLA.Micros m
	WHERE m.id_micros = @id_micro
	
	SELECT TOP 1 @microElegido=m.id_micros 
	FROM SI_NO_APROBAMOS_HAY_TABLA.Micros m
	WHERE m.modelo = @modelo
	AND m.id_marca = @idMarca
	AND [SI_NO_APROBAMOS_HAY_TABLA].func_puede_reemplazar_desde(m.id_micros, GETDATE()) = 1
	AND m.baja = 0
	
	IF @microElegido is not null
	BEGIN
		UPDATE SI_NO_APROBAMOS_HAY_TABLA.Viaje
		SET id_micro = @microElegido
		WHERE id_micro = @id_micro
		AND fecha_salida >= GETDATE()
		SET @id_micro_nuevo = @microElegido
	END
	ELSE
	BEGIN
		SET @id_micro_nuevo = 0
	END
END