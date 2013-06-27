using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDeDatos.AccesoDatos;
using FrbaBus.Common.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace FrbaBus.DAO
{
    public class CiudadDAO : IEntidadDAO<Ciudad>
    {
        #region Miembros de IEntidadDAO<Ciudad>

        public GestionDeDatos.AccesoDatos.IAccesoBD accesoBD
        {
            get
            {
                return new AccesoBD();
            }
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
            string consulta = "DELETE FROM [SI_NO_APROBAMOS_HAY_TABLA].[Ciudad] WHERE '" + entidad.Descripcion + "'=descripcion";
            this.accesoBD.EjecutarComando(consulta);
        }

        public void Modificacion(Ciudad entidad)
        {
            string consulta = "UPDATE [PRUEBAS].[dbo].[Ciudad] SET descripcion='" + entidad.Descripcion + "' WHERE descripcion="; // Falta ver de donde traigo la descripcion que quiero modificar
            this.accesoBD.EjecutarComando(consulta);
        }

        public IList<Ciudad> Listar()
        {
            IList<Ciudad> ciudades = new List<Ciudad>();

            DataSet ds = this.ObtenerRegistros();
            foreach (DataRow theRow in ds.Tables[0].Rows)
            {
                ciudades.Add(this.BuilderCiudad(theRow));
            }

            return ciudades;
        }

        private Ciudad BuilderCiudad(DataRow theRow)
        {
            return new Ciudad()
            {
                Descripcion = theRow["nombre"].ToString(),
                Id = Convert.ToInt32(theRow["id_ciudad"])
            };
        }

        #endregion

        #region Miembros de IEntidadDAO<Ciudad>


        public DataSet ObtenerRegistros()
        {
            DataSet ciudades = this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_listar_ciudad", new Dictionary<System.Data.SqlClient.SqlParameter,object>());
            return ciudades;
        }

        #endregion

        public DataSet ObtenerRegistrosFiltrados(string ciudadElegida)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter pNombre = new SqlParameter("@p_ciudad", SqlDbType.VarChar, 50, "p_ciudad");
            parametros.Add(pNombre, ciudadElegida);

            return this.accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_ciudad", parametros);
        }
    }
}
