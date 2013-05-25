using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDeDatos.AccesoDatos;

namespace FrbaBus.DAO
{
    public interface IEntidadDAO<T>
    {
        IAccesoBD accesoBD { get; set; }

        void Alta(T entidad);
        void Baja(T entidad);
        void Modificacion(T entidad);
        IList<T> Listar();

    }
}
