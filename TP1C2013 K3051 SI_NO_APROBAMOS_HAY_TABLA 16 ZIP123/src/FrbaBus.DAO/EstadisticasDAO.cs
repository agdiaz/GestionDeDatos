using System;
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

        public IList<DestinoMasVendido> ListarDestinosMasVendidos(Semestre s)
        {
            IList<DestinoMasVendido> destinos = new List<DestinoMasVendido>();

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
        private DataSet ConsultarListado(string nombre, Semestre s)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@fecha_inicio", SqlDbType.DateTime, 8, "fecha_inicio"), s.Inicio);
            parametros.Add(new SqlParameter("@fecha_fin", SqlDbType.DateTime, 8, "fecha_fin"), s.Fin);

            return this.accesoBD.RealizarConsultaAlmacenada(nombre, parametros);
        }
        public DataSet DestinosMasVendidos(Semestre s)
        {
            return ConsultarListado("[SI_NO_APROBAMOS_HAY_TABLA].sp_top5_destino_mas_vendido_por_semestre", s);
        }

        #endregion

        #region DestinosConMasMicrosVacios
        public IList<DestinoConMasMicrosVacios> ListarDestinosConMasMicrosVacios(Semestre s)
        {
            IList<DestinoConMasMicrosVacios> destinos = new List<DestinoConMasMicrosVacios>();

            foreach (DataRow row in this.DestinosConMasMicrosVacios(s).Tables[0].Rows)
            {
                destinos.Add(this.BuildDestinoConMasMicrosVacios(row));
            }
            return destinos;
        }

        private DestinoConMasMicrosVacios BuildDestinoConMasMicrosVacios(DataRow row)
        {
            return new DestinoConMasMicrosVacios()
            {
                Nombre = row["nombre"].ToString(),
                Butacas_libres = Convert.ToInt32(row["butacas_libres_x_viaje"].ToString())
            };
        }

        public DataSet DestinosConMasMicrosVacios(Semestre s)
        {
            return ConsultarListado("[SI_NO_APROBAMOS_HAY_TABLA].sp_top5_destino_micros_mas_vacios_por_semestre", s);
        }


        #endregion
        
        #region ClientesConMasPuntos
        public IList<ClienteConMasPuntos> ListarClientesConMasPuntos(Semestre s)
        {
            IList<ClienteConMasPuntos> clientes = new List<ClienteConMasPuntos>();

            foreach (DataRow row in this.ClientesConMasPuntos(s).Tables[0].Rows)
            {
                clientes.Add(this.BuildClienteConMasPuntos(row));
            }
            return clientes;
        }

        private ClienteConMasPuntos BuildClienteConMasPuntos(DataRow row)
        {
            return new ClienteConMasPuntos()
            {
                Dni = Convert.ToInt32(row["dni"].ToString()),
                PuntosTotales = Convert.ToInt32(row["puntosTotales"].ToString())
            };
        }

        public DataSet ClientesConMasPuntos(Semestre s)
        {
            return ConsultarListado("[SI_NO_APROBAMOS_HAY_TABLA].sp_clientes_mas_puntos", s);
        }
        #endregion

        #region DestinosMasCancelados
        public IList<DestinoMasCancelado> ListarDestinosMasCancelados(Semestre s)
        {
            IList<DestinoMasCancelado> clientes = new List<DestinoMasCancelado>();

            foreach (DataRow row in this.DestinosMasCancelados(s).Tables[0].Rows)
            {
                clientes.Add(this.BuildDestinoMasCancelado(row));
            }
            return clientes;
        }

        private DestinoMasCancelado BuildDestinoMasCancelado(DataRow row)
        {
            return new DestinoMasCancelado()
            {
                Nombre = row["nombre"].ToString(),
                CantidadPasajesCancelados = Convert.ToInt32(row["pasajes_cancelados"].ToString())
            };
        }

        public DataSet DestinosMasCancelados(Semestre s)
        {
            return ConsultarListado("[SI_NO_APROBAMOS_HAY_TABLA].sp_top5_destinos_mas_cancelados_por_semestre", s);
        }
        #endregion
        
        #region MicrosConMasDiasFueraDeServicio
        public IList<MicroConMasDiasFueraDeServicio> ListarMicrosConMasDiasFueraDeServicio(Semestre s)
        {
            IList<MicroConMasDiasFueraDeServicio> clientes = new List<MicroConMasDiasFueraDeServicio>();

            foreach (DataRow row in this.MicrosConMasDiasFueraDeServicio(s).Tables[0].Rows)
            {
                clientes.Add(this.BuildMicroConMasDiasFueraDeServicio(row));
            }
            return clientes;
        }

        private MicroConMasDiasFueraDeServicio BuildMicroConMasDiasFueraDeServicio(DataRow row)
        {
            return new MicroConMasDiasFueraDeServicio()
            {
                Id = Convert.ToInt32(row["id_micro"].ToString()),
                Patente = row["patente"].ToString(),
                DiasFueraServicio = Convert.ToInt32(row["diastot"].ToString())
            };
        }

        public DataSet MicrosConMasDiasFueraDeServicio(Semestre s)
        {
            return ConsultarListado("[SI_NO_APROBAMOS_HAY_TABLA].sp_micros_mas_baja_serv", s);
        }
        #endregion
    }
}
