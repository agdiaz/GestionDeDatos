CREATE TRIGGER trgPuntaje ON [SI_NO_APROBAMOS_HAY_TABLA].Pasaje
FOR INSERT
AS
	DECLARE @dni numeric(18,0)
	DECLARE @precio numeric(18,2)
	DECLARE @idCompra int
	
	SELECT @dni=i.dni FROM INSERTED i
	SELECT @precio=i.pre_pasaje FROM INSERTED i
	SELECT @idCompra=i.id_compra FROM INSERTED i
	
	INSERT INTO [SI_NO_APROBAMOS_HAY_TABLA].Puntaje
		(dni, id_compra, puntos)
	VALUES
		(@dni, @idCompra, @precio/5)
GO