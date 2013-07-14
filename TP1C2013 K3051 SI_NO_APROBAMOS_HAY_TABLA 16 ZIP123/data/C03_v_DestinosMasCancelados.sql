CREATE VIEW [SI_NO_APROBAMOS_HAY_TABLA].v_DestinosMasCancelados
AS
SELECT Ciudad.nombre, COUNT(id_pasaje) as CantCancelados
from SI_NO_APROBAMOS_HAY_TABLA.Ciudad
inner join SI_NO_APROBAMOS_HAY_TABLA.Recorrido
	on Ciudad.id_ciudad = Recorrido.id_ciudad_destino
inner join SI_NO_APROBAMOS_HAY_TABLA.Viaje
	on Recorrido.id_recorrido = Viaje.id_recorrido
inner join SI_NO_APROBAMOS_HAY_TABLA.Pasaje
	on Pasaje.id_viaje = Viaje.id_viaje
where Pasaje.cancel = 1
and Ciudad.baja = 0
and Recorrido.baja = 0
and Viaje.baja = 0
and Pasaje.baja = 0
group by Viaje.id_viaje, Ciudad.nombre
order by CantCancelados DESC
	
