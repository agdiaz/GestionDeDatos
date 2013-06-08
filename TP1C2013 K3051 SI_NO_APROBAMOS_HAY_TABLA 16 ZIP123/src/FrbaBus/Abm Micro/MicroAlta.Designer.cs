namespace FrbaBus.Abm_Micro
{
    partial class MicroAlta
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
            this.cbbMicroAltaTipoServicio = new System.Windows.Forms.ComboBox();
            this.lblMicroAltaTipoServicio = new System.Windows.Forms.Label();
            this.lblMicroAltaCantidadButacas = new System.Windows.Forms.Label();
            this.lblMicroAltaTipoEmpresa = new System.Windows.Forms.Label();
            this.cbbMicroAltaTipoEmpresa = new System.Windows.Forms.ComboBox();
            this.lblMicroAltaKgsEncomiendas = new System.Windows.Forms.Label();
            this.btnMicroAltaGuardar = new System.Windows.Forms.Button();
            this.btnMicroAltaLimpiar = new System.Windows.Forms.Button();
            this.lblMicroAltaModelo = new System.Windows.Forms.Label();
            this.cbbMicroAltaTipoModelo = new System.Windows.Forms.ComboBox();
            this.mtbMicroAltaCantidadButacas = new System.Windows.Forms.MaskedTextBox();
            this.mtbMicroAltaKgsEncomiendas = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // cbbMicroAltaTipoServicio
            // 
            this.cbbMicroAltaTipoServicio.FormattingEnabled = true;
            this.cbbMicroAltaTipoServicio.Location = new System.Drawing.Point(288, 108);
            this.cbbMicroAltaTipoServicio.Name = "cbbMicroAltaTipoServicio";
            this.cbbMicroAltaTipoServicio.Size = new System.Drawing.Size(121, 21);
            this.cbbMicroAltaTipoServicio.TabIndex = 0;
            // 
            // lblMicroAltaTipoServicio
            // 
            this.lblMicroAltaTipoServicio.AutoSize = true;
            this.lblMicroAltaTipoServicio.Location = new System.Drawing.Point(85, 116);
            this.lblMicroAltaTipoServicio.Name = "lblMicroAltaTipoServicio";
            this.lblMicroAltaTipoServicio.Size = new System.Drawing.Size(82, 13);
            this.lblMicroAltaTipoServicio.TabIndex = 1;
            this.lblMicroAltaTipoServicio.Text = "Tipo de servicio";
            // 
            // lblMicroAltaCantidadButacas
            // 
            this.lblMicroAltaCantidadButacas.AutoSize = true;
            this.lblMicroAltaCantidadButacas.Location = new System.Drawing.Point(85, 150);
            this.lblMicroAltaCantidadButacas.Name = "lblMicroAltaCantidadButacas";
            this.lblMicroAltaCantidadButacas.Size = new System.Drawing.Size(105, 13);
            this.lblMicroAltaCantidadButacas.TabIndex = 2;
            this.lblMicroAltaCantidadButacas.Text = "Cantidad de butacas";
            // 
            // lblMicroAltaTipoEmpresa
            // 
            this.lblMicroAltaTipoEmpresa.AutoSize = true;
            this.lblMicroAltaTipoEmpresa.Location = new System.Drawing.Point(85, 41);
            this.lblMicroAltaTipoEmpresa.Name = "lblMicroAltaTipoEmpresa";
            this.lblMicroAltaTipoEmpresa.Size = new System.Drawing.Size(48, 13);
            this.lblMicroAltaTipoEmpresa.TabIndex = 4;
            this.lblMicroAltaTipoEmpresa.Text = "Empresa";
            // 
            // cbbMicroAltaTipoEmpresa
            // 
            this.cbbMicroAltaTipoEmpresa.FormattingEnabled = true;
            this.cbbMicroAltaTipoEmpresa.Location = new System.Drawing.Point(288, 33);
            this.cbbMicroAltaTipoEmpresa.Name = "cbbMicroAltaTipoEmpresa";
            this.cbbMicroAltaTipoEmpresa.Size = new System.Drawing.Size(121, 21);
            this.cbbMicroAltaTipoEmpresa.TabIndex = 5;
            this.cbbMicroAltaTipoEmpresa.SelectedIndexChanged += new System.EventHandler(this.cbbMicroAltaTipoEmpresa_SelectedIndexChanged);
            // 
            // lblMicroAltaKgsEncomiendas
            // 
            this.lblMicroAltaKgsEncomiendas.AutoSize = true;
            this.lblMicroAltaKgsEncomiendas.Location = new System.Drawing.Point(85, 188);
            this.lblMicroAltaKgsEncomiendas.Name = "lblMicroAltaKgsEncomiendas";
            this.lblMicroAltaKgsEncomiendas.Size = new System.Drawing.Size(170, 13);
            this.lblMicroAltaKgsEncomiendas.TabIndex = 6;
            this.lblMicroAltaKgsEncomiendas.Text = "Kgs disponibles para encomiendas";
            // 
            // btnMicroAltaGuardar
            // 
            this.btnMicroAltaGuardar.Enabled = false;
            this.btnMicroAltaGuardar.Location = new System.Drawing.Point(439, 237);
            this.btnMicroAltaGuardar.Name = "btnMicroAltaGuardar";
            this.btnMicroAltaGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnMicroAltaGuardar.TabIndex = 8;
            this.btnMicroAltaGuardar.Text = "Guardar";
            this.btnMicroAltaGuardar.UseVisualStyleBackColor = true;
            // 
            // btnMicroAltaLimpiar
            // 
            this.btnMicroAltaLimpiar.Location = new System.Drawing.Point(12, 237);
            this.btnMicroAltaLimpiar.Name = "btnMicroAltaLimpiar";
            this.btnMicroAltaLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnMicroAltaLimpiar.TabIndex = 9;
            this.btnMicroAltaLimpiar.Text = "Limpiar";
            this.btnMicroAltaLimpiar.UseVisualStyleBackColor = true;
            // 
            // lblMicroAltaModelo
            // 
            this.lblMicroAltaModelo.AutoSize = true;
            this.lblMicroAltaModelo.Location = new System.Drawing.Point(88, 80);
            this.lblMicroAltaModelo.Name = "lblMicroAltaModelo";
            this.lblMicroAltaModelo.Size = new System.Drawing.Size(42, 13);
            this.lblMicroAltaModelo.TabIndex = 10;
            this.lblMicroAltaModelo.Text = "Modelo";
            // 
            // cbbMicroAltaTipoModelo
            // 
            this.cbbMicroAltaTipoModelo.FormattingEnabled = true;
            this.cbbMicroAltaTipoModelo.Location = new System.Drawing.Point(288, 71);
            this.cbbMicroAltaTipoModelo.Name = "cbbMicroAltaTipoModelo";
            this.cbbMicroAltaTipoModelo.Size = new System.Drawing.Size(121, 21);
            this.cbbMicroAltaTipoModelo.TabIndex = 11;
            // 
            // mtbMicroAltaCantidadButacas
            // 
            this.mtbMicroAltaCantidadButacas.Location = new System.Drawing.Point(288, 147);
            this.mtbMicroAltaCantidadButacas.Mask = "99999";
            this.mtbMicroAltaCantidadButacas.Name = "mtbMicroAltaCantidadButacas";
            this.mtbMicroAltaCantidadButacas.Size = new System.Drawing.Size(121, 20);
            this.mtbMicroAltaCantidadButacas.TabIndex = 12;
            this.mtbMicroAltaCantidadButacas.ValidatingType = typeof(int);
            // 
            // mtbMicroAltaKgsEncomiendas
            // 
            this.mtbMicroAltaKgsEncomiendas.Location = new System.Drawing.Point(288, 185);
            this.mtbMicroAltaKgsEncomiendas.Mask = "99999";
            this.mtbMicroAltaKgsEncomiendas.Name = "mtbMicroAltaKgsEncomiendas";
            this.mtbMicroAltaKgsEncomiendas.Size = new System.Drawing.Size(121, 20);
            this.mtbMicroAltaKgsEncomiendas.TabIndex = 13;
            this.mtbMicroAltaKgsEncomiendas.ValidatingType = typeof(int);
            // 
            // MicroAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 272);
            this.Controls.Add(this.mtbMicroAltaKgsEncomiendas);
            this.Controls.Add(this.mtbMicroAltaCantidadButacas);
            this.Controls.Add(this.cbbMicroAltaTipoModelo);
            this.Controls.Add(this.lblMicroAltaModelo);
            this.Controls.Add(this.btnMicroAltaLimpiar);
            this.Controls.Add(this.btnMicroAltaGuardar);
            this.Controls.Add(this.lblMicroAltaKgsEncomiendas);
            this.Controls.Add(this.cbbMicroAltaTipoEmpresa);
            this.Controls.Add(this.lblMicroAltaTipoEmpresa);
            this.Controls.Add(this.lblMicroAltaCantidadButacas);
            this.Controls.Add(this.lblMicroAltaTipoServicio);
            this.Controls.Add(this.cbbMicroAltaTipoServicio);
            this.Name = "MicroAlta";
            this.Text = "MicroAlta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbMicroAltaTipoServicio;
        private System.Windows.Forms.Label lblMicroAltaTipoServicio;
        private System.Windows.Forms.Label lblMicroAltaCantidadButacas;
        private System.Windows.Forms.Label lblMicroAltaTipoEmpresa;
        private System.Windows.Forms.ComboBox cbbMicroAltaTipoEmpresa;
        private System.Windows.Forms.Label lblMicroAltaKgsEncomiendas;
        private System.Windows.Forms.Button btnMicroAltaGuardar;
        private System.Windows.Forms.Button btnMicroAltaLimpiar;
        private System.Windows.Forms.Label lblMicroAltaModelo;
        private System.Windows.Forms.ComboBox cbbMicroAltaTipoModelo;
        private System.Windows.Forms.MaskedTextBox mtbMicroAltaCantidadButacas;
        private System.Windows.Forms.MaskedTextBox mtbMicroAltaKgsEncomiendas;
    }
}