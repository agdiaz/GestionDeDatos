using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.DAO;
using FrbaBus.Common.Entidades;
using System.Data;

namespace FrbaBus.Manager
{
    public class RecompensaManager
    {
        private RecompensaDAO _dao;

        public RecompensaManager()
        {
            _dao = new RecompensaDAO();
        }

        public IList<Recompensa> ListarFiltrado(string descripcion, int puntosDesde, int puntosHasta, int stockDesde, int stockHasta)
        {
            return _dao.ListarFiltrado(descripcion, puntosDesde, puntosHasta, stockDesde, stockHasta);
        }

        public DataSet ObtenerRegistroPuntosCliente(decimal dni)
        {
            return _dao.ObtenerRegistroPuntosCliente(dni);
        }

        public string ObtenerPuntosCliente(decimal dni)
        {
            return _dao.ObtenerPuntosCliente(dni);
        }

        public void CanjearPuntos(decimal dni, int id_recompensa, int cantidadPedidad)
        {
            _dao.CanjearPuntos(dni,id_recompensa,cantidadPedidad);
        }
    }
}
