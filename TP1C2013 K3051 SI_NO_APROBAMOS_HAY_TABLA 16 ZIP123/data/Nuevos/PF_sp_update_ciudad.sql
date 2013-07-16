CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_update_ciudad(
	@p_nombre varchar(50),
	@p_id int
)
AS
BEGIN
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Ciudad
	SET nombre = @p_nombre
	WHERE id_ciudad = @p_id
END
