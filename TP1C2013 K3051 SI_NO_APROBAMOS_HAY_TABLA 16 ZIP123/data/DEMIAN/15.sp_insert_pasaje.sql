CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insertar_pasaje
(
	@p_id_pasaje int output,
	@p_id_compra int,
	@p_id_butaca int,
	@p_dni numeric(18,0),
	@p_pre_pasaje int,
	@p_id_viaje int
)
AS
BEGIN
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Pasaje
		(id_compra, id_butaca, dni, pre_pasaje, id_viaje)
	VALUES
		(@p_id_compra, @p_id_butaca, @p_dni, @p_pre_pasaje, @p_id_viaje)

	SET @p_id_compra = SCOPE_IDENTITY()
END
