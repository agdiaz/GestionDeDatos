using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.DAO;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Manager
{
    public class PasajeManager
    {
        private PasajeDAO _daoPasaje;
        private EncomiendaDAO _daoEncomienda;

        public PasajeManager()
        {
            _daoPasaje = new PasajeDAO();
            _daoEncomienda = new EncomiendaDAO();
        }

        public decimal BuscarPrecio(Recorrido recorrido, decimal nroDni)
        {
            return _daoPasaje.BuscarPrecio(recorrido, nroDni);
        }

        public IList<Pasaje> ListarFiltrado(int IdMicro, decimal nroDni, int IdButaca, decimal precio)
        {
            return _daoPasaje.ListarFiltrado(IdMicro, nroDni, IdButaca, precio);
        }

        public IList<Encomienda> ListarFiltrado(decimal nroDni, int IdEncomienda, int IdViaje, int idCompra, decimal kgs)
        {
            return _daoEncomienda.ListarFiltrado(nroDni, IdEncomienda, IdViaje, idCompra, kgs);
        }

    }
}
