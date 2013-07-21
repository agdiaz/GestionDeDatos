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
        private UsuarioManager _usuarioManager;

        public ClienteManager()
        {
            _dao = new ClienteDAO();
            _usuarioManager = new UsuarioManager();
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


        public void GenerarUsuario(Cliente _cliente)
        {
            this._dao.GenerarUsuario(_cliente);
        }

        public Usuario ObtenerUsuario(Cliente _cliente)
        {
            return _usuarioManager.Obtener(_cliente.NroDni);
        }
    }
}
