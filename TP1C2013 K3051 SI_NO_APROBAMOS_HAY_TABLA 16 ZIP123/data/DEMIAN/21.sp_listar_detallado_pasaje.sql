CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_listar_detallado_pasaje
(
	@p_id_micro int,
	@p_dni numeric(18,0),
	@p_id_butaca int,
	@p_precio numeric(18,2)
)
AS
BEGIN
	SELECT p.id_pasaje, p.id_compra, p.id_butaca,
		p.id_cancelacion, p.dni, p.pre_pasaje,
		p.disponible, p.cancel, p.fecha_cancel,
		p.motivo_cancel, p.id_viaje
	FROM SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Butaca b
		ON p.id_butaca = b.id_butaca
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Micros m
		ON b.id_micro = m.id_micros
	WHERE ((@p_id_micro is null) OR (m.id_micros = @p_id_micro))
	AND ((@p_dni is null) OR (p.dni = @p_dni))
	AND ((@p_id_butaca IS NULL) OR (p.id_butaca = @p_id_butaca))
	AND ((@p_precio IS NULL) OR (p.pre_pasaje = @p_precio))
	
END