CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_compra
(	
	@p_id_compra int output,
	@p_id_usuario int,
	@p_fecha_compra datetime
)
AS
BEGIN
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Compra
		(id_usuario, fecha_compra)
	VALUES
		(@p_id_usuario, @p_fecha_compra)

	SET @p_id_compra = SCOPE_IDENTITY()
END
