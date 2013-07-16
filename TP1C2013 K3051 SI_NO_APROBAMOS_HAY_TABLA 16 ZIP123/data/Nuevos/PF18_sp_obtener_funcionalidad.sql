CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_funcionalidad(
	@p_id int
	)
AS
BEGIN
SELECT [id_funcionalidad]
      ,[funcionalidad]
      ,[activa]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad]
	WHERE id_funcionalidad = @p_id
	AND baja=0
END
GO
