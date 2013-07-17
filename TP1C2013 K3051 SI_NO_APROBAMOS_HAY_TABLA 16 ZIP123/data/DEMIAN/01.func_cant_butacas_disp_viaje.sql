
CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].cant_butacas_disp_viaje
(
	@id_viaje int
)
RETURNS int
AS
BEGIN
	DECLARE @cant_total int
	DECLARE @cant_ocupadas int
	DECLARE @id_micro int
	
	SELECT @id_micro=m.id_micros, @cant_total=COUNT(b.id_butaca)
	FROM SI_NO_APROBAMOS_HAY_TABLA.Viaje v
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Micros m
		ON v.id_micro = m.id_micros
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Butaca b
		ON b.id_micro = m.id_micros
	WHERE v.id_viaje = @id_viaje
	GROUP BY v.id_viaje, m.id_micros
	
	SELECT @cant_ocupadas=COUNT(*)
	FROM SI_NO_APROBAMOS_HAY_TABLA.Viaje v
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
		ON p.id_viaje = v.id_viaje
	WHERE v.id_viaje = @id_viaje
	
	return @cant_total - @cant_ocupadas
END
