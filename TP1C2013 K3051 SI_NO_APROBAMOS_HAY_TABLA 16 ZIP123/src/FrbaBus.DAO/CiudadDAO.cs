using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDeDatos.AccesoDatos;
using FrbaBus.Common.Entidades;
using System.Data;
using System.Data.SqlClient;
using FrbaBus.DAO.Builder;

namespace FrbaBus.DAO
{
    public class CiudadDAO : IEntidadDAO<Ciudad>
    {
        private IBuilder<Ciudad> _builder;
        public GestionDeDatos.AccesoDatos.IAccesoBD accesoBD
        {
            get
            {
                return new AccesoBD();
            }
        }

        public CiudadDAO()
        {
            this._builder = new CiudadBuilder();
        }

        #region Miembros de IEntidadDAO<Ciudad>
        
        public Ciudad Obtener(object id)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id"), id);

            DataRow row = accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_obtener_ciudad", parametros).Tables[0].Rows[0];
            return _builder.Build(row);
        }

        public int Alta(Ciudad entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter pNombre = new SqlParameter("@nombre", SqlDbType.VarChar, 50, "nombre");
            parametros.Add(pNombre, entidad.Descripcion);

            SqlParameter pId = new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id");
            pId.Direction = ParameterDirection.Output;
            parametros.Add(pId, 0);

            this.accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_insert_ciudad", parametros);
            return Convert.ToInt32(pId.Value);
        }
        public void Baja(Ciudad entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter pId = new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id");
            parametros.Add(pId, entidad.Id);

            this.accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_borrar_ciudad", parametros);
        }
        public void Modificacion(Ciudad entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter pNombre = new SqlParameter("@nombre", SqlDbType.VarChar, 50, "nombre");
            parametros.Add(pNombre, entidad.Descripcion);

            SqlParameter pId = new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id");
            parametros.Add(pId, entidad.Id);

            this.accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_modificar_ciudad", parametros);
        }

        public IList<Ciudad> Listar()
        {
            IList<Ciudad> ciudades = new List<Ciudad>();

            DataSet ds = this.ObtenerRegistros();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                ciudades.Add(this._builder.Build(r));
            }

            return ciudades;
        }
        public IList<Ciudad> ListarRegistrosFiltrados(string nombre)
        {
            IList<Ciudad> ciudades = new List<Ciudad>();

            DataSet ds = ObtenerRegistrosFiltrados(nombre);
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                ciudades.Add(this._builder.Build(r));
            }

            return ciudades;
        }

        private DataSet ObtenerRegistros()
        {
            DataSet ciudades = this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_listar_ciudad", new Dictionary<System.Data.SqlClient.SqlParameter, object>());
            return ciudades;
        }
        private DataSet ObtenerRegistrosFiltrados(string nombre)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter pNombre = new SqlParameter("@p_ciudad", SqlDbType.VarChar, 50, "p_ciudad");
            parametros.Add(pNombre, nombre);

            return this.accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_ciudad", parametros);
        }

        #endregion
    }

}
