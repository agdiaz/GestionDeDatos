CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_funcionalidad
	@p_id int
AS
BEGIN
	SELECT id_funcionalidad, funcionalidad, activa
	from SI_NO_APROBAMOS_HAY_TABLA.Funcionalidad
	where Funcionalidad.id_funcionalidad = @p_id
END
GO
