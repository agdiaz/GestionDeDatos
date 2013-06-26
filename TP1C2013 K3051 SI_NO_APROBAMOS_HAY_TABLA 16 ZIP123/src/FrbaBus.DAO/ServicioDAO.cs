using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using GestionDeDatos.AccesoDatos;
using System.Data;
using System.Data.SqlClient;

namespace FrbaBus.DAO
{
    public class ServicioDAO : IEntidadDAO<Servicio>
    {
        #region Miembros de IEntidadDAO<Servicio>

        public GestionDeDatos.AccesoDatos.IAccesoBD accesoBD
        {
            get { return new AccesoBD(); }
        }

        public int Alta(Servicio entidad)
        {
            throw new NotImplementedException();
        }

        public void Baja(Servicio entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Servicio entidad)
        {
            throw new NotImplementedException();
        }

        public IList<Servicio> Listar()
        {
            DataTable dt = this.ObtenerRegistros().Tables[0];
            IList<Servicio> servicios = new List<Servicio>(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
            {
                servicios.Add(this.BuilderServicio(row));
            }

            return servicios;
        }

        public DataSet ObtenerRegistros()
        {
            return this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_listar_servicio");
        }

        private Servicio BuilderServicio(DataRow row)
        {
            Servicio s = new Servicio()
            {
                Id = Convert.ToInt32(row["id_servicio"].ToString()),
                TipoServicio = row["tipo_servicio"].ToString(),
                Adicional = Convert.ToDecimal(row["pocent_adic"].ToString())
            };
            return s;
        }

        #endregion
    }
}
