using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GestionDeDatos.AccesoDatos
{
    public interface IAccesoBD
    {
        string ConnectionString { get; }

        DataSet RealizarConsulta(string consulta);
        DataSet RealizarConsulta(string consulta, Dictionary<SqlParameter, object> parametros);
        int EjecutarComando(string comando);
        int EjecutarComando(string comando, Dictionary<SqlParameter, object> parametros);
        DataSet RealizarConsultaAlmacenada(string comando);
        DataSet RealizarConsultaAlmacenada(string comando, Dictionary<SqlParameter, object> parametros);
    }
}
