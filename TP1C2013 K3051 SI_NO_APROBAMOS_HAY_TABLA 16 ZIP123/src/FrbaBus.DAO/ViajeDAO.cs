﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using GestionDeDatos.AccesoDatos;
using System.Data.SqlClient;
using System.Data;
using FrbaBus.DAO.Builder;

namespace FrbaBus.DAO
{
    public class ViajeDAO : IEntidadDAO<Viaje>
    {
        private IBuilder<Viaje> _builder;
        private IAccesoBD _accesoBD;
        public ViajeDAO()
        {
            this._builder = new ViajeBuilder();
            this._accesoBD = new AccesoBD();
        }
        #region Miembros de IEntidadDAO<Viaje>

        public IAccesoBD accesoBD
        {
            get { return _accesoBD; }
        }

        public Viaje Obtener(object id)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id"), id);

            DataRow row = accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_obtener_viaje", parametros).Tables[0].Rows[0];
            return _builder.Build(row);
        }

        public int Alta(Viaje entidad)
        {
            throw new NotImplementedException();
        }

        public void Baja(Viaje entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Viaje entidad)
        {
            throw new NotImplementedException();
        }

        public IList<Viaje> Listar()
        {
            List<Viaje> viajes = new List<Viaje>();

            foreach (DataRow row in this.ObtenerRegistros().Tables[0].Rows)
            {
                viajes.Add(this._builder.Build(row));
            }

            return viajes;
        }

        #endregion


        private DataSet ObtenerRegistros()
        {
            return accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_listar_viajes");
        }
        private DataSet ObtenerRegistros(Recorrido rec)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id"), rec.Id);

            return accesoBD.RealizarConsultaAlmacenada("[SI_NO_APROBAMOS_HAY_TABLA].sp_listar_viajes_recorrido", parametros);
        }
        public IList<Viaje> ListarPorRecorrido(Recorrido rec)
        {
            List<Viaje> viajes = new List<Viaje>();

            foreach (DataRow row in this.ObtenerRegistros().Tables[0].Rows)
            {
                viajes.Add(this._builder.Build(row));
            }

            return viajes;
        }
    }
}
