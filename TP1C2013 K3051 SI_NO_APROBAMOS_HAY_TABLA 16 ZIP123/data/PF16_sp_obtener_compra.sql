CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_compra
	@p_id int
AS
BEGIN
	SELECT id_compra, id_usuario, fecha_compra, cancel, fecha_cancel, motivo_cancel
	from SI_NO_APROBAMOS_HAY_TABLA.Compra
	where Compra.id_compra= @p_id
END
GO
