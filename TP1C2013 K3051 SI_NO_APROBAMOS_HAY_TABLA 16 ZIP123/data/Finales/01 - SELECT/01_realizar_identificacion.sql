-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Demian
-- Create date: 20/06/2013
-- Description:	identifica usuarios y graba intentos fallidos
-- =============================================
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].realizar_identificacion 
	-- Add the parameters for the stored procedure here
	@userName nvarchar(50),
	@passwordHash varbinary(32),
	@resultado int OUTPUT
AS
BEGIN
	-- 0 Exito
	-- -1 Bloqueado
	-- -2 Usuario invalido o contrasena falsa
	SET NOCOUNT ON;
	
	DECLARE @hashReal varbinary(32)
	DECLARE @fallidos int
	
	SELECT @hashReal=us.hash_password, @fallidos=us.cant_intentos_fallidos
	FROM SI_NO_APROBAMOS_HAY_TABLA.Usuario us
	WHERE us.username = @userName
	
	IF @@ROWCOUNT = 0
	BEGIN
		--Usuario invalido
		SET @resultado = -2
		RETURN
	END
	
	IF @fallidos >= 3
	BEGIN
		--Usuario bloqueado
		SET @resultado = -1
		RETURN
	END
	
	IF @hashReal = @passwordHash
	BEGIN
		--Exito
		UPDATE SI_NO_APROBAMOS_HAY_TABLA.Usuario
		SET cant_intentos_fallidos = 0
		WHERE username = @userName
		
		SET @resultado = 0
		
		RETURN
	END
	
	--Password incorrecto
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Usuario
	SET cant_intentos_fallidos = (cant_intentos_fallidos + 1)
	WHERE username = @userName
	
	SET @resultado = -2
	RETURN
		
END
GO
