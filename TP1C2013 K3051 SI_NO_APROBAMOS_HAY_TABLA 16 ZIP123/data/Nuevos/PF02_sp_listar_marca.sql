CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_marca
AS
BEGIN
SELECT [id_marca],[nombre]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Marca]
  WHERE
  baja = 0
END