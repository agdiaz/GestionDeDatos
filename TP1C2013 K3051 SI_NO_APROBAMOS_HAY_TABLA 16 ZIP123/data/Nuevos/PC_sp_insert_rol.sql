USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_rol]    Script Date: 07/16/2013 00:51:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*===========================SP INSERT ROL==============================*/

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_rol]
(
	@p_nombre nvarchar(50),
	@p_inhabilitado bit,
	@p_id int output
)
AS
BEGIN

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol]
           ([nombre]
           ,[inhabilitado])
     VALUES (@p_nombre,@p_inhabilitado)

SET @p_id = SCOPE_IDENTITY()

END

/*===========================SP INSERT ROL FUNCIONALIDAD==============================*/
