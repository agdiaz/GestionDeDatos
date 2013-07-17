
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_viaje_ciudades_salida_llegada
(
	@id_ciudad_origen int,
	@id_ciudad_destino int,
	@fecha_salida	datetime
)
AS
BEGIN
	SELECT DISTINCT v.id_viaje, 
			v.fecha_salida, 
			v.fecha_arribo_estimada,
			r.id_recorrido,
			SI_NO_APROBAMOS_HAY_TABLA.precio_pasaje_micro_recorrido(
			m.id_micros, r.id_recorrido )as 'precio',
			(SI_NO_APROBAMOS_HAY_TABLA.kg_disponibles_viaje(v.id_viaje)) as 'kg_disponibles',
			(SI_NO_APROBAMOS_HAY_TABLA.cant_butacas_disp_viaje(v.id_viaje)) as 'butacas_disponibles',
			r.id_servicio,
			s.tipo_servicio
	FROM SI_NO_APROBAMOS_HAY_TABLA.Recorrido r
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Servicio s
		ON s.id_servicio = r.id_servicio
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Viaje v
		ON v.id_recorrido = r.id_recorrido
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Micros m
		ON m.id_micros = v.id_micro
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Butaca b
		ON b.id_micro = m.id_micros
	WHERE r.id_ciudad_origen = @id_ciudad_origen
	AND r.id_ciudad_destino = @id_ciudad_destino
	AND DATEPART(DAY,v.fecha_salida) = DATEPART(DAY,@fecha_salida)
	AND DATEPART(MONTH,v.fecha_salida) = DATEPART(MONTH,@fecha_salida)
	AND DATEPART(YEAR,v.fecha_salida) = DATEPART(YEAR,@fecha_salida)
	AND v.baja = 0
	AND m.baja = 0
	AND b.baja = 0
	and s.baja = 0
	
END	