using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.DAO;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Manager
{
    public class EmpresaManager
    {
        private EmpresaDAO _dao;

        public EmpresaManager()
        {
            this._dao = new EmpresaDAO();
        }

        public Empresa Obtener(int id)
        {
            return _dao.Obtener(id);
        }
        public Empresa Alta(Empresa empresa)
        {
            int id = this._dao.Alta(empresa);
            empresa.Id = id;
            return empresa;
        }
        public void Modificar(Empresa empresa)
        {
            _dao.Modificacion(empresa);
        }
        public void Baja(Empresa empresa)
        {
            _dao.Baja(empresa);
        }

        public IList<Empresa> Listar()
        {
            return _dao.Listar();
        }

    }
}
