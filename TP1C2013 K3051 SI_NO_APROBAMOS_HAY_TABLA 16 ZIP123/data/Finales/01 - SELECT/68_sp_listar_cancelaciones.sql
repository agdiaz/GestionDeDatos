CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_listar_cancelaciones
AS
BEGIN
SELECT [id_cancelacion]
      ,[fecha_cancel]
      ,[motivo_cancel]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cancelacion]
END