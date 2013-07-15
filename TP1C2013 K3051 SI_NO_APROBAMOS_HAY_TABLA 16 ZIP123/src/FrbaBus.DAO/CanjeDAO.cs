using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;

namespace FrbaBus.DAO
{
    public class CanjeDAO : IEntidadDAO<Canje>
    {
        #region Miembros de IEntidadDAO<Canje>

        public GestionDeDatos.AccesoDatos.IAccesoBD accesoBD
        {
            get { throw new NotImplementedException(); }
        }

        public Canje Obtener(object id)
        {
            throw new NotImplementedException();
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

        #endregion
    }
}
