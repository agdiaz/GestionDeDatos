CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_butacas_micro
(
	@p_id_micro int
)
AS
BEGIN
	SELECT b.id_butaca, b.nro_butaca, b.tipo_butaca, b.piso
	FROM SI_NO_APROBAMOS_HAY_TABLA.Butaca b
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Micros m
		ON m.id_micros = b.id_micro
	WHERE m.id_micros = @p_id_micro
	AND m.baja = 0
	AND b.baja = 0
END
