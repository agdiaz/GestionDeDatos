CREATE PROCEDURE sp_update_viaje_fecha_arribo
(
	@patente nvarchar(50),
	@fecha_hora_llegada datetime
)
AS
BEGIN
	DECLARE @micro_id int
	SELECT @micro_id = micros.[id_micros]
				FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros] AS micros
				WHERE @patente=micros.patente
	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje]
	SET [fecha_arribo]=@fecha_hora_llegada
	WHERE viaje.id_micro = @micro_id
END
GO
