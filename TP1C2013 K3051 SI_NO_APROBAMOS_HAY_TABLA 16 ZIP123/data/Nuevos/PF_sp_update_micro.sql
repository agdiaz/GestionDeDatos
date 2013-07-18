CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_update_micro]
	@p_marca varchar(50) = NULL, 
	@p_modelo nvarchar(50) = NULL,
	@p_tipo_servicio nvarchar(255) = NULL,
	@p_patente nvarchar(50) = NULL,
	@p_kgs_encomienda numeric(18,2)= NULL,
	@p_fecha_alta datetime,
	@p_baja_vida_util bit,
	@p_fec_baja_vida_util datetime,
	@p_id int
AS
BEGIN
UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
   SET [fecha_alta] = @p_fecha_alta
      ,[modelo] = @p_modelo
      ,[patente] = @p_patente
      ,[id_marca] = @p_marca
      ,[id_servicio] = @p_tipo_servicio
      ,[baja_vida_util] = @p_baja_vida_util
      ,[fec_baja_vida_util] = @p_fec_baja_vida_util
      ,[capacidad_kg] = @p_kgs_encomienda
      
 WHERE id_micros = @p_id
END

