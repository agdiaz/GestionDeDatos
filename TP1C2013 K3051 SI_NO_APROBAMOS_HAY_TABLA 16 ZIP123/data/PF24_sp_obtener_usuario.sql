CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_usuario(

@p_username nvarchar(50)
)
AS
BEGIN
	SELECT 
	[id_usuario]
      ,[id_rol]
      ,[dni]
      ,[hash_password]
      ,[cant_intentos_fallidos]
      ,[username]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Usuario]
	where username = @p_username
END
GO
