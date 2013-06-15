namespace FrbaBus.Abm_Viaje
{
    partial class ViajeListado
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblViajeListadoFechaSalida = new System.Windows.Forms.Label();
            this.lblViajeListadoFechaLLegada = new System.Windows.Forms.Label();
            this.dtpViajeListadoFechaSalida = new System.Windows.Forms.DateTimePicker();
            this.dtpViajeListadoFechaLlegada = new System.Windows.Forms.DateTimePicker();
            this.lblViajeListadoFechaLlegadaEstimada = new System.Windows.Forms.Label();
            this.dtpViajeListadoFechaLlegadaEstimada = new System.Windows.Forms.DateTimePicker();
            this.lblViajeListadoMicro = new System.Windows.Forms.Label();
            this.lblViajeListadoRecorrido = new System.Windows.Forms.Label();
            this.tbViajeListadoMicro = new System.Windows.Forms.TextBox();
            this.tbViajeListadoRecorrido = new System.Windows.Forms.TextBox();
            this.dgvViajeListado = new System.Windows.Forms.DataGridView();
            this.btnViajeListadoLimpiar = new System.Windows.Forms.Button();
            this.btnViajeListadoBuscar = new System.Windows.Forms.Button();
            this.btnViajeListadoDarBaja = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViajeListado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbViajeListadoRecorrido);
            this.groupBox1.Controls.Add(this.tbViajeListadoMicro);
            this.groupBox1.Controls.Add(this.lblViajeListadoRecorrido);
            this.groupBox1.Controls.Add(this.lblViajeListadoMicro);
            this.groupBox1.Controls.Add(this.dtpViajeListadoFechaLlegadaEstimada);
            this.groupBox1.Controls.Add(this.lblViajeListadoFechaLlegadaEstimada);
            this.groupBox1.Controls.Add(this.dtpViajeListadoFechaLlegada);
            this.groupBox1.Controls.Add(this.dtpViajeListadoFechaSalida);
            this.groupBox1.Controls.Add(this.lblViajeListadoFechaLLegada);
            this.groupBox1.Controls.Add(this.lblViajeListadoFechaSalida);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de busqueda";
            // 
            // lblViajeListadoFechaSalida
            // 
            this.lblViajeListadoFechaSalida.AutoSize = true;
            this.lblViajeListadoFechaSalida.Location = new System.Drawing.Point(6, 25);
            this.lblViajeListadoFechaSalida.Name = "lblViajeListadoFechaSalida";
            this.lblViajeListadoFechaSalida.Size = new System.Drawing.Size(67, 13);
            this.lblViajeListadoFechaSalida.TabIndex = 0;
            this.lblViajeListadoFechaSalida.Text = "Fecha salida";
            // 
            // lblViajeListadoFechaLLegada
            // 
            this.lblViajeListadoFechaLLegada.AutoSize = true;
            this.lblViajeListadoFechaLLegada.Location = new System.Drawing.Point(6, 51);
            this.lblViajeListadoFechaLLegada.Name = "lblViajeListadoFechaLLegada";
            this.lblViajeListadoFechaLLegada.Size = new System.Drawing.Size(74, 13);
            this.lblViajeListadoFechaLLegada.TabIndex = 1;
            this.lblViajeListadoFechaLLegada.Text = "Fecha llegada";
            // 
            // dtpViajeListadoFechaSalida
            // 
            this.dtpViajeListadoFechaSalida.Location = new System.Drawing.Point(129, 19);
            this.dtpViajeListadoFechaSalida.Name = "dtpViajeListadoFechaSalida";
            this.dtpViajeListadoFechaSalida.Size = new System.Drawing.Size(200, 20);
            this.dtpViajeListadoFechaSalida.TabIndex = 2;
            this.dtpViajeListadoFechaSalida.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dtpViajeListadoFechaLlegada
            // 
            this.dtpViajeListadoFechaLlegada.Location = new System.Drawing.Point(129, 45);
            this.dtpViajeListadoFechaLlegada.Name = "dtpViajeListadoFechaLlegada";
            this.dtpViajeListadoFechaLlegada.Size = new System.Drawing.Size(200, 20);
            this.dtpViajeListadoFechaLlegada.TabIndex = 3;
            // 
            // lblViajeListadoFechaLlegadaEstimada
            // 
            this.lblViajeListadoFechaLlegadaEstimada.AutoSize = true;
            this.lblViajeListadoFechaLlegadaEstimada.Location = new System.Drawing.Point(6, 75);
            this.lblViajeListadoFechaLlegadaEstimada.Name = "lblViajeListadoFechaLlegadaEstimada";
            this.lblViajeListadoFechaLlegadaEstimada.Size = new System.Drawing.Size(119, 13);
            this.lblViajeListadoFechaLlegadaEstimada.TabIndex = 4;
            this.lblViajeListadoFechaLlegadaEstimada.Text = "Fecha llegada estimada";
            // 
            // dtpViajeListadoFechaLlegadaEstimada
            // 
            this.dtpViajeListadoFechaLlegadaEstimada.Location = new System.Drawing.Point(129, 69);
            this.dtpViajeListadoFechaLlegadaEstimada.Name = "dtpViajeListadoFechaLlegadaEstimada";
            this.dtpViajeListadoFechaLlegadaEstimada.Size = new System.Drawing.Size(200, 20);
            this.dtpViajeListadoFechaLlegadaEstimada.TabIndex = 5;
            // 
            // lblViajeListadoMicro
            // 
            this.lblViajeListadoMicro.AutoSize = true;
            this.lblViajeListadoMicro.Location = new System.Drawing.Point(375, 25);
            this.lblViajeListadoMicro.Name = "lblViajeListadoMicro";
            this.lblViajeListadoMicro.Size = new System.Drawing.Size(33, 13);
            this.lblViajeListadoMicro.TabIndex = 6;
            this.lblViajeListadoMicro.Text = "Micro";
            // 
            // lblViajeListadoRecorrido
            // 
            this.lblViajeListadoRecorrido.AutoSize = true;
            this.lblViajeListadoRecorrido.Location = new System.Drawing.Point(375, 51);
            this.lblViajeListadoRecorrido.Name = "lblViajeListadoRecorrido";
            this.lblViajeListadoRecorrido.Size = new System.Drawing.Size(53, 13);
            this.lblViajeListadoRecorrido.TabIndex = 7;
            this.lblViajeListadoRecorrido.Text = "Recorrido";
            // 
            // tbViajeListadoMicro
            // 
            this.tbViajeListadoMicro.Location = new System.Drawing.Point(437, 22);
            this.tbViajeListadoMicro.Name = "tbViajeListadoMicro";
            this.tbViajeListadoMicro.Size = new System.Drawing.Size(100, 20);
            this.tbViajeListadoMicro.TabIndex = 8;
            // 
            // tbViajeListadoRecorrido
            // 
            this.tbViajeListadoRecorrido.Location = new System.Drawing.Point(437, 48);
            this.tbViajeListadoRecorrido.Name = "tbViajeListadoRecorrido";
            this.tbViajeListadoRecorrido.Size = new System.Drawing.Size(100, 20);
            this.tbViajeListadoRecorrido.TabIndex = 9;
            // 
            // dgvViajeListado
            // 
            this.dgvViajeListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViajeListado.Location = new System.Drawing.Point(12, 176);
            this.dgvViajeListado.Name = "dgvViajeListado";
            this.dgvViajeListado.Size = new System.Drawing.Size(611, 150);
            this.dgvViajeListado.TabIndex = 1;
            // 
            // btnViajeListadoLimpiar
            // 
            this.btnViajeListadoLimpiar.Location = new System.Drawing.Point(12, 131);
            this.btnViajeListadoLimpiar.Name = "btnViajeListadoLimpiar";
            this.btnViajeListadoLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnViajeListadoLimpiar.TabIndex = 2;
            this.btnViajeListadoLimpiar.Text = "Limpiar";
            this.btnViajeListadoLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnViajeListadoBuscar
            // 
            this.btnViajeListadoBuscar.Location = new System.Drawing.Point(546, 131);
            this.btnViajeListadoBuscar.Name = "btnViajeListadoBuscar";
            this.btnViajeListadoBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnViajeListadoBuscar.TabIndex = 3;
            this.btnViajeListadoBuscar.Text = "Buscar";
            this.btnViajeListadoBuscar.UseVisualStyleBackColor = true;
            // 
            // btnViajeListadoDarBaja
            // 
            this.btnViajeListadoDarBaja.Location = new System.Drawing.Point(546, 363);
            this.btnViajeListadoDarBaja.Name = "btnViajeListadoDarBaja";
            this.btnViajeListadoDarBaja.Size = new System.Drawing.Size(75, 23);
            this.btnViajeListadoDarBaja.TabIndex = 4;
            this.btnViajeListadoDarBaja.Text = "Dar de baja";
            this.btnViajeListadoDarBaja.UseVisualStyleBackColor = true;
            // 
            // ViajeListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 398);
            this.Controls.Add(this.btnViajeListadoDarBaja);
            this.Controls.Add(this.btnViajeListadoBuscar);
            this.Controls.Add(this.btnViajeListadoLimpiar);
            this.Controls.Add(this.dgvViajeListado);
            this.Controls.Add(this.groupBox1);
            this.Name = "ViajeListado";
            this.Text = "Listado viajes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViajeListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpViajeListadoFechaLlegadaEstimada;
        private System.Windows.Forms.Label lblViajeListadoFechaLlegadaEstimada;
        private System.Windows.Forms.DateTimePicker dtpViajeListadoFechaLlegada;
        private System.Windows.Forms.DateTimePicker dtpViajeListadoFechaSalida;
        private System.Windows.Forms.Label lblViajeListadoFechaLLegada;
        private System.Windows.Forms.Label lblViajeListadoFechaSalida;
        private System.Windows.Forms.TextBox tbViajeListadoRecorrido;
        private System.Windows.Forms.TextBox tbViajeListadoMicro;
        private System.Windows.Forms.Label lblViajeListadoRecorrido;
        private System.Windows.Forms.Label lblViajeListadoMicro;
        private System.Windows.Forms.DataGridView dgvViajeListado;
        private System.Windows.Forms.Button btnViajeListadoLimpiar;
        private System.Windows.Forms.Button btnViajeListadoBuscar;
        private System.Windows.Forms.Button btnViajeListadoDarBaja;
    }
}