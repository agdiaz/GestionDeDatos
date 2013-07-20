using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using FrbaBus.DAO.Builder;
using GestionDeDatos.AccesoDatos;

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
            throw new NotImplementedException();
        }

        public int Alta(Compra entidad)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        #endregion
    }
}
