using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using System.Data;
using System.Data.SqlClient;
using GestionDeDatos.AccesoDatos;
using FrbaBus.DAO.Builder;

namespace FrbaBus.DAO
{
    public class FuncionalidadDAO : IEntidadDAO<Funcionalidad>
    {
        public GestionDeDatos.AccesoDatos.IAccesoBD accesoBD
        {
            get { return new AccesoBD(); }
        }
        private IBuilder<Funcionalidad> _builder;
        
        public FuncionalidadDAO()
        {
            this._builder = new FuncionalidadBuilder();
        }

        #region Miembros de IEntidadDAO<Funcionalidad>
        public Funcionalidad Obtener(object id)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id"), id);

            DataSet ds = this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_funcionalidad", parametros);
            DataRow row = ds.Tables[0].Rows[0];

            return this._builder.Build(row);
        }

        public int Alta(Funcionalidad entidad)
        {
            throw new NotImplementedException();
        }

        public void Baja(Funcionalidad entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Funcionalidad entidad)
        {
            throw new NotImplementedException();
        }

        public IList<Funcionalidad> Listar()
        {
            IList<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            foreach (DataRow item in this.ObtenerRegistros().Tables[0].Rows)
            {
                funcionalidades.Add(this._builder.Build(item));
            }
            return funcionalidades;
        }

        public IList<Funcionalidad> ObtenerFuncionalidadesAsociadas(RolUsuario rolUsuario)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("p_id_rol", SqlDbType.Int, 4, "p_id_rol"), rolUsuario.IdRol);

            DataSet ds = accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_listar_funcionalidades_rol", parametros);

            IList<Funcionalidad> funcionalidades = new List<Funcionalidad>(ds.Tables[0].Rows.Count);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                funcionalidades.Add(this._builder.Build(row));
            }
            return funcionalidades;
        }

        public int AltaRolFuncionalidad(RolUsuario rol, int idFuncionalidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            SqlParameter pIdRol = new SqlParameter("@p_id_rol", SqlDbType.Int, 4, "p_id_rol");
            parametros.Add(pIdRol, rol.IdRol);

            SqlParameter pIdFuncionalidad = new SqlParameter("@p_id_funcionalidad", SqlDbType.Int, 4, "p_id_funcionalidad");
            parametros.Add(pIdFuncionalidad, idFuncionalidad);

            return this.accesoBD.EjecutarComando("sp_insert_rol_funcionalidad", parametros);
        }

        #endregion

        private DataSet ObtenerRegistros()
        {
            return this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_listar_funcionalidad");
        }
    }
}
