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
            this.cbFechaEstimada = new System.Windows.Forms.CheckBox();
            this.cbFechaLlegada = new System.Windows.Forms.CheckBox();
            this.cbFechaSalida = new System.Windows.Forms.CheckBox();
            this.cbRecorrido = new System.Windows.Forms.ComboBox();
            this.cbMicro = new System.Windows.Forms.ComboBox();
            this.lblViajeListadoRecorrido = new System.Windows.Forms.Label();
            this.btnViajeListadoLimpiar = new System.Windows.Forms.Button();
            this.btnViajeListadoBuscar = new System.Windows.Forms.Button();
            this.lblViajeListadoMicro = new System.Windows.Forms.Label();
            this.dtpViajeListadoFechaLlegadaEstimada = new System.Windows.Forms.DateTimePicker();
            this.dtpViajeListadoFechaLlegada = new System.Windows.Forms.DateTimePicker();
            this.dtpViajeListadoFechaSalida = new System.Windows.Forms.DateTimePicker();
            this.dgvViajeListado = new System.Windows.Forms.DataGridView();
            this.btnViajeListadoDarBaja = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViajeListado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbFechaEstimada);
            this.groupBox1.Controls.Add(this.cbFechaLlegada);
            this.groupBox1.Controls.Add(this.cbFechaSalida);
            this.groupBox1.Controls.Add(this.cbRecorrido);
            this.groupBox1.Controls.Add(this.cbMicro);
            this.groupBox1.Controls.Add(this.lblViajeListadoRecorrido);
            this.groupBox1.Controls.Add(this.btnViajeListadoLimpiar);
            this.groupBox1.Controls.Add(this.btnViajeListadoBuscar);
            this.groupBox1.Controls.Add(this.lblViajeListadoMicro);
            this.groupBox1.Controls.Add(this.dtpViajeListadoFechaLlegadaEstimada);
            this.groupBox1.Controls.Add(this.dtpViajeListadoFechaLlegada);
            this.groupBox1.Controls.Add(this.dtpViajeListadoFechaSalida);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(859, 146);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de busqueda";
            // 
            // cbFechaEstimada
            // 
            this.cbFechaEstimada.AutoSize = true;
            this.cbFechaEstimada.Location = new System.Drawing.Point(6, 83);
            this.cbFechaEstimada.Name = "cbFechaEstimada";
            this.cbFechaEstimada.Size = new System.Drawing.Size(138, 17);
            this.cbFechaEstimada.TabIndex = 12;
            this.cbFechaEstimada.Text = "Fecha llegada estimada";
            this.cbFechaEstimada.UseVisualStyleBackColor = true;
            // 
            // cbFechaLlegada
            // 
            this.cbFechaLlegada.AutoSize = true;
            this.cbFechaLlegada.Location = new System.Drawing.Point(6, 53);
            this.cbFechaLlegada.Name = "cbFechaLlegada";
            this.cbFechaLlegada.Size = new System.Drawing.Size(93, 17);
            this.cbFechaLlegada.TabIndex = 11;
            this.cbFechaLlegada.Text = "Fecha llegada";
            this.cbFechaLlegada.UseVisualStyleBackColor = true;
            // 
            // cbFechaSalida
            // 
            this.cbFechaSalida.AutoSize = true;
            this.cbFechaSalida.Location = new System.Drawing.Point(6, 24);
            this.cbFechaSalida.Name = "cbFechaSalida";
            this.cbFechaSalida.Size = new System.Drawing.Size(86, 17);
            this.cbFechaSalida.TabIndex = 10;
            this.cbFechaSalida.Text = "Fecha salida";
            this.cbFechaSalida.UseVisualStyleBackColor = true;
            // 
            // cbRecorrido
            // 
            this.cbRecorrido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRecorrido.FormattingEnabled = true;
            this.cbRecorrido.Location = new System.Drawing.Point(397, 49);
            this.cbRecorrido.Name = "cbRecorrido";
            this.cbRecorrido.Size = new System.Drawing.Size(438, 21);
            this.cbRecorrido.TabIndex = 9;
            // 
            // cbMicro
            // 
            this.cbMicro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMicro.FormattingEnabled = true;
            this.cbMicro.Location = new System.Drawing.Point(397, 22);
            this.cbMicro.Name = "cbMicro";
            this.cbMicro.Size = new System.Drawing.Size(438, 21);
            this.cbMicro.TabIndex = 8;
            // 
            // lblViajeListadoRecorrido
            // 
            this.lblViajeListadoRecorrido.AutoSize = true;
            this.lblViajeListadoRecorrido.Location = new System.Drawing.Point(344, 52);
            this.lblViajeListadoRecorrido.Name = "lblViajeListadoRecorrido";
            this.lblViajeListadoRecorrido.Size = new System.Drawing.Size(53, 13);
            this.lblViajeListadoRecorrido.TabIndex = 7;
            this.lblViajeListadoRecorrido.Text = "Recorrido";
            // 
            // btnViajeListadoLimpiar
            // 
            this.btnViajeListadoLimpiar.Location = new System.Drawing.Point(97, 117);
            this.btnViajeListadoLimpiar.Name = "btnViajeListadoLimpiar";
            this.btnViajeListadoLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnViajeListadoLimpiar.TabIndex = 2;
            this.btnViajeListadoLimpiar.Text = "Limpiar";
            this.btnViajeListadoLimpiar.UseVisualStyleBackColor = true;
            this.btnViajeListadoLimpiar.Click += new System.EventHandler(this.btnViajeListadoLimpiar_Click);
            // 
            // btnViajeListadoBuscar
            // 
            this.btnViajeListadoBuscar.Location = new System.Drawing.Point(9, 117);
            this.btnViajeListadoBuscar.Name = "btnViajeListadoBuscar";
            this.btnViajeListadoBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnViajeListadoBuscar.TabIndex = 3;
            this.btnViajeListadoBuscar.Text = "Buscar";
            this.btnViajeListadoBuscar.UseVisualStyleBackColor = true;
            this.btnViajeListadoBuscar.Click += new System.EventHandler(this.btnViajeListadoBuscar_Click);
            // 
            // lblViajeListadoMicro
            // 
            this.lblViajeListadoMicro.AutoSize = true;
            this.lblViajeListadoMicro.Location = new System.Drawing.Point(344, 25);
            this.lblViajeListadoMicro.Name = "lblViajeListadoMicro";
            this.lblViajeListadoMicro.Size = new System.Drawing.Size(33, 13);
            this.lblViajeListadoMicro.TabIndex = 6;
            this.lblViajeListadoMicro.Text = "Micro";
            // 
            // dtpViajeListadoFechaLlegadaEstimada
            // 
            this.dtpViajeListadoFechaLlegadaEstimada.Location = new System.Drawing.Point(150, 80);
            this.dtpViajeListadoFechaLlegadaEstimada.Name = "dtpViajeListadoFechaLlegadaEstimada";
            this.dtpViajeListadoFechaLlegadaEstimada.Size = new System.Drawing.Size(200, 20);
            this.dtpViajeListadoFechaLlegadaEstimada.TabIndex = 5;
            // 
            // dtpViajeListadoFechaLlegada
            // 
            this.dtpViajeListadoFechaLlegada.Location = new System.Drawing.Point(105, 50);
            this.dtpViajeListadoFechaLlegada.Name = "dtpViajeListadoFechaLlegada";
            this.dtpViajeListadoFechaLlegada.Size = new System.Drawing.Size(200, 20);
            this.dtpViajeListadoFechaLlegada.TabIndex = 3;
            // 
            // dtpViajeListadoFechaSalida
            // 
            this.dtpViajeListadoFechaSalida.Location = new System.Drawing.Point(105, 19);
            this.dtpViajeListadoFechaSalida.Name = "dtpViajeListadoFechaSalida";
            this.dtpViajeListadoFechaSalida.Size = new System.Drawing.Size(200, 20);
            this.dtpViajeListadoFechaSalida.TabIndex = 2;
            this.dtpViajeListadoFechaSalida.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dgvViajeListado
            // 
            this.dgvViajeListado.AllowUserToAddRows = false;
            this.dgvViajeListado.AllowUserToDeleteRows = false;
            this.dgvViajeListado.AllowUserToResizeColumns = false;
            this.dgvViajeListado.AllowUserToResizeRows = false;
            this.dgvViajeListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViajeListado.Location = new System.Drawing.Point(12, 180);
            this.dgvViajeListado.Name = "dgvViajeListado";
            this.dgvViajeListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvViajeListado.Size = new System.Drawing.Size(859, 239);
            this.dgvViajeListado.TabIndex = 1;
            // 
            // btnViajeListadoDarBaja
            // 
            this.btnViajeListadoDarBaja.Location = new System.Drawing.Point(109, 426);
            this.btnViajeListadoDarBaja.Name = "btnViajeListadoDarBaja";
            this.btnViajeListadoDarBaja.Size = new System.Drawing.Size(75, 23);
            this.btnViajeListadoDarBaja.TabIndex = 4;
            this.btnViajeListadoDarBaja.Text = "Dar de baja";
            this.btnViajeListadoDarBaja.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(28, 426);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 5;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // ViajeListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 461);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnViajeListadoDarBaja);
            this.Controls.Add(this.dgvViajeListado);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViajeListado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrbaBus - Viajes :: Listado";
            this.Load += new System.EventHandler(this.ViajeListado_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViajeListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpViajeListadoFechaLlegadaEstimada;
        private System.Windows.Forms.DateTimePicker dtpViajeListadoFechaLlegada;
        private System.Windows.Forms.DateTimePicker dtpViajeListadoFechaSalida;
        private System.Windows.Forms.Label lblViajeListadoRecorrido;
        private System.Windows.Forms.Label lblViajeListadoMicro;
        private System.Windows.Forms.DataGridView dgvViajeListado;
        private System.Windows.Forms.Button btnViajeListadoLimpiar;
        private System.Windows.Forms.Button btnViajeListadoBuscar;
        private System.Windows.Forms.Button btnViajeListadoDarBaja;
        private System.Windows.Forms.ComboBox cbMicro;
        private System.Windows.Forms.ComboBox cbRecorrido;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.CheckBox cbFechaEstimada;
        private System.Windows.Forms.CheckBox cbFechaLlegada;
        private System.Windows.Forms.CheckBox cbFechaSalida;
    }
}