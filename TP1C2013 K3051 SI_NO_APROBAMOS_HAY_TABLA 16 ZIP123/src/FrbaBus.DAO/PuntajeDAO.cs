using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;

namespace FrbaBus.DAO
{
    public class PuntajeDAO : IEntidadDAO<Puntaje>
    {
        #region Miembros de IEntidadDAO<Puntaje>

        public GestionDeDatos.AccesoDatos.IAccesoBD accesoBD
        {
            get { throw new NotImplementedException(); }
        }

        public Puntaje Obtener(object id)
        {
            throw new NotImplementedException();
        }

        public int Alta(Puntaje entidad)
        {
            throw new NotImplementedException();
        }

        public void Baja(Puntaje entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Puntaje entidad)
        {
            throw new NotImplementedException();
        }

        public IList<Puntaje> Listar()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
