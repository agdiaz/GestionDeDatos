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
        public IList<Empresa> Listar()
        {
            return _dao.Listar();
        }

    }
}
