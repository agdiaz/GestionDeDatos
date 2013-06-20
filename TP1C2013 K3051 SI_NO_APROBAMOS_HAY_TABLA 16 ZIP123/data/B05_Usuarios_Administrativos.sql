Declare @id_rol_administrativo int

SELECT @id_rol_administrativo = R.id_rol
FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].Rol R
WHERE R.nombre = 'Administrativo'

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Usuario]
           ([id_rol]
           ,[dni]
           ,[username]
           ,[hash_password]
           ,[cant_intentos_fallidos])
     VALUES
           (@id_rol_administrativo
           ,99999999
           ,'admin1'
           ,CAST(0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7 AS VARBINARY(32))
           ,0)

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Usuario]
           ([id_rol]
           ,[dni]
           ,[username]
           ,[hash_password]
           ,[cant_intentos_fallidos])
     VALUES
           (@id_rol_administrativo
           ,99999998
           ,'admin2'
           ,CAST(0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7 AS VARBINARY(32))
           ,0)
           
INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Usuario]
           ([id_rol]
           ,[dni]
           ,[username]
           ,[hash_password]
           ,[cant_intentos_fallidos])
     VALUES
           (@id_rol_administrativo
           ,99999997
           ,'admin3'
           ,CAST(0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7 AS VARBINARY(32))
           ,0)

INSERT INTO [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Usuario]
           ([id_rol]
           ,[dni]
           ,[username]
           ,[hash_password]
           ,[cant_intentos_fallidos])
     VALUES
           (@id_rol_administrativo
           ,99999996
           ,'admin4'
           ,CAST(0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7 AS VARBINARY(32))
           ,0)
