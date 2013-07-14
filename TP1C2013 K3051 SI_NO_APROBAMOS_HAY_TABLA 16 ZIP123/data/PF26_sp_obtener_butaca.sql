CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_butaca
	@p_id int
AS
BEGIN
	SELECT b.id_butaca, b.nro_butaca, b.id_micro, b.tipo_butaca, b.piso
	from SI_NO_APROBAMOS_HAY_TABLA.Butaca b
	where b.id_butaca = @p_id
END
GO
