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
        public IList<DestinoMasVendido> DestinosMasVendidos(Semestre semestre)
        {
            return this._dao.ListarDestinosMasVendidos(semestre);
        }

        public IList<DestinoConMasMicrosVacios> DestinosConMasMicrosVacios(Semestre semestre)
        {
            return this._dao.ListarDestinosConMasMicrosVacios(semestre);
        }

        public IList<ClienteConMasPuntos> ClientesConMasPuntos(Semestre semestre)
        {
            return this._dao.ListarClientesConMasPuntos(semestre);
        }

        public IList<DestinoMasCancelado> DestinosMasCancelados(Semestre semestre)
        {
            return this._dao.ListarDestinosMasCancelados(semestre);
        }

        public IList<MicroConMasDiasFueraDeServicio> MicrosConMasDiasFueraDeServicio(Semestre semestre)
        {
            return this._dao.ListarMicrosConMasDiasFueraDeServicio(semestre);
        }
    }
}
