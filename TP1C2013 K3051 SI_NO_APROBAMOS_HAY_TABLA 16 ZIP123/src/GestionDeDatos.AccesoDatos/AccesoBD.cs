using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GestionDeDatos.AccesoDatos
{
    public class AccesoBD : IAccesoBD
    {
        public string ConnectionString { get; set; }

        public AccesoBD(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public DataSet RealizarConsulta(string consulta)
        {
            return this.RealizarConsulta(consulta, new Dictionary<string, string>());
        }
        public DataSet RealizarConsulta(string consulta, Dictionary<string, string> parametros)
        {
            DataSet ds = new DataSet();

            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            using (SqlCommand sqlCommand = new SqlCommand(consulta))
            {
                foreach (KeyValuePair<string, string> item in parametros)
	            {
                    sqlCommand.Parameters.Add(item.Key, item.Value);
	            }
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(ds);
            }
            sqlConnection.Close();
            return ds;
        }

        public int EjecutarComando(string comando)
        {
            return this.EjecutarComando(comando, new Dictionary<string, string>());
        }
        public int EjecutarComando(string comando, Dictionary<string, string> parametros)
        {
            int rowsAffected = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(comando))
            {
                foreach (KeyValuePair<string, string> item in parametros)
                {
                    sqlCommand.Parameters.Add(item.Key, item.Value);
                }

                rowsAffected = sqlCommand.ExecuteNonQuery();
            }

            sqlConnection.Close();
            return rowsAffected;
        }

    }
}
