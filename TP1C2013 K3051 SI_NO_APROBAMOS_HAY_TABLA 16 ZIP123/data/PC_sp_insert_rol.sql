CREATE PROCEDURE sp_insert_rol
(
	@nombre nvarchar(50),
	@inhabilitado bit 0
)
AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol]
           ([nombre]
           ,[inhabilitado])
     VALUES (@nombre,@inhabilitado)
END
