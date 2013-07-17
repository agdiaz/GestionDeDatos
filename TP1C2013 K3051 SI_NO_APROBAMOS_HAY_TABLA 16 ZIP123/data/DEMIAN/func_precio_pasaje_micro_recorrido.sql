
CREATE FUNCTION SI_NO_APROBAMOS_HAY_TABLA.precio_pasaje_micro_recorrido
(
	@id_micro int,
	@id_recorrido numeric(18,0)
)
RETURNS numeric(18,2)
AS
BEGIN
	
	DECLARE @pre_base numeric(18,2)
	DECLARE @porcent_adic decimal(5,2)
	DECLARE @pre_final numeric(18,2)

	SELECT @pre_base = r.pre_base_pasaje
	FROM SI_NO_APROBAMOS_HAY_TABLA.Recorrido r
	WHERE r.id_recorrido = @id_recorrido

	SELECT @porcent_adic = s.pocent_adic
	FROM SI_NO_APROBAMOS_HAY_TABLA.Micros m
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Servicio s
		ON m.id_servicio = s.id_servicio
	WHERE id_micros =  @id_micro
	
	SET @pre_final = @pre_base + (@pre_base * @porcent_adic) / 100
	
	RETURN @pre_final
END

