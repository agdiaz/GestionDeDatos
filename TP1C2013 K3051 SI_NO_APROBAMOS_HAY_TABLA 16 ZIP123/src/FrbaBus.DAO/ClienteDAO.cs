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
    public class ClienteDAO : IEntidadDAO<Cliente>
    {
        #region Miembros de IEntidadDAO<Cliente>

        public GestionDeDatos.AccesoDatos.IAccesoBD accesoBD
        {
            get { return new AccesoBD(); }
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
            throw new NotImplementedException();
        }

        public DataSet ObtenerRegistros()
        {
            return this.accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_listar_cliente");
        }

        #endregion

        public DataSet ObtenerRegistrosFiltrados(string dni, string nombre, string apellido, string discapacitado, string sexo)
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
    }
}
