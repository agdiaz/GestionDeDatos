CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_compras01
AS
BEGIN
	SELECT [id_compra]
		  ,[id_usuario]
		  ,[fecha_compra]
		  ,ISNULL([fecha_cancel],0)
		  ,(
			SELECT COUNT(*)
			FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Pasaje] as pasaje
			WHERE pasaje.id_compra = compra.id_compra
					AND	pasaje.id_cancelacion IS NULL
			) AS Pasajes
		  ,(
			SELECT COUNT(*)
			FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Encomienda] as encomienda
			WHERE encomienda.id_compra = compra.id_compra
					AND	encomienda.id_cancelacion IS NULL
			) AS Encomiendas
		  ,ISNULL([motivo_cancel], '') as motivo_cancel
	  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Compra] as compra
	  WHERE [baja] = 0
END