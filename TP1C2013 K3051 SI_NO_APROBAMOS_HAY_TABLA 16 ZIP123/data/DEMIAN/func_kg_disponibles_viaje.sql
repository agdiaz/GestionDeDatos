CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].kg_disponibles_viaje
(
	@id_viaje int
)
RETURNS numeric(18,2)
AS
BEGIN
	DECLARE @kg_totales numeric(18,0)
	DECLARE @kg_ocupados numeric(18,0)
	
	SELECT @kg_totales=m.capacidad_kg
	FROM [SI_NO_APROBAMOS_HAY_TABLA].Viaje v
	INNER JOIN [SI_NO_APROBAMOS_HAY_TABLA].Micros m
		ON v.id_micro = m.id_micros
	WHERE v.id_viaje = @id_viaje
	
	SELECT @kg_ocupados=SUM(e.peso)
	FROM [SI_NO_APROBAMOS_HAY_TABLA].Viaje v
	INNER JOIN [SI_NO_APROBAMOS_HAY_TABLA].Encomienda e
		ON e.id_viaje = v.id_viaje
	WHERE v.id_viaje = @id_viaje
	
	RETURN @kg_totales - @kg_ocupados
		
END
