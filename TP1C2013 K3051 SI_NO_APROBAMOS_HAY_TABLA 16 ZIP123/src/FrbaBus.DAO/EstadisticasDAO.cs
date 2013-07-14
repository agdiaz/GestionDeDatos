﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDeDatos.AccesoDatos;
using System.Data;
using FrbaBus.Common.Entidades.Estadisticas;
using System.Data.SqlClient;

namespace FrbaBus.DAO
{
    public class EstadisticasDAO
    {
        private IAccesoBD accesoBD = new AccesoBD();
        
        #region DestinosMasVendidos

        public IList<IListadoEstadistico> ListarDestinosMasVendidos(Semestre s)
        {
            IList<IListadoEstadistico> destinos = new List<IListadoEstadistico>();

            foreach (DataRow row in this.DestinosMasVendidos(s).Tables[0].Rows)
            {
                destinos.Add(this.BuildDestinoMasVendido(row));
            }
            return destinos;
        }

        private DestinoMasVendido BuildDestinoMasVendido(DataRow row)
        {
            return new DestinoMasVendido()
            {
                Nombre = row["nombre"].ToString(),
                Butacas = Convert.ToInt32(row["butacas_vendidas"].ToString())
            };
        }

        public DataSet DestinosMasVendidos(Semestre s)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@fecha_inicio", SqlDbType.DateTime, 8, "fecha_inicio"), s.Inicio);
            parametros.Add(new SqlParameter("@fecha_fin", SqlDbType.DateTime, 8, "fecha_fin"), s.Fin);

            string consulta = "[SI_NO_APROBAMOS_HAY_TABLA].sp_top5_destino_mas_vendido_por_semestre";
            return this.accesoBD.RealizarConsultaAlmacenada(consulta, parametros);
        }

        #endregion

        #region DestinosConMasMicrosVacios
        public IList<IListadoEstadistico> ListarDestinosConMasMicrosVacios()
        {
            IList<IListadoEstadistico> destinos = new List<IListadoEstadistico>();

            foreach (DataRow row in this.DestinosConMasMicrosVacios().Tables[0].Rows)
            {
                destinos.Add(this.BuildDestinoConMasMicrosVacios(row));
            }
            return destinos;
        }

        private DestinoConMasMicrosVacios BuildDestinoConMasMicrosVacios(DataRow row)
        {
            throw new NotImplementedException();
        }

        public DataSet DestinosConMasMicrosVacios()
        {
            string consulta = "SELECT * FROM [SI_NO_APROBAMOS_HAY_TABLA].[v_DestinosConMasMicrosVacios]";
            return this.accesoBD.RealizarConsulta(consulta);
        }


        #endregion
        
        #region ClientesConMasPuntos
        public IList<IListadoEstadistico> ListarClientesConMasPuntos()
        {
            IList<IListadoEstadistico> clientes = new List<IListadoEstadistico>();

            foreach (DataRow row in this.ClientesConMasPuntos().Tables[0].Rows)
            {
                clientes.Add(this.BuildClienteConMasPuntos(row));
            }
            return clientes;
        }

        private ClienteConMasPuntos BuildClienteConMasPuntos(DataRow row)
        {
            throw new NotImplementedException();
        }

        public DataSet ClientesConMasPuntos()
        {
            string consulta = "SELECT * FROM [SI_NO_APROBAMOS_HAY_TABLA].[v_ClientesConMasPuntos]";
            return this.accesoBD.RealizarConsulta(consulta);
        }
        #endregion

        #region DestinosMasCancelados
        public IList<IListadoEstadistico> ListarDestinosMasCancelados()
        {
            IList<IListadoEstadistico> clientes = new List<IListadoEstadistico>();

            foreach (DataRow row in this.DestinosMasCancelados().Tables[0].Rows)
            {
                clientes.Add(this.BuildDestinoMasCancelado(row));
            }
            return clientes;
        }

        private DestinoMasCancelado BuildDestinoMasCancelado(DataRow row)
        {
            throw new NotImplementedException();
        }

        public DataSet DestinosMasCancelados()
        {
            string consulta = "SELECT * FROM [SI_NO_APROBAMOS_HAY_TABLA].[v_DestinosMasCancelados]";
            return this.accesoBD.RealizarConsulta(consulta);
        }
        #endregion
        
        #region MicrosConMasDiasFueraDeServicio
        public IList<IListadoEstadistico> ListarMicrosConMasDiasFueraDeServicio()
        {
            IList<IListadoEstadistico> clientes = new List<IListadoEstadistico>();

            foreach (DataRow row in this.MicrosConMasDiasFueraDeServicio().Tables[0].Rows)
            {
                clientes.Add(this.BuildMicroConMasDiasFueraDeServicio(row));
            }
            return clientes;
        }

        private MicroConMasDiasFueraDeServicio BuildMicroConMasDiasFueraDeServicio(DataRow row)
        {
            throw new NotImplementedException();
        }

        public DataSet MicrosConMasDiasFueraDeServicio()
        {
            string consulta = "SELECT * FROM [SI_NO_APROBAMOS_HAY_TABLA].[v_MicrosConMasDiasFueraDeServicio]";
            return this.accesoBD.RealizarConsulta(consulta);
        }
        #endregion
    }
}
