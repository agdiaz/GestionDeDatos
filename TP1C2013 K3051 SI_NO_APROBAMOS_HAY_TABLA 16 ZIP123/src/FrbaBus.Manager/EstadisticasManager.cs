using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaBus.Common.Entidades;
using FrbaBus.Common.Entidades.Estadisticas;
using FrbaBus.DAO;

namespace FrbaBus.Manager
{
    public class EstadisticasManager
    {
        private EstadisticasDAO _dao;
        
        public EstadisticasManager()
        {
            this._dao = new EstadisticasDAO();
        }
        public IList<IListadoEstadistico> DestinosMasVendidos(Semestre semestre)
        {
            return this._dao.ListarDestinosMasVendidos();
        }

        public IList<IListadoEstadistico> DestinosConMasMicrosVacios(Semestre semestre)
        {
            return this._dao.ListarDestinosConMasMicrosVacios();
        }

        public IList<IListadoEstadistico> ClientesConMasPuntos(Semestre semestre)
        {
            return this._dao.ListarClientesConMasPuntos();
        }

        public IList<IListadoEstadistico> DestinosMasCancelados(Semestre semestre)
        {
            return this._dao.ListarDestinosMasCancelados();
        }

        public IList<IListadoEstadistico> MicrosConMasDiasFueraDeServicio(Semestre semestre)
        {
            return this._dao.ListarMicrosConMasDiasFueraDeServicio();
        }
    }
}
