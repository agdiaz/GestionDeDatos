CREATE PROCEDURE sp_micros_arribos_atrasados
(
	@fecha_inicio datetime,
	@fecha_fin datetime
)
AS
BEGIN
	SELECT vista_micros.[id_micros], vista_micros.[id_viaje], vista_micros.[fecha_arribo], vista_micros.[fecha_arribo_estimada]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].micros_arribos_retrasados AS vista_micros
	WHERE vista_micros.[fecha_arribo] BETWEEN @fecha_inicio AND @fecha_fin
END
