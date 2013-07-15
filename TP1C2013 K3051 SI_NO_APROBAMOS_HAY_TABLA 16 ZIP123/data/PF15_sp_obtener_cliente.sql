CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_cliente
	@p_dni numeric(18,0)
AS
BEGIN
	SELECT dni, nombre, apellido, direccion, telefono, mail, fecha_nacimiento, sexo, es_discapacitado
	from SI_NO_APROBAMOS_HAY_TABLA.Cliente
	where Cliente.dni = @p_dni
END
GO
