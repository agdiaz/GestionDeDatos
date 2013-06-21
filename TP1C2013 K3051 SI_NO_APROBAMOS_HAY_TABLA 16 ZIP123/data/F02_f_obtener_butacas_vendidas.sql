CREATE FUNCTION SI_NO_APROBAMOS_HAY_TABLA.f_obtener_butacas_vendidas
(
	@p_id_viaje int 
)
RETURNS int
AS
BEGIN

DECLARE @cantidad int
	SELECT @cantidad = COUNT(*)
	FROM SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
	WHERE p.id_viaje = @p_id_viaje
	AND p.cancel = 0
	AND p.baja = 0

	RETURN @cantidad

END

