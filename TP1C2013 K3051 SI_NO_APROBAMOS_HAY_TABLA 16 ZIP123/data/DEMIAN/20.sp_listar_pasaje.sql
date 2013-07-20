--listar pasaje
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_listar_pasaje
AS
BEGIN
	SELECT p.id_pasaje, p.id_compra,
		p.id_butaca, p.id_cancelacion, p.dni, p.pre_pasaje,
		p.disponible, p.cancel, p.fecha_cancel, p.motivo_cancel,
		p.id_viaje
	FROM SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
	where p.baja = 0
	AND p.id_cancelacion is null
END