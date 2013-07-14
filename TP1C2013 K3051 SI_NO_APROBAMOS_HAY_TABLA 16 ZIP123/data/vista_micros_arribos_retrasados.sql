CREATE VIEW [SI_NO_APROBAMOS_HAY_TABLA].micros_arribos_retrasados
AS SELECT micro.id_micros, viaje.id_viaje, viaje.fecha_arribo, viaje.fecha_arribo_estimada
FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros] AS micro
	inner join [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje] AS viaje
		ON viaje.id_micro=micro.id_micros
WHERE viaje.fecha_arribo <> viaje.fecha_arribo_estimada AND viaje.baja=0