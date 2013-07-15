using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using FrbaBus.DAO.Builder;
using System.Data.SqlClient;
using System.Data;
using GestionDeDatos.AccesoDatos;

namespace FrbaBus.DAO
{
    public class UsuarioDAO : IEntidadDAO<Usuario>
    {
        private IBuilder<Usuario> _builder;
        public UsuarioDAO()
        {
            this._builder = new UsuarioBuilder();
        }

        public int RealizarIdentificacion(string username, byte[] hash)
        {
            int resultado = -3;
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            parametros.Add(new SqlParameter("@userName", SqlDbType.VarChar, 50, "userName"), username);
            parametros.Add(new SqlParameter("@passwordHash", SqlDbType.VarBinary, 32, "passwordHash"), hash);

            var parametroResultado = new SqlParameter("@resultado", SqlDbType.Int, 4, "resultado");
            parametroResultado.Direction = ParameterDirection.Output;
            parametros.Add(parametroResultado, 0);

            accesoBD.EjecutarComando("[GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[realizar_identificacion]", parametros);

            resultado = (int)parametroResultado.Value;
            return resultado;
        }

        #region Miembros de IEntidadDAO<Usuario>

        public IAccesoBD accesoBD
        {
            get { return new AccesoBD() ; }
        }

        public Usuario Obtener(object id)
        {
            throw new NotImplementedException();
        }

        public int Alta(Usuario entidad)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();

            parametros.Add(new SqlParameter("@userName", SqlDbType.VarChar, 50, "userName"), entidad.Username);
            parametros.Add(new SqlParameter("@passwordHash", SqlDbType.VarBinary, 32, "passwordHash"), entidad.HashPassword);

            return this.accesoBD.EjecutarComando("SI_NO_APROBAMOS_HAY_TABLA.insertar_usuario_admin", parametros);
        }

        public void Baja(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public IList<Usuario> Listar()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
