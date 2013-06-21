ALTER PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_rol
(
	@nombre nvarchar(50),
	@inhabilitado bit = '0',
	@p_id int output
)
AS
BEGIN

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol]
           ([nombre]
           ,[inhabilitado])
     VALUES (@nombre,@inhabilitado)

SET @p_id = SCOPE_IDENTITY()

END
