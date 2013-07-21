CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_filtrar_compras
(
	@id_compra int,
	@id_usuario int,
	@fecha_compra datetime
)
AS
BEGIN
SELECT c.[id_compra]
      ,c.[id_usuario]
      ,ISNULL(c.[id_cancelacion], 0) as id_cancelacion
      ,c.[fecha_compra]
  FROM [SI_NO_APROBAMOS_HAY_TABLA].[Compra] c
	WHERE [baja] = 0
	AND ((@id_usuario is null) OR (c.id_usuario = @id_usuario) )
	AND ((@id_compra is null) OR (c.id_compra = @id_compra))
	AND ((@fecha_compra is null) OR (c.fecha_compra = @fecha_compra))
END