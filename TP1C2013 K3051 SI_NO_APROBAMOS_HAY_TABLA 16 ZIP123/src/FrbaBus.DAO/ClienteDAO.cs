using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using GestionDeDatos.AccesoDatos;

namespace FrbaBus.DAO
{
    public class ClienteDAO : IEntidadDAO<Cliente>
    {
        #region Miembros de IEntidadDAO<Cliente>

        public GestionDeDatos.AccesoDatos.IAccesoBD accesoBD
        {
            get { return new AccesoBD(); }
        }

        public void Alta(Cliente entidad)
        {
            string insert = string.Format("INSERT INTO [SI_NO_APROBAMOS_HAY_TABLA].Cliente (dni, nombre, apellido, direccion, telefono, mail, fecha_nacimiento, es_discapacitado, sexo) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')",
                entidad.DNI, entidad.Nombre, entidad.Apellido, entidad.Direccion, entidad.Telefono, entidad.Mail, entidad.FechaNacimiento.ToString(), entidad.EsDiscapacitado ? 1 : 0, entidad.Sexo);
            this.accesoBD.EjecutarComando(insert);
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

        public System.Data.DataSet ObtenerRegistros()
        {
            string query = "SELECT [dni],[nombre],[apellido],[direccion],[telefono],[mail],[fecha_nacimiento],[es_discapacitado],[sexo] FROM [GD1C2013].[SI_NO_APROBAMOS_HAY_TABLA].[Cliente]";
            return this.accesoBD.RealizarConsulta(query);
        }

        #endregion
    }
}
