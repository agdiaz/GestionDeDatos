using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using GestionDeDatos.AccesoDatos;
using FrbaBus.Common.Entidades;
using FrbaBus.DAO.Builder;

namespace FrbaBus.DAO
{
    public class RecorridoDAO : IEntidadDAO<Recorrido>
    {
        private IBuilder<Recorrido> _builder;
        public RecorridoDAO()
        {
            _builder = new RecorridoBuilder();
        }

        #region Miembros de IEntidadDAO<Recorrido>

        public IAccesoBD accesoBD
        {
            get { return new AccesoBD(); }
        }

        public Recorrido Obtener(object id)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_id", SqlDbType.Decimal, 18, "p_id"), id);

            DataRow row = accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_obtener_recorrido", parametros).Tables[0].Rows[0];
            return _builder.Build(row);
        }

        public int Alta(Recorrido entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter p0 = new SqlParameter("@p_id_ciudad_origen", SqlDbType.Int, 4, "p_id_ciudad_origen");
            parametros.Add(p0, entidad.IdCiudadOrigen);

            SqlParameter p1 = new SqlParameter("@p_id_ciudad_destino", SqlDbType.Int, 4, "p_id_ciudad_destino");
            parametros.Add(p1, entidad.IdCiudadDestino);

            SqlParameter p2 = new SqlParameter("@p_pre_base_kg", SqlDbType.Decimal, 18, "p_pre_base_kg");
            parametros.Add(p2, entidad.PrecioBaseKG);

            SqlParameter p3 = new SqlParameter("@p_pre_base_pasaje", SqlDbType.Decimal, 50, "p_pre_base_pasaje");
            parametros.Add(p3, entidad.PrecioBasePasaje);

            SqlParameter p4 = new SqlParameter("@p_id_servicio", SqlDbType.Int, 4, "p_id_servicio");
            parametros.Add(p4, entidad.IdServicio);

            SqlParameter pId = new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id");
            pId.Direction = ParameterDirection.Output;
            parametros.Add(pId, 0);

            this.accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_insert_recorrido", parametros);
            return Convert.ToInt32(pId.Value);
        }

        public void Baja(Recorrido entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter p0 = new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id");
            parametros.Add(p0, entidad.Id);
            
            this.accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_delete_recorrido", parametros);
        }

        public void Modificacion(Recorrido entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter p0 = new SqlParameter("@p_id_ciudad_origen", SqlDbType.Int, 4, "p_id_ciudad_origen");
            parametros.Add(p0, entidad.IdCiudadOrigen);

            SqlParameter p1 = new SqlParameter("@p_id_ciudad_destino", SqlDbType.Int, 4, "p_id_ciudad_destino");
            parametros.Add(p1, entidad.IdCiudadDestino);

            SqlParameter p2 = new SqlParameter("@p_pre_base_kg", SqlDbType.Decimal, 18, "p_pre_base_kg");
            parametros.Add(p2, entidad.PrecioBaseKG);

            SqlParameter p3 = new SqlParameter("@p_pre_base_pasaje", SqlDbType.Decimal, 50, "p_pre_base_pasaje");
            parametros.Add(p3, entidad.PrecioBasePasaje);

            SqlParameter p4 = new SqlParameter("@p_id_servicio", SqlDbType.Int, 4, "p_id_servicio");
            parametros.Add(p4, entidad.IdServicio);

            SqlParameter pId = new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id");
            parametros.Add(pId, entidad.Id);

            this.accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_update_recorrido", parametros);

        }

        public IList<Recorrido> Listar()
        {
            IList<Recorrido> lista = new List<Recorrido>();
            foreach (DataRow item in this.ObtenerRegistros().Tables[0].Rows)
            {
                lista.Add(this._builder.Build(item));
            }
            return lista;
        }

        public IList<Recorrido> ListarFiltrado(string origen, string destino, string servicio)
        {
            IList<Recorrido> lista = new List<Recorrido>();
            foreach (DataRow item in this.ObtenerRegistrosFiltrado(origen, destino, servicio).Tables[0].Rows)
            {
                lista.Add(this._builder.Build(item));
            }
            return lista;
        }

        #endregion

        private DataSet ObtenerRegistros()
        {
            return accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_listar_recorrido");
        }
        private DataSet ObtenerRegistrosFiltrado(string origen, string destino, string servicio)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            if (!string.IsNullOrEmpty(origen))
                parametros.Add(new SqlParameter("@p_ciudad_origen", SqlDbType.VarChar, 50, "p_ciudad_origen"), origen);
            if (!string.IsNullOrEmpty(destino))
                parametros.Add(new SqlParameter("@p_ciudad_destino", SqlDbType.VarChar, 50, "p_ciudad_destino"), destino);
            if (!string.IsNullOrEmpty(servicio))
                parametros.Add(new SqlParameter("@p_tipo_servicio", SqlDbType.VarChar, 50, "p_tipo_servicio"), servicio);

            DataSet ds = this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_listar_filtrado_recorrido", parametros);
            return ds;
        }

    }
}
