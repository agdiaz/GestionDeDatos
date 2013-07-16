using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GestionDeDatos.AccesoDatos;
using FrbaBus.Common.Entidades;
using System.Data.SqlClient;
using FrbaBus.DAO.Builder;

namespace FrbaBus.DAO
{
    public class EmpresaDAO : IEntidadDAO<Empresa>
    {
        private IBuilder<Empresa> _builder;
        public EmpresaDAO()
        {
            this._builder = new EmpresaBuilder();
        }

        #region Miembros de IEntidadDAO<Empresa>

        public IAccesoBD accesoBD
        {
            get { return new AccesoBD(); }
        }

        public Empresa Obtener(object id)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id"), id);

            DataSet ds = this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_marca", parametros);
            DataRow row = ds.Tables[0].Rows[0];
            return this._builder.Build(row);
        }

        public int Alta(Empresa entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter pId = new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id");
            pId.Direction = ParameterDirection.Output;
            parametros.Add(pId, 0);

            SqlParameter pNombre = new SqlParameter("@p_nombre", SqlDbType.VarChar, 50, "p_nombre");
            parametros.Add(pNombre, entidad.Descripcion);

            this.accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_insert_marca", parametros);
            return Convert.ToInt32(pId.Value);
        }

        public void Baja(Empresa entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id"), entidad.Id);

            this.accesoBD.EjecutarComando("SI_NO_APROBAMOS_HAY_TABLA.sp_delete_marca");
        }

        public void Modificacion(Empresa entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter pId = new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id");
            parametros.Add(pId, entidad.Id);

            SqlParameter pNombre = new SqlParameter("@p_nombre", SqlDbType.VarChar, 50, "p_nombre");
            parametros.Add(pNombre, entidad.Descripcion);

            this.accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_update_marca", parametros);
        }
        
        public IList<Empresa> Listar()
        {
            DataTable dt = ObtenerEmpresas().Tables[0];
            IList<Empresa> empresas = new List<Empresa>(dt.Rows.Count);

            foreach (DataRow row in dt.Rows)
            {
                empresas.Add(this._builder.Build(row));
            }
            return empresas;
        }
        #endregion

        private DataSet ObtenerEmpresas()
        {
            return new AccesoBD().RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_listar_marca");
        }
    }
}
