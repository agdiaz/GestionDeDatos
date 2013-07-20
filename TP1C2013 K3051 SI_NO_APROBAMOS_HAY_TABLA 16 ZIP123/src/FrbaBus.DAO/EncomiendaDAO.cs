using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using GestionDeDatos.AccesoDatos;
using FrbaBus.DAO.Builder;
using System.Data;
using System.Data.SqlClient;

namespace FrbaBus.DAO
{
    public class EncomiendaDAO : IEntidadDAO<Encomienda>
    {
        private IAccesoBD _acceso;
        private IBuilder<Encomienda> _builder;

        public EncomiendaDAO()
        {
            _acceso = new AccesoBD();
            _builder = new EncomiendaBuilder();
        }

        #region Miembros de IEntidadDAO<Encomienda>

        public GestionDeDatos.AccesoDatos.IAccesoBD accesoBD
        {
            get { return _acceso; }
        }

        public Encomienda Obtener(object id)
        {
            throw new NotImplementedException();
        }

        public int Alta(Encomienda entidad)
        {
            throw new NotImplementedException();
        }

        public void Baja(Encomienda entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Encomienda entidad)
        {
            throw new NotImplementedException();
        }

        public IList<Encomienda> Listar()
        {
            throw new NotImplementedException();
        }

        #endregion

        public IList<Encomienda> ListarFiltrado(decimal nroDni, int IdEncomienda, int IdViaje, int IdCompra, decimal kgs)
        {
            IList<Encomienda> lista = new List<Encomienda>();

            foreach (DataRow row in ObtenerFiltrado(nroDni, IdEncomienda, IdViaje, IdCompra, kgs).Tables[0].Rows)
            {
                lista.Add(this._builder.Build(row));
            }

            return lista;
        }

        private DataSet ObtenerFiltrado(decimal nroDni, int IdEncomienda, int IdViaje, int IdCompra, decimal kgs)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            if (nroDni > 0)
                parametros.Add(new SqlParameter("@p_dni", SqlDbType.Decimal, 18, "p_dni"), nroDni);
            else
                parametros.Add(new SqlParameter("@p_dni", SqlDbType.Decimal, 18, "p_dni"), DBNull.Value);
            
            if (IdEncomienda > 0)
                parametros.Add(new SqlParameter("@p_id_encomienda", SqlDbType.Int, 4, "p_id_encomienda"), IdEncomienda);
            else
                parametros.Add(new SqlParameter("@p_id_encomienda", SqlDbType.Int, 4, "p_id_encomienda"), DBNull.Value);

            if (IdViaje > 0)
                parametros.Add(new SqlParameter("@p_id_viaje", SqlDbType.Int, 4, "p_id_viaje"), IdViaje);
            else
                parametros.Add(new SqlParameter("@p_id_viaje", SqlDbType.Int, 4, "p_id_viaje"), DBNull.Value);

            if (IdCompra > 0)
                parametros.Add(new SqlParameter("@p_id_compra", SqlDbType.Int, 4, "p_id_compra"), IdCompra);
            else
                parametros.Add(new SqlParameter("@p_id_compra", SqlDbType.Int, 4, "p_id_compra"), DBNull.Value);

            if (kgs > 0)
                parametros.Add(new SqlParameter("@p_kgs", SqlDbType.Decimal, 18, "p_kgs"), kgs);
            else
                parametros.Add(new SqlParameter("@p_kgs", SqlDbType.Decimal, 18, "p_kgs"), DBNull.Value);

            try
            {
                DataSet ds = accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_listar_detallado_encomienda", parametros);
                return ds;
            }
            catch (AccesoBDException ex)
            {
                ex.ToString();
                return new DataSet();
            }
        }
    }
}
