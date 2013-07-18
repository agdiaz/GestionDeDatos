CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_registro_llegada]
(
	@p_id_viaje int,
	@p_fecha_llegada datetime
)
AS
BEGIN
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Viaje
	SET fecha_arribo = @p_fecha_llegada
	WHERE id_viaje = @p_id_viaje
END
