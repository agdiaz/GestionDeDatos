using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using GestionDeDatos.AccesoDatos;
using System.Data.SqlClient;
using System.Data;

namespace FrbaBus.DAO
{
    public class CancelacionDAO : IEntidadDAO<Cancelacion>
    {
        private IAccesoBD _acceso;
        public CancelacionDAO()
        {
            _acceso = new AccesoBD();
        }
        #region Miembros de IEntidadDAO<Cancelacion>

        public GestionDeDatos.AccesoDatos.IAccesoBD accesoBD
        {
            get { return _acceso; }
        }

        public Cancelacion Obtener(object id)
        {
            throw new NotImplementedException();
        }

        public int Alta(Cancelacion entidad)
        {
            throw new NotImplementedException();
        }

        public void Baja(Cancelacion entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Cancelacion entidad)
        {
            throw new NotImplementedException();
        }

        public IList<Cancelacion> Listar()
        {
            throw new NotImplementedException();
        }

        #endregion

        public void CancelarCompra(Compra compra, string motivo)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter p0 = new SqlParameter("id_compra", SqlDbType.Int, 4, "id_compra");
            parametros.Add(p0, compra.IdCompra);

            SqlParameter p1 = new SqlParameter("motivo", SqlDbType.NVarChar, 200, "motivo");
            parametros.Add(p1, motivo);

            this.accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_cancelar_compra", parametros);
        }

        public void CancelarPasaje(Pasaje pasaje, string motivo)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter p0 = new SqlParameter("id_pasaje", SqlDbType.Decimal, 18, "id_pasaje");
            parametros.Add(p0, pasaje.Id);

            SqlParameter p1 = new SqlParameter("motivo", SqlDbType.NVarChar, 200, "motivo");
            parametros.Add(p1, motivo);

            this.accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_cancelar_pasaje", parametros);
        }

        public void CancelarEncomienda(Encomienda encomienda, string motivo)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter p0 = new SqlParameter("id_encomienda", SqlDbType.Decimal, 18, "id_encomienda");
            parametros.Add(p0, encomienda.IdEncomienda);

            SqlParameter p1 = new SqlParameter("motivo", SqlDbType.NVarChar, 200, "motivo");
            parametros.Add(p1, motivo);

            this.accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_cancelar_encomienda", parametros);
        }
    }
}
