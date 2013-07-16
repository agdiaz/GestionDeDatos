CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_update_rol(
	@p_nombre varchar(50),
	@p_id int,
	@p_inhabilitado bit,
	@p_baja bit 
)
AS
BEGIN
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Rol
	SET nombre = @p_nombre,
	inhabilitado = @p_inhabilitado,
	baja = @p_baja
	
	WHERE id_rol = @p_id
END