CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_canjes_cliente(
	@p_dni numeric(18,0)
)
AS
BEGIN
	SELECT [id_canje]
      ,[dni]
      ,[id_recompensa]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Canje] c
	WHERE c.dni = @p_dni
END