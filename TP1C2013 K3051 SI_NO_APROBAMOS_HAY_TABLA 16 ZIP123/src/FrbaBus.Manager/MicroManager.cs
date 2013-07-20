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
        private ServicioManager _servicioManager;
        private EmpresaManager _empresaManager;
        private ButacaManager _butacaManager;

        private MicroDAO _dao; 
        
        public MicroManager()
        {
            this._dao = new MicroDAO();
            _servicioManager = new ServicioManager();
            _empresaManager = new EmpresaManager();
            _butacaManager = new ButacaManager();
        }
        
        public Micro Obtener(int id)
        {
            Micro m = this._dao.Obtener(id);
            
            m.Empresa = _empresaManager.Obtener(m.IdEmpresa);
            m.Servicio = _servicioManager.Obtener(m.IdServicio);
            //m.Butacas = _butacaManager.ObtenerButacasMicro(m);

            return m;
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

        public bool CheckearPatanteUnica(Micro micro)
        {
            return _dao.CheckearPatanteUnica(micro);
        }


        public IList<Micro> Listar()
        {
            var micros = _dao.Listar();
            foreach (Micro m in micros)
            {
                m.Empresa = _empresaManager.Obtener(m.IdEmpresa);
                m.Servicio = _servicioManager.Obtener(m.IdServicio);
                //m.Butacas = _butacaManager.ObtenerButacasMicro(m);
            }
            return micros;
        }
        public IList<Micro> ListarFiltrado(decimal kgsEncomiendas, string numeroPatente, int numeroMicro, string tipoEmpresa, string tipoModelo, string tipoServicio)
        {
            var micros = _dao.ListarFiltrado(kgsEncomiendas, numeroPatente, numeroMicro, tipoEmpresa, tipoModelo, tipoServicio);
            foreach (Micro m in micros)
            {
                m.Empresa = _empresaManager.Obtener(m.IdEmpresa);
                m.Servicio = _servicioManager.Obtener(m.IdServicio);
                //m.Butacas = _butacaManager.ObtenerButacasMicro(m);
            }

            return micros;
        }
        public IList<Micro> ListarDisponibles(int ciudadOrigenId, int ciudadDestinoId, DateTime fechaSalida)
        {
            var micros = _dao.ListarDisponibles(ciudadOrigenId, ciudadDestinoId, fechaSalida);
            foreach (Micro m in micros)
            {
                m.Empresa = _empresaManager.Obtener(m.IdEmpresa);
                m.Servicio = _servicioManager.Obtener(m.IdServicio);
                //m.Butacas = _butacaManager.ObtenerButacasMicro(m);
            
            }
            return micros;
        }

        public void ObtenerDisponibilidades(Micro micro, int idViaje)
        {
            _dao.ObtenerDisponibilidades(micro, idViaje);
        }

        public void CancelarTodosLosViajes(Micro _micro)
        {
            _dao.CancelarTodosLosViajes(_micro.Id);
        }

        public int ReAsignarMicros(Micro _micro)
        {
            return _dao.ReAsignarMicros(_micro.Id);
        }
    }
}
