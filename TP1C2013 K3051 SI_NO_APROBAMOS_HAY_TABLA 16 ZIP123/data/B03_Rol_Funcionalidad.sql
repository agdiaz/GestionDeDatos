/*======================CLIENTE===================*/

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Cliente' AND Funcionalidad.funcionalidad='tsmClienteListado'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Cliente' AND Funcionalidad.funcionalidad='tsmClientePasajeroFrecuenteConsultar'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Cliente' AND Funcionalidad.funcionalidad='tsmPasajeEncomiendaAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Cliente' AND Funcionalidad.funcionalidad='tsmEncomiendaCancelar'

/*======================ADMINISTRADOR===================*/

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmRolAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmRolListado'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmCiudadAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmCiudadListado'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmRecorridoAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmRecorridoListado'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmMicroAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmMicRolistado'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmClienteListado'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmClienteAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmClientePasajeroFrecuenteConsultar'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmViajeAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmViajeListado'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmEncomiendaAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmEncomiendaCancelar'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmEstadisticasT5ClientesMasPuntos'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmEstadisticasT5DestMasCancelados'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmEstadisticasT5DestMasMicrosVacios'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmEstadisticasT5DestMasVendidos'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmEstadisticasT5MicrosMasDiasFueraDeServicio'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmPremiosAlta'

insert into [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol_Funcionalidad](id_Rol,id_funcionalidad)
select id_Rol, id_funcionalidad
from [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Rol] as Rol, [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Funcionalidad] as Funcionalidad
where Rol.nombre='Administrativo' AND Funcionalidad.funcionalidad='tsmPremiosListado'
