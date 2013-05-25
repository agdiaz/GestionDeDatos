using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDeDatos.AccesoDatos;
using FrbaBus.Common.Entidades;

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
            throw new NotImplementedException();
        }

        public void Modificacion(Ciudad entidad)
        {
            throw new NotImplementedException();
        }

        public IList<Ciudad> Listar()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
