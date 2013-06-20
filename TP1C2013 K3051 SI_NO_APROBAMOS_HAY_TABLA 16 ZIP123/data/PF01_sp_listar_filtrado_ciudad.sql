
ALTER PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_ciudad 
	@p_ciudad varchar(50) = NULL
AS
BEGIN
	SELECT c.[id_ciudad],c.[nombre]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] c
	where ((@p_ciudad IS NULL) OR (c.nombre = @p_ciudad))	
END
