CREATE PROCEDURE sp_baja_logica_rol
(
	@id_rol int
)
AS
BEGIN
	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol]
	SET [inhabilitado] = 1
	WHERE Rol.id_rol = @id_rol
END
