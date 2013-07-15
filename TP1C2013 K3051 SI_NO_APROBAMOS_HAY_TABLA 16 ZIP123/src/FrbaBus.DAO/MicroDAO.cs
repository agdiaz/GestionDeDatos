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

        public MicroDAO()
        {
            this._builder = new MicroBuilder();
        }

        #region Miembros de IEntidadDAO<Micro>

        public IAccesoBD accesoBD
        {
            get { return new AccesoBD(); }
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
            throw new NotImplementedException();
        }

        public void Baja(Micro entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Micro entidad)
        {
            throw new NotImplementedException();
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
        public IList<Micro> ListarFiltrado(string kgsEncomiendas, string numeroPatente, string numeroMicro, string tipoEmpresa, string tipoModelo, string tipoServicio)
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
        private DataSet ObtenerRegistrosMicro(string kgsEncomiendas, string numeroPatente, string numeroMicro, string tipoEmpresa, string tipoModelo, string tipoServicio)
        {
            var parametros = new Dictionary<System.Data.SqlClient.SqlParameter, object>();
            if (!string.IsNullOrEmpty(kgsEncomiendas))
            {
                parametros.Add(new SqlParameter("@p_kgm_Encomiendas", SqlDbType.Decimal, 4, "p_kgm_encomiendas"), kgsEncomiendas);
            }
            if (!string.IsNullOrEmpty(numeroPatente))
            {
                parametros.Add(new SqlParameter("@p_kgm_Encomiendas", SqlDbType.Decimal, 4, "p_kgm_encomiendas"), kgsEncomiendas);
            }
            if (!string.IsNullOrEmpty(numeroMicro))
            {
                parametros.Add(new SqlParameter("@p_kgm_Encomiendas", SqlDbType.Decimal, 4, "p_kgm_encomiendas"), kgsEncomiendas);
            }
            if (!string.IsNullOrEmpty(tipoEmpresa))
            {
                parametros.Add(new SqlParameter("@p_kgm_Encomiendas", SqlDbType.Decimal, 4, "p_kgm_encomiendas"), kgsEncomiendas);
            }
            if (!string.IsNullOrEmpty(tipoModelo))
            {
                parametros.Add(new SqlParameter("@p_kgm_Encomiendas", SqlDbType.Decimal, 4, "p_kgm_encomiendas"), kgsEncomiendas);
            }
            if (!string.IsNullOrEmpty(tipoServicio))
            {
                parametros.Add(new SqlParameter("@p_kgm_Encomiendas", SqlDbType.Decimal, 4, "p_kgm_encomiendas"), kgsEncomiendas);
            }
            return this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_listar_filtrado_micro", parametros);
        }

    }
}
