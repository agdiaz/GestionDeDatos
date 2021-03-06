USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_insertar_encomienda]    Script Date: 07/21/2013 03:09:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insertar_encomienda]
(
	@p_id_encomienda int output,
	@p_id_compra int,
	@p_dni numeric(18,0),
	@p_pre_encomienda int,
	@p_id_viaje int,
	@p_peso numeric(18,0)
)
AS
BEGIN
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Encomienda
		(id_viaje, id_compra, dni, pre_encomienda, peso)
	VALUES
		(@p_id_viaje,@p_id_compra, @p_dni, @p_pre_encomienda, @p_peso)

	SET @p_id_encomienda = SCOPE_IDENTITY()
END
