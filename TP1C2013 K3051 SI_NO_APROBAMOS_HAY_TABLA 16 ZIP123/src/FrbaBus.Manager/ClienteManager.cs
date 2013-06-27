using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using FrbaBus.DAO;
using System.Data;

namespace FrbaBus.Manager
{
    public class ClienteManager
    {
        public void Alta(long dni, string nombre, string apellido, string direccion, string telefono, string mail, DateTime fechaNac, bool esDiscapacitado, string sexo)
        {
            Cliente cliente = new Cliente()
            {
                DNI = dni,
                Apellido = apellido,
                Nombre = nombre,
                Direccion = direccion,
                Telefono = telefono,
                FechaNacimiento = fechaNac,
                EsDiscapacitado = esDiscapacitado,
                Mail = mail,
                Sexo = sexo
            };

            new ClienteDAO().Alta(cliente);
        }

        public DataSet Listar()
        {
            return new ClienteDAO().ObtenerRegistros();
        }

        public DataSet ObtenerRegistrosCliente(string dni, string nombre, string apellido, string discapacitado, string sexo)
        {
            return new ClienteDAO().ObtenerRegistrosFiltrados(dni, nombre, apellido, discapacitado, sexo);
        }

    }
}
