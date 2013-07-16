CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_usuario(

@p_id int
)
AS
BEGIN
	SELECT 
      [id_rol]
      ,[dni]
      ,[username]
      ,[hash_password]
      ,[cant_intentos_fallidos]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Usuario]
	where id_usuario = @p_id
END
GO
