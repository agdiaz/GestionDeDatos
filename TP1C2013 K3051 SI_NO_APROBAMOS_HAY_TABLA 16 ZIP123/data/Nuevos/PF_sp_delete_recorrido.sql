CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_delete_recorrido
(
@p_id int
)
AS
BEGIN
	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].Recorrido
	SET baja=1			
	WHERE id_recorrido = @p_id
END