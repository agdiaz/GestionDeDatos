USE [GD1C2013]

declare @sql varchar(max)

set @sql = (SELECT 
    'DROP FUNCTION [' + routine_schema + '].[' + routine_name + ']; '
from 
    information_schema.routines where routine_schema = 'SI_NO_APROBAMOS_HAY_TABLA' and routine_type = 'FUNCTION'
FOR XML PATH (''))
print(@sql)
exec(@sql)