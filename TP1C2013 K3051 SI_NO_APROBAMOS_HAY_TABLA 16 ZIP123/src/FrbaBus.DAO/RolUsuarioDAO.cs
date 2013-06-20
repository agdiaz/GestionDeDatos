using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using System.Data;
using GestionDeDatos.AccesoDatos;

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
            int resultado = 1;
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@userName", username);
            parametros.Add("@passwordHash", hash);
            parametros.Add("@resultado", resultado);

            accesoBD.EjecutarComando("[GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[realizar_identificacion]", parametros);

            return resultado;
        }
        public RolUsuario ObtenerRolAsociado(Usuario u)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("userName", u.Username);

            DataSet ds = accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.obtener_rol", parametros);
            DataRow row = ds.Tables[0].Rows[0];

            return new RolUsuario(row["nombre"].ToString());
        }
        public IList<Funcionalidad> ObtenerFuncionalidadesAsociadas(RolUsuario rolUsuario)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("nombre_rol", rolUsuario.Nombre);

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

        
    }
}
