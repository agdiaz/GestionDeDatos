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
    public class ViajeDAO : IEntidadDAO<Viaje>
    {
        private IBuilder<Viaje> _builder;
        private IAccesoBD _accesoBD;
        
        public ViajeDAO()
        {
            this._builder = new ViajeBuilder();
            this._accesoBD = new AccesoBD();
        }
        
        #region Miembros de IEntidadDAO<Viaje>

        public IAccesoBD accesoBD
        {
            get { return _accesoBD; }
        }

        public Viaje Obtener(object id)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id"), id);

            DataRow row = accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_obtener_viaje", parametros).Tables[0].Rows[0];
            return _builder.Build(row);
        }

        public int Alta(Viaje entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter p0 = new SqlParameter("@p_Fecha_Arribo_Estimada", SqlDbType.DateTime, 8, "p_Fecha_Arribo_Estimada");
            parametros.Add(p0, entidad.FechaArriboEstimada);

            SqlParameter p1 = new SqlParameter("@p_Fecha_Salida", SqlDbType.DateTime, 8, "p_Fecha_Salida");
            parametros.Add(p1, entidad.FechaSalida);

            SqlParameter p2 = new SqlParameter("@p_id_micro", SqlDbType.Int, 4, "p_id_micro");
            parametros.Add(p2, entidad.IdMicro);

            SqlParameter p3 = new SqlParameter("@p_id_recorrido", SqlDbType.Int, 4, "p_id_recorrido");
            parametros.Add(p3, entidad.IdRecorrido);

            SqlParameter pId = new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id");
            pId.Direction = ParameterDirection.Output;
            parametros.Add(pId, 0);

            this.accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_insert_viaje", parametros);
            return Convert.ToInt32(pId.Value);
        }

        public void Baja(Viaje entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id"), entidad.Id);

            accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_delete_viaje", parametros);

        }

        public void Modificacion(Viaje entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter p0 = new SqlParameter("@p_Fecha_Arribo_Estimada", SqlDbType.DateTime, 8, "p_Fecha_Arribo_Estimada");
            parametros.Add(p0, entidad.FechaArriboEstimada);

            SqlParameter p1 = new SqlParameter("@p_Fecha_Salida", SqlDbType.DateTime, 8, "p_Fecha_Salida");
            parametros.Add(p1, entidad.FechaSalida);

            SqlParameter p2 = new SqlParameter("@p_id_micro", SqlDbType.Int, 4, "p_id_micro");
            parametros.Add(p2, entidad.IdMicro);

            SqlParameter p3 = new SqlParameter("@p_id_recorrido", SqlDbType.Int, 4, "p_id_recorrido");
            parametros.Add(p3, entidad.IdRecorrido);

            SqlParameter pId = new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id");
            parametros.Add(pId, entidad.Id);

            this.accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_update_viaje", parametros);
        }

        public IList<Viaje> Listar()
        {
            List<Viaje> viajes = new List<Viaje>();

            foreach (DataRow row in this.ObtenerRegistros().Tables[0].Rows)
            {
                viajes.Add(this._builder.Build(row));
            }

            return viajes;
        }

        #endregion

        private DataSet ObtenerRegistros()
        {
            return accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_listar_viajes");
        }
        public DataSet ObtenerRegistros(DateTime? llegada, DateTime? salida, DateTime? estimada, Recorrido rec, Micro micro)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            if (micro.Id > 0)
                parametros.Add(new SqlParameter("@p_micro", SqlDbType.Int, 4, "p_micro"), micro.Id);
            if (rec.Id > 0)
                parametros.Add(new SqlParameter("@p_recorrido", SqlDbType.Decimal, 18, "p_recorrido"), (decimal)rec.Id);

            if (salida.HasValue)
                parametros.Add(new SqlParameter("@p_fecha_salida", SqlDbType.DateTime, 8, "p_fecha_salida"), salida.Value);

            if (llegada.HasValue)
                parametros.Add(new SqlParameter("@p_fecha_llegada", SqlDbType.DateTime, 8, "p_fecha_llegada"), llegada.Value);

            if (estimada.HasValue)
                parametros.Add(new SqlParameter("@p_fecha_llegada_estimada", SqlDbType.DateTime, 8, "p_fecha_llegada_estimada"), estimada.Value);

            return accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_viaje", parametros);
        }
        private DataSet ObtenerRegistros(Recorrido rec)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id"), rec.Id);

            return accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_listar_viajes_recorrido", parametros);
        }
        
        public IList<Viaje> ListarPorRecorrido(Recorrido rec)
        {
            List<Viaje> viajes = new List<Viaje>();

            foreach (DataRow row in this.ObtenerRegistros().Tables[0].Rows)
            {
                viajes.Add(this._builder.Build(row));
            }

            return viajes;
        }
        public IList<Viaje> ListarFiltrado(DateTime? llegada, DateTime? salida, DateTime? estimada, Recorrido rec, Micro micro)
        {
            List<Viaje> viajes = new List<Viaje>();

            foreach (DataRow row in this.ObtenerRegistros(llegada, salida, estimada, rec, micro).Tables[0].Rows)
            {
                viajes.Add(this._builder.Build(row));
            }

            return viajes;
        }

        public void GenerarArribo(Viaje viaje)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_id_viaje", SqlDbType.Int, 4, "p_id_viaje"), viaje.Id);
            parametros.Add(new SqlParameter("@p_fecha_llegada", SqlDbType.DateTime, 8, "p_fecha_llegada"), viaje.FechaArribo);

            accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_registro_llegada", parametros);
        }
    }
}
