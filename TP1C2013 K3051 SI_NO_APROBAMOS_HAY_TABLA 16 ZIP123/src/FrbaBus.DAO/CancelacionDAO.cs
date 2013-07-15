using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;

namespace FrbaBus.DAO
{
    class CancelacionDAO : IEntidadDAO<Cancelacion>
    {
        #region Miembros de IEntidadDAO<Cancelacion>

        public GestionDeDatos.AccesoDatos.IAccesoBD accesoBD
        {
            get { throw new NotImplementedException(); }
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
    }
}
