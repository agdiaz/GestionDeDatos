CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_obtener_micro_disponibilidades
(
	@p_id_viaje int
)
AS
BEGIN
	SELECT [SI_NO_APROBAMOS_HAY_TABLA].kg_disponibles_viaje(@p_id_viaje) as kgs,
	[SI_NO_APROBAMOS_HAY_TABLA].cant_butacas_disp_viaje(@p_id_viaje) as butacas
	
END