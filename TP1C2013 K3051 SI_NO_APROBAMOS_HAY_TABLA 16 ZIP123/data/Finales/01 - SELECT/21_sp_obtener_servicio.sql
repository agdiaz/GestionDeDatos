CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_servicio
	@p_id int
AS
BEGIN
	SELECT s.id_servicio, s.tipo_servicio, s.pocent_adic
	from SI_NO_APROBAMOS_HAY_TABLA.Servicio s
	where s.id_servicio = @p_id
	AND baja = 0
END
GO
