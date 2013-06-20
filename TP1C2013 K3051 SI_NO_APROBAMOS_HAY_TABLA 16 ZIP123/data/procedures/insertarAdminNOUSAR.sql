SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Demian
-- Create date: 10/6/2013
-- =============================================
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].insertar_usuario_admin
	@userName nvarchar(50),
	@passwordHash	varbinary(32)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @idAdmin int

	SELECT @idAdmin = r.id_rol
	FROM SI_NO_APROBAMOS_HAY_TABLA.Rol r
	WHERE r.nombre = 'Administrativo'
	
	DECLARE @dniLoco numeric(18,0)
	
	SELECT top 1 @dniLoco = c.dni
	FROM SI_NO_APROBAMOS_HAY_TABLA.Cliente c
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Usuario
	SET id_rol = @idAdmin
	WHERE dni = @dniLoco
	
END
GO