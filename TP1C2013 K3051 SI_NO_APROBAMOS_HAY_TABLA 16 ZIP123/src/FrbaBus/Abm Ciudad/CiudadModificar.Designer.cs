namespace FrbaBus.Abm_Ciudad
{
    partial class CiudadModificar
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
            this.lblCiudadModificarCiudad = new System.Windows.Forms.Label();
            this.btnCiudadModificarLimpiar = new System.Windows.Forms.Button();
            this.btnCiudadModificarGuardar = new System.Windows.Forms.Button();
            this.tbCiudadModificarCiudad = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCiudadModificarCiudad
            // 
            this.lblCiudadModificarCiudad.AutoSize = true;
            this.lblCiudadModificarCiudad.Location = new System.Drawing.Point(12, 9);
            this.lblCiudadModificarCiudad.Name = "lblCiudadModificarCiudad";
            this.lblCiudadModificarCiudad.Size = new System.Drawing.Size(40, 13);
            this.lblCiudadModificarCiudad.TabIndex = 0;
            this.lblCiudadModificarCiudad.Text = "Ciudad";
            // 
            // btnCiudadModificarLimpiar
            // 
            this.btnCiudadModificarLimpiar.Location = new System.Drawing.Point(216, 32);
            this.btnCiudadModificarLimpiar.Name = "btnCiudadModificarLimpiar";
            this.btnCiudadModificarLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnCiudadModificarLimpiar.TabIndex = 1;
            this.btnCiudadModificarLimpiar.Text = "Limpiar";
            this.btnCiudadModificarLimpiar.UseVisualStyleBackColor = true;
            this.btnCiudadModificarLimpiar.Click += new System.EventHandler(this.btnCiudadModificarLimpiar_Click);
            // 
            // btnCiudadModificarGuardar
            // 
            this.btnCiudadModificarGuardar.Location = new System.Drawing.Point(297, 32);
            this.btnCiudadModificarGuardar.Name = "btnCiudadModificarGuardar";
            this.btnCiudadModificarGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnCiudadModificarGuardar.TabIndex = 2;
            this.btnCiudadModificarGuardar.Text = "Guardar";
            this.btnCiudadModificarGuardar.UseVisualStyleBackColor = true;
            this.btnCiudadModificarGuardar.Click += new System.EventHandler(this.btnCiudadModificarGuardar_Click);
            // 
            // tbCiudadModificarCiudad
            // 
            this.tbCiudadModificarCiudad.Location = new System.Drawing.Point(71, 6);
            this.tbCiudadModificarCiudad.Name = "tbCiudadModificarCiudad";
            this.tbCiudadModificarCiudad.Size = new System.Drawing.Size(301, 20);
            this.tbCiudadModificarCiudad.TabIndex = 0;
            // 
            // CiudadModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 62);
            this.Controls.Add(this.tbCiudadModificarCiudad);
            this.Controls.Add(this.btnCiudadModificarGuardar);
            this.Controls.Add(this.btnCiudadModificarLimpiar);
            this.Controls.Add(this.lblCiudadModificarCiudad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CiudadModificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrbaBus - Ciudades :: Modificar";
            this.Load += new System.EventHandler(this.CiudadModificar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCiudadModificarCiudad;
        private System.Windows.Forms.Button btnCiudadModificarLimpiar;
        private System.Windows.Forms.Button btnCiudadModificarGuardar;
        private System.Windows.Forms.TextBox tbCiudadModificarCiudad;
    }
}