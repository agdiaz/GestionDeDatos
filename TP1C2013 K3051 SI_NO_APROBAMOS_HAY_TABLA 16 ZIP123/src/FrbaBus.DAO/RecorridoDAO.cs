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
            throw new NotImplementedException();
        }

        public int Alta(Recorrido entidad)
        {
            throw new NotImplementedException();
        }

        public void Baja(Recorrido entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Recorrido entidad)
        {
            throw new NotImplementedException();
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

        public IList<Recorrido> ListarFiltrado(int origenId, int destinoId, int servicioId)
        {
            IList<Recorrido> lista = new List<Recorrido>();
            foreach (DataRow item in this.ObtenerRegistrosFiltrado(origenId, destinoId, servicioId).Tables[0].Rows)
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
        private DataSet ObtenerRegistrosFiltrado(int origenId, int destinoId, int servicioId)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            if (origenId > -1)
                parametros.Add(new SqlParameter("@p_ciudad_origen", SqlDbType.Int, 4, "p_ciudad_origen"), origenId);
            if (destinoId > -1)
                parametros.Add(new SqlParameter("@p_ciudad_destino", SqlDbType.Int, 4, "p_ciudad_destino"), destinoId);
            if (servicioId > -1)
                parametros.Add(new SqlParameter("@p_tipo_servicio", SqlDbType.Int, 4, "p_tipo_servicio"), servicioId);

            DataSet ds = this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_listar_filtrado_recorrido", parametros);
            return ds;
        }

    }
}
