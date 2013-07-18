USE [GD1C2013]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_recompensa]
	@p_descrip nvarchar(200),
	@p_puntos_desde int,
	@p_puntos_hasta int,
	@p_stock_desde int,
	@p_stock_hasta int
AS
BEGIN
	SELECT
		id_recompensa,
		descripcion,
		stock,
		puntos_costo
	FROM SI_NO_APROBAMOS_HAY_TABLA.Recompensa
	WHERE((@p_descrip IS NULL) OR (UPPER(descripcion) LIKE '%'  + UPPER(@p_descrip) + '%'))
	AND ((@p_puntos_desde IS NULL) OR (puntos_costo >= @p_puntos_desde))
	AND ((@p_puntos_hasta IS NULL) OR (puntos_costo <= @p_puntos_hasta))
	AND ((@p_stock_desde IS NULL) OR (stock >= @p_stock_desde))
	AND ((@p_stock_hasta IS NULL) OR (stock <= @p_stock_hasta))
END
