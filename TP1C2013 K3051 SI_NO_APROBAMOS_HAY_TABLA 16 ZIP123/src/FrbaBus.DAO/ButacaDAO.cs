using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using GestionDeDatos.AccesoDatos;
using System.Data.SqlClient;
using System.Data;
using FrbaBus.DAO.Builder;

namespace FrbaBus.DAO
{
    public class ButacaDAO : IEntidadDAO<Butaca>
    {
        private IAccesoBD _acceso;
        private IBuilder<Butaca> _builder;
        public ButacaDAO()
        {
            this._builder = new ButacaBuilder();
            this._acceso = new AccesoBD();
        }

        #region Miembros de IEntidadDAO<Butaca>

        public GestionDeDatos.AccesoDatos.IAccesoBD accesoBD
        {
            get { return _acceso; }
        }

        public Butaca Obtener(object id)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id"), id);

            DataRow row = accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_obtener_butaca", parametros).Tables[0].Rows[0];
            return _builder.Build(row);
        }

        public int Alta(Butaca entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter p0 = new SqlParameter("@p_nro_butaca", SqlDbType.Decimal, 18, "p_nro_butaca");
            parametros.Add(p0, entidad.NroButaca);

            SqlParameter p1 = new SqlParameter("@p_id_micro", SqlDbType.Int, 4, "p_id_micro");
            parametros.Add(p1, entidad.IdMicro);

            SqlParameter p2 = new SqlParameter("@p_tipo_butaca", SqlDbType.NVarChar, 50, "p_tipo_butaca");
            parametros.Add(p2, entidad.TipoButaca);

            SqlParameter p3 = new SqlParameter("@p_piso", SqlDbType.Decimal, 18, "p_piso");
            parametros.Add(p3, entidad.Piso);

            SqlParameter pId = new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id");
            pId.Direction = ParameterDirection.Output;
            parametros.Add(pId, 0);

            this.accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_insert_butaca", parametros);
            return Convert.ToInt32(pId.Value);
        }

        public void Baja(Butaca entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Butaca entidad)
        {
            throw new NotImplementedException();
        }

        public IList<Butaca> Listar()
        {
            throw new NotImplementedException();
        }

        public IList<Butaca> Listar(int idMicro)
        {
            IList<Butaca> butacas = new List<Butaca>();

            DataSet ds = this.ObtenerRegistros(idMicro);
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                butacas.Add(this._builder.Build(r));
            }

            return butacas;
        }

        private DataSet ObtenerRegistros(int idMicro)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter p1 = new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id");
            parametros.Add(p1, idMicro);

            return this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_butacas_por_micro", parametros);
        }
        #endregion

        public IList<Butaca> ListarLibres(Viaje viaje)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_id_viaje", SqlDbType.Int, 4, "p_id_viaje"), viaje.Id);

            IList<Butaca> butacas = new List<Butaca>();
            foreach (DataRow row in accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].[sp_butacas_libres_viaje]",parametros).Tables[0].Rows)
            {
                butacas.Add(_builder.Build(row));
            }
            return butacas;
        }

        public IList<Butaca> ListarOcupadas(Viaje viaje)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_id_viaje", SqlDbType.Int, 4, "p_id_viaje"), viaje.Id);

            IList<Butaca> butacas = new List<Butaca>();
            foreach (DataRow row in accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].[sp_butacas_ocupadas_viaje]", parametros).Tables[0].Rows)
            {
                butacas.Add(_builder.Build(row));
            }
            return butacas;
        }
    }
}
