CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_canje(
	@p_id int
	)
AS
BEGIN
	SELECT [id_canje]
      ,[dni]
      ,[id_recompensa]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Canje] c
	WHERE c.id_canje = @p_id
END

