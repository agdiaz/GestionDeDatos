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
            this.lblMicroListadoTipoEmpresa = new System.Windows.Forms.Label();
            this.cbbMicroListadoTipoEmpresa = new System.Windows.Forms.ComboBox();
            this.lblMicroListadoTipoModelo = new System.Windows.Forms.Label();
            this.lblMicroListadoTipoServicio = new System.Windows.Forms.Label();
            this.cbbMicroListadoTipoModelo = new System.Windows.Forms.ComboBox();
            this.cbbMicroListadoTipoServicio = new System.Windows.Forms.ComboBox();
            this.lblMicroListadoPatente = new System.Windows.Forms.Label();
            this.lblMicroListadoNumeroMicro = new System.Windows.Forms.Label();
            this.lblMicroListadoKgsEncomiendas = new System.Windows.Forms.Label();
            this.tbMicroListadoPatente = new System.Windows.Forms.TextBox();
            this.tbMicroListadoNumeroPatente = new System.Windows.Forms.TextBox();
            this.tbMicroListadoKgsEncomiendas = new System.Windows.Forms.TextBox();
            this.btnMicroListadoLimpiar = new System.Windows.Forms.Button();
            this.btnMicroListadoBuscar = new System.Windows.Forms.Button();
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
            this.groupBox1.Controls.Add(this.tbMicroListadoNumeroPatente);
            this.groupBox1.Controls.Add(this.tbMicroListadoPatente);
            this.groupBox1.Controls.Add(this.lblMicroListadoKgsEncomiendas);
            this.groupBox1.Controls.Add(this.lblMicroListadoNumeroMicro);
            this.groupBox1.Controls.Add(this.lblMicroListadoPatente);
            this.groupBox1.Controls.Add(this.cbbMicroListadoTipoServicio);
            this.groupBox1.Controls.Add(this.cbbMicroListadoTipoModelo);
            this.groupBox1.Controls.Add(this.lblMicroListadoTipoServicio);
            this.groupBox1.Controls.Add(this.lblMicroListadoTipoModelo);
            this.groupBox1.Controls.Add(this.cbbMicroListadoTipoEmpresa);
            this.groupBox1.Controls.Add(this.lblMicroListadoTipoEmpresa);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(31, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de busqueda";
            // 
            // lblMicroListadoTipoEmpresa
            // 
            this.lblMicroListadoTipoEmpresa.AutoSize = true;
            this.lblMicroListadoTipoEmpresa.ForeColor = System.Drawing.Color.Black;
            this.lblMicroListadoTipoEmpresa.Location = new System.Drawing.Point(7, 20);
            this.lblMicroListadoTipoEmpresa.Name = "lblMicroListadoTipoEmpresa";
            this.lblMicroListadoTipoEmpresa.Size = new System.Drawing.Size(48, 13);
            this.lblMicroListadoTipoEmpresa.TabIndex = 0;
            this.lblMicroListadoTipoEmpresa.Text = "Empresa";
            // 
            // cbbMicroListadoTipoEmpresa
            // 
            this.cbbMicroListadoTipoEmpresa.FormattingEnabled = true;
            this.cbbMicroListadoTipoEmpresa.Location = new System.Drawing.Point(134, 17);
            this.cbbMicroListadoTipoEmpresa.Name = "cbbMicroListadoTipoEmpresa";
            this.cbbMicroListadoTipoEmpresa.Size = new System.Drawing.Size(121, 21);
            this.cbbMicroListadoTipoEmpresa.TabIndex = 1;
            // 
            // lblMicroListadoTipoModelo
            // 
            this.lblMicroListadoTipoModelo.AutoSize = true;
            this.lblMicroListadoTipoModelo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMicroListadoTipoModelo.Location = new System.Drawing.Point(7, 51);
            this.lblMicroListadoTipoModelo.Name = "lblMicroListadoTipoModelo";
            this.lblMicroListadoTipoModelo.Size = new System.Drawing.Size(42, 13);
            this.lblMicroListadoTipoModelo.TabIndex = 2;
            this.lblMicroListadoTipoModelo.Text = "Modelo";
            // 
            // lblMicroListadoTipoServicio
            // 
            this.lblMicroListadoTipoServicio.AutoSize = true;
            this.lblMicroListadoTipoServicio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMicroListadoTipoServicio.Location = new System.Drawing.Point(7, 81);
            this.lblMicroListadoTipoServicio.Name = "lblMicroListadoTipoServicio";
            this.lblMicroListadoTipoServicio.Size = new System.Drawing.Size(82, 13);
            this.lblMicroListadoTipoServicio.TabIndex = 3;
            this.lblMicroListadoTipoServicio.Text = "Tipo de servicio";
            // 
            // cbbMicroListadoTipoModelo
            // 
            this.cbbMicroListadoTipoModelo.FormattingEnabled = true;
            this.cbbMicroListadoTipoModelo.Location = new System.Drawing.Point(134, 51);
            this.cbbMicroListadoTipoModelo.Name = "cbbMicroListadoTipoModelo";
            this.cbbMicroListadoTipoModelo.Size = new System.Drawing.Size(121, 21);
            this.cbbMicroListadoTipoModelo.TabIndex = 4;
            // 
            // cbbMicroListadoTipoServicio
            // 
            this.cbbMicroListadoTipoServicio.FormattingEnabled = true;
            this.cbbMicroListadoTipoServicio.Location = new System.Drawing.Point(134, 81);
            this.cbbMicroListadoTipoServicio.Name = "cbbMicroListadoTipoServicio";
            this.cbbMicroListadoTipoServicio.Size = new System.Drawing.Size(121, 21);
            this.cbbMicroListadoTipoServicio.TabIndex = 5;
            // 
            // lblMicroListadoPatente
            // 
            this.lblMicroListadoPatente.AutoSize = true;
            this.lblMicroListadoPatente.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMicroListadoPatente.Location = new System.Drawing.Point(317, 20);
            this.lblMicroListadoPatente.Name = "lblMicroListadoPatente";
            this.lblMicroListadoPatente.Size = new System.Drawing.Size(44, 13);
            this.lblMicroListadoPatente.TabIndex = 6;
            this.lblMicroListadoPatente.Text = "Patente";
            // 
            // lblMicroListadoNumeroMicro
            // 
            this.lblMicroListadoNumeroMicro.AutoSize = true;
            this.lblMicroListadoNumeroMicro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMicroListadoNumeroMicro.Location = new System.Drawing.Point(317, 51);
            this.lblMicroListadoNumeroMicro.Name = "lblMicroListadoNumeroMicro";
            this.lblMicroListadoNumeroMicro.Size = new System.Drawing.Size(87, 13);
            this.lblMicroListadoNumeroMicro.TabIndex = 7;
            this.lblMicroListadoNumeroMicro.Text = "Numero de micro";
            // 
            // lblMicroListadoKgsEncomiendas
            // 
            this.lblMicroListadoKgsEncomiendas.AutoSize = true;
            this.lblMicroListadoKgsEncomiendas.ForeColor = System.Drawing.Color.Black;
            this.lblMicroListadoKgsEncomiendas.Location = new System.Drawing.Point(317, 81);
            this.lblMicroListadoKgsEncomiendas.Name = "lblMicroListadoKgsEncomiendas";
            this.lblMicroListadoKgsEncomiendas.Size = new System.Drawing.Size(91, 13);
            this.lblMicroListadoKgsEncomiendas.TabIndex = 8;
            this.lblMicroListadoKgsEncomiendas.Text = "Kgs encomiendas";
            // 
            // tbMicroListadoPatente
            // 
            this.tbMicroListadoPatente.Location = new System.Drawing.Point(427, 17);
            this.tbMicroListadoPatente.Name = "tbMicroListadoPatente";
            this.tbMicroListadoPatente.Size = new System.Drawing.Size(100, 20);
            this.tbMicroListadoPatente.TabIndex = 9;
            // 
            // tbMicroListadoNumeroPatente
            // 
            this.tbMicroListadoNumeroPatente.Location = new System.Drawing.Point(427, 51);
            this.tbMicroListadoNumeroPatente.Name = "tbMicroListadoNumeroPatente";
            this.tbMicroListadoNumeroPatente.Size = new System.Drawing.Size(100, 20);
            this.tbMicroListadoNumeroPatente.TabIndex = 10;
            // 
            // tbMicroListadoKgsEncomiendas
            // 
            this.tbMicroListadoKgsEncomiendas.Location = new System.Drawing.Point(427, 81);
            this.tbMicroListadoKgsEncomiendas.Name = "tbMicroListadoKgsEncomiendas";
            this.tbMicroListadoKgsEncomiendas.Size = new System.Drawing.Size(100, 20);
            this.tbMicroListadoKgsEncomiendas.TabIndex = 11;
            // 
            // btnMicroListadoLimpiar
            // 
            this.btnMicroListadoLimpiar.ForeColor = System.Drawing.Color.Black;
            this.btnMicroListadoLimpiar.Location = new System.Drawing.Point(41, 159);
            this.btnMicroListadoLimpiar.Name = "btnMicroListadoLimpiar";
            this.btnMicroListadoLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnMicroListadoLimpiar.TabIndex = 1;
            this.btnMicroListadoLimpiar.Text = "Limpiar";
            this.btnMicroListadoLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnMicroListadoBuscar
            // 
            this.btnMicroListadoBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnMicroListadoBuscar.Location = new System.Drawing.Point(483, 159);
            this.btnMicroListadoBuscar.Name = "btnMicroListadoBuscar";
            this.btnMicroListadoBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnMicroListadoBuscar.TabIndex = 2;
            this.btnMicroListadoBuscar.Text = "Buscar";
            this.btnMicroListadoBuscar.UseVisualStyleBackColor = true;
            // 
            // dgvMicroListado
            // 
            this.dgvMicroListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMicroListado.Location = new System.Drawing.Point(41, 209);
            this.dgvMicroListado.Name = "dgvMicroListado";
            this.dgvMicroListado.Size = new System.Drawing.Size(517, 150);
            this.dgvMicroListado.TabIndex = 3;
            // 
            // btnMicroListadoDarBaja
            // 
            this.btnMicroListadoDarBaja.Enabled = false;
            this.btnMicroListadoDarBaja.ForeColor = System.Drawing.Color.Black;
            this.btnMicroListadoDarBaja.Location = new System.Drawing.Point(41, 383);
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
            this.btnMicroListadoModificar.Location = new System.Drawing.Point(483, 382);
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
            this.ClientSize = new System.Drawing.Size(620, 447);
            this.Controls.Add(this.btnMicroListadoModificar);
            this.Controls.Add(this.btnMicroListadoDarBaja);
            this.Controls.Add(this.dgvMicroListado);
            this.Controls.Add(this.btnMicroListadoBuscar);
            this.Controls.Add(this.btnMicroListadoLimpiar);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Name = "MicroListado";
            this.Text = "MicroListado";
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
        private System.Windows.Forms.TextBox tbMicroListadoNumeroPatente;
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