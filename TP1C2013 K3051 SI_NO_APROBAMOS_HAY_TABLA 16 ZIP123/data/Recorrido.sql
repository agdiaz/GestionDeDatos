select	m2.Recorrido_Codigo					as id_recorrido, 
		corig.id_ciudad						as id_ciudad_origen,
		cdes.id_ciudad						as id_ciudad_destino,
		SUM(m2.Recorrido_Precio_BaseKG)		as pre_base_kg, 
		SUM(m2.Recorrido_Precio_BasePasaje)	as pre_base_pasaje,
		serv.id_servicio					as id_servicio
from( 
	select distinct m.Recorrido_Codigo, m.Recorrido_Ciudad_Origen,
					m.Recorrido_Ciudad_Destino,	m.Recorrido_Precio_BaseKG, 
					m.Recorrido_Precio_BasePasaje, m.Tipo_Servicio
	from gd_esquema.Maestra m
) as m2
inner join SI_NO_APROBAMOS_HAY_TABLA.Ciudad cdes
	on cdes.nombre = m2.Recorrido_Ciudad_Destino
inner join SI_NO_APROBAMOS_HAY_TABLA.Ciudad corig
	on corig.nombre = m2.Recorrido_Ciudad_Origen
inner join SI_NO_APROBAMOS_HAY_TABLA.Servicio serv
	on serv.tipo_servicio = m2.Tipo_Servicio
group by m2.Recorrido_Codigo, corig.id_ciudad, cdes.id_ciudad, serv.id_servicio
