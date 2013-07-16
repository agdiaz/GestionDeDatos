using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.DAO;
using FrbaBus.Common.Entidades;
using System.Data;

namespace FrbaBus.Manager
{
    public class MicroManager
    {
        private MicroDAO _dao; 
        
        public MicroManager()
        {
            this._dao = new MicroDAO();
        }

        public Micro Alta(Micro micro)
        {
            int id = _dao.Alta(micro);
            micro.Id = id;
            return micro;
        }

        public void Baja(Micro micro)
        {
            _dao.Baja(micro);
        }

        public void Modificar(Micro micro)
        {
            _dao.Modificacion(micro);
        }

        public IList<Micro> Listar()
        {
            return _dao.Listar();
        }
        public IList<Micro> ListarFiltrado(string kgsEncomiendas, string numeroPatente, string numeroMicro, string tipoEmpresa, string tipoModelo, string tipoServicio)
        {
            return _dao.ListarFiltrado(kgsEncomiendas, numeroPatente, numeroMicro, tipoEmpresa, tipoModelo, tipoServicio);
        }
        public IList<Micro> ListarDisponibles(int ciudadOrigenId, int ciudadDestinoId, DateTime fechaSalida)
        {
            return _dao.ListarDisponibles(ciudadOrigenId, ciudadDestinoId, fechaSalida);
        }
    }
}
