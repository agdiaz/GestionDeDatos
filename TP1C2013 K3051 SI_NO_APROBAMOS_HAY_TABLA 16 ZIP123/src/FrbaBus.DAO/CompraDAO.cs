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
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id"), id);

            DataRow row = accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_obtener_compra", parametros).Tables[0].Rows[0];
            return _builder.Build(row);
        }

        public int Alta(Compra entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter p0 = new SqlParameter("@p_id_usuario", SqlDbType.Int, 4, "p_id_usuario");
            parametros.Add(p0, entidad.IdUsuario);

            SqlParameter p1 = new SqlParameter("@p_fecha_compra", SqlDbType.DateTime, 8, "p_fecha_compra");
            parametros.Add(p1, entidad.FechaCompra);

            SqlParameter pId = new SqlParameter("@p_id_compra", SqlDbType.Int, 4, "p_id_compra");
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
            IList<Compra> compras = new List<Compra>();
            foreach (DataRow row in ObtenerRegistros().Tables[0].Rows)
            {
                compras.Add(this._builder.Build(row));
            }
            return compras;
        }

        private DataSet ObtenerRegistros()
        {
            DataSet ciudades = this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_listar_compras");
            return ciudades;
             
        }

        #endregion

        public int CompraPasaje(Compra compra, Pasaje pasaje)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            var pId = new SqlParameter("@p_id_pasaje", SqlDbType.Int, 4, "p_id_pasaje");
            pId.Direction = ParameterDirection.Output;
            parametros.Add(pId, 0);

            parametros.Add(new SqlParameter("@p_id_compra", SqlDbType.Int, 4, "p_id_compra"), compra.IdCompra);
            parametros.Add(new SqlParameter("@p_id_butaca", SqlDbType.Int, 4, "p_id_butaca"), pasaje.Butaca.Id);
            parametros.Add(new SqlParameter("@p_dni", SqlDbType.Decimal, 18, "p_dni"), pasaje.NroDni);
            parametros.Add(new SqlParameter("@p_pre_pasaje", SqlDbType.Int, 4, "p_pre_pasaje"), pasaje.PrecioPasaje);
            parametros.Add(new SqlParameter("@p_id_viaje", SqlDbType.Int, 4, "p_id_viaje"), pasaje.IdViaje);

            this.accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_insertar_pasaje", parametros);
            return Convert.ToInt32(pId.Value);
        }

        public int CompraEncomienda(Compra compra, Encomienda encomienda)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            var pId = new SqlParameter("@p_id_encomienda", SqlDbType.Int, 4, "p_id_encomienda");
            pId.Direction = ParameterDirection.Output;
            parametros.Add(pId, 0);

            parametros.Add(new SqlParameter("@p_id_compra", SqlDbType.Int, 4, "p_id_compra"), compra.IdCompra);
            parametros.Add(new SqlParameter("@p_dni", SqlDbType.Decimal, 18, "p_dni"), encomienda.NroDni);
            parametros.Add(new SqlParameter("@p_pre_encomienda", SqlDbType.Int, 4, "p_pre_encomienda"), encomienda.PrecioEncomienda);
            parametros.Add(new SqlParameter("@p_id_viaje", SqlDbType.Int, 4, "p_id_viaje"), encomienda.IdViaje);
            parametros.Add(new SqlParameter("@p_peso", SqlDbType.Decimal, 18, "p_peso"), encomienda.Peso);
            
            this.accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_insertar_encomienda", parametros);
            return Convert.ToInt32(pId.Value);
        }

        public IList<Compra> ListarFiltrado(decimal nroDni, int idCompra, DateTime fecha)
        {
            IList<Compra> compras = new List<Compra>();

            foreach (DataRow row in ObtenerFiltrado(nroDni, idCompra, fecha).Tables[0].Rows)
            {
                compras.Add(this._builder.Build(row));
            }

            return compras;
        }

        private DataSet ObtenerFiltrado(decimal nroDni, int idCompra, DateTime fecha)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            
            if (idCompra > 0)
                parametros.Add(new SqlParameter("@id_compra", SqlDbType.Int, 4, "id_compra"), nroDni);
            if (nroDni > 0)
            parametros.Add(new SqlParameter("@dni", SqlDbType.Decimal, 18, "dni"), idCompra);
            if (fecha != null)
                parametros.Add(new SqlParameter("@fecha_compra", SqlDbType.DateTime, 8, "fecha_compra"), fecha);

            return accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_filtrar_compras", parametros);
            
        }
    }
}
