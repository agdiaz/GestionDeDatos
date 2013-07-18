using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.DAO;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Manager
{
    public class ViajeManager
    {
        private ViajeDAO _dao;
        private MicroManager _microManager;
        private RecorridoManager _recManager;

        public ViajeManager()
        {
            _dao = new ViajeDAO();
            _microManager = new MicroManager();
            _recManager = new RecorridoManager();
        }

        public IList<Viaje> Listar()
        {
            IList<Viaje> viajes = _dao.Listar();

            foreach (Viaje viaje in viajes)
            {
                viaje.Micro = _microManager.Obtener(viaje.IdMicro);
                viaje.Recorrido = _recManager.Obtener(viaje.IdRecorrido);
            }
            
            return viajes;
        }

        public IList<Viaje> ListarPorRecorrido(Recorrido rec)
        {
            IList<Viaje> viajes = _dao.ListarPorRecorrido(rec);
            foreach (Viaje viaje in viajes)
            {
                viaje.Recorrido = rec;
                viaje.Micro = _microManager.Obtener(viaje.IdMicro);
            }
            return viajes;
        }

        public object ListarFiltrado(DateTime llegada, DateTime salida, Recorrido rec, Micro micro)
        {
            IList<Viaje> viajes = _dao.ListarFiltrado(llegada, salida, rec,  micro);
            foreach (Viaje viaje in viajes)
            {
                viaje.Recorrido = rec;
                viaje.Micro = _microManager.Obtener(viaje.IdMicro);
            }
            return viajes;
        }
    }
}
