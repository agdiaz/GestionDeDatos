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
            var rec = _dao.Obtener(id);

            Ciudad ciudadDestino = _ciudadManager.Obtener(rec.IdCiudadDestino);
            Ciudad ciudadOrigen = _ciudadManager.Obtener(rec.IdCiudadOrigen);
            Servicio servicio = _servicioManager.Obtener(rec.IdServicio);

            rec.CiudadDestino = ciudadDestino;
            rec.CiudadOrigen = ciudadOrigen;
            rec.Servicio = servicio;

            return rec;
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
                Ciudad ciudadOrigen = _ciudadManager.Obtener(rec.IdCiudadOrigen);
                Servicio servicio = _servicioManager.Obtener(rec.IdServicio);

                rec.CiudadDestino = ciudadDestino;
                rec.CiudadOrigen = ciudadOrigen;
                rec.Servicio = servicio;
            }
            return rtn;
        }
        public IList<Recorrido> ListarFiltrado(Ciudad origen, Ciudad destino, Servicio servicio)
        {
            IList<Recorrido> rtn = _dao.ListarFiltrado(origen.Id, destino.Id, servicio.Id);
            foreach (Recorrido rec in rtn)
            {
                Ciudad ciudadDestino = (destino.Id > 0) ? destino : _ciudadManager.Obtener(rec.IdCiudadDestino);
                Ciudad ciudadOrigen = (origen.Id > 0) ? origen : _ciudadManager.Obtener(rec.IdCiudadOrigen);

                Servicio serv =  (servicio.Id > 0) ? servicio : _servicioManager.Obtener(rec.IdServicio);

                rec.CiudadDestino = ciudadDestino;
                rec.CiudadOrigen = ciudadOrigen;
                rec.Servicio = serv;
            }
            return rtn;

        }
    }
}
