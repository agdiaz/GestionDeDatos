USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_cliente]    Script Date: 07/18/2013 02:28:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_cliente]
AS
BEGIN
	SELECT c.[dni]
      ,c.[nombre]
      ,c.[apellido]
      ,c.[direccion]
      ,c.[telefono]
      ,c.[mail]
      ,c.[fecha_nacimiento]
      ,c.[es_discapacitado]
      ,c.[sexo]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente] c
  WHERE c.baja = 0
END
