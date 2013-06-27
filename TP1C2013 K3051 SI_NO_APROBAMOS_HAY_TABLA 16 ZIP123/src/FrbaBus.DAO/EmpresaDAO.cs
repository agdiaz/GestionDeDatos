using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GestionDeDatos.AccesoDatos;
using FrbaBus.Common.Entidades;
using System.Data.SqlClient;

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

        public DataSet ObtenerRegistrosMicro(string kgsEncomiendas, string numeroPatente, string numeroMicro, string tipoEmpresa, string tipoModelo, string tipoServicio)
        {
            var parametros = new Dictionary<System.Data.SqlClient.SqlParameter, object>();
            if (!string.IsNullOrEmpty(kgsEncomiendas))
            {
                parametros.Add(new SqlParameter("@p_kgm_Encomiendas", SqlDbType.Decimal, 4, "p_kgm_encomiendas"), kgsEncomiendas);
            }
            if (!string.IsNullOrEmpty(numeroPatente))
            {
                parametros.Add(new SqlParameter("@p_kgm_Encomiendas", SqlDbType.Decimal, 4, "p_kgm_encomiendas"), kgsEncomiendas);
            }
            if (!string.IsNullOrEmpty(numeroMicro))
            {
                parametros.Add(new SqlParameter("@p_kgm_Encomiendas", SqlDbType.Decimal, 4, "p_kgm_encomiendas"), kgsEncomiendas);
            }
            if (!string.IsNullOrEmpty(tipoEmpresa))
            {
                parametros.Add(new SqlParameter("@p_kgm_Encomiendas", SqlDbType.Decimal, 4, "p_kgm_encomiendas"), kgsEncomiendas);
            }
            if (!string.IsNullOrEmpty(tipoModelo))
            {
                parametros.Add(new SqlParameter("@p_kgm_Encomiendas", SqlDbType.Decimal, 4, "p_kgm_encomiendas"), kgsEncomiendas);
            }
            if (!string.IsNullOrEmpty(tipoServicio))
            {
                parametros.Add(new SqlParameter("@p_kgm_Encomiendas", SqlDbType.Decimal, 4, "p_kgm_encomiendas"), kgsEncomiendas);
            }
            return new AccesoBD().RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_listar_filtrado_micro", parametros);
        }
    }
}
