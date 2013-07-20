CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_butacas_ocupadas_viaje
(
	@p_id_viaje int
)
AS
BEGIN
	SELECT b.id_butaca, b.nro_butaca, b.tipo_butaca, b.piso, b.id_micro
	FROM SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Butaca b
	ON b.id_butaca = p.id_butaca
	WHERE p.id_viaje = @p_id_viaje
END