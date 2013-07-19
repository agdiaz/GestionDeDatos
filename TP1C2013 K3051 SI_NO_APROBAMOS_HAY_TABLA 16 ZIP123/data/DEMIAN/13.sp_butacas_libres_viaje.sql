CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_butacas_libres_viaje
(
	@p_id_viaje int
)
AS
BEGIN
	SELECT b.id_butaca, b.nro_butaca, b.tipo_butaca, b.piso
	FROM SI_NO_APROBAMOS_HAY_TABLA.Butaca b
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Micros m
		ON m.id_micros = b.id_micro
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Viaje v
		ON v.id_micro = m.id_micros
	WHERE v.id_viaje = @p_id_viaje
	AND b.id_butaca NOT IN
		(
			SELECT b.id_butaca
			FROM SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
			INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Butaca b
				ON b.id_butaca = p.id_butaca
			WHERE p.id_viaje = @p_id_viaje	
		)
END