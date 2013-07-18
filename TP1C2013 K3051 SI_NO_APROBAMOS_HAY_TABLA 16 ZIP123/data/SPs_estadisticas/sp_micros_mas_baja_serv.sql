
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_micros_mas_baja_serv]
(
	@p_fecha_inicio datetime,
	@p_fecha_fin datetime
)
AS
BEGIN
	
	DECLARE @id_micro int
	DECLARE @patente nvarchar(50)
	DECLARE @fec_fuera datetime
	DECLARE @fec_reinic datetime

	DECLARE CUR CURSOR FOR
		SELECT	bsm.id_micros,
				m.patente,
				bsm.fec_fuera_servicio,
				ISNULL(bsm.fec_reinicio_servicio, GETDATE()) as 'fec_reinicio_servicio'
		FROM SI_NO_APROBAMOS_HAY_TABLA.baja_servicio_micro bsm
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Micros m
			ON m.id_micros = bsm.id_micros

	
	CREATE TABLE #tmpDias (
		id_micro		int,
		patente			nvarchar(50),
		dias			int
	)
	
	
	SET NOCOUNT ON
	OPEN CUR
	FETCH NEXT FROM CUR
	INTO @id_micro, @patente, @fec_fuera, @fec_reinic
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		--Todos estos if son mutuamente exclusivos
		
		IF @fec_fuera >= @p_fecha_inicio AND @fec_reinic <= @p_fecha_fin
		BEGIN
			--Arranca y termina dentro del periodo
			INSERT INTO #tmpDias (id_micro, patente, dias)
			VALUES (@id_micro, @patente, ABS(DATEDIFF(DAY, @fec_fuera, @fec_reinic)))
		END
		 
		IF @fec_fuera < @p_fecha_inicio AND @fec_reinic <= @p_fecha_fin
		BEGIN
			--Arranca antes del periodo pero termina dentro
			INSERT INTO #tmpDias (id_micro, patente, dias)
			VALUES (@id_micro, @patente, ABS(DATEDIFF(DAY, @p_fecha_inicio, @fec_reinic)))				
		END
		
		IF @fec_fuera < @p_fecha_inicio AND @fec_reinic > @p_fecha_fin
		BEGIN
			--Arranca antes del periodo y termina despues del periodo
			INSERT INTO #tmpDias (id_micro, patente, dias)
			VALUES (@id_micro, @patente, ABS(DATEDIFF(DAY, @p_fecha_inicio, @p_fecha_fin)))			
		END
		
		IF @fec_fuera >= @p_fecha_inicio AND @fec_reinic > @p_fecha_fin
		BEGIN
			--Arranca dentro del periodo pero termina despues
			INSERT INTO #tmpDias (id_micro, patente, dias)
			VALUES (@id_micro, @patente, ABS(DATEDIFF(DAY, @fec_fuera, @p_fecha_fin)))
		END
		
		FETCH NEXT FROM CUR
		INTO @id_micro, @patente, @fec_fuera, @fec_reinic
	END
	
	CLOSE CUR
	DEALLOCATE CUR
	
	SELECT TOP 5 tmp.id_micro, tmp.patente, SUM(tmp.dias) as 'diastot'
	FROM #tmpDias tmp 
	GROUP BY tmp.id_micro, tmp.patente
	ORDER BY diastot DESC
	
	DROP TABLE #tmpDias
END












