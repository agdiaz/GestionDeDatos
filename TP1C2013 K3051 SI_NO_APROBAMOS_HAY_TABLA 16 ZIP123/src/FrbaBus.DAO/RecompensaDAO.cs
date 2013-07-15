using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;

namespace FrbaBus.DAO
{
    public class RecompensaDAO : IEntidadDAO<Recompensa>
    {

        #region Miembros de IEntidadDAO<Recompensa>

        public GestionDeDatos.AccesoDatos.IAccesoBD accesoBD
        {
            get { throw new NotImplementedException(); }
        }

        public Recompensa Obtener(object id)
        {
            throw new NotImplementedException();
        }

        public int Alta(Recompensa entidad)
        {
            throw new NotImplementedException();
        }

        public void Baja(Recompensa entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Recompensa entidad)
        {
            throw new NotImplementedException();
        }

        public IList<Recompensa> Listar()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
