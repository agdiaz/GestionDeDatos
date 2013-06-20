using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using System.Data;
using GestionDeDatos.AccesoDatos;
using System.Data.SqlClient;

namespace FrbaBus.DAO
{
    public class RolUsuarioDAO : IEntidadDAO<RolUsuario>
    {
        #region Miembros de IEntidadDAO<RolUsuario>

        public GestionDeDatos.AccesoDatos.IAccesoBD accesoBD
        {
            get
            {
                return new AccesoBD();
            }
        }
        public int RealizarIdentificacion(string username, byte[] hash)
        {
            int resultado = -3 ;
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            parametros.Add(new SqlParameter("@userName", SqlDbType.VarChar, 50, "userName"), username);
            parametros.Add(new SqlParameter("@passwordHash", SqlDbType.VarBinary, 32, "passwordHash"), hash);
            
            var parametroResultado = new SqlParameter("@resultado", SqlDbType.Int, 4, "resultado");
            parametroResultado.Direction = ParameterDirection.Output;
            parametros.Add(parametroResultado, 0);

            accesoBD.EjecutarComando("[GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[realizar_identificacion]", parametros);
            
            resultado = (int)parametroResultado.Value;
            return resultado;
        }
        public RolUsuario ObtenerRolAsociado(Usuario u)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@userName", SqlDbType.VarChar, 50, "userName"), u.Username);
        
            DataSet ds = accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.obtener_rol", parametros);
            DataRow row = ds.Tables[0].Rows[0];

            return new RolUsuario(row["nombre"].ToString());
        }
        public IList<Funcionalidad> ObtenerFuncionalidadesAsociadas(RolUsuario rolUsuario)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@nombre_rol", SqlDbType.VarChar, 50, "nombre_rol"), rolUsuario.Nombre);

            DataSet ds = accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.obtener_funcionalidades_rol", parametros);

            IList<Funcionalidad> funcionalidades = null;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                funcionalidades.Add(this.BuildFuncionalidad(row));
            }
            return funcionalidades;
        }

        private Funcionalidad BuildFuncionalidad(DataRow row)
        {
            Funcionalidad f = new Funcionalidad()
            {
                Activa = row["activa"].ToString() == "1" ? true : false,
                Nombre = row["nombre"].ToString()
            };
            return f;
        }


        public void Alta(RolUsuario entidad)
        {
            throw new NotImplementedException();
        }

        public void Baja(RolUsuario entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(RolUsuario entidad)
        {
            throw new NotImplementedException();
        }

        public IList<RolUsuario> Listar()
        {
            throw new NotImplementedException();
        }

        public DataSet ObtenerRegistros()
        {
            throw new NotImplementedException();
        }

        #endregion

        public void InsertarUsuario(string username, byte[] hashPassword)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            parametros.Add(new SqlParameter("@userName", SqlDbType.VarChar, 50, "userName"), username);
            parametros.Add(new SqlParameter("@passwordHash", SqlDbType.VarBinary, 32, "passwordHash"), hashPassword);

            this.accesoBD.EjecutarComando("SI_NO_APROBAMOS_HAY_TABLA.InsertarUsuario", parametros);
        }
    }
}
