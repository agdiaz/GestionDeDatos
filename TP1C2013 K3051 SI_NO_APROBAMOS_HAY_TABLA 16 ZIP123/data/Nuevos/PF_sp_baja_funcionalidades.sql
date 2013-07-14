CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_baja_funcionalidades]
(
	@p_id_rol int 
)
AS
BEGIN

DELETE FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad]
	WHERE Rol_funcionalidad.id_rol = @p_id_rol
END

