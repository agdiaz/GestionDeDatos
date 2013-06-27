namespace FrbaBus.Abm_Micro
{
    partial class MicroListado
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
            this.tbMicroListadoKgsEncomiendas = new System.Windows.Forms.TextBox();
            this.tbMicroListadoNumeroMicro = new System.Windows.Forms.TextBox();
            this.tbMicroListadoPatente = new System.Windows.Forms.TextBox();
            this.btnMicroListadoLimpiar = new System.Windows.Forms.Button();
            this.btnMicroListadoBuscar = new System.Windows.Forms.Button();
            this.lblMicroListadoKgsEncomiendas = new System.Windows.Forms.Label();
            this.lblMicroListadoNumeroMicro = new System.Windows.Forms.Label();
            this.lblMicroListadoPatente = new System.Windows.Forms.Label();
            this.cbbMicroListadoTipoServicio = new System.Windows.Forms.ComboBox();
            this.cbbMicroListadoTipoModelo = new System.Windows.Forms.ComboBox();
            this.lblMicroListadoTipoServicio = new System.Windows.Forms.Label();
            this.lblMicroListadoTipoModelo = new System.Windows.Forms.Label();
            this.cbbMicroListadoTipoEmpresa = new System.Windows.Forms.ComboBox();
            this.lblMicroListadoTipoEmpresa = new System.Windows.Forms.Label();
            this.dgvMicroListado = new System.Windows.Forms.DataGridView();
            this.btnMicroListadoDarBaja = new System.Windows.Forms.Button();
            this.btnMicroListadoModificar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMicroListado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbMicroListadoKgsEncomiendas);
            this.groupBox1.Controls.Add(this.tbMicroListadoNumeroMicro);
            this.groupBox1.Controls.Add(this.tbMicroListadoPatente);
            this.groupBox1.Controls.Add(this.btnMicroListadoLimpiar);
            this.groupBox1.Controls.Add(this.btnMicroListadoBuscar);
            this.groupBox1.Controls.Add(this.lblMicroListadoKgsEncomiendas);
            this.groupBox1.Controls.Add(this.lblMicroListadoNumeroMicro);
            this.groupBox1.Controls.Add(this.lblMicroListadoPatente);
            this.groupBox1.Controls.Add(this.cbbMicroListadoTipoServicio);
            this.groupBox1.Controls.Add(this.cbbMicroListadoTipoModelo);
            this.groupBox1.Controls.Add(this.lblMicroListadoTipoServicio);
            this.groupBox1.Controls.Add(this.lblMicroListadoTipoModelo);
            this.groupBox1.Controls.Add(this.cbbMicroListadoTipoEmpresa);
            this.groupBox1.Controls.Add(this.lblMicroListadoTipoEmpresa);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // tbMicroListadoKgsEncomiendas
            // 
            this.tbMicroListadoKgsEncomiendas.Location = new System.Drawing.Point(376, 70);
            this.tbMicroListadoKgsEncomiendas.Name = "tbMicroListadoKgsEncomiendas";
            this.tbMicroListadoKgsEncomiendas.Size = new System.Drawing.Size(100, 20);
            this.tbMicroListadoKgsEncomiendas.TabIndex = 11;
            // 
            // tbMicroListadoNumeroMicro
            // 
            this.tbMicroListadoNumeroMicro.Location = new System.Drawing.Point(376, 44);
            this.tbMicroListadoNumeroMicro.Name = "tbMicroListadoNumeroMicro";
            this.tbMicroListadoNumeroMicro.Size = new System.Drawing.Size(100, 20);
            this.tbMicroListadoNumeroMicro.TabIndex = 10;
            // 
            // tbMicroListadoPatente
            // 
            this.tbMicroListadoPatente.Location = new System.Drawing.Point(376, 13);
            this.tbMicroListadoPatente.Name = "tbMicroListadoPatente";
            this.tbMicroListadoPatente.Size = new System.Drawing.Size(100, 20);
            this.tbMicroListadoPatente.TabIndex = 9;
            // 
            // btnMicroListadoLimpiar
            // 
            this.btnMicroListadoLimpiar.ForeColor = System.Drawing.Color.Black;
            this.btnMicroListadoLimpiar.Location = new System.Drawing.Point(515, 42);
            this.btnMicroListadoLimpiar.Name = "btnMicroListadoLimpiar";
            this.btnMicroListadoLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnMicroListadoLimpiar.TabIndex = 1;
            this.btnMicroListadoLimpiar.Text = "Limpiar";
            this.btnMicroListadoLimpiar.UseVisualStyleBackColor = true;
            this.btnMicroListadoLimpiar.Click += new System.EventHandler(this.btnMicroListadoLimpiar_Click);
            // 
            // btnMicroListadoBuscar
            // 
            this.btnMicroListadoBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnMicroListadoBuscar.Location = new System.Drawing.Point(515, 14);
            this.btnMicroListadoBuscar.Name = "btnMicroListadoBuscar";
            this.btnMicroListadoBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnMicroListadoBuscar.TabIndex = 2;
            this.btnMicroListadoBuscar.Text = "Buscar";
            this.btnMicroListadoBuscar.UseVisualStyleBackColor = true;
            this.btnMicroListadoBuscar.Click += new System.EventHandler(this.btnMicroListadoBuscar_Click);
            // 
            // lblMicroListadoKgsEncomiendas
            // 
            this.lblMicroListadoKgsEncomiendas.AutoSize = true;
            this.lblMicroListadoKgsEncomiendas.ForeColor = System.Drawing.Color.Black;
            this.lblMicroListadoKgsEncomiendas.Location = new System.Drawing.Point(284, 73);
            this.lblMicroListadoKgsEncomiendas.Name = "lblMicroListadoKgsEncomiendas";
            this.lblMicroListadoKgsEncomiendas.Size = new System.Drawing.Size(86, 13);
            this.lblMicroListadoKgsEncomiendas.TabIndex = 8;
            this.lblMicroListadoKgsEncomiendas.Text = "Kgs encomienda";
            // 
            // lblMicroListadoNumeroMicro
            // 
            this.lblMicroListadoNumeroMicro.AutoSize = true;
            this.lblMicroListadoNumeroMicro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMicroListadoNumeroMicro.Location = new System.Drawing.Point(283, 46);
            this.lblMicroListadoNumeroMicro.Name = "lblMicroListadoNumeroMicro";
            this.lblMicroListadoNumeroMicro.Size = new System.Drawing.Size(87, 13);
            this.lblMicroListadoNumeroMicro.TabIndex = 7;
            this.lblMicroListadoNumeroMicro.Text = "Numero de micro";
            // 
            // lblMicroListadoPatente
            // 
            this.lblMicroListadoPatente.AutoSize = true;
            this.lblMicroListadoPatente.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMicroListadoPatente.Location = new System.Drawing.Point(283, 20);
            this.lblMicroListadoPatente.Name = "lblMicroListadoPatente";
            this.lblMicroListadoPatente.Size = new System.Drawing.Size(44, 13);
            this.lblMicroListadoPatente.TabIndex = 6;
            this.lblMicroListadoPatente.Text = "Patente";
            // 
            // cbbMicroListadoTipoServicio
            // 
            this.cbbMicroListadoTipoServicio.FormattingEnabled = true;
            this.cbbMicroListadoTipoServicio.Location = new System.Drawing.Point(88, 70);
            this.cbbMicroListadoTipoServicio.Name = "cbbMicroListadoTipoServicio";
            this.cbbMicroListadoTipoServicio.Size = new System.Drawing.Size(189, 21);
            this.cbbMicroListadoTipoServicio.TabIndex = 5;
            // 
            // cbbMicroListadoTipoModelo
            // 
            this.cbbMicroListadoTipoModelo.FormattingEnabled = true;
            this.cbbMicroListadoTipoModelo.Location = new System.Drawing.Point(88, 43);
            this.cbbMicroListadoTipoModelo.Name = "cbbMicroListadoTipoModelo";
            this.cbbMicroListadoTipoModelo.Size = new System.Drawing.Size(189, 21);
            this.cbbMicroListadoTipoModelo.TabIndex = 4;
            // 
            // lblMicroListadoTipoServicio
            // 
            this.lblMicroListadoTipoServicio.AutoSize = true;
            this.lblMicroListadoTipoServicio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMicroListadoTipoServicio.Location = new System.Drawing.Point(6, 73);
            this.lblMicroListadoTipoServicio.Name = "lblMicroListadoTipoServicio";
            this.lblMicroListadoTipoServicio.Size = new System.Drawing.Size(82, 13);
            this.lblMicroListadoTipoServicio.TabIndex = 3;
            this.lblMicroListadoTipoServicio.Text = "Tipo de servicio";
            // 
            // lblMicroListadoTipoModelo
            // 
            this.lblMicroListadoTipoModelo.AutoSize = true;
            this.lblMicroListadoTipoModelo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMicroListadoTipoModelo.Location = new System.Drawing.Point(7, 46);
            this.lblMicroListadoTipoModelo.Name = "lblMicroListadoTipoModelo";
            this.lblMicroListadoTipoModelo.Size = new System.Drawing.Size(42, 13);
            this.lblMicroListadoTipoModelo.TabIndex = 2;
            this.lblMicroListadoTipoModelo.Text = "Modelo";
            // 
            // cbbMicroListadoTipoEmpresa
            // 
            this.cbbMicroListadoTipoEmpresa.FormattingEnabled = true;
            this.cbbMicroListadoTipoEmpresa.Location = new System.Drawing.Point(88, 16);
            this.cbbMicroListadoTipoEmpresa.Name = "cbbMicroListadoTipoEmpresa";
            this.cbbMicroListadoTipoEmpresa.Size = new System.Drawing.Size(189, 21);
            this.cbbMicroListadoTipoEmpresa.TabIndex = 1;
            // 
            // lblMicroListadoTipoEmpresa
            // 
            this.lblMicroListadoTipoEmpresa.AutoSize = true;
            this.lblMicroListadoTipoEmpresa.ForeColor = System.Drawing.Color.Black;
            this.lblMicroListadoTipoEmpresa.Location = new System.Drawing.Point(7, 20);
            this.lblMicroListadoTipoEmpresa.Name = "lblMicroListadoTipoEmpresa";
            this.lblMicroListadoTipoEmpresa.Size = new System.Drawing.Size(37, 13);
            this.lblMicroListadoTipoEmpresa.TabIndex = 0;
            this.lblMicroListadoTipoEmpresa.Text = "Marca";
            // 
            // dgvMicroListado
            // 
            this.dgvMicroListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMicroListado.Location = new System.Drawing.Point(12, 120);
            this.dgvMicroListado.Name = "dgvMicroListado";
            this.dgvMicroListado.Size = new System.Drawing.Size(517, 256);
            this.dgvMicroListado.TabIndex = 3;
            // 
            // btnMicroListadoDarBaja
            // 
            this.btnMicroListadoDarBaja.Enabled = false;
            this.btnMicroListadoDarBaja.ForeColor = System.Drawing.Color.Black;
            this.btnMicroListadoDarBaja.Location = new System.Drawing.Point(12, 382);
            this.btnMicroListadoDarBaja.Name = "btnMicroListadoDarBaja";
            this.btnMicroListadoDarBaja.Size = new System.Drawing.Size(75, 23);
            this.btnMicroListadoDarBaja.TabIndex = 4;
            this.btnMicroListadoDarBaja.Text = "Dar de baja";
            this.btnMicroListadoDarBaja.UseVisualStyleBackColor = true;
            // 
            // btnMicroListadoModificar
            // 
            this.btnMicroListadoModificar.Enabled = false;
            this.btnMicroListadoModificar.ForeColor = System.Drawing.Color.Black;
            this.btnMicroListadoModificar.Location = new System.Drawing.Point(93, 382);
            this.btnMicroListadoModificar.Name = "btnMicroListadoModificar";
            this.btnMicroListadoModificar.Size = new System.Drawing.Size(75, 23);
            this.btnMicroListadoModificar.TabIndex = 5;
            this.btnMicroListadoModificar.Text = "Modificar";
            this.btnMicroListadoModificar.UseVisualStyleBackColor = true;
            // 
            // MicroListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 433);
            this.Controls.Add(this.btnMicroListadoModificar);
            this.Controls.Add(this.btnMicroListadoDarBaja);
            this.Controls.Add(this.dgvMicroListado);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Name = "MicroListado";
            this.Text = "FrbaBus - Micros :: Listado";
            this.Load += new System.EventHandler(this.MicroListado_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMicroListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbbMicroListadoTipoServicio;
        private System.Windows.Forms.ComboBox cbbMicroListadoTipoModelo;
        private System.Windows.Forms.Label lblMicroListadoTipoServicio;
        private System.Windows.Forms.Label lblMicroListadoTipoModelo;
        private System.Windows.Forms.ComboBox cbbMicroListadoTipoEmpresa;
        private System.Windows.Forms.Label lblMicroListadoTipoEmpresa;
        private System.Windows.Forms.TextBox tbMicroListadoKgsEncomiendas;
        private System.Windows.Forms.TextBox tbMicroListadoNumeroMicro;
        private System.Windows.Forms.TextBox tbMicroListadoPatente;
        private System.Windows.Forms.Label lblMicroListadoKgsEncomiendas;
        private System.Windows.Forms.Label lblMicroListadoNumeroMicro;
        private System.Windows.Forms.Label lblMicroListadoPatente;
        private System.Windows.Forms.Button btnMicroListadoLimpiar;
        private System.Windows.Forms.Button btnMicroListadoBuscar;
        private System.Windows.Forms.DataGridView dgvMicroListado;
        private System.Windows.Forms.Button btnMicroListadoDarBaja;
        private System.Windows.Forms.Button btnMicroListadoModificar;

    }
}