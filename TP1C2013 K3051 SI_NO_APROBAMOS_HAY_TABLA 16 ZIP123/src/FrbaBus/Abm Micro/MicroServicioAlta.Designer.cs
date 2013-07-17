namespace FrbaBus.Abm_Micro
{
    partial class MicroServicioAlta
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
            this.lblMicroServicioAltaTipoServicio = new System.Windows.Forms.Label();
            this.tbMicroServicioAltaTipoServicio = new System.Windows.Forms.TextBox();
            this.btnMicroServicioAltaLimpiar = new System.Windows.Forms.Button();
            this.btnMicroServicioAltaGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMicroServicioAltaTipoServicio
            // 
            this.lblMicroServicioAltaTipoServicio.AutoSize = true;
            this.lblMicroServicioAltaTipoServicio.Location = new System.Drawing.Point(12, 9);
            this.lblMicroServicioAltaTipoServicio.Name = "lblMicroServicioAltaTipoServicio";
            this.lblMicroServicioAltaTipoServicio.Size = new System.Drawing.Size(82, 13);
            this.lblMicroServicioAltaTipoServicio.TabIndex = 0;
            this.lblMicroServicioAltaTipoServicio.Text = "Tipo de servicio";
            // 
            // tbMicroServicioAltaTipoServicio
            // 
            this.tbMicroServicioAltaTipoServicio.Location = new System.Drawing.Point(109, 6);
            this.tbMicroServicioAltaTipoServicio.Name = "tbMicroServicioAltaTipoServicio";
            this.tbMicroServicioAltaTipoServicio.Size = new System.Drawing.Size(253, 20);
            this.tbMicroServicioAltaTipoServicio.TabIndex = 1;
            // 
            // btnMicroServicioAltaLimpiar
            // 
            this.btnMicroServicioAltaLimpiar.Location = new System.Drawing.Point(278, 32);
            this.btnMicroServicioAltaLimpiar.Name = "btnMicroServicioAltaLimpiar";
            this.btnMicroServicioAltaLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnMicroServicioAltaLimpiar.TabIndex = 2;
            this.btnMicroServicioAltaLimpiar.Text = "Limpiar";
            this.btnMicroServicioAltaLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnMicroServicioAltaGuardar
            // 
            this.btnMicroServicioAltaGuardar.Location = new System.Drawing.Point(197, 32);
            this.btnMicroServicioAltaGuardar.Name = "btnMicroServicioAltaGuardar";
            this.btnMicroServicioAltaGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnMicroServicioAltaGuardar.TabIndex = 3;
            this.btnMicroServicioAltaGuardar.Text = "Guardar";
            this.btnMicroServicioAltaGuardar.UseVisualStyleBackColor = true;
            this.btnMicroServicioAltaGuardar.Click += new System.EventHandler(this.btnMicroServicioAltaGuardar_Click);
            // 
            // MicroServicioAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 58);
            this.Controls.Add(this.btnMicroServicioAltaGuardar);
            this.Controls.Add(this.btnMicroServicioAltaLimpiar);
            this.Controls.Add(this.tbMicroServicioAltaTipoServicio);
            this.Controls.Add(this.lblMicroServicioAltaTipoServicio);
            this.Location = new System.Drawing.Point(71, 6);
            this.Name = "MicroServicioAlta";
            this.Text = "Alta Servicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMicroServicioAltaTipoServicio;
        private System.Windows.Forms.TextBox tbMicroServicioAltaTipoServicio;
        private System.Windows.Forms.Button btnMicroServicioAltaLimpiar;
        private System.Windows.Forms.Button btnMicroServicioAltaGuardar;
    }
}