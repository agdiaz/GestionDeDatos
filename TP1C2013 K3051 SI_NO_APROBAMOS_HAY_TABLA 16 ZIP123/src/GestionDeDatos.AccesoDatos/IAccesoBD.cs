using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GestionDeDatos.AccesoDatos
{
    public interface IAccesoBD
    {
        string ConnectionString { get; }

        DataSet RealizarConsulta(string consulta);
        DataSet RealizarConsulta(string consulta, Dictionary<string, object> parametros);
        int EjecutarComando(string comando);
        int EjecutarComando(string comando, Dictionary<string, object> parametros);
        DataSet RealizarConsultaAlmacenada(string comando, Dictionary<string, object> parametros);
    }
}
