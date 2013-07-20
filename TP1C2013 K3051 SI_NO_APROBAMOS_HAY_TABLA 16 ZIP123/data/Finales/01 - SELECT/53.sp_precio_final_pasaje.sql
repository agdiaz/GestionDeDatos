CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_precio_real_pasaje
(
	@dni numeric(18,0),
	@id_recorrido numeric(18,0)
)
AS
BEGIN
	DECLARE @pre_base numeric(18,2)
	DECLARE @porcent_adic decimal(5,2)
	DECLARE @pre_final numeric(18,2)
	DECLARE @edad int
	DECLARE @sexo varchar(50) 
	DECLARE @discapacitado char(1)
	
	SELECT @pre_base = r.pre_base_pasaje
	FROM SI_NO_APROBAMOS_HAY_TABLA.Recorrido r
	WHERE r.id_recorrido = @id_recorrido

	SELECT @porcent_adic = s.pocent_adic
	FROM SI_NO_APROBAMOS_HAY_TABLA.Recorrido r
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Servicio s
		ON r.id_servicio = s.id_servicio
	WHERE r.id_recorrido = @id_recorrido
	
	SET @pre_final = @pre_base + (@pre_base * @porcent_adic) / 100
	
	SELECT @edad=(DATEDIFF(YEAR, ISNULL(c.fecha_nacimiento, GETDATE()) , GETDATE())), 
		@sexo=ISNULL(c.sexo, 'H'),
		@discapacitado = ISNULL(c.es_discapacitado, 'N')
	FROM SI_NO_APROBAMOS_HAY_TABLA.Cliente c
	WHERE c.dni = @dni
	
	IF @discapacitado = 'S'
	BEGIN
		SELECT 0 as 'precio'
		RETURN
	END
	
	IF @sexo = 'H' AND @edad > 64
	BEGIN
		SELECT @pre_final / 2 as 'precio'
		RETURN
	END
	
	IF @sexo = 'M' AND @edad > 59
	BEGIN
		SELECT @pre_final / 2 as 'precio'
		RETURN
	END
	
	SELECT @pre_final as 'precio'
END