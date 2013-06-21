CREATE FUNCTION SI_NO_APROBAMOS_HAY_TABLA.f_obtener_butacas_por_micro
(
	@p_id_micro int 
)
RETURNS int
AS
BEGIN
	DECLARE @cantidad int

SELECT @cantidad = COUNT(*)
	FROM SI_NO_APROBAMOS_HAY_TABLA.Butaca b
	WHERE b.id_micro = @p_id_micro
	
	RETURN @cantidad

END
