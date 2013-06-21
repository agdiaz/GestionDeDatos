CREATE PROCEDURE sp_dar_baja_recorrido
(
	@id_recorrido numeric(18,0),
	@baja bit
)
AS
BEGIN
	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido]
	SET [baja] = @baja
	WHERE @id_recorrido=Recorrido.id_recorrido
END
