USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_obtener_usuario]    Script Date: 07/16/2013 03:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_obtener_usuario](

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
	and baja = 0
END
