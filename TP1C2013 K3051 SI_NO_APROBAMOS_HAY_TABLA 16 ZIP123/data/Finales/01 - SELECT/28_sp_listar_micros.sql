USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_micros]    Script Date: 07/16/2013 20:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_micros]
AS
BEGIN
SELECT Mi.[id_micros]
      ,Mi.[fecha_alta]
      ,Mi.[nro_micro]
      ,Mi.[modelo]
      ,Mi.[patente]
      ,Ma.nombre
      ,Ma.id_marca
      ,Mi.[id_servicio]
      ,Mi.[baja_vida_util]
      ,Mi.[fec_baja_vida_util]
      ,Mi.[capacidad_kg]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros] Mi
  INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Marca Ma
	on Mi.id_marca = Ma.id_marca
  WHERE Mi.baja = 0
END
