CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_rol_funcionalidad]
(
	@p_id_rol int,
	@p_id_funcionalidad int
)
AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_funcionalidad]
           ([id_rol]
           ,[id_funcionalidad])
     VALUES (@p_id_rol, @p_id_funcionalidad)
END
