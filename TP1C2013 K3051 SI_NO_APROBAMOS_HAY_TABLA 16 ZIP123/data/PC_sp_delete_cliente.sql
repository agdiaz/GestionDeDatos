CREATE PROCEDURE sp_baja_logica_cliente
(
	@dni numeric(18,0)
)
AS
BEGIN
UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
	SET habilitado=TRUE			--Se tiene que agregar campo
	WHERE Cliente.dni=@dni
END
