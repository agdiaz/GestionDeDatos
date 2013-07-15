--Invocar solo una vez en el script de creacion
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_calcular_puntajes_pasajes
AS
BEGIN
	INSERT INTO [SI_NO_APROBAMOS_HAY_TABLA].Puntaje
		(dni, id_compra, puntos)
	SELECT p.dni, p.id_compra, (p.pre_pasaje/5) 
	FROM SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
END
GO

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_calcular_puntajes_encomiendas
AS
BEGIN
	INSERT INTO [SI_NO_APROBAMOS_HAY_TABLA].Puntaje
		(dni, id_compra, puntos)
	SELECT e.dni, e.id_compra, (e.pre_encomienda/5) 
	FROM SI_NO_APROBAMOS_HAY_TABLA.Encomienda e
END
GO
