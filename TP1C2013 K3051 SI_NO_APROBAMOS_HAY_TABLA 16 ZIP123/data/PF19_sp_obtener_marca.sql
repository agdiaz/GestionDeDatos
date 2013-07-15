CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_marca
	@p_id int
AS
BEGIN
	SELECT id_marca, nombre
	from SI_NO_APROBAMOS_HAY_TABLA.Marca
	where Marca.id_marca = @p_id
END
GO
