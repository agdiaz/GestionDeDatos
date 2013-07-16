CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_update_marca(
	@p_nombre varchar(50),
	@p_id int
)
AS
BEGIN
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Marca
	SET nombre = @p_nombre
	WHERE id_marca = @p_id
END
