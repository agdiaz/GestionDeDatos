using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GestionDeDatos.AccesoDatos;
using FrbaBus.Common.Entidades;

namespace FrbaBus.DAO
{
    public class EmpresaDAO
    {
        public DataSet ObtenerEmpresasDisponibles()
        {
            return new AccesoBD().RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_listar_marca");
        }

        public IList<Empresa> Listar()
        {
            DataTable dt = ObtenerEmpresasDisponibles().Tables[0];
            IList<Empresa> empresas = new List<Empresa>(dt.Rows.Count);

            foreach (DataRow row in dt.Rows)
            {
                empresas.Add(this.BuilderEmpresa(row));
            }
            return empresas;
        }

        private Empresa BuilderEmpresa(DataRow row)
        {
            return new Empresa()
            {
                Id = Convert.ToInt32(row["id_marca"].ToString()),
                Descripcion = row["nombre"].ToString()
            };
        }
    }
}
