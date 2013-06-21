CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_buscar_micros
@p_fecha_salida datetime = NULL,
@p_ciudad_origen int = NULL,
@p_ciudad_destino int = NULL

AS
BEGIN

	SELECT micro.id_micros
	,marca.nombre
	,SI_NO_APROBAMOS_HAY_TABLA.f_obtener_butacas_por_micro(micro.id_micros) as butacas_total
	,SI_NO_APROBAMOS_HAY_TABLA.f_obtener_butacas_vendidas(viaje.id_viaje) as butacas_vendidas
	,SI_NO_APROBAMOS_HAY_TABLA.f_obtener_butacas_por_micro(micro.id_micros)
	- SI_NO_APROBAMOS_HAY_TABLA.f_obtener_butacas_vendidas(viaje.id_viaje) as butacas_disponibles
	,micro.capacidad_kg 
	,SI_NO_APROBAMOS_HAY_TABLA.f_obtener_kg_vendidos(viaje.id_viaje) as kgs_vendidos
	,micro.capacidad_kg -
	SI_NO_APROBAMOS_HAY_TABLA.f_obtener_kg_vendidos(viaje.id_viaje) as kgs_disponibles
	,servicio.tipo_servicio
	FROM SI_NO_APROBAMOS_HAY_TABLA.Micros micro
	-- Micro <--> Marca
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Marca marca
		ON marca.id_marca = micro.id_marca
	-- Micro <--> Servicio
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Servicio servicio
		ON servicio.id_servicio = micro.id_servicio
	-- Micro <--> Viaje
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Viaje viaje
		ON viaje.id_micro = micro.id_micros
		AND  @p_fecha_salida = viaje.fecha_salida
	-- Viaje <--> Recorrido
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Recorrido recorrido
		ON recorrido.id_recorrido = viaje.id_recorrido
		AND @p_ciudad_destino = recorrido.id_ciudad_destino
		AND @p_ciudad_origen = recorrido.id_ciudad_origen
	WHERE micro.baja_fuera_servicio = 0
	AND micro.baja_vida_util = 0
	AND micro.baja = 0
	AND viaje.baja = 0
	AND recorrido.baja = 0
		
		
END
