CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_ciudad(
	@p_id int
)
AS
BEGIN
	SELECT [id_ciudad]
      ,[nombre]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad]
	WHERE Ciudad.id_ciudad = @p_id
END
GO
