CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_marca
	@p_id int
AS
BEGIN
SELECT [id_marca]
      ,[nombre]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Marca]
	WHERE id_marca = @p_id
END
