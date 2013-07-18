using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using FrbaBus.DAO;
using System.Data;

namespace FrbaBus.Manager
{
    public class ClienteManager
    {
        private ClienteDAO _dao;
        public ClienteManager()
        {
            _dao = new ClienteDAO();
        }

        public Cliente Obtener(decimal nroDni)
        {
            return _dao.Obtener(nroDni);
        }

        public Cliente Alta(Cliente cliente)
        {
            int id = _dao.Alta(cliente);
            return cliente;
        }

        public void Baja(Cliente cliente)
        {
            _dao.Baja(cliente);
        }

        public void Modificar(Cliente cliente)
        {
            _dao.Modificacion(cliente);
        }

        public IList<Cliente> Listar()
        {
            return _dao.Listar();
        }
        
        public IList<Cliente> ListarFiltrado(string dni, string nombre, string apellido, string discapacitado, string sexo)
        {
            return _dao.ListarFiltrados(dni, nombre, apellido, discapacitado, sexo);
        }

    }
}
