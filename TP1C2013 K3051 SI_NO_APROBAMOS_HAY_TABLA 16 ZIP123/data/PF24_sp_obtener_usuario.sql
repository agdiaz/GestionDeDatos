CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_usuario
	@p_id int
AS
BEGIN
	SELECT u.id_usuario, u.id_rol, u.dni, u.username, u.hash_password, u.cant_intentos_fallidos
	from SI_NO_APROBAMOS_HAY_TABLA.Usuario u 
	where u.id_usuario = @p_id
END
GO
