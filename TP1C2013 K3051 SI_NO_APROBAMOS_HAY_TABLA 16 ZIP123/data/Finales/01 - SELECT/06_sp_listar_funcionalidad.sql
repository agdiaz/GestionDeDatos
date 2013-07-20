
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_funcionalidad
AS
BEGIN
SELECT [id_funcionalidad]
      ,[funcionalidad]
      ,[activa]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad]
  WHERE baja = 0
 END
