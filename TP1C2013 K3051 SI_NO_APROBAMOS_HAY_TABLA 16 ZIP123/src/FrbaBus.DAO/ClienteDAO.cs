using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using GestionDeDatos.AccesoDatos;
using System.Data;
using System.Data.SqlClient;
using FrbaBus.DAO.Builder;

namespace FrbaBus.DAO
{
    public class ClienteDAO : IEntidadDAO<Cliente>
    {
        public IBuilder<Cliente> _builder;
        public ClienteDAO()
        {
            this._builder = new ClienteBuilder();
        }

        #region Miembros de IEntidadDAO<Cliente>

        public GestionDeDatos.AccesoDatos.IAccesoBD accesoBD
        {
            get { return new AccesoBD(); }
        }
        
        public Cliente Obtener(object id)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_dni", SqlDbType.Decimal, 18, "p_dni"), id);

            DataRow row = accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_obtener_cliente", parametros).Tables[0].Rows[0];
            return _builder.Build(row);

        }

        public int Alta(Cliente entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter p0 = new SqlParameter("@p_nombre", SqlDbType.NVarChar, 255, "p_nombre");
            parametros.Add(p0, entidad.Nombre);

            SqlParameter p1 = new SqlParameter("@p_dni", SqlDbType.Decimal, 18, "p_dni");
            parametros.Add(p1, entidad.NroDni);

            SqlParameter p2 = new SqlParameter("@p_apellido", SqlDbType.NVarChar, 255, "p_apellido");
            parametros.Add(p2, entidad.Apellido);

            SqlParameter p3 = new SqlParameter("@p_direccion", SqlDbType.NVarChar, 255, "p_direccion");
            parametros.Add(p3, entidad.Direccion);

            SqlParameter p4 = new SqlParameter("@p_telefono", SqlDbType.Decimal, 18, "p_telefono");
            parametros.Add(p4, entidad.Telefono);

            SqlParameter p5 = new SqlParameter("@p_mail", SqlDbType.NVarChar, 255, "p_mail");
            parametros.Add(p5, entidad.Mail);

            SqlParameter p6 = new SqlParameter("@p_fecha_nacimiento", SqlDbType.DateTime, 8, "p_fecha_nacimiento");
            parametros.Add(p6, entidad.FechaNacimiento);

            SqlParameter p7 = new SqlParameter("@p_es_discapacitado", SqlDbType.Char, 1, "p_es_discapacitado");
            parametros.Add(p7, entidad.EsDiscapacitado ? 'S' : 'N');

            SqlParameter p8 = new SqlParameter("@p_sexo", SqlDbType.VarChar, 50, "p_sexo");
            parametros.Add(p8, entidad.Sexo);

            this.accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_insert_cliente", parametros);
            
            return 0;
        }

        public void Baja(Cliente entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_dni", SqlDbType.Decimal, 18, "p_dni"), entidad.NroDni);

            accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_delete_cliente", parametros);
        }

        public void Modificacion(Cliente entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            SqlParameter p0 = new SqlParameter("@p_nombre", SqlDbType.NVarChar, 255, "p_nombre");
            parametros.Add(p0, entidad.Nombre);

            SqlParameter p1 = new SqlParameter("@p_dni", SqlDbType.Decimal, 18, "p_dni");
            parametros.Add(p1, entidad.NroDni);

            SqlParameter p2 = new SqlParameter("@p_apellido", SqlDbType.NVarChar, 255, "p_apellido");
            parametros.Add(p2, entidad.Apellido);

            SqlParameter p3 = new SqlParameter("@p_direccion", SqlDbType.NVarChar, 255, "p_direccion");
            parametros.Add(p3, entidad.Direccion);

            SqlParameter p4 = new SqlParameter("@p_telefono", SqlDbType.Decimal, 18, "p_telefono");
            parametros.Add(p4, entidad.Telefono);

            SqlParameter p5 = new SqlParameter("@p_mail", SqlDbType.NVarChar, 255, "p_mail");
            parametros.Add(p5, entidad.Mail);

            SqlParameter p6 = new SqlParameter("@p_fecha_nacimiento", SqlDbType.DateTime, 8, "p_fecha_nacimiento");
            parametros.Add(p6, entidad.FechaNacimiento);

            SqlParameter p7 = new SqlParameter("@p_es_discapacitado", SqlDbType.Char, 1, "p_es_discapacitado");
            parametros.Add(p7, entidad.EsDiscapacitado ? 'S' : 'N');

            SqlParameter p8 = new SqlParameter("@p_sexo", SqlDbType.VarChar, 50, "p_sexo");
            parametros.Add(p8, entidad.Sexo);

            this.accesoBD.EjecutarComando("[SI_NO_APROBAMOS_HAY_TABLA].sp_update_cliente", parametros);
            
        }

        public IList<Cliente> Listar()
        {
            IList<Cliente> clientes = new List<Cliente>();
            foreach (DataRow row in this.ObtenerRegistros().Tables[0].Rows)
            {
                clientes.Add(this._builder.Build(row));
            }
            return clientes;
        }

        public IList<Cliente> ListarFiltrados(string dni, string nombre, string apellido, string discapacitado, string sexo)
        {
            IList<Cliente> clientes = new List<Cliente>();
            DataSet registros = this.ObtenerRegistrosFiltrados(dni, nombre, apellido, discapacitado, sexo);
            
            foreach (DataRow row in registros.Tables[0].Rows)
            {
                clientes.Add(this._builder.Build(row));
            }
            
            return clientes;
        
        }

        #endregion

        private DataSet ObtenerRegistros()
        {
            return this.accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_listar_cliente");
        }

        private DataSet ObtenerRegistrosFiltrados(string dni, string nombre, string apellido, string discapacitado, string sexo)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            if (!string.IsNullOrEmpty(nombre))
            {
                SqlParameter pNombre = new SqlParameter("@p_nombre", SqlDbType.NVarChar, 255, "p_nombre");
                parametros.Add(pNombre, nombre);
            }
            if (!string.IsNullOrEmpty(apellido))
            {
                SqlParameter pApellido = new SqlParameter("@p_apellido", SqlDbType.NVarChar, 255, "p_apellido");
                parametros.Add(pApellido, apellido);
            }
            if (!string.IsNullOrEmpty(dni))
            {
                SqlParameter pDni = new SqlParameter("@p_dni", SqlDbType.Decimal, 18, "p_dni");
                parametros.Add(pDni, Convert.ToDecimal(dni));
            }
            if (!string.IsNullOrEmpty(discapacitado))
            {
                SqlParameter pDiscapacitado = new SqlParameter("@p_discapacitado", SqlDbType.Char, 1, "p_discapacitado");
                parametros.Add(pDiscapacitado, discapacitado[0]);
            }
            if (!string.IsNullOrEmpty(sexo))
            {
                SqlParameter pSexo = new SqlParameter("@p_sexo", SqlDbType.VarChar, 50, "p_sexo");
                parametros.Add(pSexo, sexo);
            }

            return this.accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_listar_filtrado_cliente", parametros);
        }
    }
}
