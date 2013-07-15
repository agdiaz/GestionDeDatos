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

            DataRow row = accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_obtener_ciudad", parametros).Tables[0].Rows[0];
            return _builder.Build(row);

        }

        public int Alta(Cliente entidad)
        {
            string insert = string.Format("INSERT INTO [SI_NO_APROBAMOS_HAY_TABLA].Cliente (dni, nombre, apellido, direccion, telefono, mail, fecha_nacimiento, es_discapacitado, sexo) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')",
                entidad.DNI, entidad.Nombre, entidad.Apellido, entidad.Direccion, entidad.Telefono, entidad.Mail, entidad.FechaNacimiento.ToString(), entidad.EsDiscapacitado ? 1 : 0, entidad.Sexo);
            this.accesoBD.EjecutarComando(insert);
            return -1;
        }

        public void Baja(Cliente entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Cliente entidad)
        {
            throw new NotImplementedException();
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

        private DataSet ObtenerRegistros()
        {
            return this.accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_listar_cliente");
        }

        private DataSet ObtenerRegistrosFiltrados(string dni, string nombre, string apellido, string discapacitado, string sexo)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            
            if (!string.IsNullOrEmpty(nombre))
            {
                SqlParameter pNombre = new SqlParameter("@p_nombre", SqlDbType.NVarChar, 50, "p_nombre");
                parametros.Add(pNombre, nombre);
            }
            if (!string.IsNullOrEmpty(apellido))
            {
                SqlParameter pApellido = new SqlParameter("@p_apellido", SqlDbType.NVarChar, 50, "p_apellido");
                parametros.Add(pApellido, apellido);
            }
            if (!string.IsNullOrEmpty(dni))
            {
                SqlParameter pDni = new SqlParameter("@p_dni", SqlDbType.Variant, 18, "p_dni");
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

        #endregion
    }
}
