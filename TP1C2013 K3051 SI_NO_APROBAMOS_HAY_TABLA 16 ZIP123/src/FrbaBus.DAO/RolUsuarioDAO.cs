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

            SqlParameter rolParameter = new SqlParameter("@rol", SqlDbType.VarChar, 50, "rol");
            rolParameter.Direction = ParameterDirection.Output;
            parametros.Add(rolParameter, string.Empty);

            accesoBD.EjecutarComando("SI_NO_APROBAMOS_HAY_TABLA.obtener_rol", parametros);

            var rolNombre = rolParameter.Value.ToString();
            return new RolUsuario(rolNombre);
        }
        
        public IList<Funcionalidad> ObtenerFuncionalidadesAsociadas(RolUsuario rolUsuario)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@nombre_rol", SqlDbType.VarChar, 50, "nombre_rol"), rolUsuario.Nombre);

            DataSet ds = accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.obtener_funcionalidades_rol", parametros);

            IList<Funcionalidad> funcionalidades = new List<Funcionalidad>(ds.Tables[0].Rows.Count);
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
                //Activa = row["activa"].ToString() == "1" ? true : false,
                Nombre = row["funcionalidad"].ToString()
            };
            return f;
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
            parametros.Add(pInhabilitados, entidad.Habilitado ? 1 : 0);


            this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_modificar_rol", parametros);

            entidad.Funcionalidades = this.ObtenerFuncionalidadesAsociadas(entidad);
        }

        public IList<RolUsuario> Listar()
        {
            IList<RolUsuario> roles = new List<RolUsuario>();
            foreach (DataRow item in this.ObtenerRegistros().Tables[0].Rows)
            {
                RolUsuario r = this.BuildRol(item);
                r.Funcionalidades = ObtenerFuncionalidadesAsociadas(r);
                roles.Add(r);
            }
            return roles;
        }

        private RolUsuario BuildRol(DataRow item)
        {
            return new RolUsuario()
            {
                IdRol = Convert.ToInt32(item["id_rol"].ToString()),
                Nombre = item["nombre"].ToString()
            };
        }

        public DataSet ObtenerRegistros()
        {
            return this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_listar_rol", new Dictionary<SqlParameter, object>());
        }

        #endregion

        public void InsertarUsuario(string username, byte[] hashPassword)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            parametros.Add(new SqlParameter("@userName", SqlDbType.VarChar, 50, "userName"), username);
            parametros.Add(new SqlParameter("@passwordHash", SqlDbType.VarBinary, 32, "passwordHash"), hashPassword);

            this.accesoBD.EjecutarComando("SI_NO_APROBAMOS_HAY_TABLA.insertar_usuario_admin", parametros);
        }

        public DataSet ObtenerRegistrosRolUsuario(string nombreRol, string nombreFuncionalidad)
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


        public void BajaRolFuncionalidades(RolUsuario rol)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter pId = new SqlParameter("@p_id_rol", SqlDbType.Int, 4, "p_id_rol");
            parametros.Add(pId, rol.IdRol);
            
            this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_baja_funcionalidades", parametros);
        }

        public IList<RolUsuario> ListarRegistrosRolUsuario(string nombreRol, string funcionalidadElegida)
        {
            IList<RolUsuario> roles = new List<RolUsuario>();

            DataSet ds = this.ObtenerRegistrosRolUsuario(nombreRol, funcionalidadElegida);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                roles.Add(this.BuildRol(item));
            }

            return roles;
        }
    }
}
