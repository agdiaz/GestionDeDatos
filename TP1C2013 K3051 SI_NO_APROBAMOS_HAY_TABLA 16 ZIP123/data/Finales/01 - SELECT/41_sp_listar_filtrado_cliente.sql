USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_cliente]    Script Date: 07/18/2013 00:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_cliente]
	@p_dni numeric(18,0) = NULL,
	@p_nombre nvarchar(255) = NULL,
	@p_apellido nvarchar(255) = NULL,
	@p_discapacitado CHAR(1) = NULL,
	@p_sexo varchar(50) = NULL
AS
BEGIN
	SELECT [dni]
      ,[nombre]
      ,[apellido]
      ,[direccion]
      ,[telefono]
      ,[mail]
      ,[fecha_nacimiento]
      ,[es_discapacitado]
      ,[sexo]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
	where ((@p_dni IS NULL) OR (dni = @p_dni))
	and ((@p_nombre IS NULL) OR (UPPER(nombre) like '%' + UPPER(@p_nombre) +'%'))
	and ((@p_apellido IS NULL) OR (apellido like '%' + @p_apellido + '%'))
	and ((@p_discapacitado IS NULL) OR (ISNULL(es_discapacitado, 'N') = @p_discapacitado))
	and ((@p_sexo IS NULL) OR (sexo like '%' + @p_sexo + '%'))
	and baja=0
END
