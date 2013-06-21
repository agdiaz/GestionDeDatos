
CREATE FUNCTION SI_NO_APROBAMOS_HAY_TABLA.f_obtener_kg_vendidos
(
	@p_id_viaje int
)
RETURNS int
AS
BEGIN
	DECLARE @total numeric(18,0)
	SELECT @total = SUM(e.peso)
	FROM SI_NO_APROBAMOS_HAY_TABLA.Encomienda e
	where @p_id_viaje = e.id_viaje

	RETURN @total

END


