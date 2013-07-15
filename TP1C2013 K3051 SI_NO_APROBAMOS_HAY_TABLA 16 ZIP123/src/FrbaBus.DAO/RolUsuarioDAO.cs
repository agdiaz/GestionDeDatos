using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using System.Data;
using GestionDeDatos.AccesoDatos;
using System.Data.SqlClient;
using FrbaBus.DAO.Builder;

namespace FrbaBus.DAO
{
    public class RolUsuarioDAO : IEntidadDAO<RolUsuario>
    {
        private IBuilder<RolUsuario> _builder;
        public RolUsuarioDAO()
        {
            _builder = new RolUsuarioBuilder();
        }

        #region Miembros de IEntidadDAO<RolUsuario>

        public IAccesoBD accesoBD
        {
            get
            {
                return new AccesoBD();
            }
        }
        
        public RolUsuario ObtenerRolAsociado(Usuario u)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@userName", SqlDbType.VarChar, 50, "userName"), u.Username);

            SqlParameter rolParameter = new SqlParameter("@rol", SqlDbType.VarChar, 50, "rol");
            rolParameter.Direction = ParameterDirection.Output;
            parametros.Add(rolParameter, string.Empty);

            accesoBD.EjecutarComando("SI_NO_APROBAMOS_HAY_TABLA.obtener_rol", parametros);

            var rolNombre = rolParameter.Value.ToString();
            return new RolUsuario(rolNombre);
        }
        
        public RolUsuario Obtener(object id)
        {
            throw new NotImplementedException();
        }

        public int Alta(RolUsuario entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter pNombre = new SqlParameter("@nombre", SqlDbType.NVarChar, 50, "nombre");
            parametros.Add(pNombre, entidad.Nombre);

            SqlParameter pInhabilitados = new SqlParameter("@inhabilitado", SqlDbType.Bit, 1, "inhabilitado");
            parametros.Add(pInhabilitados, 0);

            SqlParameter pId = new SqlParameter("@p_id", SqlDbType.NVarChar, 50, "p_id");
            pId.Direction = ParameterDirection.Output;
            parametros.Add(pId, 0);

            this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_insert_rol", parametros);
            return Convert.ToInt32(pId.Value);
        }

        public void Baja(RolUsuario entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter pId = new SqlParameter("@p_id", SqlDbType.NVarChar, 50, "p_id");
            pId.Direction = ParameterDirection.Output;
            parametros.Add(pId, 0);

            this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_baja_rol", parametros);
        }

        public void Modificacion(RolUsuario entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter pId = new SqlParameter("@p_id", SqlDbType.NVarChar, 50, "p_id");
            pId.Direction = ParameterDirection.Output;
            parametros.Add(pId, 0);

            SqlParameter pNombre = new SqlParameter("@nombre", SqlDbType.NVarChar, 50, "nombre");
            parametros.Add(pNombre, entidad.Nombre);

            SqlParameter pInhabilitados = new SqlParameter("@inhabilitado", SqlDbType.Bit, 1, "inhabilitado");
            parametros.Add(pInhabilitados, entidad.Inhabilitado ? 1 : 0);


            this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_modificar_rol", parametros);
        }

        public IList<RolUsuario> Listar()
        {
            IList<RolUsuario> roles = new List<RolUsuario>();
            foreach (DataRow item in this.ObtenerRegistros().Tables[0].Rows)
            {
                RolUsuario r = this._builder.Build(item);
                roles.Add(r);
            }
            return roles;
        }
        public IList<RolUsuario> ListarFiltrado(string nombreRol, string funcionalidadElegida)
        {
            IList<RolUsuario> roles = new List<RolUsuario>();

            DataSet ds = this.ObtenerRegistrosFiltrado(nombreRol, funcionalidadElegida);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                roles.Add(this._builder.Build(item));
            }

            return roles;
        }        
        public void BajaRolFuncionalidades(RolUsuario rol)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter pId = new SqlParameter("@p_id_rol", SqlDbType.Int, 4, "p_id_rol");
            parametros.Add(pId, rol.IdRol);

            this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_baja_funcionalidades", parametros);
        }
        #endregion

        private DataSet ObtenerRegistros()
        {
            return this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_listar_rol", new Dictionary<SqlParameter, object>());
        }
        private DataSet ObtenerRegistrosFiltrado(string nombreRol, string nombreFuncionalidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            if (!string.IsNullOrEmpty(nombreRol))
            {
                SqlParameter pNombreRol = new SqlParameter("@p_rol", SqlDbType.NVarChar, 50, "p_rol");
                parametros.Add(pNombreRol, nombreRol);
            }
            if (!string.IsNullOrEmpty(nombreFuncionalidad))
            {
                SqlParameter pNombreFuncionalidad = new SqlParameter("@p_funcionalidad", SqlDbType.NVarChar, 50, "p_funcionalidad");
                parametros.Add(pNombreFuncionalidad, nombreFuncionalidad);
            }
            return this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_listar_filtrado_rol", parametros );
        }
    }
}
