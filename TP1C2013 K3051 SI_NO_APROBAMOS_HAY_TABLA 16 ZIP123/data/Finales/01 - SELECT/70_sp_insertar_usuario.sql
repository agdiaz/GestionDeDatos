CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insertar_usuario
(
	@dni numeric(18,0),
	@username nvarchar(50)
)
AS
BEGIN	
	
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Usuario
		(id_rol, dni, username)
	VALUES (2, @dni, @username)
END