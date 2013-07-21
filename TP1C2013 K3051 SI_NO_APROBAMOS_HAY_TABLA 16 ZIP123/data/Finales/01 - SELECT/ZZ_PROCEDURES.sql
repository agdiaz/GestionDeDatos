
GO 

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

GO 


GO 

USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_obtener_usuario]    Script Date: 07/16/2013 03:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_obtener_usuario](

@p_username nvarchar(50)
)
AS
BEGIN
	SELECT 
	[id_usuario]
      ,[id_rol]
      ,[dni]
      ,[hash_password]
      ,[cant_intentos_fallidos]
      ,[username]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Usuario]
	where username = @p_username
END

GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_rol
	@p_id int
AS
BEGIN
	SELECT [id_rol]
      ,[nombre]
      ,[activado]
      ,[inhabilitado]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol]
	where Rol.id_rol = @p_id
END

GO 


GO 

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Demian
-- Create date: 20/6/2013
-- Description:	Selecciona las funcionalidades
-- =============================================
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_funcionalidades_rol(
	@p_id_rol int) 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT f.[id_funcionalidad]
      ,f.[funcionalidad]
      ,f.[activa]
      ,f.[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] f
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Rol_funcionalidad rf
		ON rf.id_funcionalidad = f.id_funcionalidad
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Rol r
		ON rf.id_rol = r.id_rol
	WHERE r.id_rol = @p_id_rol
	and r.baja = 0
	and f.baja = 0
END


GO 


GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_rol
	AS
BEGIN
	SELECT [id_rol]
      ,[nombre]
      ,[inhabilitado]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol]
  WHERE baja = 0
END

GO 


GO 


CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_funcionalidad
AS
BEGIN
SELECT [id_funcionalidad]
      ,[funcionalidad]
      ,[activa]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad]
  WHERE baja = 0
 END

GO 


GO 

USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_rol]    Script Date: 07/16/2013 01:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_rol]
	@p_rol nvarchar(50) = NULL, @p_funcionalidad nvarchar(255) = NULL 
	AS
BEGIN
	SELECT distinct r.id_rol, r.[nombre], r.inhabilitado
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] r
	left join [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].Rol_Funcionalidad rf
		on r.id_rol = rf.id_rol
	left join [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].Funcionalidad f
		on rf.id_funcionalidad = f.id_funcionalidad
	where ((@p_rol IS NULL) OR (r.nombre like '%' + @p_rol + '%'))
	and ((@p_funcionalidad IS NULL) OR (f.funcionalidad like '%' +  @p_funcionalidad + '%'))
	and r.baja = 0
	and rf.baja = 0
	and f.baja = 0
END

GO 


GO 

USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_rol]    Script Date: 07/16/2013 00:51:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*===========================SP INSERT ROL==============================*/

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_rol]
(
	@p_nombre nvarchar(50),
	@p_inhabilitado bit,
	@p_id int output
)
AS
BEGIN

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol]
           ([nombre]
           ,[inhabilitado])
     VALUES (@p_nombre,@p_inhabilitado)

SET @p_id = SCOPE_IDENTITY()

END

/*===========================SP INSERT ROL FUNCIONALIDAD==============================*/

GO 


GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_rol_funcionalidad]
(
	@p_id_rol int,
	@p_id_funcionalidad int
)
AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_funcionalidad]
           ([id_rol]
           ,[id_funcionalidad])
     VALUES (@p_id_rol, @p_id_funcionalidad)
END

GO 


GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_baja_funcionalidades]
(
	@p_id_rol int 
)
AS
BEGIN

DELETE FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad]
	WHERE Rol_funcionalidad.id_rol = @p_id_rol
END


GO 


GO 

USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_delete_rol]    Script Date: 07/16/2013 00:50:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_delete_rol]
(
	@p_id_rol int
)
AS
BEGIN
	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol]
	SET baja=1
	WHERE Rol.id_rol = @p_id_rol
END

GO 


GO 


CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_ciudad 
AS
BEGIN
	SELECT [id_ciudad],[nombre],[baja]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad]
	WHERE baja = 0
END

GO 


GO 

USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_ciudad]    Script Date: 07/16/2013 01:22:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_ciudad] 
	@p_nombre varchar(50) = NULL
AS
BEGIN
	SELECT c.[id_ciudad],c.[nombre]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] c
	where ((@p_nombre IS NULL) OR (c.nombre like '%' + @p_nombre + '%'))	
	and baja = 0
END

GO 


GO 

USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_ciudad]    Script Date: 07/16/2013 01:18:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*===========================SP INSERT CIUDAD==============================*/

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_ciudad]
(
	@p_nombre varchar(50),
	@p_id int output
)
AS
BEGIN

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad]
           ([nombre])
     VALUES
           (@p_nombre)

SET @p_id = SCOPE_IDENTITY()

END

/*===========================SP INSERT CLIENTE==============================*/

GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_update_ciudad(
	@p_nombre varchar(50),
	@p_id int
)
AS
BEGIN
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Ciudad
	SET nombre = @p_nombre
	WHERE id_ciudad = @p_id
END

GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_delete_ciudad
(
@p_id_ciudad INT
)
AS
BEGIN
	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].Ciudad
	SET baja=1			
	WHERE id_ciudad=@p_id_ciudad
END
GO 


GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_servicio
AS
BEGIN
  SELECT [id_servicio]
	,[tipo_servicio]
	,[pocent_adic]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Servicio]
  WHERE [baja] = 0
END


GO 


GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_recorrido
	AS
BEGIN
	SELECT r.[id_recorrido]
      ,r.[id_ciudad_origen]
	  ,co.[nombre] as 'nombreOrigen'
      ,r.[id_ciudad_destino]
      ,cd.[nombre] as 'nombreDestino'
	  ,r.[pre_base_kg]
      ,r.[pre_base_pasaje]
      ,r.[id_servicio]
      ,r.[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] r
  INNER JOIN [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] co
	ON r.id_ciudad_origen = co.id_ciudad
  INNER JOIN [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] cd
	ON r.id_ciudad_destino = cd.id_ciudad
  WHERE r.[baja] = 0
END

GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_cliente
	@p_dni numeric(18,0)
AS
BEGIN
	SELECT TOP 1 [dni]
      ,[nombre]
      ,[apellido]
      ,[direccion]
      ,[telefono]
      ,[mail]
      ,[fecha_nacimiento]
      ,[es_discapacitado]
      ,[sexo]
      ,[inhabilitado]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
	WHERE Cliente.dni = @p_dni
END


GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_ciudad(
	@p_id int
)
AS
BEGIN
	SELECT [id_ciudad]
      ,[nombre]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad]
	WHERE Ciudad.id_ciudad = @p_id
END
GO

GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_servicio
	@p_id int
AS
BEGIN
	SELECT s.id_servicio, s.tipo_servicio, s.pocent_adic
	from SI_NO_APROBAMOS_HAY_TABLA.Servicio s
	where s.id_servicio = @p_id
END
GO

GO 


GO 

USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_recorrido]    Script Date: 07/16/2013 02:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_recorrido]
	@p_id_ciudad_origen int=NULL,
	@p_id_ciudad_destino int=NULL, 
	@p_id_servicio int=NULL
	AS
BEGIN
	SELECT distinct r.[id_recorrido]
      ,r.[id_ciudad_origen]
      ,r.[id_ciudad_destino]
      ,r.[pre_base_kg]
      ,r.[pre_base_pasaje]
      ,r.[id_servicio]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] r 
	where ((@p_id_ciudad_origen IS NULL) OR (r.id_ciudad_origen = @p_id_ciudad_origen))
	and ((@p_id_ciudad_destino IS NULL) OR (r.id_ciudad_destino = @p_id_ciudad_destino))
	and ((@p_id_servicio IS NULL) OR ( r.id_servicio = @p_id_servicio))
	and r.baja = 0
END

GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_recorrido
(
	@p_id int output,
	@p_id_ciudad_origen int,
	@p_id_ciudad_destino int,
	@p_pre_base_kg numeric(18,2),
	@p_pre_base_pasaje numeric(18,2),
	@p_id_servicio int
)
AS
BEGIN
	INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido]
           ([id_ciudad_origen]
           ,[id_ciudad_destino]
           ,[pre_base_kg]
           ,[pre_base_pasaje]
           ,[id_servicio])
	VALUES
           (@p_id_ciudad_origen,
           @p_id_ciudad_destino,
           @p_pre_base_kg,
           @p_pre_base_pasaje,
           @p_id_servicio)
           
	  SET @p_id = SCOPE_IDENTITY()
END
GO 


GO 

USE [GD1C2013]
GO

/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_update_recorrido]    Script Date: 07/16/2013 03:04:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_update_recorrido]
(
	@p_id int,
	@p_id_ciudad_origen int,
	@p_id_ciudad_destino int,
	@p_pre_base_kg numeric(18,2),
	@p_pre_base_pasaje numeric(18,2),
	@p_id_servicio int
)
AS
BEGIN
UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].Recorrido
SET id_ciudad_origen = @p_id_ciudad_origen,
	id_ciudad_destino = @p_id_ciudad_destino,
	pre_base_kg = @p_pre_base_kg,
	pre_base_pasaje = @p_pre_base_pasaje,
	id_servicio = @p_id_servicio 
	
WHERE id_recorrido =@p_id
END

GO


GO 


GO 


CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_baja_recorrido
	@id_recorrido numeric(18,0) 
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION baja_recorrido
	DECLARE @motivo nvarchar(200)
	SET @motivo = 'Baja de recorrido'
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Recorrido 
	SET baja = 1
	WHERE id_recorrido = @id_recorrido
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Viaje
	SET baja = 1
	WHERE id_recorrido = @id_recorrido
	
	--Doy de baja todas las compras del recorrido
	declare @idCompraAct int

	declare cur CURSOR LOCAL for
		SELECT c.id_compra
		FROM SI_NO_APROBAMOS_HAY_TABLA.Compra c
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
			ON p.id_compra = c.id_compra
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Viaje v
			ON p.id_viaje = v.id_viaje
			AND v.id_recorrido = @id_recorrido
		WHERE c.id_cancelacion IS NULL
		
	open cur

	fetch next from cur into @idCompraAct

	while @@FETCH_STATUS = 0 
	BEGIN
		exec SI_NO_APROBAMOS_HAY_TABLA.sp_cancelar_compra @idCompraAct, @motivo
		fetch next from cur into @idCompraAct 
	END

	close cur
	deallocate cur

	COMMIT TRANSACTION baja_recorrido	
END
GO 


GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_cancelar_compra
	@id_compra	int,
	@motivo		nvarchar(200)
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION cancel 
	DECLARE @id_cancel int
	
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Cancelacion
	  (motivo_cancel)
	VALUES (@motivo)
	
	SET @id_cancel = SCOPE_IDENTITY()
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Compra
	SET id_cancelacion = @id_cancel
	WHERE id_compra = @id_compra
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Encomienda
	SET id_cancelacion = @id_cancel
	WHERE id_compra = @id_compra
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Pasaje
	SET id_cancelacion = @id_cancel
	WHERE id_compra = @id_compra
	
	COMMIT TRANSACTION cancel
END
GO 


GO 


CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_baja_recorrido
	@id_recorrido numeric(18,0) 
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION baja_recorrido
	DECLARE @motivo nvarchar(200)
	SET @motivo = 'Baja de recorrido'
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Recorrido 
	SET baja = 1
	WHERE id_recorrido = @id_recorrido
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Viaje
	SET baja = 1
	WHERE id_recorrido = @id_recorrido
	
	--Doy de baja todas las compras del recorrido
	declare @idCompraAct int

	declare cur CURSOR LOCAL for
		SELECT c.id_compra
		FROM SI_NO_APROBAMOS_HAY_TABLA.Compra c
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
			ON p.id_compra = c.id_compra
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Viaje v
			ON p.id_viaje = v.id_viaje
			AND v.id_recorrido = @id_recorrido
		WHERE c.id_cancelacion IS NULL
		
	open cur

	fetch next from cur into @idCompraAct

	while @@FETCH_STATUS = 0 
	BEGIN
		exec SI_NO_APROBAMOS_HAY_TABLA.sp_cancelar_compra @idCompraAct, @motivo
		fetch next from cur into @idCompraAct 
	END

	close cur
	deallocate cur

	COMMIT TRANSACTION baja_recorrido	
END
GO 


GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_marca
AS
BEGIN
SELECT [id_marca],[nombre]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Marca]
  WHERE
  baja = 0
END
GO 


GO 

USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_micros]    Script Date: 07/16/2013 20:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_micros]
AS
BEGIN
SELECT Mi.[id_micros]
      ,Mi.[fecha_alta]
      ,Mi.[nro_micro]
      ,Mi.[modelo]
      ,Mi.[patente]
      ,Ma.nombre
      ,Ma.id_marca
      ,Mi.[id_servicio]
      ,Mi.[baja_vida_util]
      ,Mi.[fec_baja_vida_util]
      ,Mi.[capacidad_kg]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros] Mi
  INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Marca Ma
	on Mi.id_marca = Ma.id_marca
  WHERE Mi.baja = 0
END

GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_marca
	@p_id int
AS
BEGIN
SELECT [id_marca]
      ,[nombre]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Marca]
	WHERE id_marca = @p_id
END

GO 


GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_micros
	@p_marca varchar(50) = NULL, 
	@p_modelo nvarchar(50) = NULL,
	@p_tipo_servicio nvarchar(255) = NULL,
	@p_patente nvarchar(50) = NULL,
	@p_nro_micro int = NULL,
	@p_kgs_encomienda numeric(18,2)= NULL 
AS
BEGIN
	SELECT m.[id_micros]
      ,m.[fecha_alta]
      ,m.[nro_micro]
      ,m.[modelo]
      ,m.[patente]
      ,m.[id_marca]
      ,m.[id_servicio]
      ,m.[baja_vida_util]
      ,m.[fec_baja_vida_util]
      ,m.[capacidad_kg]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros] m
	left join SI_NO_APROBAMOS_HAY_TABLA.Servicio s
		on s.id_servicio = m.id_servicio
	left join SI_NO_APROBAMOS_HAY_TABLA.Marca ma
		on ma.id_marca = m.id_marca 
	where ((@p_modelo IS NULL) OR (m.modelo like '%' + @p_modelo + '%' ))
	and ((@p_patente IS NULL) OR (m.patente like '%' + @p_patente + '%' ))
	and ((@p_nro_micro IS NULL) OR (m.nro_micro = @p_nro_micro ))
	and ((@p_kgs_encomienda IS NULL) OR (m.capacidad_kg = @p_kgs_encomienda ))
	and ((@p_marca IS NULL) OR (ma.nombre = @p_marca))
	and ((@p_tipo_servicio IS NULL) OR (s.tipo_servicio = @p_tipo_servicio ))
	and m.baja = 0
END
GO 


GO 

USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_micro]    Script Date: 07/20/2013 01:39:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_micro]
(
	@p_fecha_alta datetime2(7),
	@p_nro_micro int,
	@p_modelo nvarchar(50),
	@p_patente nvarchar(50),
	@p_id_marca int,
	@p_id_servicio int,
	@p_baja_vida_util bit,
	@p_fec_baja_vida_util datetime = NULL,
	@p_capacidad_kg numeric(18,2),
	@p_id int output
)
AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
           ([fecha_alta]
           ,[nro_micro]
           ,[modelo]
           ,[patente]
           ,[id_marca]
           ,[id_servicio]
           ,[baja_vida_util]
           ,[fec_baja_vida_util]
           ,[capacidad_kg]
           ,[baja])
     VALUES
           (@p_fecha_alta
           ,@p_nro_micro
           ,@p_modelo
           ,@p_patente
           ,@p_id_marca
           ,@p_id_servicio
           ,@p_baja_vida_util
           ,@p_fec_baja_vida_util
           ,@p_capacidad_kg
           ,0)
	SET @p_id = SCOPE_IDENTITY()
END
GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_butaca
(

	@p_nro_butaca numeric(18,0),
	@p_id_micro int,
	@p_tipo_butaca nvarchar(50),
	@p_piso numeric(18,0),
	@p_id int output
)

AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Butaca]
           ([nro_butaca]
           ,[id_micro]
           ,[tipo_butaca]
           ,[piso])
     VALUES
           (@p_nro_butaca
           ,@p_id_micro
           ,@p_tipo_butaca
           ,@p_piso)

SET @p_id = SCOPE_IDENTITY()

END

GO 


GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_update_micro]
	@p_marca varchar(50) = NULL, 
	@p_modelo nvarchar(50) = NULL,
	@p_tipo_servicio nvarchar(255) = NULL,
	@p_patente nvarchar(50) = NULL,
	@p_kgs_encomienda numeric(18,2)= NULL,
	@p_fecha_alta datetime,
	@p_baja_vida_util bit,
	@p_fec_baja_vida_util datetime,
	@p_id int
AS
BEGIN
UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
   SET [fecha_alta] = @p_fecha_alta
      ,[modelo] = @p_modelo
      ,[patente] = @p_patente
      ,[id_marca] = @p_marca
      ,[id_servicio] = @p_tipo_servicio
      ,[baja_vida_util] = @p_baja_vida_util
      ,[fec_baja_vida_util] = @p_fec_baja_vida_util
      ,[capacidad_kg] = @p_kgs_encomienda
      
 WHERE id_micros = @p_id
END


GO 


GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_baja_logica_micro
(
	@id_micro int
)
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION baja_logica_micro
	
	DECLARE @idCompraAct int

	DECLARE cur_compras CURSOR LOCAL for
		SELECT DISTINCT c.id_compra
		FROM SI_NO_APROBAMOS_HAY_TABLA.Viaje v
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
			ON p.id_viaje = v.id_viaje
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Encomienda e
			ON e.id_viaje = v.id_viaje
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Compra c
			ON p.id_compra = c.id_compra
			OR e.id_compra = c.id_compra
		WHERE v.id_micro = @id_micro
		AND v.baja = 0
		AND p.baja = 0
		AND e.baja = 0

	open cur_compras

	fetch next from cur_compras into @idCompraAct

	while @@FETCH_STATUS = 0 
	BEGIN
		exec SI_NO_APROBAMOS_HAY_TABLA.sp_cancelar_compra @idCompraAct, 'Baja de micro' 
		fetch next from cur_compras into @idCompraAct 
	END

	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
	SET Micros.baja = 1
	WHERE Micros.id_micros = @id_micro
	
	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Butaca]
	SET Butaca.baja = 1
	WHERE Butaca.id_micro = @id_micro
		
	COMMIT TRANSACTION baja_logica_micro
END


GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_marca
(
	@p_nombre varchar(50),
	@p_id int output
)
AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Marca]
           ([nombre])
     VALUES
           (@p_nombre)
           
           SET @p_id = SCOPE_IDENTITY()
END

GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_servicio
(	@p_tipo_servicio nvarchar(255),
    @p_adicional decimal(5,2),
    @p_id int output
)
AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Servicio]
           ([tipo_servicio]
           ,[pocent_adic]
           ,[baja])
     VALUES (@p_tipo_servicio, @p_adicional, 0)

SET @p_id = SCOPE_IDENTITY()
     
END

GO 


GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_viaje(
@p_fecha_salida datetime = NULL,
@p_fecha_llegada datetime = NULL,
@p_fecha_llegada_estimada datetime = NULL,
@p_micro int = NULL,
@p_recorrido numeric(18,2) = NULL 
)
	AS
BEGIN
	SELECT v.[id_viaje]
      ,v.[id_recorrido]
      ,v.[id_micro]
      ,v.[fecha_salida]
      ,v.[fecha_arribo_estimada]
      ,v.[fecha_arribo]
	 FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje] v
	where ((@p_fecha_salida IS NULL) OR (v.fecha_salida = @p_fecha_salida))
	and ((@p_fecha_llegada IS NULL) OR  (v.fecha_arribo = @p_fecha_llegada))
	and ((@p_fecha_llegada_estimada IS NULL) OR (v.fecha_arribo_estimada = @p_fecha_llegada_estimada ))
	and ((@p_micro IS NULL) OR (v.id_micro = @p_micro))
	and ((@p_recorrido IS NULL) OR (v.id_recorrido = @p_recorrido))
END


GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_recorrido(
	@p_id numeric(18,0)
	)
AS
BEGIN
	SELECT [id_recorrido]
      ,[id_ciudad_origen]
      ,[id_ciudad_destino]
      ,[pre_base_kg]
      ,[pre_base_pasaje]
      ,[id_servicio]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido]
WHERE id_recorrido = @p_id
END

GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_micro
	@p_id int
AS
BEGIN
	SELECT TOP 1 [id_micros]
      ,[fecha_alta]
      ,[nro_micro]
      ,[modelo]
      ,[patente]
      ,[id_marca]
      ,[id_servicio]
      ,[baja_vida_util]
      ,[fec_baja_vida_util]
      ,[capacidad_kg]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
  WHERE id_micros = @p_id
END
GO

GO 


GO 

USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_cliente]    Script Date: 07/18/2013 02:28:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_cliente]
AS
BEGIN
	SELECT c.[dni]
      ,c.[nombre]
      ,c.[apellido]
      ,c.[direccion]
      ,c.[telefono]
      ,c.[mail]
      ,c.[fecha_nacimiento]
      ,c.[es_discapacitado]
      ,c.[sexo]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente] c
  WHERE c.baja = 0
END

GO 


GO 

USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_cliente]    Script Date: 07/18/2013 00:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_cliente]
	@p_dni numeric(18,0) = NULL,
	@p_nombre nvarchar(255) = NULL,
	@p_apellido nvarchar(255) = NULL,
	@p_discapacitado CHAR(1) = NULL,
	@p_sexo varchar(50) = NULL
AS
BEGIN
	SELECT [dni]
      ,[nombre]
      ,[apellido]
      ,[direccion]
      ,[telefono]
      ,[mail]
      ,[fecha_nacimiento]
      ,[es_discapacitado]
      ,[sexo]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
	where ((@p_dni IS NULL) OR (dni = @p_dni))
	and ((@p_nombre IS NULL) OR (UPPER(nombre) like '%' + UPPER(@p_nombre) +'%'))
	and ((@p_apellido IS NULL) OR (apellido like '%' + @p_apellido + '%'))
	and ((@p_discapacitado IS NULL) OR (ISNULL(es_discapacitado, 'N') = @p_discapacitado))
	and ((@p_sexo IS NULL) OR (sexo like '%' + @p_sexo + '%'))
	and baja=0
END

GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_cliente
(
	@p_dni numeric(18,0),
	@p_nombre nvarchar(255),
	@p_apellido nvarchar(255),
	@p_direccion nvarchar(255),
	@p_telefono numeric(18,0),
	@p_mail nvarchar(255),
	@p_fecha_nacimiento datetime,
	@p_es_discapacitado char(1),
	@p_sexo varchar(50)
)
AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
           ([dni]
           ,[nombre]
           ,[apellido]
           ,[direccion]
           ,[telefono]
           ,[mail]
           ,[fecha_nacimiento]
           ,[es_discapacitado]
           ,[sexo])
     VALUES
           (@p_dni
           ,@p_nombre
           ,@p_apellido
           ,@p_direccion
           ,@p_telefono
           ,@p_mail
           ,@p_fecha_nacimiento
           ,@p_es_discapacitado
           ,@p_sexo)
END

GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_update_cliente
(
	@p_dni numeric(18,0),
	@p_nombre nvarchar(255),
	@p_apellido nvarchar(255),
	@p_direccion nvarchar(255),
	@p_telefono numeric(18,0),
	@p_mail nvarchar(255),
	@p_fecha_nacimiento datetime,
	@p_es_discapacitado char(1),
	@p_sexo varchar(50)
)
AS
BEGIN
UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
SET [nombre]=@p_nombre
           ,[apellido]=@p_apellido
           ,[direccion]=@p_direccion
           ,[telefono]=@p_telefono
           ,[mail]=@p_mail
           ,[fecha_nacimiento]=@p_fecha_nacimiento
           ,[es_discapacitado]=@p_es_discapacitado
           ,[sexo]=@p_sexo
WHERE [dni]=@p_dni
END


GO 


GO 

USE [GD1C2013]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_recompensa]
	@p_descrip nvarchar(200),
	@p_puntos_desde int,
	@p_puntos_hasta int,
	@p_stock_desde int,
	@p_stock_hasta int
AS
BEGIN
	SELECT
		id_recompensa,
		descripcion,
		stock,
		puntos_costo
	FROM SI_NO_APROBAMOS_HAY_TABLA.Recompensa
	WHERE((@p_descrip IS NULL) OR (UPPER(descripcion) LIKE '%'  + UPPER(@p_descrip) + '%'))
	AND ((@p_puntos_desde IS NULL) OR (puntos_costo >= @p_puntos_desde))
	AND ((@p_puntos_hasta IS NULL) OR (puntos_costo <= @p_puntos_hasta))
	AND ((@p_stock_desde IS NULL) OR (stock >= @p_stock_desde))
	AND ((@p_stock_hasta IS NULL) OR (stock <= @p_stock_hasta))
END

GO 


GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_puntos_por_cliente]
(
	@p_dni numeric(18,0)
)
AS
BEGIN
	SELECT SUM(p.puntos - p.puntos_usados) as 'puntosTotales'
	FROM SI_NO_APROBAMOS_HAY_TABLA.Puntaje p
	WHERE DATEDIFF(year,p.fecha_otorgado, GETDATE() ) < 1
	AND p.dni = @p_dni
	GROUP BY p.dni
	ORDER BY puntosTotales DESC
END
GO 


GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_puntos_por_cliente_detallado
(
	@p_dni numeric(18,0)
)
AS
BEGIN
	SELECT p.dni,
	(p.puntos) as 'puntosOtorgados',
	(p.puntos_usados) as 'puntosUtilizados', 
	(p.puntos - p.puntos_usados) as 'puntosRestantes',
	(p.fecha_otorgado)
	FROM SI_NO_APROBAMOS_HAY_TABLA.Puntaje p
	WHERE DATEDIFF(year,p.fecha_otorgado, GETDATE() ) < 1
	AND p.dni = @p_dni
	ORDER BY p.fecha_otorgado ASC
END
GO 


GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_canjear_recompensa
(
	@p_dni numeric(18,0),
	@p_id_recompensa int,
	@p_cantidad	int
)
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION canje_recompensa
	
	DECLARE @puntos_costo int
	DECLARE @puntos_act int
	DECLARE @puntos_usados_act int
	DECLARE @stock_check int
	
	SELECT @puntos_costo = (r.puntos_costo * @p_cantidad)
	FROM [SI_NO_APROBAMOS_HAY_TABLA].Recompensa r
	WHERE id_recompensa = @p_id_recompensa
	
	SELECT @stock_check=r.stock
	FROM [SI_NO_APROBAMOS_HAY_TABLA].Recompensa r
	WHERE id_recompensa = @p_id_recompensa
	
	IF ( @stock_check - @p_cantidad ) < 0
	BEGIN
		ROLLBACK TRANSACTION canje_recompensa
		RAISERROR('No hay stock suficiente', 12, 2)
	END
	
	UPDATE [SI_NO_APROBAMOS_HAY_TABLA].Recompensa
	SET stock = stock - @p_cantidad
	WHERE id_recompensa = @p_id_recompensa

	DECLARE CUR_PUNTAJE CURSOR FOR
		SELECT p.puntos, p.puntos_usados
		FROM [SI_NO_APROBAMOS_HAY_TABLA].Puntaje p
		WHERE p.dni = @p_dni
		AND DATEDIFF(year, p.fecha_otorgado, GETDATE()) < 1
		AND (p.puntos -  p.puntos_usados) >0 
		AND baja = 0
		ORDER BY p.fecha_otorgado ASC
		FOR UPDATE OF p.puntos_usados
	
	SET NOCOUNT ON	
	OPEN CUR_PUNTAJE
	FETCH NEXT FROM CUR_PUNTAJE 
	INTO @puntos_act, @puntos_usados_act
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF (@puntos_act - @puntos_usados_act) > @puntos_costo
		BEGIN
			--Hay puntos suficientes aca
			UPDATE [SI_NO_APROBAMOS_HAY_TABLA].Puntaje 
			SET puntos_usados = puntos_usados + @puntos_costo
			WHERE CURRENT OF CUR_PUNTAJE
			SET @puntos_costo = 0
			BREAK 
		END
		ELSE
		BEGIN
			--todavia no hay puntos suficientes en esta linea
			SET @puntos_costo = @puntos_costo - (@puntos_act - @puntos_usados_act)
			UPDATE [SI_NO_APROBAMOS_HAY_TABLA].Puntaje 
			SET puntos_usados = puntos
			WHERE CURRENT OF CUR_PUNTAJE
		END
		
		FETCH NEXT FROM CUR_PUNTAJE 
		INTO @puntos_act, @puntos_usados_act
	END	
	
	IF @puntos_costo = 0
	BEGIN
		COMMIT TRANSACTION canje_recompensa
	END
	ELSE
	BEGIN
		ROLLBACK TRANSACTION canje_recompensa
		RAISERROR('No hay suficientes puntos', 12, 2)
	END
	
	CLOSE CUR_PUNTAJE
	DEALLOCATE CUR_PUNTAJE
END
GO


GO 


GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_clientes_mas_puntos]
(
	@fecha_inicio datetime,
	@fecha_fin datetime
)
AS
BEGIN
	SELECT TOP 5 p.dni, SUM(p.puntos - p.puntos_usados) as 'puntosTotales'
	FROM SI_NO_APROBAMOS_HAY_TABLA.Puntaje p
	WHERE p.fecha_otorgado BETWEEN @fecha_inicio AND @fecha_fin
	GROUP BY p.dni
	ORDER BY puntosTotales DESC
END
GO 


GO 

GO
CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].butacas_vendidas_por_viaje
(
	@id_viaje int
)
RETURNS int
BEGIN
	DECLARE @butacas_vendidas_x_viaje int
	SELECT @butacas_vendidas_x_viaje=COUNT(*)
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje] AS viaje
		INNER JOIN [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[pasaje] AS pasaje
			ON viaje.id_viaje=pasaje.id_viaje
	WHERE viaje.id_viaje=@id_viaje AND pasaje.id_cancelacion IS NULL
	RETURN @butacas_vendidas_x_viaje
END

GO

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_top5_destino_mas_vendido_por_semestre]
(
	@fecha_inicio datetime,
	@fecha_fin datetime
)
AS
BEGIN
	SELECT DISTINCT TOP 5 ciudad.[nombre],
			SUM ([SI_NO_APROBAMOS_HAY_TABLA].butacas_vendidas_por_viaje(viaje.[id_viaje])) AS butacas_vendidas
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] as ciudad
		 inner join [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] as recorrido
			on ciudad.[id_ciudad]=recorrido.[id_ciudad_destino]
		 inner join [SI_NO_APROBAMOS_HAY_TABLA].[Viaje] as viaje
			on viaje.[id_recorrido]=recorrido.id_recorrido
	WHERE recorrido.baja=0 
			AND viaje.baja=0 
			AND viaje.fecha_salida BETWEEN @fecha_inicio AND @fecha_fin
	GROUP BY ciudad.[id_ciudad], ciudad.[nombre]
	ORDER BY SUM ([SI_NO_APROBAMOS_HAY_TABLA].butacas_vendidas_por_viaje(viaje.[id_viaje])) desc
END

GO 


GO 


CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_micros_mas_baja_serv]
(
	@fecha_inicio datetime,
	@fecha_fin datetime
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
		
		IF @fec_fuera >= @fecha_inicio AND
			@fec_fuera < @fecha_fin	AND
			@fec_reinic <= @fecha_fin AND
			@fec_reinic > @fecha_fin
		BEGIN
			--Arranca y termina dentro del periodo
			INSERT INTO #tmpDias (id_micro, patente, dias)
			VALUES (@id_micro, @patente, ABS(DATEDIFF(DAY, @fec_fuera, @fec_reinic)))
		END
		 
		IF @fec_fuera < @fecha_inicio AND
			@fec_fuera < @fecha_fin	AND
			@fec_reinic <= @fecha_fin AND
			@fec_reinic > @fecha_inicio
		BEGIN
			--Arranca antes del periodo pero termina dentro
			INSERT INTO #tmpDias (id_micro, patente, dias)
			VALUES (@id_micro, @patente, ABS(DATEDIFF(DAY, @fecha_inicio, @fec_reinic)))				
		END
		
		IF @fec_fuera < @fecha_inicio AND 
			@fec_fuera < @fecha_fin AND
			@fec_reinic > @fecha_fin AND
			@fec_reinic > @fecha_inicio
		BEGIN
			--Arranca antes del periodo y termina despues del periodo
			INSERT INTO #tmpDias (id_micro, patente, dias)
			VALUES (@id_micro, @patente, ABS(DATEDIFF(DAY, @fecha_inicio, @fecha_fin)))			
		END
		
		IF @fec_fuera >= @fecha_inicio AND
			@fec_fuera < @fecha_fin AND
			@fec_reinic > @fecha_fin AND
			@fec_reinic > @fecha_inicio
		BEGIN
			--Arranca dentro del periodo pero termina despues
			INSERT INTO #tmpDias (id_micro, patente, dias)
			VALUES (@id_micro, @patente, ABS(DATEDIFF(DAY, @fec_fuera, @fecha_fin)))
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













GO 


GO 

CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].cant_pasajes_cancelados_viaje
(
	@id_viaje int
)
RETURNS int
AS
BEGIN
	DECLARE @cant_pasajes_cancelados_x_viaje int
	
	SELECT @cant_pasajes_cancelados_x_viaje=COUNT(*)
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Pasaje] AS pasaje
	WHERE pasaje.id_viaje=@id_viaje
			AND pasaje.id_cancelacion IS NOT NULL
	
	RETURN @cant_pasajes_cancelados_x_viaje
END

GO

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_top5_destinos_mas_cancelados_por_semestre]
(
	@fecha_inicio datetime,
	@fecha_fin datetime
)
AS
BEGIN
	SELECT DISTINCT TOP 5 ciudad.[nombre],
			SUM ([SI_NO_APROBAMOS_HAY_TABLA].cant_pasajes_cancelados_viaje(viaje.[id_viaje])) AS pasajes_cancelados
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] AS ciudad
		 INNER JOIN [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] AS recorrido
			ON ciudad.[id_ciudad]=recorrido.[id_ciudad_destino]
		 INNER JOIN [SI_NO_APROBAMOS_HAY_TABLA].[Viaje] AS viaje
			ON viaje.[id_recorrido]=recorrido.id_recorrido
	WHERE recorrido.baja=0 
			AND viaje.baja=0 
			AND viaje.fecha_salida BETWEEN @fecha_inicio AND @fecha_fin
	GROUP BY ciudad.[id_ciudad], ciudad.[nombre]
	ORDER BY SUM ([SI_NO_APROBAMOS_HAY_TABLA].cant_pasajes_cancelados_viaje(viaje.[id_viaje])) DESC
END

GO 


GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_top5_destino_micros_mas_vacios_por_semestre]
(
	@fecha_inicio datetime,
	@fecha_fin datetime
)
AS
BEGIN
	SELECT DISTINCT TOP 5 ciudad.[nombre],
			SUM ([SI_NO_APROBAMOS_HAY_TABLA].cant_butacas_disp_viaje(viaje.[id_viaje])) AS butacas_libres_x_viaje
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] as ciudad
		 inner join [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] as recorrido
			on ciudad.[id_ciudad]=recorrido.[id_ciudad_destino]
		 inner join [SI_NO_APROBAMOS_HAY_TABLA].[Viaje] as viaje
			on viaje.[id_recorrido]=recorrido.id_recorrido
	WHERE recorrido.baja=0 
			AND viaje.baja=0 
	GROUP BY ciudad.[id_ciudad], ciudad.[nombre]
	ORDER BY SUM ([SI_NO_APROBAMOS_HAY_TABLA].cant_butacas_disp_viaje(viaje.[id_viaje])) desc
END

GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_precio_final_pasaje
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
GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_butacas_ocupadas_viaje
(
	@p_id_viaje int
)
AS
BEGIN
	SELECT b.id_butaca, b.nro_butaca, b.tipo_butaca, b.piso, b.id_micro
	FROM SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Butaca b
	ON b.id_butaca = p.id_butaca
	WHERE p.id_viaje = @p_id_viaje
END
GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_butacas_libres_viaje
(
	@p_id_viaje int
)
AS
BEGIN
	SELECT b.id_butaca, b.nro_butaca, b.tipo_butaca, b.piso
	FROM SI_NO_APROBAMOS_HAY_TABLA.Butaca b
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Micros m
		ON m.id_micros = b.id_micro
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Viaje v
		ON v.id_micro = m.id_micros
	WHERE v.id_viaje = @p_id_viaje
	AND b.id_butaca NOT IN
		(
			SELECT b.id_butaca
			FROM SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
			INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Butaca b
				ON b.id_butaca = p.id_butaca
			WHERE p.id_viaje = @p_id_viaje	
		)
END
GO 


GO 


CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].cant_butacas_disp_viaje
(
	@id_viaje int
)
RETURNS int
AS
BEGIN
	DECLARE @cant_total int
	DECLARE @cant_ocupadas int
	DECLARE @id_micro int
	
	SELECT @id_micro=m.id_micros, @cant_total=COUNT(b.id_butaca)
	FROM SI_NO_APROBAMOS_HAY_TABLA.Viaje v
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Micros m
		ON v.id_micro = m.id_micros
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Butaca b
		ON b.id_micro = m.id_micros
	WHERE v.id_viaje = @id_viaje
	GROUP BY v.id_viaje, m.id_micros
	
	SELECT @cant_ocupadas=COUNT(*)
	FROM SI_NO_APROBAMOS_HAY_TABLA.Viaje v
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
		ON p.id_viaje = v.id_viaje
	WHERE v.id_viaje = @id_viaje
	
	return @cant_total - @cant_ocupadas
END

GO 


GO 

CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].kg_disponibles_viaje
(
	@id_viaje int
)
RETURNS numeric(18,2)
AS
BEGIN
	DECLARE @kg_totales numeric(18,0)
	DECLARE @kg_ocupados numeric(18,0)
	
	SELECT @kg_totales=m.capacidad_kg
	FROM [SI_NO_APROBAMOS_HAY_TABLA].Viaje v
	INNER JOIN [SI_NO_APROBAMOS_HAY_TABLA].Micros m
		ON v.id_micro = m.id_micros
	WHERE v.id_viaje = @id_viaje
	
	SELECT @kg_ocupados=SUM(e.peso)
	FROM [SI_NO_APROBAMOS_HAY_TABLA].Viaje v
	INNER JOIN [SI_NO_APROBAMOS_HAY_TABLA].Encomienda e
		ON e.id_viaje = v.id_viaje
	WHERE v.id_viaje = @id_viaje
	
	RETURN @kg_totales - @kg_ocupados
		
END

GO 


GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_obtener_micro_disponibilidades
(
	@p_id_viaje int
)
AS
BEGIN
	SELECT [SI_NO_APROBAMOS_HAY_TABLA].kg_disponibles_viaje(@p_id_viaje) as kgs,
	[SI_NO_APROBAMOS_HAY_TABLA].cant_butacas_disp_viaje(@p_id_viaje) as butacas
	
END
GO 


GO 

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
GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_compra
(	
	@p_id_compra int output,
	@p_id_usuario int,
	@p_fecha_compra datetime
)
AS
BEGIN
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Compra
		(id_usuario, fecha_compra)
	VALUES
		(@p_id_usuario, @p_fecha_compra)

	SET @p_id_compra = SCOPE_IDENTITY()
END

GO 


GO 


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
GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insertar_encomienda
(
	@p_id_encomienda int output,
	@p_id_compra int,
	@p_dni numeric(18,0),
	@p_pre_encomienda int,
	@p_id_viaje int
)
AS
BEGIN
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Encomienda
		(id_viaje, id_compra, dni, pre_encomienda)
	VALUES
		(@p_id_viaje,@p_id_compra, @p_dni, @p_pre_encomienda)

	SET @p_id_encomienda = SCOPE_IDENTITY()
END

GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insertar_pasaje
(
	@p_id_pasaje int output,
	@p_id_compra int,
	@p_id_butaca int,
	@p_dni numeric(18,0),
	@p_pre_pasaje int,
	@p_id_viaje int
)
AS
BEGIN
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Pasaje
		(id_compra, id_butaca, dni, pre_pasaje, id_viaje)
	VALUES
		(@p_id_compra, @p_id_butaca, @p_dni, @p_pre_pasaje, @p_id_viaje)

	SET @p_id_pasaje = SCOPE_IDENTITY()
END

GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_listar_compras
AS
BEGIN
SELECT [id_compra]
      ,[id_usuario]
      ,ISNULL([id_cancelacion], 0) as id_cancelacion
      ,[fecha_compra]
      ,[cancel]
      ,[fecha_cancel]
      ,ISNULL([motivo_cancel], '') as motivo_cancel
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Compra]
  WHERE [baja] = 0
END



GO 


GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_cancelar_compra
	@id_compra	int,
	@motivo		nvarchar(200)
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION cancel 
	DECLARE @id_cancel int
	
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Cancelacion
	  (motivo_cancel)
	VALUES (@motivo)
	
	SET @id_cancel = SCOPE_IDENTITY()
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Compra
	SET id_cancelacion = @id_cancel
	WHERE id_compra = @id_compra
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Compra
	SET baja = 1
	WHERE id_compra = @id_compra
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Encomienda
	SET id_cancelacion = @id_cancel
	WHERE id_compra = @id_compra
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Encomienda
	SET baja = 1
	WHERE id_compra = @id_compra
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Pasaje
	SET id_cancelacion = @id_cancel
	WHERE id_compra = @id_compra
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Pasaje
	SET baja = 1
	WHERE id_compra = @id_compra
	
	COMMIT TRANSACTION cancel
END
GO 


GO 


CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_cancelar_pasaje
	@id_pasaje	numeric(18,0),
	@motivo		nvarchar(200)
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION cancel 
	DECLARE @id_cancel int
	
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Cancelacion
	  (motivo_cancel)
	VALUES (@motivo)
	
	SET @id_cancel = SCOPE_IDENTITY()
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Pasaje
	SET id_cancelacion = @id_cancel
	WHERE id_pasaje = @id_pasaje
	
	COMMIT TRANSACTION cancel
END
GO 


GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_cancelar_encomienda
	@id_encomienda	numeric(18,0),
	@motivo			nvarchar(200)
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION cancel 
	DECLARE @id_cancel int
	
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Cancelacion
	  (motivo_cancel)
	VALUES (@motivo)
	
	SET @id_cancel = SCOPE_IDENTITY()
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Encomienda
	SET id_cancelacion = @id_cancel
	WHERE id_encomienda= @id_encomienda
	
	COMMIT TRANSACTION cancel
END
GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_listar_cancelaciones
AS
BEGIN
SELECT [id_cancelacion]
      ,[fecha_cancel]
      ,[motivo_cancel]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cancelacion]
END
GO 


GO 


CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].func_puede_reemplazar_desde
(
	@id_micro_candidato int,
	@fechaInic datetime
)
RETURNS bit 
BEGIN
	IF (
		SELECT COUNT(v.id_viaje) 
		FROM SI_NO_APROBAMOS_HAY_TABLA.Micros m
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Viaje v
			ON m.id_micros = v.id_micro
		WHERE m.id_micros = @id_micro_candidato
		AND v.fecha_salida >= @fechaInic
	) > 0
	BEGIN
		RETURN 0
	END
	RETURN 1
END

GO

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_reemplazar_futuros_por_otro_micro
(
	@id_micro int,
	@id_micro_nuevo int output
)
AS
BEGIN
	DECLARE @modelo nvarchar(50)
	DECLARE @idMarca int
	DECLARE @microElegido int
	
	SELECT @modelo=m.modelo, @idMarca=m.id_marca
	FROM SI_NO_APROBAMOS_HAY_TABLA.Micros m
	WHERE m.id_micros = @id_micro
	
	SELECT TOP 1 @microElegido=m.id_micros 
	FROM SI_NO_APROBAMOS_HAY_TABLA.Micros m
	WHERE m.modelo = @modelo
	AND m.id_marca = @idMarca
	AND [SI_NO_APROBAMOS_HAY_TABLA].func_puede_reemplazar_desde(m.id_micros, GETDATE()) = 1
	AND m.id_micros <> @id_micro
	AND m.baja = 0
	
	IF @microElegido is not null
	BEGIN
		UPDATE SI_NO_APROBAMOS_HAY_TABLA.Viaje
		SET id_micro = @microElegido
		WHERE id_micro = @id_micro
		AND fecha_salida >= GETDATE()
		SET @id_micro_nuevo = @microElegido
	END
	ELSE
	BEGIN
		SET @id_micro_nuevo = 0
	END
END
GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insertar_usuario
(
	@dni numeric(18,0),
	@username nvarchar(50)
)
AS
BEGIN	
	
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Usuario
		(id_rol, dni, username)
	VALUES (2, @dni, @username)
END
GO 


GO 

GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_obtener_usuario_por_dni](

	@p_dni numeric(18,0)
)
AS
BEGIN
	SELECT 
		[id_usuario]
      ,[id_rol]
      ,[dni]
      ,[hash_password]
      ,[cant_intentos_fallidos]
      ,[username]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Usuario]
	where dni = @p_dni
END
GO
GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_compra
(
	@p_id int
)
AS
BEGIN
SELECT [id_compra]
      ,[id_usuario]
      ,ISNULL([id_cancelacion], 0) as id_cancelacion
      ,[fecha_compra]
      ,[cancel]
      ,[fecha_cancel]
      ,ISNULL([motivo_cancel], '') as motivo_cancel
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Compra]
  WHERE id_compra = @p_id
END



GO 


GO 

USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_viaje]    Script Date: 07/18/2013 21:37:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_viaje]
(
	@p_id_recorrido numeric(18,0),
	@p_id_micro int,
	@p_fecha_salida datetime,
	@p_fecha_arribo_estimada datetime,
	@p_id int output
)
AS
BEGIN

	IF (@p_fecha_salida > GETDATE())
	BEGIN
	INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje]
           ([id_recorrido]
           ,[id_micro]
           ,[fecha_salida]
           ,[fecha_arribo_estimada]
          )
	VALUES
           (@p_id_recorrido,
           @p_id_micro,
           @p_fecha_salida,
           @p_fecha_arribo_estimada
           )
           
	SET @p_id = SCOPE_IDENTITY()
	END
END

GO 


GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_registro_llegada]
(
	@p_id_viaje int,
	@p_fecha_llegada datetime
)
AS
BEGIN
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Viaje
	SET fecha_arribo = @p_fecha_llegada
	WHERE id_viaje = @p_id_viaje
END

GO 


GO 

USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_update_rol]    Script Date: 07/16/2013 00:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_update_rol](
	@p_nombre varchar(50),
	@p_id int,
	@p_inhabilitado bit
)
AS
BEGIN
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Rol
	SET nombre = @p_nombre,
		inhabilitado = @p_inhabilitado
	WHERE id_rol = @p_id
END
GO 


GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_update_viaje]
	@p_Fecha_Salida datetime,
	@p_Fecha_Arribo_Estimada datetime,
	@p_id_micro int,
	@p_id_recorrido int,
	@p_id int
AS
BEGIN
UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje]
   SET [id_recorrido] = @p_id_recorrido
      ,[id_micro] = @p_id_micro
      ,[fecha_salida] = @p_Fecha_Salida
      ,[fecha_arribo_estimada] = @p_Fecha_Arribo_Estimada 
 WHERE id_viaje = @p_id
END


GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_delete_cliente
(
	@p_dni int
)
AS
BEGIN
UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
	SET baja=1			
	WHERE Cliente.dni=@p_dni
END

GO 


GO 

CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_delete_viaje
(
	@p_id int
)
AS
BEGIN
UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje]
	SET baja=1			
	WHERE id_viaje=@p_id
END

GO 


GO 

GO 
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
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_obtener_usuario]    Script Date: 07/16/2013 03:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_obtener_usuario](

@p_username nvarchar(50)
)
AS
BEGIN
	SELECT 
	[id_usuario]
      ,[id_rol]
      ,[dni]
      ,[hash_password]
      ,[cant_intentos_fallidos]
      ,[username]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Usuario]
	where username = @p_username
END
GO 
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_rol
	@p_id int
AS
BEGIN
	SELECT [id_rol]
      ,[nombre]
      ,[activado]
      ,[inhabilitado]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol]
	where Rol.id_rol = @p_id
END
GO 
GO 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Demian
-- Create date: 20/6/2013
-- Description:	Selecciona las funcionalidades
-- =============================================
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_funcionalidades_rol(
	@p_id_rol int) 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT f.[id_funcionalidad]
      ,f.[funcionalidad]
      ,f.[activa]
      ,f.[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] f
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Rol_funcionalidad rf
		ON rf.id_funcionalidad = f.id_funcionalidad
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Rol r
		ON rf.id_rol = r.id_rol
	WHERE r.id_rol = @p_id_rol
	and r.baja = 0
	and f.baja = 0
END

GO 
GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_rol
	AS
BEGIN
	SELECT [id_rol]
      ,[nombre]
      ,[inhabilitado]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol]
  WHERE baja = 0
END
GO 
GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_funcionalidad
AS
BEGIN
SELECT [id_funcionalidad]
      ,[funcionalidad]
      ,[activa]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad]
  WHERE baja = 0
 END
GO 
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_rol]    Script Date: 07/16/2013 01:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_rol]
	@p_rol nvarchar(50) = NULL, @p_funcionalidad nvarchar(255) = NULL 
	AS
BEGIN
	SELECT distinct r.id_rol, r.[nombre], r.inhabilitado
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] r
	left join [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].Rol_Funcionalidad rf
		on r.id_rol = rf.id_rol
	left join [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].Funcionalidad f
		on rf.id_funcionalidad = f.id_funcionalidad
	where ((@p_rol IS NULL) OR (r.nombre like '%' + @p_rol + '%'))
	and ((@p_funcionalidad IS NULL) OR (f.funcionalidad like '%' +  @p_funcionalidad + '%'))
	and r.baja = 0
	and rf.baja = 0
	and f.baja = 0
END
GO 
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_rol]    Script Date: 07/16/2013 00:51:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*===========================SP INSERT ROL==============================*/

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_rol]
(
	@p_nombre nvarchar(50),
	@p_inhabilitado bit,
	@p_id int output
)
AS
BEGIN

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol]
           ([nombre]
           ,[inhabilitado])
     VALUES (@p_nombre,@p_inhabilitado)

SET @p_id = SCOPE_IDENTITY()

END

/*===========================SP INSERT ROL FUNCIONALIDAD==============================*/
GO 
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_rol_funcionalidad]
(
	@p_id_rol int,
	@p_id_funcionalidad int
)
AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_funcionalidad]
           ([id_rol]
           ,[id_funcionalidad])
     VALUES (@p_id_rol, @p_id_funcionalidad)
END
GO 
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_baja_funcionalidades]
(
	@p_id_rol int 
)
AS
BEGIN

DELETE FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad]
	WHERE Rol_funcionalidad.id_rol = @p_id_rol
END

GO 
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_delete_rol]    Script Date: 07/16/2013 00:50:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_delete_rol]
(
	@p_id_rol int
)
AS
BEGIN
	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol]
	SET baja=1
	WHERE Rol.id_rol = @p_id_rol
END
GO 
GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_ciudad 
AS
BEGIN
	SELECT [id_ciudad],[nombre],[baja]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad]
	WHERE baja = 0
END
GO 
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_ciudad]    Script Date: 07/16/2013 01:22:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_ciudad] 
	@p_nombre varchar(50) = NULL
AS
BEGIN
	SELECT c.[id_ciudad],c.[nombre]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] c
	where ((@p_nombre IS NULL) OR (c.nombre like '%' + @p_nombre + '%'))	
	and baja = 0
END
GO 
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_ciudad]    Script Date: 07/16/2013 01:18:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*===========================SP INSERT CIUDAD==============================*/

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_ciudad]
(
	@p_nombre varchar(50),
	@p_id int output
)
AS
BEGIN

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad]
           ([nombre])
     VALUES
           (@p_nombre)

SET @p_id = SCOPE_IDENTITY()

END

/*===========================SP INSERT CLIENTE==============================*/
GO 
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_update_ciudad(
	@p_nombre varchar(50),
	@p_id int
)
AS
BEGIN
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Ciudad
	SET nombre = @p_nombre
	WHERE id_ciudad = @p_id
END
GO 
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_delete_ciudad
(
@p_id_ciudad INT
)
AS
BEGIN
	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].Ciudad
	SET baja=1			
	WHERE id_ciudad=@p_id_ciudad
END
GO 
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_servicio
AS
BEGIN
  SELECT [id_servicio]
	,[tipo_servicio]
	,[pocent_adic]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Servicio]
  WHERE [baja] = 0
END

GO 
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_recorrido
	AS
BEGIN
	SELECT r.[id_recorrido]
      ,r.[id_ciudad_origen]
	  ,co.[nombre] as 'nombreOrigen'
      ,r.[id_ciudad_destino]
      ,cd.[nombre] as 'nombreDestino'
	  ,r.[pre_base_kg]
      ,r.[pre_base_pasaje]
      ,r.[id_servicio]
      ,r.[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] r
  INNER JOIN [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] co
	ON r.id_ciudad_origen = co.id_ciudad
  INNER JOIN [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] cd
	ON r.id_ciudad_destino = cd.id_ciudad
  WHERE r.[baja] = 0
END
GO 
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_cliente
	@p_dni numeric(18,0)
AS
BEGIN
	SELECT TOP 1 [dni]
      ,[nombre]
      ,[apellido]
      ,[direccion]
      ,[telefono]
      ,[mail]
      ,[fecha_nacimiento]
      ,[es_discapacitado]
      ,[sexo]
      ,[inhabilitado]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
	WHERE Cliente.dni = @p_dni
END

GO 
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_ciudad(
	@p_id int
)
AS
BEGIN
	SELECT [id_ciudad]
      ,[nombre]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad]
	WHERE Ciudad.id_ciudad = @p_id
END
GO
GO 
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_servicio
	@p_id int
AS
BEGIN
	SELECT s.id_servicio, s.tipo_servicio, s.pocent_adic
	from SI_NO_APROBAMOS_HAY_TABLA.Servicio s
	where s.id_servicio = @p_id
END
GO
GO 
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_recorrido]    Script Date: 07/16/2013 02:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_recorrido]
	@p_id_ciudad_origen int=NULL,
	@p_id_ciudad_destino int=NULL, 
	@p_id_servicio int=NULL
	AS
BEGIN
	SELECT distinct r.[id_recorrido]
      ,r.[id_ciudad_origen]
      ,r.[id_ciudad_destino]
      ,r.[pre_base_kg]
      ,r.[pre_base_pasaje]
      ,r.[id_servicio]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] r 
	where ((@p_id_ciudad_origen IS NULL) OR (r.id_ciudad_origen = @p_id_ciudad_origen))
	and ((@p_id_ciudad_destino IS NULL) OR (r.id_ciudad_destino = @p_id_ciudad_destino))
	and ((@p_id_servicio IS NULL) OR ( r.id_servicio = @p_id_servicio))
	and r.baja = 0
END
GO 
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_recorrido
(
	@p_id int output,
	@p_id_ciudad_origen int,
	@p_id_ciudad_destino int,
	@p_pre_base_kg numeric(18,2),
	@p_pre_base_pasaje numeric(18,2),
	@p_id_servicio int
)
AS
BEGIN
	INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido]
           ([id_ciudad_origen]
           ,[id_ciudad_destino]
           ,[pre_base_kg]
           ,[pre_base_pasaje]
           ,[id_servicio])
	VALUES
           (@p_id_ciudad_origen,
           @p_id_ciudad_destino,
           @p_pre_base_kg,
           @p_pre_base_pasaje,
           @p_id_servicio)
           
	  SET @p_id = SCOPE_IDENTITY()
END
GO 
GO 
USE [GD1C2013]
GO

/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_update_recorrido]    Script Date: 07/16/2013 03:04:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_update_recorrido]
(
	@p_id int,
	@p_id_ciudad_origen int,
	@p_id_ciudad_destino int,
	@p_pre_base_kg numeric(18,2),
	@p_pre_base_pasaje numeric(18,2),
	@p_id_servicio int
)
AS
BEGIN
UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].Recorrido
SET id_ciudad_origen = @p_id_ciudad_origen,
	id_ciudad_destino = @p_id_ciudad_destino,
	pre_base_kg = @p_pre_base_kg,
	pre_base_pasaje = @p_pre_base_pasaje,
	id_servicio = @p_id_servicio 
	
WHERE id_recorrido =@p_id
END

GO

GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_cancelar_compra
	@id_compra	int,
	@motivo		nvarchar(200)
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION cancel 
	DECLARE @id_cancel int
	
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Cancelacion
	  (motivo_cancel)
	VALUES (@motivo)
	
	SET @id_cancel = SCOPE_IDENTITY()
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Compra
	SET id_cancelacion = @id_cancel
	WHERE id_compra = @id_compra
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Encomienda
	SET id_cancelacion = @id_cancel
	WHERE id_compra = @id_compra
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Pasaje
	SET id_cancelacion = @id_cancel
	WHERE id_compra = @id_compra
	
	COMMIT TRANSACTION cancel
END
GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_baja_recorrido
	@id_recorrido numeric(18,0) 
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION baja_recorrido
	DECLARE @motivo nvarchar(200)
	SET @motivo = 'Baja de recorrido'
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Recorrido 
	SET baja = 1
	WHERE id_recorrido = @id_recorrido
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Viaje
	SET baja = 1
	WHERE id_recorrido = @id_recorrido
	
	--Doy de baja todas las compras del recorrido
	declare @idCompraAct int

	declare cur CURSOR LOCAL for
		SELECT c.id_compra
		FROM SI_NO_APROBAMOS_HAY_TABLA.Compra c
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
			ON p.id_compra = c.id_compra
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Viaje v
			ON p.id_viaje = v.id_viaje
			AND v.id_recorrido = @id_recorrido
		WHERE c.id_cancelacion IS NULL
		
	open cur

	fetch next from cur into @idCompraAct

	while @@FETCH_STATUS = 0 
	BEGIN
		exec SI_NO_APROBAMOS_HAY_TABLA.sp_cancelar_compra @idCompraAct, @motivo
		fetch next from cur into @idCompraAct 
	END

	close cur
	deallocate cur

	COMMIT TRANSACTION baja_recorrido	
END
GO 
GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_marca
AS
BEGIN
SELECT [id_marca],[nombre]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Marca]
  WHERE
  baja = 0
END
GO 
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_micros]    Script Date: 07/16/2013 20:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_micros]
AS
BEGIN
SELECT Mi.[id_micros]
      ,Mi.[fecha_alta]
      ,Mi.[nro_micro]
      ,Mi.[modelo]
      ,Mi.[patente]
      ,Ma.nombre
      ,Ma.id_marca
      ,Mi.[id_servicio]
      ,Mi.[baja_vida_util]
      ,Mi.[fec_baja_vida_util]
      ,Mi.[capacidad_kg]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros] Mi
  INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Marca Ma
	on Mi.id_marca = Ma.id_marca
  WHERE Mi.baja = 0
END
GO 
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_marca
	@p_id int
AS
BEGIN
SELECT [id_marca]
      ,[nombre]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Marca]
	WHERE id_marca = @p_id
END
GO 
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_micros
	@p_marca varchar(50) = NULL, 
	@p_modelo nvarchar(50) = NULL,
	@p_tipo_servicio nvarchar(255) = NULL,
	@p_patente nvarchar(50) = NULL,
	@p_nro_micro int = NULL,
	@p_kgs_encomienda numeric(18,2)= NULL 
AS
BEGIN
	SELECT m.[id_micros]
      ,m.[fecha_alta]
      ,m.[nro_micro]
      ,m.[modelo]
      ,m.[patente]
      ,m.[id_marca]
      ,m.[id_servicio]
      ,m.[baja_vida_util]
      ,m.[fec_baja_vida_util]
      ,m.[capacidad_kg]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros] m
	left join SI_NO_APROBAMOS_HAY_TABLA.Servicio s
		on s.id_servicio = m.id_servicio
	left join SI_NO_APROBAMOS_HAY_TABLA.Marca ma
		on ma.id_marca = m.id_marca 
	where ((@p_modelo IS NULL) OR (m.modelo like '%' + @p_modelo + '%' ))
	and ((@p_patente IS NULL) OR (m.patente like '%' + @p_patente + '%' ))
	and ((@p_nro_micro IS NULL) OR (m.nro_micro = @p_nro_micro ))
	and ((@p_kgs_encomienda IS NULL) OR (m.capacidad_kg = @p_kgs_encomienda ))
	and ((@p_marca IS NULL) OR (ma.nombre = @p_marca))
	and ((@p_tipo_servicio IS NULL) OR (s.tipo_servicio = @p_tipo_servicio ))
	and m.baja = 0
END
GO 
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_micro]    Script Date: 07/20/2013 01:39:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_micro]
(
	@p_fecha_alta datetime2(7),
	@p_nro_micro int,
	@p_modelo nvarchar(50),
	@p_patente nvarchar(50),
	@p_id_marca int,
	@p_id_servicio int,
	@p_baja_vida_util bit,
	@p_fec_baja_vida_util datetime = NULL,
	@p_capacidad_kg numeric(18,2),
	@p_id int output
)
AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
           ([fecha_alta]
           ,[nro_micro]
           ,[modelo]
           ,[patente]
           ,[id_marca]
           ,[id_servicio]
           ,[baja_vida_util]
           ,[fec_baja_vida_util]
           ,[capacidad_kg]
           ,[baja])
     VALUES
           (@p_fecha_alta
           ,@p_nro_micro
           ,@p_modelo
           ,@p_patente
           ,@p_id_marca
           ,@p_id_servicio
           ,@p_baja_vida_util
           ,@p_fec_baja_vida_util
           ,@p_capacidad_kg
           ,0)
	SET @p_id = SCOPE_IDENTITY()
END
GO 
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_butaca
(

	@p_nro_butaca numeric(18,0),
	@p_id_micro int,
	@p_tipo_butaca nvarchar(50),
	@p_piso numeric(18,0),
	@p_id int output
)

AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Butaca]
           ([nro_butaca]
           ,[id_micro]
           ,[tipo_butaca]
           ,[piso])
     VALUES
           (@p_nro_butaca
           ,@p_id_micro
           ,@p_tipo_butaca
           ,@p_piso)

SET @p_id = SCOPE_IDENTITY()

END
GO 
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_update_micro]
	@p_marca varchar(50) = NULL, 
	@p_modelo nvarchar(50) = NULL,
	@p_tipo_servicio nvarchar(255) = NULL,
	@p_patente nvarchar(50) = NULL,
	@p_kgs_encomienda numeric(18,2)= NULL,
	@p_fecha_alta datetime,
	@p_baja_vida_util bit,
	@p_fec_baja_vida_util datetime,
	@p_id int
AS
BEGIN
UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
   SET [fecha_alta] = @p_fecha_alta
      ,[modelo] = @p_modelo
      ,[patente] = @p_patente
      ,[id_marca] = @p_marca
      ,[id_servicio] = @p_tipo_servicio
      ,[baja_vida_util] = @p_baja_vida_util
      ,[fec_baja_vida_util] = @p_fec_baja_vida_util
      ,[capacidad_kg] = @p_kgs_encomienda
      
 WHERE id_micros = @p_id
END

GO 
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_baja_logica_micro
(
	@id_micro int
)
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION baja_logica_micro
	
	DECLARE @idCompraAct int

	DECLARE cur_compras CURSOR LOCAL for
		SELECT DISTINCT c.id_compra
		FROM SI_NO_APROBAMOS_HAY_TABLA.Viaje v
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
			ON p.id_viaje = v.id_viaje
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Encomienda e
			ON e.id_viaje = v.id_viaje
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Compra c
			ON p.id_compra = c.id_compra
			OR e.id_compra = c.id_compra
		WHERE v.id_micro = @id_micro
		AND v.baja = 0
		AND p.baja = 0
		AND e.baja = 0

	open cur_compras

	fetch next from cur_compras into @idCompraAct

	while @@FETCH_STATUS = 0 
	BEGIN
		exec SI_NO_APROBAMOS_HAY_TABLA.sp_cancelar_compra @idCompraAct, 'Baja de micro' 
		fetch next from cur_compras into @idCompraAct 
	END

	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
	SET Micros.baja = 1
	WHERE Micros.id_micros = @id_micro
	
	UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Butaca]
	SET Butaca.baja = 1
	WHERE Butaca.id_micro = @id_micro
		
	COMMIT TRANSACTION baja_logica_micro
END

GO 
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_marca
(
	@p_nombre varchar(50),
	@p_id int output
)
AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Marca]
           ([nombre])
     VALUES
           (@p_nombre)
           
           SET @p_id = SCOPE_IDENTITY()
END
GO 
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_servicio
(	@p_tipo_servicio nvarchar(255),
    @p_adicional decimal(5,2),
    @p_id int output
)
AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Servicio]
           ([tipo_servicio]
           ,[pocent_adic]
           ,[baja])
     VALUES (@p_tipo_servicio, @p_adicional, 0)

SET @p_id = SCOPE_IDENTITY()
     
END
GO 
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_viaje(
@p_fecha_salida datetime = NULL,
@p_fecha_llegada datetime = NULL,
@p_fecha_llegada_estimada datetime = NULL,
@p_micro int = NULL,
@p_recorrido numeric(18,2) = NULL 
)
	AS
BEGIN
	SELECT v.[id_viaje]
      ,v.[id_recorrido]
      ,v.[id_micro]
      ,v.[fecha_salida]
      ,v.[fecha_arribo_estimada]
      ,v.[fecha_arribo]
	 FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje] v
	where ((@p_fecha_salida IS NULL) OR (v.fecha_salida = @p_fecha_salida))
	and ((@p_fecha_llegada IS NULL) OR  (v.fecha_arribo = @p_fecha_llegada))
	and ((@p_fecha_llegada_estimada IS NULL) OR (v.fecha_arribo_estimada = @p_fecha_llegada_estimada ))
	and ((@p_micro IS NULL) OR (v.id_micro = @p_micro))
	and ((@p_recorrido IS NULL) OR (v.id_recorrido = @p_recorrido))
END

GO 
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_recorrido(
	@p_id numeric(18,0)
	)
AS
BEGIN
	SELECT [id_recorrido]
      ,[id_ciudad_origen]
      ,[id_ciudad_destino]
      ,[pre_base_kg]
      ,[pre_base_pasaje]
      ,[id_servicio]
      ,[baja]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Recorrido]
WHERE id_recorrido = @p_id
END
GO 
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_micro
	@p_id int
AS
BEGIN
	SELECT TOP 1 [id_micros]
      ,[fecha_alta]
      ,[nro_micro]
      ,[modelo]
      ,[patente]
      ,[id_marca]
      ,[id_servicio]
      ,[baja_vida_util]
      ,[fec_baja_vida_util]
      ,[capacidad_kg]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Micros]
  WHERE id_micros = @p_id
END
GO
GO 
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_cliente]    Script Date: 07/18/2013 02:28:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_cliente]
AS
BEGIN
	SELECT c.[dni]
      ,c.[nombre]
      ,c.[apellido]
      ,c.[direccion]
      ,c.[telefono]
      ,c.[mail]
      ,c.[fecha_nacimiento]
      ,c.[es_discapacitado]
      ,c.[sexo]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente] c
  WHERE c.baja = 0
END
GO 
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_cliente]    Script Date: 07/18/2013 00:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_cliente]
	@p_dni numeric(18,0) = NULL,
	@p_nombre nvarchar(255) = NULL,
	@p_apellido nvarchar(255) = NULL,
	@p_discapacitado CHAR(1) = NULL,
	@p_sexo varchar(50) = NULL
AS
BEGIN
	SELECT [dni]
      ,[nombre]
      ,[apellido]
      ,[direccion]
      ,[telefono]
      ,[mail]
      ,[fecha_nacimiento]
      ,[es_discapacitado]
      ,[sexo]
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
	where ((@p_dni IS NULL) OR (dni = @p_dni))
	and ((@p_nombre IS NULL) OR (UPPER(nombre) like '%' + UPPER(@p_nombre) +'%'))
	and ((@p_apellido IS NULL) OR (apellido like '%' + @p_apellido + '%'))
	and ((@p_discapacitado IS NULL) OR (ISNULL(es_discapacitado, 'N') = @p_discapacitado))
	and ((@p_sexo IS NULL) OR (sexo like '%' + @p_sexo + '%'))
	and baja=0
END
GO 
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_cliente
(
	@p_dni numeric(18,0),
	@p_nombre nvarchar(255),
	@p_apellido nvarchar(255),
	@p_direccion nvarchar(255),
	@p_telefono numeric(18,0),
	@p_mail nvarchar(255),
	@p_fecha_nacimiento datetime,
	@p_es_discapacitado char(1),
	@p_sexo varchar(50)
)
AS
BEGIN
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
           ([dni]
           ,[nombre]
           ,[apellido]
           ,[direccion]
           ,[telefono]
           ,[mail]
           ,[fecha_nacimiento]
           ,[es_discapacitado]
           ,[sexo])
     VALUES
           (@p_dni
           ,@p_nombre
           ,@p_apellido
           ,@p_direccion
           ,@p_telefono
           ,@p_mail
           ,@p_fecha_nacimiento
           ,@p_es_discapacitado
           ,@p_sexo)
END
GO 
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_update_cliente
(
	@p_dni numeric(18,0),
	@p_nombre nvarchar(255),
	@p_apellido nvarchar(255),
	@p_direccion nvarchar(255),
	@p_telefono numeric(18,0),
	@p_mail nvarchar(255),
	@p_fecha_nacimiento datetime,
	@p_es_discapacitado char(1),
	@p_sexo varchar(50)
)
AS
BEGIN
UPDATE [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]
SET [nombre]=@p_nombre
           ,[apellido]=@p_apellido
           ,[direccion]=@p_direccion
           ,[telefono]=@p_telefono
           ,[mail]=@p_mail
           ,[fecha_nacimiento]=@p_fecha_nacimiento
           ,[es_discapacitado]=@p_es_discapacitado
           ,[sexo]=@p_sexo
WHERE [dni]=@p_dni
END

GO 
GO 
USE [GD1C2013]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_listar_filtrado_recompensa]
	@p_descrip nvarchar(200),
	@p_puntos_desde int,
	@p_puntos_hasta int,
	@p_stock_desde int,
	@p_stock_hasta int
AS
BEGIN
	SELECT
		id_recompensa,
		descripcion,
		stock,
		puntos_costo
	FROM SI_NO_APROBAMOS_HAY_TABLA.Recompensa
	WHERE((@p_descrip IS NULL) OR (UPPER(descripcion) LIKE '%'  + UPPER(@p_descrip) + '%'))
	AND ((@p_puntos_desde IS NULL) OR (puntos_costo >= @p_puntos_desde))
	AND ((@p_puntos_hasta IS NULL) OR (puntos_costo <= @p_puntos_hasta))
	AND ((@p_stock_desde IS NULL) OR (stock >= @p_stock_desde))
	AND ((@p_stock_hasta IS NULL) OR (stock <= @p_stock_hasta))
END
GO 
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_puntos_por_cliente]
(
	@p_dni numeric(18,0)
)
AS
BEGIN
	SELECT SUM(p.puntos - p.puntos_usados) as 'puntosTotales'
	FROM SI_NO_APROBAMOS_HAY_TABLA.Puntaje p
	WHERE DATEDIFF(year,p.fecha_otorgado, GETDATE() ) < 1
	AND p.dni = @p_dni
	GROUP BY p.dni
	ORDER BY puntosTotales DESC
END
GO 
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_puntos_por_cliente_detallado
(
	@p_dni numeric(18,0)
)
AS
BEGIN
	SELECT p.dni,
	(p.puntos) as 'puntosOtorgados',
	(p.puntos_usados) as 'puntosUtilizados', 
	(p.puntos - p.puntos_usados) as 'puntosRestantes',
	(p.fecha_otorgado)
	FROM SI_NO_APROBAMOS_HAY_TABLA.Puntaje p
	WHERE DATEDIFF(year,p.fecha_otorgado, GETDATE() ) < 1
	AND p.dni = @p_dni
	ORDER BY p.fecha_otorgado ASC
END 
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_canjear_recompensa
(
	@p_dni numeric(18,0),
	@p_id_recompensa int,
	@p_cantidad	int
)
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION canje_recompensa
	
	DECLARE @puntos_costo int
	DECLARE @puntos_act int
	DECLARE @puntos_usados_act int
	DECLARE @stock_check int
	
	SELECT @puntos_costo = (r.puntos_costo * @p_cantidad)
	FROM [SI_NO_APROBAMOS_HAY_TABLA].Recompensa r
	WHERE id_recompensa = @p_id_recompensa
	
	SELECT @stock_check=r.stock
	FROM [SI_NO_APROBAMOS_HAY_TABLA].Recompensa r
	WHERE id_recompensa = @p_id_recompensa
	
	IF ( @stock_check - @p_cantidad ) < 0
	BEGIN
		ROLLBACK TRANSACTION canje_recompensa
		RAISERROR('No hay stock suficiente', 12, 2)
	END
	
	UPDATE [SI_NO_APROBAMOS_HAY_TABLA].Recompensa
	SET stock = stock - @p_cantidad
	WHERE id_recompensa = @p_id_recompensa

	DECLARE CUR_PUNTAJE CURSOR FOR
		SELECT p.puntos, p.puntos_usados
		FROM [SI_NO_APROBAMOS_HAY_TABLA].Puntaje p
		WHERE p.dni = @p_dni
		AND DATEDIFF(year, p.fecha_otorgado, GETDATE()) < 1
		AND (p.puntos -  p.puntos_usados) >0 
		AND baja = 0
		ORDER BY p.fecha_otorgado ASC
		FOR UPDATE OF p.puntos_usados
	
	SET NOCOUNT ON	
	OPEN CUR_PUNTAJE
	FETCH NEXT FROM CUR_PUNTAJE 
	INTO @puntos_act, @puntos_usados_act
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF (@puntos_act - @puntos_usados_act) > @puntos_costo
		BEGIN
			--Hay puntos suficientes aca
			UPDATE [SI_NO_APROBAMOS_HAY_TABLA].Puntaje 
			SET puntos_usados = puntos_usados + @puntos_costo
			WHERE CURRENT OF CUR_PUNTAJE
			SET @puntos_costo = 0
			BREAK 
		END
		ELSE
		BEGIN
			--todavia no hay puntos suficientes en esta linea
			SET @puntos_costo = @puntos_costo - (@puntos_act - @puntos_usados_act)
			UPDATE [SI_NO_APROBAMOS_HAY_TABLA].Puntaje 
			SET puntos_usados = puntos
			WHERE CURRENT OF CUR_PUNTAJE
		END
		
		FETCH NEXT FROM CUR_PUNTAJE 
		INTO @puntos_act, @puntos_usados_act
	END	
	
	IF @puntos_costo = 0
	BEGIN
		COMMIT TRANSACTION canje_recompensa
	END
	ELSE
	BEGIN
		ROLLBACK TRANSACTION canje_recompensa
		RAISERROR('No hay suficientes puntos', 12, 2)
	END
	
	CLOSE CUR_PUNTAJE
	DEALLOCATE CUR_PUNTAJE
END
GO

GO 
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_clientes_mas_puntos]
(
	@fecha_inicio datetime,
	@fecha_fin datetime
)
AS
BEGIN
	SELECT TOP 5 p.dni, SUM(p.puntos - p.puntos_usados) as 'puntosTotales'
	FROM SI_NO_APROBAMOS_HAY_TABLA.Puntaje p
	WHERE p.fecha_otorgado BETWEEN @fecha_inicio AND @fecha_fin
	GROUP BY p.dni
	ORDER BY puntosTotales DESC
END
GO
CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].butacas_vendidas_por_viaje
(
	@id_viaje int
)
RETURNS int
BEGIN
	DECLARE @butacas_vendidas_x_viaje int
	SELECT @butacas_vendidas_x_viaje=COUNT(*)
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje] AS viaje
		INNER JOIN [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[pasaje] AS pasaje
			ON viaje.id_viaje=pasaje.id_viaje
	WHERE viaje.id_viaje=@id_viaje AND pasaje.id_cancelacion IS NULL
	RETURN @butacas_vendidas_x_viaje
END

GO

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_top5_destino_mas_vendido_por_semestre]
(
	@fecha_inicio datetime,
	@fecha_fin datetime
)
AS
BEGIN
	SELECT DISTINCT TOP 5 ciudad.[nombre],
			SUM ([SI_NO_APROBAMOS_HAY_TABLA].butacas_vendidas_por_viaje(viaje.[id_viaje])) AS butacas_vendidas
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] as ciudad
		 inner join [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] as recorrido
			on ciudad.[id_ciudad]=recorrido.[id_ciudad_destino]
		 inner join [SI_NO_APROBAMOS_HAY_TABLA].[Viaje] as viaje
			on viaje.[id_recorrido]=recorrido.id_recorrido
	WHERE recorrido.baja=0 
			AND viaje.baja=0 
			AND viaje.fecha_salida BETWEEN @fecha_inicio AND @fecha_fin
	GROUP BY ciudad.[id_ciudad], ciudad.[nombre]
	ORDER BY SUM ([SI_NO_APROBAMOS_HAY_TABLA].butacas_vendidas_por_viaje(viaje.[id_viaje])) desc
END
GO 
GO 

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_micros_mas_baja_serv]
(
	@fecha_inicio datetime,
	@fecha_fin datetime
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
		
		IF @fec_fuera >= @fecha_inicio AND
			@fec_fuera < @fecha_fin	AND
			@fec_reinic <= @fecha_fin AND
			@fec_reinic > @fecha_fin
		BEGIN
			--Arranca y termina dentro del periodo
			INSERT INTO #tmpDias (id_micro, patente, dias)
			VALUES (@id_micro, @patente, ABS(DATEDIFF(DAY, @fec_fuera, @fec_reinic)))
		END
		 
		IF @fec_fuera < @fecha_inicio AND
			@fec_fuera < @fecha_fin	AND
			@fec_reinic <= @fecha_fin AND
			@fec_reinic > @fecha_inicio
		BEGIN
			--Arranca antes del periodo pero termina dentro
			INSERT INTO #tmpDias (id_micro, patente, dias)
			VALUES (@id_micro, @patente, ABS(DATEDIFF(DAY, @fecha_inicio, @fec_reinic)))				
		END
		
		IF @fec_fuera < @fecha_inicio AND 
			@fec_fuera < @fecha_fin AND
			@fec_reinic > @fecha_fin AND
			@fec_reinic > @fecha_inicio
		BEGIN
			--Arranca antes del periodo y termina despues del periodo
			INSERT INTO #tmpDias (id_micro, patente, dias)
			VALUES (@id_micro, @patente, ABS(DATEDIFF(DAY, @fecha_inicio, @fecha_fin)))			
		END
		
		IF @fec_fuera >= @fecha_inicio AND
			@fec_fuera < @fecha_fin AND
			@fec_reinic > @fecha_fin AND
			@fec_reinic > @fecha_inicio
		BEGIN
			--Arranca dentro del periodo pero termina despues
			INSERT INTO #tmpDias (id_micro, patente, dias)
			VALUES (@id_micro, @patente, ABS(DATEDIFF(DAY, @fec_fuera, @fecha_fin)))
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












GO 
GO 
CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].cant_pasajes_cancelados_viaje
(
	@id_viaje int
)
RETURNS int
AS
BEGIN
	DECLARE @cant_pasajes_cancelados_x_viaje int
	
	SELECT @cant_pasajes_cancelados_x_viaje=COUNT(*)
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Pasaje] AS pasaje
	WHERE pasaje.id_viaje=@id_viaje
			AND pasaje.id_cancelacion IS NOT NULL
	
	RETURN @cant_pasajes_cancelados_x_viaje
END

GO

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_top5_destinos_mas_cancelados_por_semestre]
(
	@fecha_inicio datetime,
	@fecha_fin datetime
)
AS
BEGIN
	SELECT DISTINCT TOP 5 ciudad.[nombre],
			SUM ([SI_NO_APROBAMOS_HAY_TABLA].cant_pasajes_cancelados_viaje(viaje.[id_viaje])) AS pasajes_cancelados
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] AS ciudad
		 INNER JOIN [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] AS recorrido
			ON ciudad.[id_ciudad]=recorrido.[id_ciudad_destino]
		 INNER JOIN [SI_NO_APROBAMOS_HAY_TABLA].[Viaje] AS viaje
			ON viaje.[id_recorrido]=recorrido.id_recorrido
	WHERE recorrido.baja=0 
			AND viaje.baja=0 
			AND viaje.fecha_salida BETWEEN @fecha_inicio AND @fecha_fin
	GROUP BY ciudad.[id_ciudad], ciudad.[nombre]
	ORDER BY SUM ([SI_NO_APROBAMOS_HAY_TABLA].cant_pasajes_cancelados_viaje(viaje.[id_viaje])) DESC
END
GO 
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_top5_destino_micros_mas_vacios_por_semestre]
(
	@fecha_inicio datetime,
	@fecha_fin datetime
)
AS
BEGIN
	SELECT DISTINCT TOP 5 ciudad.[nombre],
			SUM ([SI_NO_APROBAMOS_HAY_TABLA].cant_butacas_disp_viaje(viaje.[id_viaje])) AS butacas_libres_x_viaje
	FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] as ciudad
		 inner join [SI_NO_APROBAMOS_HAY_TABLA].[Recorrido] as recorrido
			on ciudad.[id_ciudad]=recorrido.[id_ciudad_destino]
		 inner join [SI_NO_APROBAMOS_HAY_TABLA].[Viaje] as viaje
			on viaje.[id_recorrido]=recorrido.id_recorrido
	WHERE recorrido.baja=0 
			AND viaje.baja=0 
	GROUP BY ciudad.[id_ciudad], ciudad.[nombre]
	ORDER BY SUM ([SI_NO_APROBAMOS_HAY_TABLA].cant_butacas_disp_viaje(viaje.[id_viaje])) desc
END
GO 
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_precio_final_pasaje
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
GO 
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_butacas_ocupadas_viaje
(
	@p_id_viaje int
)
AS
BEGIN
	SELECT b.id_butaca, b.nro_butaca, b.tipo_butaca, b.piso, b.id_micro
	FROM SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Butaca b
	ON b.id_butaca = p.id_butaca
	WHERE p.id_viaje = @p_id_viaje
END
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_butacas_libres_viaje
(
	@p_id_viaje int
)
AS
BEGIN
	SELECT b.id_butaca, b.nro_butaca, b.tipo_butaca, b.piso
	FROM SI_NO_APROBAMOS_HAY_TABLA.Butaca b
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Micros m
		ON m.id_micros = b.id_micro
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Viaje v
		ON v.id_micro = m.id_micros
	WHERE v.id_viaje = @p_id_viaje
	AND b.id_butaca NOT IN
		(
			SELECT b.id_butaca
			FROM SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
			INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Butaca b
				ON b.id_butaca = p.id_butaca
			WHERE p.id_viaje = @p_id_viaje	
		)
END
GO 

CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].cant_butacas_disp_viaje
(
	@id_viaje int
)
RETURNS int
AS
BEGIN
	DECLARE @cant_total int
	DECLARE @cant_ocupadas int
	DECLARE @id_micro int
	
	SELECT @id_micro=m.id_micros, @cant_total=COUNT(b.id_butaca)
	FROM SI_NO_APROBAMOS_HAY_TABLA.Viaje v
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Micros m
		ON v.id_micro = m.id_micros
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Butaca b
		ON b.id_micro = m.id_micros
	WHERE v.id_viaje = @id_viaje
	GROUP BY v.id_viaje, m.id_micros
	
	SELECT @cant_ocupadas=COUNT(*)
	FROM SI_NO_APROBAMOS_HAY_TABLA.Viaje v
	INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Pasaje p
		ON p.id_viaje = v.id_viaje
	WHERE v.id_viaje = @id_viaje
	
	return @cant_total - @cant_ocupadas
END
GO 
GO 
CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].kg_disponibles_viaje
(
	@id_viaje int
)
RETURNS numeric(18,2)
AS
BEGIN
	DECLARE @kg_totales numeric(18,0)
	DECLARE @kg_ocupados numeric(18,0)
	
	SELECT @kg_totales=m.capacidad_kg
	FROM [SI_NO_APROBAMOS_HAY_TABLA].Viaje v
	INNER JOIN [SI_NO_APROBAMOS_HAY_TABLA].Micros m
		ON v.id_micro = m.id_micros
	WHERE v.id_viaje = @id_viaje
	
	SELECT @kg_ocupados=SUM(e.peso)
	FROM [SI_NO_APROBAMOS_HAY_TABLA].Viaje v
	INNER JOIN [SI_NO_APROBAMOS_HAY_TABLA].Encomienda e
		ON e.id_viaje = v.id_viaje
	WHERE v.id_viaje = @id_viaje
	
	RETURN @kg_totales - @kg_ocupados
		
END
GO 
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_obtener_micro_disponibilidades
(
	@p_id_viaje int
)
AS
BEGIN
	SELECT [SI_NO_APROBAMOS_HAY_TABLA].kg_disponibles_viaje(@p_id_viaje) as kgs,
	[SI_NO_APROBAMOS_HAY_TABLA].cant_butacas_disp_viaje(@p_id_viaje) as butacas
	
END
GO 
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
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insert_compra
(	
	@p_id_compra int output,
	@p_id_usuario int,
	@p_fecha_compra datetime
)
AS
BEGIN
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Compra
		(id_usuario, fecha_compra)
	VALUES
		(@p_id_usuario, @p_fecha_compra)

	SET @p_id_compra = SCOPE_IDENTITY()
END
GO 
GO 

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
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insertar_encomienda
(
	@p_id_encomienda int output,
	@p_id_compra int,
	@p_dni numeric(18,0),
	@p_pre_encomienda int,
	@p_id_viaje int
)
AS
BEGIN
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Encomienda
		(id_viaje, id_compra, dni, pre_encomienda)
	VALUES
		(@p_id_viaje,@p_id_compra, @p_dni, @p_pre_encomienda)

	SET @p_id_encomienda = SCOPE_IDENTITY()
END
GO 
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insertar_pasaje
(
	@p_id_pasaje int output,
	@p_id_compra int,
	@p_id_butaca int,
	@p_dni numeric(18,0),
	@p_pre_pasaje int,
	@p_id_viaje int
)
AS
BEGIN
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Pasaje
		(id_compra, id_butaca, dni, pre_pasaje, id_viaje)
	VALUES
		(@p_id_compra, @p_id_butaca, @p_dni, @p_pre_pasaje, @p_id_viaje)

	SET @p_id_pasaje = SCOPE_IDENTITY()
END
GO 
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_listar_compras
AS
BEGIN
SELECT [id_compra]
      ,[id_usuario]
      ,ISNULL([id_cancelacion], 0) as id_cancelacion
      ,[fecha_compra]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Compra]
  WHERE [baja] = 0
END


GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_cancelar_pasaje
	@id_pasaje	numeric(18,0),
	@motivo		nvarchar(200)
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION cancel 
	DECLARE @id_cancel int
	
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Cancelacion
	  (motivo_cancel)
	VALUES (@motivo)
	
	SET @id_cancel = SCOPE_IDENTITY()
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Pasaje
	SET id_cancelacion = @id_cancel
	WHERE id_pasaje = @id_pasaje
	
	COMMIT TRANSACTION cancel
END
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_cancelar_encomienda
	@id_encomienda	numeric(18,0),
	@motivo			nvarchar(200)
AS
BEGIN
	SET xact_abort on
	BEGIN TRANSACTION cancel 
	DECLARE @id_cancel int
	
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Cancelacion
	  (motivo_cancel)
	VALUES (@motivo)
	
	SET @id_cancel = SCOPE_IDENTITY()
	
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Encomienda
	SET id_cancelacion = @id_cancel
	WHERE id_encomienda= @id_encomienda
	
	COMMIT TRANSACTION cancel
END
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_listar_cancelaciones
AS
BEGIN
SELECT [id_cancelacion]
      ,[fecha_cancel]
      ,[motivo_cancel]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cancelacion]
END
GO 

CREATE FUNCTION [SI_NO_APROBAMOS_HAY_TABLA].func_puede_reemplazar_desde
(
	@id_micro_candidato int,
	@fechaInic datetime
)
RETURNS bit 
BEGIN
	IF (
		SELECT COUNT(v.id_viaje) 
		FROM SI_NO_APROBAMOS_HAY_TABLA.Micros m
		INNER JOIN SI_NO_APROBAMOS_HAY_TABLA.Viaje v
			ON m.id_micros = v.id_micro
		WHERE m.id_micros = @id_micro_candidato
		AND v.fecha_salida >= @fechaInic
	) > 0
	BEGIN
		RETURN 0
	END
	RETURN 1
END

GO

CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_reemplazar_futuros_por_otro_micro
(
	@id_micro int,
	@id_micro_nuevo int output
)
AS
BEGIN
	DECLARE @modelo nvarchar(50)
	DECLARE @idMarca int
	DECLARE @microElegido int
	
	SELECT @modelo=m.modelo, @idMarca=m.id_marca
	FROM SI_NO_APROBAMOS_HAY_TABLA.Micros m
	WHERE m.id_micros = @id_micro
	
	SELECT TOP 1 @microElegido=m.id_micros 
	FROM SI_NO_APROBAMOS_HAY_TABLA.Micros m
	WHERE m.modelo = @modelo
	AND m.id_marca = @idMarca
	AND [SI_NO_APROBAMOS_HAY_TABLA].func_puede_reemplazar_desde(m.id_micros, GETDATE()) = 1
	AND m.id_micros <> @id_micro
	AND m.baja = 0
	
	IF @microElegido is not null
	BEGIN
		UPDATE SI_NO_APROBAMOS_HAY_TABLA.Viaje
		SET id_micro = @microElegido
		WHERE id_micro = @id_micro
		AND fecha_salida >= GETDATE()
		SET @id_micro_nuevo = @microElegido
	END
	ELSE
	BEGIN
		SET @id_micro_nuevo = 0
	END
END
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_insertar_usuario
(
	@dni numeric(18,0),
	@username nvarchar(50)
)
AS
BEGIN	
	
	INSERT INTO SI_NO_APROBAMOS_HAY_TABLA.Usuario
		(id_rol, dni, username)
	VALUES (2, @dni, @username)
END
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_obtener_usuario_por_dni](

	@p_dni numeric(18,0)
)
AS
BEGIN
	SELECT 
		[id_usuario]
      ,[id_rol]
      ,[dni]
      ,[hash_password]
      ,[cant_intentos_fallidos]
      ,[username]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Usuario]
	where dni = @p_dni
END
GO 
CREATE PROCEDURE SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_compra
(
	@p_id int
)
AS
BEGIN
SELECT [id_compra]
      ,[id_usuario]
      ,ISNULL([id_cancelacion], 0) as id_cancelacion
      ,[fecha_compra]
  FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Compra]
  WHERE id_compra = @p_id
END


GO 
GO 
USE [GD1C2013]
GO
/****** Object:  StoredProcedure [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_viaje]    Script Date: 07/18/2013 21:37:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_insert_viaje]
(
	@p_id_recorrido numeric(18,0),
	@p_id_micro int,
	@p_fecha_salida datetime,
	@p_fecha_arribo_estimada datetime,
	@p_id int output
)
AS
BEGIN

	IF (@p_fecha_salida > GETDATE())
	BEGIN
	INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Viaje]
           ([id_recorrido]
           ,[id_micro]
           ,[fecha_salida]
           ,[fecha_arribo_estimada]
          )
	VALUES
           (@p_id_recorrido,
           @p_id_micro,
           @p_fecha_salida,
           @p_fecha_arribo_estimada
           )
           
	SET @p_id = SCOPE_IDENTITY()
	END
END
GO 
GO 
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].[sp_registro_llegada]
(
	@p_id_viaje int,
	@p_fecha_llegada datetime
)
AS
BEGIN
	UPDATE SI_NO_APROBAMOS_HAY_TABLA.Viaje
	SET fecha_arribo = @p_fecha_llegada
	WHERE id_viaje = @p_id_viaje
END
GO 

GO 

