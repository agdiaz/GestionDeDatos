
CREATE PROCEDURE [SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_rol
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
	and ((@p_funcionalidad IS NULL) OR (f.funcionalidad like '%' + @p_funcionalidad + '%'))
END
