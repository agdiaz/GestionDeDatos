using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDeDatos.AccesoDatos;
using FrbaBus.Common.Entidades;
using System.Data;

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
            string consulta = "INSERT INTO [SI_NO_APROBAMOS_HAY_TABLA].[Ciudad]([nombre])VALUES('"+entidad.Descripcion+"')";
            this.accesoBD.EjecutarComando(consulta);
            return -1;
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
    }
}
