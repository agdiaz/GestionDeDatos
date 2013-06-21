
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_usuario 
AS
BEGIN
SELECT [id_usuario]
      ,[id_rol]
      ,[dni]
      ,[username]
      ,[hash_password]
      ,[cant_intentos_fallidos]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Usuario]
END

