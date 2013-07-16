USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_ciudad]    Script Date: 07/16/2013 01:18:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*===========================SP INSERT CIUDAD==============================*/

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_ciudad]
(
	@p_nombre varchar(50),
	@p_id int output
)
AS
BEGIN

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad]
           ([nombre])
     VALUES
           (@p_nombre)

SET @p_id = SCOPE_IDENTITY()

END

/*===========================SP INSERT CLIENTE==============================*/
