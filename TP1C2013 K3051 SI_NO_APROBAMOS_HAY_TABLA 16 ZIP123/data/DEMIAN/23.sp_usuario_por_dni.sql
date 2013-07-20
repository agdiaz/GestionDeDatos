CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_usuario_por_dni
(
	@p_dni numeric(18,0)
)
AS
BEGIN
	SELECT u.id_usuario, u.username
	FROM SI_NO_APROBAMOS_HAY_TABLA.Usuario u
	WHERE u.dni = @p_dni
	AND u.baja = 0
END