using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common.Entidades;

namespace FrbaBus.DAO.Builder
{
    public class CompraBuilder :IBuilder<Compra>
    {
        #region Miembros de IBuilder<Compra>

        public Compra Build(System.Data.DataRow row)
        {
            Compra c = new Compra();

            c.IdCompra = Convert.ToInt32(row["id_compra"].ToString());
            c.IdUsuario = Convert.ToInt32(row["id_usuario"].ToString());
            c.IdCancelacion = Convert.ToInt32(row["id_cancelacion"].ToString());
            c.FechaCompra = Convert.ToDateTime(row["fecha_compra"].ToString());
            
            c.CancelacionCompra = new Cancelacion();
            DateTime aux;
            DateTime.TryParse(row["fecha_cancel"].ToString(), out aux);

            if (aux != null)
            {
                c.CancelacionCompra.FechaCancelacion = aux;
            }
            c.CancelacionCompra.IdCancelacion = c.IdCancelacion;
            c.CancelacionCompra.Motivo = row["motivo_cancel"].ToString();
            
            return c;
        }

        #endregion
    }
}
