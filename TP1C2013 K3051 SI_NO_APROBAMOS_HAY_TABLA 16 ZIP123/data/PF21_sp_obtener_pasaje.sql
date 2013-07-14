CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_pasaje
	@p_id numeric(18,0)
AS
BEGIN
	SELECT id_pasaje, id_compra, nro_butaca, dni, pre_pasaje, disponible, cancel, fecha_cancel,
	motivo_cancel, id_viaje
	from SI_NO_APROBAMOS_HAY_TABLA.Pasaje
	where Pasaje.id_pasaje = @p_id
END
GO
