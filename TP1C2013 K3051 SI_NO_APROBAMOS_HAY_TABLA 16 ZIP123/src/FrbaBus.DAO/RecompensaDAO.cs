using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using GestionDeDatos.AccesoDatos;
using System.Data.SqlClient;
using FrbaBus.DAO.Builder;
using System.Data;

namespace FrbaBus.DAO
{
    public class RecompensaDAO : IEntidadDAO<Recompensa>
    {

        private IBuilder<Recompensa> _builder;
        public RecompensaDAO()
        {
            this._builder = new RecompensaBuilder();
        }
        #region Miembros de IEntidadDAO<Recompensa>

        public GestionDeDatos.AccesoDatos.IAccesoBD accesoBD
        {
            get { return new AccesoBD(); }
        }

        public Recompensa Obtener(object id)
        {
            throw new NotImplementedException();
        }

        public int Alta(Recompensa entidad)
        {
            throw new NotImplementedException();
        }

        public void Baja(Recompensa entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Recompensa entidad)
        {
            throw new NotImplementedException();
        }

        public IList<Recompensa> Listar()
        {
            throw new NotImplementedException();
        }

        #endregion

        public IList<Recompensa> ListarFiltrado(string descripcion, int puntos_desde, int puntos_hasta, int stock_desde, int stock_hasta)
        {
            List<Recompensa> recompensas = new List<Recompensa>();

            foreach (DataRow row in this.ObtenerRegistros(descripcion, puntos_desde, puntos_hasta, stock_desde, stock_hasta).Tables[0].Rows)
            {
                recompensas.Add(this._builder.Build(row));
            }

            return recompensas;
        }

        public DataSet ObtenerRegistros(string descripcion, int puntos_desde, int puntos_hasta, int stock_desde, int stock_hasta)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            parametros.Add(new SqlParameter("@p_descrip", SqlDbType.Text, 200, "p_descrip"), descripcion);
            parametros.Add(new SqlParameter("@p_puntos_desde", SqlDbType.Int, 4, "p_puntos_desde"), puntos_desde);
            parametros.Add(new SqlParameter("@p_puntos_hasta", SqlDbType.Int, 4, "p_puntos_hasta"), puntos_hasta);
            parametros.Add(new SqlParameter("@p_stock_desde", SqlDbType.Int, 4, "p_stock_desde"), stock_desde);
            parametros.Add(new SqlParameter("@p_stock_hasta", SqlDbType.Int, 4, "p_stock_hasta"), stock_hasta);

            return accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_recompensa", parametros);
        }

        public DataSet ObtenerRegistroPuntosCliente(decimal dni)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            parametros.Add(new SqlParameter("@p_dni", SqlDbType.Decimal, 8, "p_dni"), dni);
            DataSet ds = accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_puntos_por_cliente_detallado",parametros);
            return ds;
        }

        public string ObtenerPuntosCliente(decimal dni)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            parametros.Add(new SqlParameter("@p_dni", SqlDbType.Decimal, 8, "p_dni"), dni);
            var fila = accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_puntos_por_cliente", parametros).Tables[0].Rows[0];
            string puntos = fila[0].ToString();

            return puntos;
        }
    }
}
