SELECT DISTINCT TOP 5 ciudad.[nombre],
		SUM ([SI_NO_APROBAMOS_HAY_TABLA].butacas_vendidas_por_viaje(viaje.[id_viaje])) AS butacas_vendidas
FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] as ciudad
	 inner join [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] as recorrido
		on ciudad.[id_ciudad]=recorrido.[id_ciudad_destino]
	 inner join [SI_NO_APROBAMOS_HAY_TABLA].[Viaje] as viaje
		on viaje.[id_recorrido]=recorrido.id_recorrido
WHERE recorrido.baja=0 AND viaje.baja=0
GROUP BY ciudad.[id_ciudad], ciudad.[nombre]
ORDER BY SUM ([SI_NO_APROBAMOS_HAY_TABLA].butacas_vendidas_por_viaje(viaje.[id_viaje])) desc