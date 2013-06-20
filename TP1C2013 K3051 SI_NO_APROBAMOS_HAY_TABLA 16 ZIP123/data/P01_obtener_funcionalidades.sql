SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Demian
-- Create date: 20/6/2013
-- Description:	Selecciona las funcionalidades
-- =============================================
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].obtener_funcionalidades_rol
	@nombre_rol nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT f.funcionalidad
	FROM SI_NO_APROBAMOS_HAY_TABLA.Funcionalidad f
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Rol_funcionalidad rf
		ON rf.id_funcionalidad = f.id_funcionalidad
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Rol r
		ON rf.id_rol = r.id_rol
	WHERE r.nombre = @nombre_rol
END
GO
