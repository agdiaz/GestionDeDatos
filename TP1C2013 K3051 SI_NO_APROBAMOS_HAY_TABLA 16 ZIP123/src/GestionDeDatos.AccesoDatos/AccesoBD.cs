using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using FrbaBus.Common.Excepciones;

namespace GestionDeDatos.AccesoDatos
{
    public class AccesoBD : IAccesoBD
    {
        public string ConnectionString { get; set; }

        public AccesoBD()
        {
            //this.ConnectionString = ConfigurationManager.AppSettings["conexíonBD"];
            this.ConnectionString = @"User ID=gd;Password=gd2013;Initial Catalog=GD1C2013;Data Source=(local)\SQLSERVER2008;Integrated Security=False";
        }

        public DataSet RealizarConsulta(string consulta)
        {
            return this.RealizarConsulta(consulta, new Dictionary<SqlParameter, object>());
        }
        public DataSet RealizarConsulta(string consulta, Dictionary<SqlParameter, object> parametros)
        {
            try
            {
                DataSet ds = new DataSet();

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand(consulta))
                {

                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.TableDirect;
                    
                    AgregarParametros(parametros, sqlCommand);

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(ds);
                }
                sqlConnection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw new AccesoBDException(consulta, parametros, ex);
            }
        }

        public int EjecutarComando(string comando)
        {
            return this.EjecutarComando(comando, new Dictionary<SqlParameter, object>());
        }
        public int EjecutarComando(string comando, Dictionary<SqlParameter, object> parametros)
        {
            try
            {
                int rowsAffected = 0;
                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(comando))
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;

                    AgregarParametros(parametros, sqlCommand);

                    rowsAffected = sqlCommand.ExecuteNonQuery();
                }

                sqlConnection.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw new AccesoBDException(comando, parametros, ex);
            }
        }

        public DataSet RealizarConsultaAlmacenada(string nombreSP, Dictionary<SqlParameter, object> parametros)
        {
            try
            {
                DataSet ds = new DataSet();

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand(nombreSP))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;

                    AgregarParametros(parametros, sqlCommand);

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(ds);
                }
                sqlConnection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw new AccesoBDException(nombreSP, parametros, ex);
            }
        }

        private static void AgregarParametros(Dictionary<SqlParameter, object> parametros, SqlCommand sqlCommand)
        {
            foreach (KeyValuePair<SqlParameter, object> item in parametros)
            {
                item.Key.Value = item.Value;
                sqlCommand.Parameters.Add(item.Key);
            }
        }
    }
}
