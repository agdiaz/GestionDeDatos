CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_delete_ciudad
(
@p_id_ciudad INT
)
AS
BEGIN
	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].Ciudad
	SET baja=1			
	WHERE id_ciudad=@p_id_ciudad
END