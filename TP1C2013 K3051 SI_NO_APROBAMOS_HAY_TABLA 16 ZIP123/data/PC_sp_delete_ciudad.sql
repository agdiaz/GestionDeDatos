CREATE PROCEDURE sp_delete_ciudad
(
@id_ciudad INT
)
AS
BEGIN
	DELETE FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad]
	WHERE @id_ciudad=id_ciudad
END