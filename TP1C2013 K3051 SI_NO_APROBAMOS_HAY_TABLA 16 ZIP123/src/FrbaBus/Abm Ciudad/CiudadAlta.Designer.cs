namespace FrbaBus.Abm_Ciudad
{
    partial class CiudadAlta
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
            this.lblCiudadAltaCiudad = new System.Windows.Forms.Label();
            this.btnCiudadAltaLimpiar = new System.Windows.Forms.Button();
            this.btnCiudadAltaGuardar = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // lblCiudadAltaCiudad
            // 
            this.lblCiudadAltaCiudad.AutoSize = true;
            this.lblCiudadAltaCiudad.Location = new System.Drawing.Point(37, 33);
            this.lblCiudadAltaCiudad.Name = "lblCiudadAltaCiudad";
            this.lblCiudadAltaCiudad.Size = new System.Drawing.Size(40, 13);
            this.lblCiudadAltaCiudad.TabIndex = 0;
            this.lblCiudadAltaCiudad.Text = "Ciudad";
            // 
            // btnCiudadAltaLimpiar
            // 
            this.btnCiudadAltaLimpiar.Location = new System.Drawing.Point(13, 116);
            this.btnCiudadAltaLimpiar.Name = "btnCiudadAltaLimpiar";
            this.btnCiudadAltaLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnCiudadAltaLimpiar.TabIndex = 2;
            this.btnCiudadAltaLimpiar.Text = "Limpiar";
            this.btnCiudadAltaLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnCiudadAltaGuardar
            // 
            this.btnCiudadAltaGuardar.Location = new System.Drawing.Point(551, 116);
            this.btnCiudadAltaGuardar.Name = "btnCiudadAltaGuardar";
            this.btnCiudadAltaGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnCiudadAltaGuardar.TabIndex = 3;
            this.btnCiudadAltaGuardar.Text = "Guardar";
            this.btnCiudadAltaGuardar.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(152, 33);
            this.maskedTextBox1.Mask = "[a-zA-Z]?";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 4;
            // 
            // CiudadAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 151);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.btnCiudadAltaGuardar);
            this.Controls.Add(this.btnCiudadAltaLimpiar);
            this.Controls.Add(this.lblCiudadAltaCiudad);
            this.Name = "CiudadAlta";
            this.Text = "Alta ciudad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCiudadAltaCiudad;
        private System.Windows.Forms.Button btnCiudadAltaLimpiar;
        private System.Windows.Forms.Button btnCiudadAltaGuardar;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
    }
}