CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_obtener_butacas_por_micro](
	@p_id int
)
AS
BEGIN

SELECT [id_butaca]
      ,[nro_butaca]
      ,[id_micro]
      ,[tipo_butaca]
      ,[piso]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Butaca]
where Butaca.id_micro = @p_id

END


