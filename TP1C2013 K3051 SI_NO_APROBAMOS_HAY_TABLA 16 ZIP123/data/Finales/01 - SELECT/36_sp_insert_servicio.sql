CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_servicio
(	@p_tipo_servicio nvarchar(255),
    @p_adicional decimal(5,2),
    @p_id int output
)
AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Servicio]
           ([tipo_servicio]
           ,[pocent_adic]
           ,[baja])
     VALUES (@p_tipo_servicio, @p_adicional, 0)

SET @p_id = SCOPE_IDENTITY()
     
END
