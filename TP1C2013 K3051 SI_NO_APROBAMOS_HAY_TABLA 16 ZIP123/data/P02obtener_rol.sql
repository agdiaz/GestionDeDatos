SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Demian
-- Create date: 20/6/2013
-- Description:	Retorna el rol
-- =============================================
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].obtener_rol 
	-- Add the parameters for the stored procedure here
	@userName nvarchar(50),
	@rol nvarchar(50) OUTPUT
	
AS
BEGIN
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT @rol=r.nombre
	FROM SI_NO_APROBAMOS_HAY_TABLA.Rol r
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Usuario u
	ON u.id_rol = r.id_rol
	WHERE u.username = @userName
END
GO
