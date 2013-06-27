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
        public IList<Micro> ObtenerMicrosDisponibles(int ciudadOrigen, int ciudadDestino, DateTime fechaSalida)
        {
            DataSet ds = new MicroDAO().ObtenerMicrosDisponibles(ciudadOrigen, ciudadDestino, fechaSalida);

            IList<Micro> micros = new List<Micro>(ds.Tables[0].Rows.Count);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                micros.Add(this.BuilderMicro(row));
            }

            return micros;
        }

        private Micro BuilderMicro(DataRow row)
        {
            return new Micro()
            {
                Marca = row["nombre"].ToString(),
                Servicio = row["tipo_servicio"].ToString(),
                Id = Convert.ToInt32(row["id_micros"].ToString()),
                ButacasDisponibles = Convert.ToInt32(row["butacas_disponibles"].ToString()),
                ButacasTotal = Convert.ToInt32(row["butacas_total"].ToString()),
                ButacasVendidas = Convert.ToInt32(row["butacas_vendidas"].ToString()),
                KgsCapacidad = Convert.ToDecimal(row["capacidad_kg"].ToString()),
                KgsDisponibles = Convert.ToDecimal(row["kgs_disponibles"].ToString()),
                KgsVendidos = Convert.ToDecimal(row["kgs_vendidos"].ToString()),

            };
        }

        public IList<Servicio> ObtenerServiciosDisponibles()
        {
            return new ServicioDAO().Listar();
        }

        public IList<Empresa> ObtenerEmpresasDisponibles()
        {
            return new EmpresaDAO().Listar();
        }

        public DataSet ObtenerRegistrosMicro(string kgsEncomiendas, string numeroPatente, string numeroMicro, string tipoEmpresa, string tipoModelo, string tipoServicio)
        {
            return new EmpresaDAO().ObtenerRegistrosMicro(kgsEncomiendas, numeroPatente, numeroMicro, tipoEmpresa, tipoModelo, tipoServicio);
        }

        public DataSet ObtenerRegistrosRecorrido()
        {
            return new MicroDAO().ObtenerRegistrosRecorrido();
        }

        public DataSet ObtenerRegistrosRecorrido(int origenId, int destinoId, int servicioId)
        {
            return new MicroDAO().ObtenerRegistrosRecorrido(origenId, destinoId, servicioId);
        }

        public DataSet ObtenerRegistrosMicro()
        {
            return new MicroDAO().ObtenerRegistrosMicro();
        }
    }
}
