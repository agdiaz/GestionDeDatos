CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_rol
	@p_id int
AS
BEGIN
	SELECT id_rol, nombre, activado, inhabilitado
	from SI_NO_APROBAMOS_HAY_TABLA.Rol
	where Rol.id_rol = @p_id
END
GO
