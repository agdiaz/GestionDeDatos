using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using FrbaBus.DAO.Builder;
using GestionDeDatos.AccesoDatos;
using System.Data.SqlClient;
using System.Data;

namespace FrbaBus.DAO
{
    public class CompraDAO : IEntidadDAO<Compra>
    {
        private IBuilder<Compra> _builder;
        private IAccesoBD _acceso;
        public CompraDAO()
        {
            _acceso = new AccesoBD();
            _builder = new CompraBuilder();
        }

        #region Miembros de IEntidadDAO<Compra>

        public GestionDeDatos.AccesoDatos.IAccesoBD accesoBD
        {
            get { return _acceso; }
        }

        public Compra Obtener(object id)
        {
            throw new NotImplementedException();
        }

        public int Alta(Compra entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter p0 = new SqlParameter("@p_id_usuario", SqlDbType.Int, 4, "p_id_usuario");
            parametros.Add(p0, entidad.IdUsuario);

            SqlParameter p1 = new SqlParameter("@p_fecha_compra", SqlDbType.DateTime, 8, "p_fecha_compra");
            parametros.Add(p1, entidad.FechaCompra);

            SqlParameter pId = new SqlParameter("@p_id_compra", SqlDbType.DateTime, 8, "p_id_compra");
            pId.Direction = ParameterDirection.Output;
            parametros.Add(pId, 0);

            this.accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_insert_compra", parametros);
            return Convert.ToInt32(pId.Value);
        }

        public void Baja(Compra entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Compra entidad)
        {
            throw new NotImplementedException();
        }

        public IList<Compra> Listar()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
