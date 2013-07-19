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

        public Viaje Alta(Viaje viaje)
        {
            int id = this._dao.Alta(viaje);
            viaje.Id = id;
            return viaje;
        }
        
        public void Modificar(Viaje viaje)
        {
            this._dao.Modificacion(viaje);
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

        public IList<Viaje> ListarFiltrado(DateTime? llegada, DateTime? salida, DateTime? estimada, Recorrido rec, Micro micro)
        {
            IList<Viaje> viajes = _dao.ListarFiltrado(llegada, salida, estimada, rec,  micro);
            foreach (Viaje viaje in viajes)
            {
                viaje.Recorrido = rec;
                viaje.Micro = _microManager.Obtener(viaje.IdMicro);
            }
            return viajes;
        }

        public void GenerarArribo(Viaje viaje)
        {
            _dao.GenerarArribo(viaje);
        }
    }
}
