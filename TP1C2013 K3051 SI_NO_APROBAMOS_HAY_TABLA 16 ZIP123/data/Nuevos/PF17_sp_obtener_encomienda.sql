CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_encomienda(
	@p_id numeric(18,0)
)
AS
BEGIN
	SELECT [id_encomienda]
      ,[id_viaje]
      ,[id_compra]
      ,[dni]
      ,[peso]
      ,[pre_encomienda]
      ,[cancel]
      ,[fecha_cancel]
      ,[motivo_cancel]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Encomienda]
	where Encomienda.id_encomienda = @p_id
END
GO
