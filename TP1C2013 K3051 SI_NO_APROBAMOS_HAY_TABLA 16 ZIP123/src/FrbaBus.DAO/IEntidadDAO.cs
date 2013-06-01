using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDeDatos.AccesoDatos;
using System.Data;

namespace FrbaBus.DAO
{
    public interface IEntidadDAO<T>
    {
        IAccesoBD accesoBD { get; }

        void Alta(T entidad);
        void Baja(T entidad);
        void Modificacion(T entidad);
        IList<T> Listar();
        DataSet ObtenerRegistros();

    }
}
