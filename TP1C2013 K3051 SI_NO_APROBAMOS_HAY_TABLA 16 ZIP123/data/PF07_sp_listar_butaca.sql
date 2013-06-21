
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_butaca
	AS
BEGIN
	SELECT [id_butaca]
      ,[nro_butaca]
      ,[id_micro]
      ,[tipo_butaca]
      ,[piso]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Butaca]
END

