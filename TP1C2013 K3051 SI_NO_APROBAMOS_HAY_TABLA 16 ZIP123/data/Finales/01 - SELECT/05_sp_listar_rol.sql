
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_rol
	AS
BEGIN
	SELECT [id_rol]
      ,[nombre]
      ,[inhabilitado]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol]
  WHERE baja = 0
END
