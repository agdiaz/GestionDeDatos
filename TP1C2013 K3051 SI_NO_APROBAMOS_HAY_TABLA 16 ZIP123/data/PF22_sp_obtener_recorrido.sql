CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_recorrido
	@p_id numeric(18,0)
AS
BEGIN
	SELECT id_recorrido, id_ciudad_origen, id_ciudad_destino, pre_base_kg, pre_base_pasaje, id_servicio
	from SI_NO_APROBAMOS_HAY_TABLA.Recorrido
	where Recorrido.id_recorrido = @p_id
END
GO
