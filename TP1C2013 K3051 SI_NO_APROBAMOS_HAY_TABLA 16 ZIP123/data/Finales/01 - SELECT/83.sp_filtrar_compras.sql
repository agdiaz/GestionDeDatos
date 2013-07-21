CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_filtrar_compras
(
	@id_compra int = NULL,
	@dni numeric(18,0) = NULL,
	@fecha_compra datetime = NULL
)
AS
BEGIN
SELECT c.[id_compra]
      ,c.[id_usuario]
      ,ISNULL(c.[id_cancelacion], 0) as id_cancelacion
      ,c.[fecha_compra]
  FROM [SI_NO_APROBAMOS_HAY_TABLA].[Compra] c
	inner join SI_NO_APROBAMOS_HAY_TABLA.Usuario u
		on c.id_usuario = u.id_usuario
	inner join SI_NO_APROBAMOS_HAY_TABLA.Cliente cli
		on u.dni = cli.dni
	AND ((@dni is null) OR (cli.dni = @dni) )
	AND ((@id_compra is null) OR (c.id_compra = @id_compra))
	AND ((@fecha_compra is null) OR (c.fecha_compra = @fecha_compra))
END