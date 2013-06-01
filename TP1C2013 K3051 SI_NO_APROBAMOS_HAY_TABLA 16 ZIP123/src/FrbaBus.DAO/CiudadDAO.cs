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

        public void Alta(Ciudad entidad)
        {
            string consulta = "INSERT INTO [PRUEBAS].[dbo].[Ciudad]([descripcion])VALUES('"+entidad.Descripcion+"')";
            this.accesoBD.EjecutarComando(consulta);
        }

        public void Baja(Ciudad entidad)
        {
            string consulta = "DELETE FROM [PRUEBAS].[dbo].[Ciudad] WHERE '"+entidad.Descripcion+"'=descripcion";
            this.accesoBD.EjecutarComando(consulta);
        }

        public void Modificacion(Ciudad entidad)
        {
            string consulta = "UPDATE [PRUEBAS].[dbo].[Ciudad] SET descripcion='" + entidad.Descripcion + "' WHERE descripcion="; // Falta ver de donde traigo la descripcion que quiero modificar
            this.accesoBD.EjecutarComando(consulta);
        }

        public IList<Ciudad> Listar()
        {
            string consulta = "SELECT * FROM [PRUEBAS].[dbo].[Ciudad]";
            DataSet ciudades = this.accesoBD.RealizarConsulta(consulta);
            foreach (DataRow theRow in ciudades.Tables["Ciudad"].Rows)
            {
                Console.WriteLine(theRow["id"] + "\t" + theRow["descripcion"]);
            }
            return null;
        }

        #endregion

        #region Miembros de IEntidadDAO<Ciudad>


        public DataSet ObtenerRegistros()
        {
            string consulta = "SELECT * FROM [PRUEBAS].[dbo].[Ciudad]";
            DataSet ciudades = this.accesoBD.RealizarConsulta(consulta);
            return ciudades;
        }

        #endregion
    }
}
