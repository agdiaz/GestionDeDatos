CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_delete_ciudad
(
@p_id_ciudad INT
)
AS
BEGIN
	DELETE FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad]
	WHERE @p_id_ciudad=id_ciudad
END