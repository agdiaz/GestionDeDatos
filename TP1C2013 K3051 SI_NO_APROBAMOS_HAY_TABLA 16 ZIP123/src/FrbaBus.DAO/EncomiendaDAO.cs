using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using GestionDeDatos.AccesoDatos;
using FrbaBus.DAO.Builder;

namespace FrbaBus.DAO
{
    public class EncomiendaDAO : IEntidadDAO<Encomienda>
    {
        private IAccesoBD _acceso;
        private IBuilder<Encomienda> _builder;

        public EncomiendaDAO()
        {
            _acceso = new AccesoBD();
            _builder = new EncomiendaBuilder();
        }

        #region Miembros de IEntidadDAO<Encomienda>

        public GestionDeDatos.AccesoDatos.IAccesoBD accesoBD
        {
            get { throw new NotImplementedException(); }
        }

        public Encomienda Obtener(object id)
        {
            throw new NotImplementedException();
        }

        public int Alta(Encomienda entidad)
        {
            throw new NotImplementedException();
        }

        public void Baja(Encomienda entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Encomienda entidad)
        {
            throw new NotImplementedException();
        }

        public IList<Encomienda> Listar()
        {
            throw new NotImplementedException();
        }

        #endregion

        public IList<Encomienda> ListarFiltrado(decimal nroDni, int IdEncomienda, int IdViaje, int IdCompra, decimal kgs)
        {
            throw new NotImplementedException();
        }
    }
}
