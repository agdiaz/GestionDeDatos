CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_viaje
	@p_id int
AS
BEGIN
	SELECT v.id_viaje, v.id_recorrido, v.id_micro, v.fecha_salida, v.fecha_arribo_estimada, v.fecha_arribo
	from SI_NO_APROBAMOS_HAY_TABLA.Viaje v
	where v.id_viaje = @p_id
END
GO
