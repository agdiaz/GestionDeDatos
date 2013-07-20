CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insertar_encomienda
(
	@p_id_encomienda int output,
	@p_id_compra int,
	@p_dni numeric(18,0),
	@p_pre_encomienda int,
	@p_id_viaje int
)
AS
BEGIN
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Encomienda
		(id_viaje, id_compra, dni, pre_encomienda)
	VALUES
		(@p_id_viaje,@p_id_compra, @p_dni, @p_pre_encomienda)

	SET @p_id_encomienda = SCOPE_IDENTITY()
END
