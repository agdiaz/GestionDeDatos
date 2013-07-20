﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;
using GestionDeDatos.AccesoDatos;
using System.Data;
using System.Data.SqlClient;
using FrbaBus.DAO.Builder;

namespace FrbaBus.DAO
{
    public class ServicioDAO : IEntidadDAO<Servicio>
    {
        private IBuilder<Servicio> _builder;
        public IAccesoBD _accesoBD;

        public ServicioDAO()
        {
            this._accesoBD = new AccesoBD();
            this._builder = new ServicioBuilder();
        }
        
        #region Miembros de IEntidadDAO<Servicio>
        public IAccesoBD accesoBD
        {
            get { return _accesoBD; }
        }
        public Servicio Obtener(object id)
        {
            Dictionary<SqlParameter, object> parametros = new Dictionary<SqlParameter, object>();
            parametros.Add(new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id"), id);

            DataSet ds = this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_obtener_servicio", parametros);
            DataRow row = ds.Tables[0].Rows[0];
            return this._builder.Build(row);
        }

        public int Alta(Servicio entidad)
        {
            throw new NotImplementedException();
        }

        public void Baja(Servicio entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(Servicio entidad)
        {
            throw new NotImplementedException();
        }

        public IList<Servicio> Listar()
        {
            DataTable dt = this.ObtenerRegistros().Tables[0];
            IList<Servicio> servicios = new List<Servicio>(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
            {
                servicios.Add(this._builder.Build(row));
            }

            return servicios;
        }

        #endregion
        
        private DataSet ObtenerRegistros()
        {
            return this.accesoBD.RealizarConsultaAlmacenada("SI_NO_APROBAMOS_HAY_TABLA.sp_listar_servicio");
        }
    }
}
