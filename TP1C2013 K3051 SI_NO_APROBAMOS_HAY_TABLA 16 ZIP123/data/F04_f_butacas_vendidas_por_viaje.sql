CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].butacas_vendidas_por_viaje
(
	@id_viaje int
)
RETURNS int
AS
BEGIN
	DECLARE @butacas_vendidas int
	
	SELECT @butacas_vendidas = COUNT(*) 
	FROM [SI_NO_APROBAMOS_HAY_TABLA].[Pasaje] AS pasaje 
	WHERE @id_viaje=pasaje.[id_viaje] AND pasaje.baja=0
	
	RETURN isnull(@butacas_vendidas,0)

END
GO