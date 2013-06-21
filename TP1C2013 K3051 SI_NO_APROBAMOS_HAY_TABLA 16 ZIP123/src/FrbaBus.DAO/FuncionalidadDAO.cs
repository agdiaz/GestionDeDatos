using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using System.Data;
using System.Data.SqlClient;
using GestionDeDatos.AccesoDatos;

namespace FrbaBus.DAO
{
    public class FuncionalidadDAO : IEntidadDAO<Funcionalidad>
    {
        #region Miembros de IEntidadDAO<Funcionalidad>

        public GestionDeDatos.AccesoDatos.IAccesoBD accesoBD
        {
            get { return new AccesoBD(); }
        }

        public int Alta(Funcionalidad entidad)
        {
            throw new NotImplementedException();
        }

        public void Baja(Funcionalidad entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Funcionalidad entidad)
        {
            throw new NotImplementedException();
        }

        public IList<Funcionalidad> Listar()
        {
            IList<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            foreach (DataRow item in this.ObtenerRegistros().Tables[0].Rows)
            {
                funcionalidades.Add(this.BuildFuncionalidad(item));
            }
            return funcionalidades;
        }

        private Funcionalidad BuildFuncionalidad(DataRow item)
        {
            return new Funcionalidad()
            {
                Id = Convert.ToInt32(item["id_funcionalidad"].ToString()),
                Activa = true,
                Nombre = item["funcionalidad"].ToString()
            };
        }

        public DataSet ObtenerRegistros()
        {
            return this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_listar_funcionalidad", new Dictionary<SqlParameter, object>());
        }

        public object AltaRolFuncionalidad(RolUsuario rol, int idFuncionalidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            SqlParameter pIdRol = new SqlParameter("@p_id_rol", SqlDbType.Int, 4, "p_id_rol");
            parametros.Add(pIdRol, rol.IdRol);

            SqlParameter pIdFuncionalidad = new SqlParameter("@p_id_funcionalidad", SqlDbType.Int, 4, "p_id_funcionalidad");
            parametros.Add(pIdFuncionalidad, idFuncionalidad);

            return this.accesoBD.EjecutarComando("sp_insert_rol_funcionalidad", parametros);
        }

        #endregion
    }
}
