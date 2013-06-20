using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDeDatos.AccesoDatos;
using System.Data;

namespace FrbaBus.DAO
{
    public class EstadisticasDAO
    {
        private IAccesoBD accesoBD = new AccesoBD();

        public DataSet DestinosMasVendidos()
        {
            string consulta = "SELECT * FROM [SI_NO_APROBAMOS_HAY_TABLA].[v_DestinosMasVendidos]";
            return this.accesoBD.RealizarConsulta(consulta);
        }

        public DataSet DestinosConMasMicrosVacios()
        {
            string consulta = "SELECT * FROM [SI_NO_APROBAMOS_HAY_TABLA].[v_DestinosConMasMicrosVacios]";
            return this.accesoBD.RealizarConsulta(consulta);
        }

        public DataSet ClientesConMasPuntos()
        {
            string consulta = "SELECT * FROM [SI_NO_APROBAMOS_HAY_TABLA].[v_ClientesConMasPuntos]";
            return this.accesoBD.RealizarConsulta(consulta);
        }

        public DataSet DestinosMasCancelados()
        {
            string consulta = "SELECT * FROM [SI_NO_APROBAMOS_HAY_TABLA].[v_DestinosMasCancelados]";
            return this.accesoBD.RealizarConsulta(consulta);
        }

        public DataSet MicrosConMasDiasFueraDeServicio()
        {
            string consulta = "SELECT * FROM [SI_NO_APROBAMOS_HAY_TABLA].[v_MicrosConMasDiasFueraDeServicio]";
            return this.accesoBD.RealizarConsulta(consulta);
        }

    }
}
