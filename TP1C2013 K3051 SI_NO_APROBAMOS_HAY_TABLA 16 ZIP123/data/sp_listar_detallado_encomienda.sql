CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_listar_detallado_encomienda
(
	@p_dni numeric(18,0),
	@p_id_encomienda int,
	@p_id_viaje int,
	@p_id_compra int,
	@p_kgs numeric(18,2)
)
AS
BEGIN
	SELECT e.id_encomienda, e.id_viaje, e.id_compra,
			e.id_cancelacion, e.dni, e.peso, e.pre_encomienda,
			e.cancel, e.fecha_cancel, e.motivo_cancel, e.baja
	FROM SI_NO_APROBAMOS_HAY_TABLA.Encomienda e
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Viaje v
		ON e.id_viaje = v.id_viaje
	WHERE ((@p_dni is null) OR (@p_dni=e.dni))
	AND ((@p_id_encomienda is null) OR (e.id_encomienda = @p_id_encomienda))
	AND ((@p_id_viaje IS NULL) OR (e.id_viaje = @p_id_viaje))
	AND ((@p_id_compra IS NULL) OR (e.id_compra = @p_id_compra))
	AND ((@p_kgs IS NULL) OR (e.peso = @p_kgs))
	
END