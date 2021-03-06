USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_update_rol]    Script Date: 07/16/2013 00:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_update_rol](
	@p_nombre varchar(50),
	@p_id int,
	@p_inhabilitado bit
)
AS
BEGIN
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Rol
	SET nombre = @p_nombre,
		inhabilitado = @p_inhabilitado
	WHERE id_rol = @p_id
END