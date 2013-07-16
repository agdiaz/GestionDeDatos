using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.DAO;
using System.Data;
using FrbaBus.Common.Entidades;

namespace FrbaBus.Manager
{
    public class RecorridoManager
    {
        private RecorridoDAO _dao;
        private CiudadManager _ciudadManager;
        private ServicioManager _servicioManager;

        public RecorridoManager()
        {
            this._dao = new RecorridoDAO();
            this._ciudadManager = new CiudadManager();
            this._servicioManager = new ServicioManager();
        }
        
        public Recorrido Obtener(int id)
        {
            return _dao.Obtener(id);
        }
        public Recorrido Alta(Recorrido rec)
        {
            int id = _dao.Alta(rec);
            rec.Id = id;
            return rec;
        }
        public void Modificar(Recorrido rec)
        {
            this._dao.Modificacion(rec);

        }
        public void Baja(Recorrido rec)
        {
            this._dao.Baja(rec);
        }

        public IList<Recorrido> Listar()
        {
            IList<Recorrido> rtn = _dao.Listar();
            foreach (Recorrido rec in rtn)
            {
                Ciudad ciudadDestino = _ciudadManager.Obtener(rec.IdCiudadDestino);
                Ciudad ciudadOrigen = _ciudadManager.Obtener(rec.IdCiudadDestino);
                Servicio servicio = _servicioManager.Obtener(rec.IdServicio);

                rec.CiudadDestino = ciudadDestino;
                rec.CiudadOrigen = ciudadOrigen;
                rec.Servicio = servicio;
            }
            return rtn;
        }
        public IList<Recorrido> ListarFiltrado(int origenId, int destinoId, int servicioId)
        {
            IList<Recorrido> rtn = _dao.ListarFiltrado(origenId, destinoId, servicioId);
            foreach (Recorrido rec in rtn)
            {
                Ciudad ciudadDestino = _ciudadManager.Obtener(rec.IdCiudadDestino);
                Ciudad ciudadOrigen = _ciudadManager.Obtener(rec.IdCiudadDestino);
                Servicio servicio = _servicioManager.Obtener(rec.IdServicio);

                rec.CiudadDestino = ciudadDestino;
                rec.CiudadOrigen = ciudadOrigen;
                rec.Servicio = servicio;
            }
            return rtn;

        }
    }
}
