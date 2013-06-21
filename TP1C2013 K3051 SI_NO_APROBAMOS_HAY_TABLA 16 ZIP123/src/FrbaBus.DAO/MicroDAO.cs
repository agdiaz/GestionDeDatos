using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using GestionDeDatos.AccesoDatos;
using System.Data;
using System.Data.SqlClient;

namespace FrbaBus.DAO
{
    public class MicroDAO 
    {
        public DataSet ObtenerMicrosDisponibles(int ciudadOrigen, int ciudadDestino, DateTime fechaSalida)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_ciudad_origen", SqlDbType.Int, 4, "p_ciudad_origen"), ciudadOrigen);
            parametros.Add(new SqlParameter("@p_ciudad_destino", SqlDbType.Int, 4, "p_ciudad_destino"), ciudadDestino);
            parametros.Add(new SqlParameter("@p_fecha_salida", SqlDbType.DateTime, 4, "p_fecha_salida"), fechaSalida);
            
            DataSet ds = new AccesoBD().RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_buscar_micros", parametros);
            return ds;

        }
    }
}
