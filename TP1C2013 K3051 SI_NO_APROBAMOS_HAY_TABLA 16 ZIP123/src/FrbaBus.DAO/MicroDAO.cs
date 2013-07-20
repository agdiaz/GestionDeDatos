using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using GestionDeDatos.AccesoDatos;
using System.Data;
using System.Data.SqlClient;
using FrbaBus.DAO.Builder;

namespace FrbaBus.DAO
{
    public class MicroDAO : IEntidadDAO<Micro>
    {
        private IBuilder<Micro> _builder;
        private IAccesoBD _accesoBD;

        public MicroDAO()
        {
            this._builder = new MicroBuilder();
            this._accesoBD = new AccesoBD();
        }

        #region Miembros de IEntidadDAO<Micro>

        public IAccesoBD accesoBD
        {
            get { return _accesoBD ; }
        }

        public Micro Obtener(object id)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id"), id);

            DataRow row = accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_obtener_micro", parametros).Tables[0].Rows[0];
            return _builder.Build(row);
        }

        public int Alta(Micro entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter p0 = new SqlParameter("@p_fecha_alta", SqlDbType.DateTime2, 8, "p_fecha_alta");
            parametros.Add(p0, entidad.FechaAlta);

            SqlParameter p1 = new SqlParameter("@p_nro_micro", SqlDbType.Int, 4, "p_nro_micro");
            parametros.Add(p1, entidad.NumeroDeMicro);

            SqlParameter p2 = new SqlParameter("@p_modelo", SqlDbType.NVarChar, 50, "p_modelo");
            parametros.Add(p2, entidad.Modelo);

            SqlParameter p3 = new SqlParameter("@p_patente", SqlDbType.NVarChar, 50, "p_patente");
            parametros.Add(p3, entidad.Patente);

            SqlParameter p4 = new SqlParameter("@p_id_marca", SqlDbType.Int, 4, "p_id_marca");
            parametros.Add(p4, entidad.Empresa.Id);

            SqlParameter p5 = new SqlParameter("@p_id_servicio", SqlDbType.Int, 4, "p_id_servicio");
            parametros.Add(p5, entidad.Servicio.Id);

            SqlParameter p6 = new SqlParameter("@p_baja_vida_util", SqlDbType.Bit, 1, "p_baja_vida_util");
            parametros.Add(p6, 0);
            
            object baja = DBNull.Value;
            if (entidad.FechaBajaVidaUtil.HasValue )
                baja = entidad.FechaBajaVidaUtil.Value;
            SqlParameter p7 = new SqlParameter("@p_fec_baja_vida_util", SqlDbType.DateTime, 8, "p_fec_baja_vida_util");
            parametros.Add(p7, baja);

            SqlParameter p8 = new SqlParameter("@p_capacidad_kg", SqlDbType.Decimal, 18, "p_capacidad_kg");
            parametros.Add(p8, entidad.KgsCapacidad);

            SqlParameter pId = new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id");
            pId.Direction = ParameterDirection.Output;
            parametros.Add(pId, 0);

            this.accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_insert_micro", parametros);
            return Convert.ToInt32(pId.Value);
        }

        public void Baja(Micro entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@id_micro", SqlDbType.Int, 4, "id_micro"), entidad.Id);


            accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].[sp_baja_logica_micro]", parametros);

            
        }

        public void Modificacion(Micro entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter p0 = new SqlParameter("@p_fecha_alta", SqlDbType.DateTime2, 8, "p_fecha_alta");
            parametros.Add(p0, entidad.FechaAlta);

            //SqlParameter p1 = new SqlParameter("@p_nro_micro", SqlDbType.Int, 4, "p_nro_micro");
            //parametros.Add(p1, entidad.NumeroDeMicro);

            SqlParameter p2 = new SqlParameter("@p_modelo", SqlDbType.NVarChar, 50, "p_modelo");
            parametros.Add(p2, entidad.Modelo);

            SqlParameter p3 = new SqlParameter("@p_patente", SqlDbType.NVarChar, 50, "p_patente");
            parametros.Add(p3, entidad.Patente);

            SqlParameter p4 = new SqlParameter("@p_marca", SqlDbType.Int, 4, "p_marca");
            parametros.Add(p4, entidad.Empresa.Id);

            SqlParameter p5 = new SqlParameter("@p_tipo_servicio", SqlDbType.Int, 4, "p_tipo_servicio");
            parametros.Add(p5, entidad.Servicio.Id);

            SqlParameter p6 = new SqlParameter("@p_baja_vida_util", SqlDbType.Bit, 1, "p_baja_vida_util");
            parametros.Add(p6, entidad.BajaVidaUtil ? 1 : 0);

            object baja = DBNull.Value;
            if (entidad.FechaBajaVidaUtil.HasValue)
                baja = entidad.FechaBajaVidaUtil.Value;
            SqlParameter p7 = new SqlParameter("@p_fec_baja_vida_util", SqlDbType.DateTime, 8, "p_fec_baja_vida_util");
            parametros.Add(p7, baja);

            SqlParameter p8 = new SqlParameter("@p_kgs_encomienda", SqlDbType.Decimal, 18, "p_kgs_encomienda");
            parametros.Add(p8, entidad.KgsCapacidad);

            SqlParameter pId = new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id");
            parametros.Add(pId, entidad.Id);

            this.accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_update_micro", parametros);
        }

        public IList<Micro> Listar()
        {
            IList<Micro> lista = new List<Micro>();
            foreach (DataRow row in this.ObtenerRegistrosMicro().Tables[0].Rows)
            {
                lista.Add(this._builder.Build(row));
            }
            return lista;
        }
        public IList<Micro> ListarFiltrado(decimal kgsEncomiendas, string numeroPatente, int numeroMicro, string tipoEmpresa, string tipoModelo, string tipoServicio)
        {
            IList<Micro> lista = new List<Micro>();
            foreach (DataRow row in this.ObtenerRegistrosMicro(kgsEncomiendas, numeroPatente, numeroMicro, tipoEmpresa, tipoModelo, tipoServicio).Tables[0].Rows)
            {
                lista.Add(this._builder.Build(row));
            }
            return lista;
        }
        public IList<Micro> ListarDisponibles(int ciudadOrigen, int ciudadDestino, DateTime fechaSalida)
        {
            DataSet ds = this.ObtenerMicrosDisponibles(ciudadOrigen, ciudadDestino, fechaSalida);

            IList<Micro> micros = new List<Micro>(ds.Tables[0].Rows.Count);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                micros.Add(this._builder.Build(row));
            }

            return micros;
        }


        #endregion

        private DataSet ObtenerMicrosDisponibles(int ciudadOrigen, int ciudadDestino, DateTime fechaSalida)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_ciudad_origen", SqlDbType.Int, 4, "p_ciudad_origen"), ciudadOrigen);
            parametros.Add(new SqlParameter("@p_ciudad_destino", SqlDbType.Int, 4, "p_ciudad_destino"), ciudadDestino);
            parametros.Add(new SqlParameter("@p_fecha_salida", SqlDbType.DateTime, 4, "p_fecha_salida"), fechaSalida);

            DataSet ds = this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_buscar_micros", parametros);
            return ds;

        }
        private DataSet ObtenerRegistrosMicro()
        {
            return this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_listar_micros");
        }
        private DataSet ObtenerRegistrosMicro(decimal kgsEncomiendas, string numeroPatente, int numeroMicro, string marca, string tipoModelo, string tipoServicio)
        {
            var parametros = new Dictionary<System.Data.SqlClient.SqlParameter, object>();
            if (kgsEncomiendas > 0)
            {
                parametros.Add(new SqlParameter("@p_kgs_encomienda", SqlDbType.Decimal, 18, "p_kgs_encomienda"), kgsEncomiendas);
            }
            if (!string.IsNullOrEmpty(numeroPatente))
            {
                parametros.Add(new SqlParameter("@p_patente", SqlDbType.NVarChar, 50, "p_patente"), numeroPatente);
            }
            if (numeroMicro > 0)
            {
                parametros.Add(new SqlParameter("@p_nro_micro", SqlDbType.Int, 4, "p_nro_micro"), numeroMicro);
            }
            if (!string.IsNullOrEmpty(marca))
            {
                parametros.Add(new SqlParameter("@p_marca", SqlDbType.VarChar, 50, "p_marca"), marca);
            }
           if (!string.IsNullOrEmpty(tipoModelo))
           {
               parametros.Add(new SqlParameter("@p_modelo", SqlDbType.NVarChar, 50, "p_modelo"), tipoModelo);
          }
            if (!string.IsNullOrEmpty(tipoServicio))
            {
                parametros.Add(new SqlParameter("@p_tipo_servicio", SqlDbType.NVarChar, 255, "p_tipo_servicio"), tipoServicio);
            }
            return this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_listar_filtrado_micros", parametros);
        }


        public void ObtenerDisponibilidades(Micro micro, int idViaje)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_id_viaje", SqlDbType.Int, 4, "p_id_viaje"), idViaje);

            DataRow row = accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_obtener_micro_disponibilidades", parametros).Tables[0].Rows[0];

            micro.ButacasDisponibles = Convert.ToInt32(row["butacas"].ToString());
            micro.KgsDisponibles = Convert.ToDecimal(row["kgs"].ToString());

        }

        public bool CheckearPatanteUnica(Micro micro)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_patente", SqlDbType.VarChar, 50, "p_patente"), micro.Patente);

            DataRow row = accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_existe_patente", parametros).Tables[0].Rows[0];

            var cant = Convert.ToInt32(row["cant"].ToString());
            return cant == 0;            
        }
    }
}
