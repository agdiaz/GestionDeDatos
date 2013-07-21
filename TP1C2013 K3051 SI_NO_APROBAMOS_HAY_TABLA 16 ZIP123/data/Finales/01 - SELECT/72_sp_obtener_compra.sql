CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_compra
(
	@p_id int
)
AS
BEGIN
SELECT [id_compra]
      ,[id_usuario]
      ,ISNULL([id_cancelacion], 0) as id_cancelacion
      ,[fecha_compra]
      ,[cancel]
      ,[fecha_cancel]
      ,ISNULL([motivo_cancel], '') as motivo_cancel
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Compra]
  WHERE id_compra = @p_id
END


