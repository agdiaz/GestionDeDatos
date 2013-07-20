using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using FrbaBus.DAO.Builder;
using GestionDeDatos.AccesoDatos;
using System.Data;
using System.Data.SqlClient;

namespace FrbaBus.DAO
{
    public class PasajeDAO : IEntidadDAO<Pasaje>
    {
        private IBuilder<Pasaje> _builder;
        private IAccesoBD _acceso;

        public PasajeDAO()
        {
            _builder = new PasajeBuilder();
            _acceso = new AccesoBD();
        }

        #region Miembros de IEntidadDAO<Pasaje>

        public GestionDeDatos.AccesoDatos.IAccesoBD accesoBD
        {
            get { return _acceso; }
        }

        public Pasaje Obtener(object id)
        {
            throw new NotImplementedException();
        }

        public int Alta(Pasaje entidad)
        {
            throw new NotImplementedException();
        }

        public void Baja(Pasaje entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Pasaje entidad)
        {
            throw new NotImplementedException();
        }

        public IList<Pasaje> Listar()
        {
            throw new NotImplementedException();
        }

        #endregion

        public decimal BuscarPrecio(Recorrido recorrido, decimal nroDni)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@dni", SqlDbType.Decimal, 18, "dni"), nroDni);
            parametros.Add(new SqlParameter("@id_recorrido", SqlDbType.Decimal, 18, "id_recorrido"), recorrido.Id);

            DataRow row = accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_precio_final_pasaje", parametros).Tables[0].Rows[0];

            return ((PasajeBuilder)_builder).BuildPrecio(row);
        }
    }
}
