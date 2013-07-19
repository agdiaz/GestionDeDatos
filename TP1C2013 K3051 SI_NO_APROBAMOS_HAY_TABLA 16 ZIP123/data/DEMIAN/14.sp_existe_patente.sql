
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_existe_patente
(
	@p_patente nvarchar(50)
)
AS
BEGIN
	SELECT COUNT(*) as 'cant'
	FROM SI_NO_APROBAMOS_HAY_TABLA.Micros
	WHERE patente = @p_patente
END