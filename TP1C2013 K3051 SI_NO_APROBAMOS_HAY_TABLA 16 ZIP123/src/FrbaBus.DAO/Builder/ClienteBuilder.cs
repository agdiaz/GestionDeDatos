using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using System.Data;

namespace FrbaBus.DAO.Builder
{
    public class ClienteBuilder : IBuilder<Cliente>
    {
        #region Miembros de IBuilder<ClienteBuilder>

        public Cliente Build(DataRow row)
        {
            Cliente c = new Cliente();

            c.NroDni = Convert.ToInt32(row["dni"].ToString());
            c.Nombre = row["nombre"].ToString();
            c.Apellido = row["apellido"].ToString();
            c.Direccion = row["direccion"].ToString();
            c.Telefono = row["telefono"].ToString();
            c.Mail = row["mail"].ToString();
            c.FechaNacimiento = Convert.ToDateTime(row["fecha_nacimiento"].ToString());
            c.EsDiscapacitado = (string.IsNullOrEmpty(row["es_discapacitado"].ToString()) || row["es_discapacitado"].ToString() == "N") ? false : true;
            c.Sexo = row["sexo"].ToString();

            return c;
        }

        #endregion
    }
}
