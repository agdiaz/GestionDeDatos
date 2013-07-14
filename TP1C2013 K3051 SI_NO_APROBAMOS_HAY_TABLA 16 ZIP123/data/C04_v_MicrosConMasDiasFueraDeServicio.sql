CREATE VIEW [SI_NO_APROBAMOS_HAY_TABLA].v_MicrosConMasDiasFueraDeServicio
AS
SELECT top 5 Micros.id_micros, DATEDIFF(day,isNull(Micros.fec_fuera_servicio,0),isNull(Micros.fec_reinicio_servicio,0)) as Diferencia
from SI_NO_APROBAMOS_HAY_TABLA.Micros
where Micros.baja = 0
order by Diferencia DESC