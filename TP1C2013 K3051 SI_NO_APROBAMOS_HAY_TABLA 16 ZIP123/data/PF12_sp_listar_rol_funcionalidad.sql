
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_rol_funcionalidad
AS
BEGIN
	SELECT [id_rol]
      ,[id_funcionalidad]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_funcionalidad]
END
