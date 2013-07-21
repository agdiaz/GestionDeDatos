namespace FrbaBus.Abm_Viaje
{
    partial class ViajeModificar
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
            this.lblViajeModificarFechaSalida = new System.Windows.Forms.Label();
            this.lblViajeModificarFechaLlegadaEstimada = new System.Windows.Forms.Label();
            this.lblViajeModificarMicro = new System.Windows.Forms.Label();
            this.lblViajeModificarRecorrido = new System.Windows.Forms.Label();
            this.dtpViajeModificarFechaSalida = new System.Windows.Forms.DateTimePicker();
            this.dtpViajeModificarFechaLlegadaEstimada = new System.Windows.Forms.DateTimePicker();
            this.btnViajeModificarGuardar = new System.Windows.Forms.Button();
            this.txtMicro = new System.Windows.Forms.TextBox();
            this.btnViajeModificarBuscarMicro = new System.Windows.Forms.Button();
            this.txtRecorrido = new System.Windows.Forms.TextBox();
            this.btnViajeModificarBuscarRecorrido = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblViajeModificarFechaSalida
            // 
            this.lblViajeModificarFechaSalida.AutoSize = true;
            this.lblViajeModificarFechaSalida.Location = new System.Drawing.Point(9, 25);
            this.lblViajeModificarFechaSalida.Name = "lblViajeModificarFechaSalida";
            this.lblViajeModificarFechaSalida.Size = new System.Drawing.Size(82, 13);
            this.lblViajeModificarFechaSalida.TabIndex = 0;
            this.lblViajeModificarFechaSalida.Text = "Fecha de salida";
            // 
            // lblViajeModificarFechaLlegadaEstimada
            // 
            this.lblViajeModificarFechaLlegadaEstimada.AutoSize = true;
            this.lblViajeModificarFechaLlegadaEstimada.Location = new System.Drawing.Point(9, 61);
            this.lblViajeModificarFechaLlegadaEstimada.Name = "lblViajeModificarFechaLlegadaEstimada";
            this.lblViajeModificarFechaLlegadaEstimada.Size = new System.Drawing.Size(134, 13);
            this.lblViajeModificarFechaLlegadaEstimada.TabIndex = 2;
            this.lblViajeModificarFechaLlegadaEstimada.Text = "Fecha de llegada estimada";
            // 
            // lblViajeModificarMicro
            // 
            this.lblViajeModificarMicro.AutoSize = true;
            this.lblViajeModificarMicro.Location = new System.Drawing.Point(9, 32);
            this.lblViajeModificarMicro.Name = "lblViajeModificarMicro";
            this.lblViajeModificarMicro.Size = new System.Drawing.Size(33, 13);
            this.lblViajeModificarMicro.TabIndex = 3;
            this.lblViajeModificarMicro.Text = "Micro";
            // 
            // lblViajeModificarRecorrido
            // 
            this.lblViajeModificarRecorrido.AutoSize = true;
            this.lblViajeModificarRecorrido.Location = new System.Drawing.Point(9, 58);
            this.lblViajeModificarRecorrido.Name = "lblViajeModificarRecorrido";
            this.lblViajeModificarRecorrido.Size = new System.Drawing.Size(53, 13);
            this.lblViajeModificarRecorrido.TabIndex = 4;
            this.lblViajeModificarRecorrido.Text = "Recorrido";
            // 
            // dtpViajeModificarFechaSalida
            // 
            this.dtpViajeModificarFechaSalida.Location = new System.Drawing.Point(161, 19);
            this.dtpViajeModificarFechaSalida.Name = "dtpViajeModificarFechaSalida";
            this.dtpViajeModificarFechaSalida.Size = new System.Drawing.Size(274, 20);
            this.dtpViajeModificarFechaSalida.TabIndex = 0;
            // 
            // dtpViajeModificarFechaLlegadaEstimada
            // 
            this.dtpViajeModificarFechaLlegadaEstimada.Location = new System.Drawing.Point(161, 55);
            this.dtpViajeModificarFechaLlegadaEstimada.Name = "dtpViajeModificarFechaLlegadaEstimada";
            this.dtpViajeModificarFechaLlegadaEstimada.Size = new System.Drawing.Size(274, 20);
            this.dtpViajeModificarFechaLlegadaEstimada.TabIndex = 1;
            // 
            // btnViajeModificarGuardar
            // 
            this.btnViajeModificarGuardar.Location = new System.Drawing.Point(378, 248);
            this.btnViajeModificarGuardar.Name = "btnViajeModificarGuardar";
            this.btnViajeModificarGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnViajeModificarGuardar.TabIndex = 8;
            this.btnViajeModificarGuardar.Text = "Guardar";
            this.btnViajeModificarGuardar.UseVisualStyleBackColor = true;
            this.btnViajeModificarGuardar.Click += new System.EventHandler(this.btnViajeModificarGuardar_Click);
            // 
            // txtMicro
            // 
            this.txtMicro.Location = new System.Drawing.Point(74, 29);
            this.txtMicro.Name = "txtMicro";
            this.txtMicro.ReadOnly = true;
            this.txtMicro.Size = new System.Drawing.Size(179, 20);
            this.txtMicro.TabIndex = 2;
            this.txtMicro.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnViajeModificarBuscarMicro
            // 
            this.btnViajeModificarBuscarMicro.Location = new System.Drawing.Point(259, 27);
            this.btnViajeModificarBuscarMicro.Name = "btnViajeModificarBuscarMicro";
            this.btnViajeModificarBuscarMicro.Size = new System.Drawing.Size(75, 23);
            this.btnViajeModificarBuscarMicro.TabIndex = 3;
            this.btnViajeModificarBuscarMicro.Text = "Buscar";
            this.btnViajeModificarBuscarMicro.UseVisualStyleBackColor = true;
            this.btnViajeModificarBuscarMicro.Click += new System.EventHandler(this.btnViajeModificarBuscarMicro_Click);
            // 
            // txtRecorrido
            // 
            this.txtRecorrido.Location = new System.Drawing.Point(74, 55);
            this.txtRecorrido.Name = "txtRecorrido";
            this.txtRecorrido.ReadOnly = true;
            this.txtRecorrido.Size = new System.Drawing.Size(179, 20);
            this.txtRecorrido.TabIndex = 4;
            // 
            // btnViajeModificarBuscarRecorrido
            // 
            this.btnViajeModificarBuscarRecorrido.Location = new System.Drawing.Point(259, 56);
            this.btnViajeModificarBuscarRecorrido.Name = "btnViajeModificarBuscarRecorrido";
            this.btnViajeModificarBuscarRecorrido.Size = new System.Drawing.Size(75, 23);
            this.btnViajeModificarBuscarRecorrido.TabIndex = 6;
            this.btnViajeModificarBuscarRecorrido.Text = "Buscar";
            this.btnViajeModificarBuscarRecorrido.UseVisualStyleBackColor = true;
            this.btnViajeModificarBuscarRecorrido.Click += new System.EventHandler(this.btnViajeModificarBuscarRecorrido_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMicro);
            this.groupBox1.Controls.Add(this.btnViajeModificarBuscarRecorrido);
            this.groupBox1.Controls.Add(this.txtRecorrido);
            this.groupBox1.Controls.Add(this.btnViajeModificarBuscarMicro);
            this.groupBox1.Controls.Add(this.lblViajeModificarMicro);
            this.groupBox1.Controls.Add(this.lblViajeModificarRecorrido);
            this.groupBox1.Location = new System.Drawing.Point(12, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 101);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblViajeModificarFechaSalida);
            this.groupBox2.Controls.Add(this.dtpViajeModificarFechaLlegadaEstimada);
            this.groupBox2.Controls.Add(this.lblViajeModificarFechaLlegadaEstimada);
            this.groupBox2.Controls.Add(this.dtpViajeModificarFechaSalida);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(441, 112);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fechas";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(12, 248);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // ViajeModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 280);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnViajeModificarGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViajeModificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrbaBus - Viajes :: Modificar";
            this.Load += new System.EventHandler(this.ViajeModificar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblViajeModificarFechaSalida;
        private System.Windows.Forms.Label lblViajeModificarFechaLlegadaEstimada;
        private System.Windows.Forms.Label lblViajeModificarMicro;
        private System.Windows.Forms.Label lblViajeModificarRecorrido;
        private System.Windows.Forms.DateTimePicker dtpViajeModificarFechaSalida;
        private System.Windows.Forms.DateTimePicker dtpViajeModificarFechaLlegadaEstimada;
        private System.Windows.Forms.Button btnViajeModificarGuardar;
        private System.Windows.Forms.TextBox txtMicro;
        private System.Windows.Forms.Button btnViajeModificarBuscarMicro;
        private System.Windows.Forms.TextBox txtRecorrido;
        private System.Windows.Forms.Button btnViajeModificarBuscarRecorrido;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLimpiar;
    }
}