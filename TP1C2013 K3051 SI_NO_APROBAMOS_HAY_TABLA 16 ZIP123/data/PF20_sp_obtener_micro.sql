CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_micro
	@p_id int
AS
BEGIN
	SELECT id_micros, fecha_alta, nro_micro, modelo, patente, id_marca, id_servicio, baja_fuera_servicio, baja_vida_util, fec_fuera_servicio, 
	fec_baja_vida_util, fec_reinicio_servicio, capacidad_kg
	from SI_NO_APROBAMOS_HAY_TABLA.Micros
	where Micros.id_micros = @p_id
END
GO
