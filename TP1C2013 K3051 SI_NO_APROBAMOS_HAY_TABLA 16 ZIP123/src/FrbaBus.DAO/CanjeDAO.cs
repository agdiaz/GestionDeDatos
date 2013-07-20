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
    public class CanjeDAO : IEntidadDAO<Canje>
    {
        public IAccesoBD _acceso;

        #region Miembros de IEntidadDAO<Canje>
        private IBuilder<Canje> _builder;
        
        public CanjeDAO()
        {
            this._builder = new CanjeBuilder();
            _acceso = new AccesoBD();
        }

        public GestionDeDatos.AccesoDatos.IAccesoBD accesoBD
        {
            get { return _acceso ; }
        }

        public Canje Obtener(object id)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id"), id);

            DataRow row = accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_obtener_canje", parametros).Tables[0].Rows[0];
            return _builder.Build(row);
        }

        public int Alta(Canje entidad)
        {
            throw new NotImplementedException();
        }

        public void Baja(Canje entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Canje entidad)
        {
            throw new NotImplementedException();
        }

        public IList<Canje> Listar()
        {
            throw new NotImplementedException();
        }

        public IList<Canje> ListarPorCliente(int dniCliente)
        {
            IList<Canje> canjes = new List<Canje>();

            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_dni", SqlDbType.Decimal, 18, "p_id"), dniCliente);

            DataSet ds = accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_obtener_canjes_cliente", parametros);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                canjes.Add(this._builder.Build(item));
            }
            return canjes;
        }

        #endregion
    }
}
