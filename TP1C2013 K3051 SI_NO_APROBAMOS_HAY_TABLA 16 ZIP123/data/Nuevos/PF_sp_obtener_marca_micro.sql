CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_obtener_marca_micro(
@p_id int 
)
AS
BEGIN
	SELECT Ma.[id_marca]
      ,Ma.[nombre]
      ,Ma.[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Marca] Ma
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Micros Mi
		on Mi.id_marca = Ma.id_marca
	where Mi.id_micros = @p_id
END

