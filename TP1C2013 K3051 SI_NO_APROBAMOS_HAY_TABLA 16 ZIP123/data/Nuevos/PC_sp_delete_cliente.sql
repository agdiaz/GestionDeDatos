CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_delete_cliente
(
	@p_dni numeric(18,0)
)
AS
BEGIN
UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
	SET baja=1			
	WHERE Cliente.dni=@p_dni
END
