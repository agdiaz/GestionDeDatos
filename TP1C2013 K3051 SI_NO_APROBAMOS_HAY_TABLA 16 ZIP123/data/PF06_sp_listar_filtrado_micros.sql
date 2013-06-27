CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_micros
	@p_marca varchar(50) = NULL, 
	@p_modelo nvarchar(50) = NULL,
	@p_tipo_servicio nvarchar(255) = NULL,
	@p_patente nvarchar(50) = NULL,
	@p_nro_micro int = NULL,
	@p_kgs_encomienda numeric(18,2)= NULL 
AS
BEGIN
	SELECT m.[id_micros]
      ,m.[fecha_alta]
      ,m.[nro_micro]
      ,m.[modelo]
      ,m.[patente]
      ,m.[id_marca]
      ,m.[id_servicio]
      ,m.[baja_fuera_servicio]
      ,m.[baja_vida_util]
      ,m.[fec_fuera_servicio]
      ,m.[fec_reinicio_servicio]
      ,m.[fec_baja_vida_util]
      ,m.[capacidad_kg]
      ,m.[baja]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros] m
	left join SI_NO_APROBAMOS_HAY_TABLA.Servicio s
		on s.id_servicio = m.id_servicio and @p_tipo_servicio = s.tipo_servicio
	left join SI_NO_APROBAMOS_HAY_TABLA.Marca ma
		on ma.id_marca = m.id_marca and @p_marca = ma.nombre
	where ((@p_modelo IS NULL) OR (m.modelo like '%' + @p_modelo + '%' ))
	and ((@p_patente IS NULL) OR (m.patente like '%' + @p_patente + '%' ))
	and ((@p_nro_micro IS NULL) OR (m.nro_micro like '%' + @p_nro_micro + '%'))
	and ((@p_kgs_encomienda IS NULL) OR (m.capacidad_kg like '%' + @p_kgs_encomienda + '%' ))

END
