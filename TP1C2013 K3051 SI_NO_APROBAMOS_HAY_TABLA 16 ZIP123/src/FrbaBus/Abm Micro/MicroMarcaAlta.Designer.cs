namespace FrbaBus.Abm_Micro
{
    partial class MicroMarcaAlta
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
            this.lblMicroMarcaAltaMarca = new System.Windows.Forms.Label();
            this.tbMicroMarcaAltaMarca = new System.Windows.Forms.TextBox();
            this.btnMicroMarcaAltaLimpiar = new System.Windows.Forms.Button();
            this.btnMicroMarcaAltaGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMicroMarcaAltaMarca
            // 
            this.lblMicroMarcaAltaMarca.AutoSize = true;
            this.lblMicroMarcaAltaMarca.Location = new System.Drawing.Point(12, 19);
            this.lblMicroMarcaAltaMarca.Name = "lblMicroMarcaAltaMarca";
            this.lblMicroMarcaAltaMarca.Size = new System.Drawing.Size(37, 13);
            this.lblMicroMarcaAltaMarca.TabIndex = 0;
            this.lblMicroMarcaAltaMarca.Text = "Marca";
            // 
            // tbMicroMarcaAltaMarca
            // 
            this.tbMicroMarcaAltaMarca.Location = new System.Drawing.Point(92, 16);
            this.tbMicroMarcaAltaMarca.Name = "tbMicroMarcaAltaMarca";
            this.tbMicroMarcaAltaMarca.Size = new System.Drawing.Size(100, 20);
            this.tbMicroMarcaAltaMarca.TabIndex = 1;
            // 
            // btnMicroMarcaAltaLimpiar
            // 
            this.btnMicroMarcaAltaLimpiar.Location = new System.Drawing.Point(12, 81);
            this.btnMicroMarcaAltaLimpiar.Name = "btnMicroMarcaAltaLimpiar";
            this.btnMicroMarcaAltaLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnMicroMarcaAltaLimpiar.TabIndex = 2;
            this.btnMicroMarcaAltaLimpiar.Text = "Limpiar";
            this.btnMicroMarcaAltaLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnMicroMarcaAltaGuardar
            // 
            this.btnMicroMarcaAltaGuardar.Location = new System.Drawing.Point(295, 81);
            this.btnMicroMarcaAltaGuardar.Name = "btnMicroMarcaAltaGuardar";
            this.btnMicroMarcaAltaGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnMicroMarcaAltaGuardar.TabIndex = 3;
            this.btnMicroMarcaAltaGuardar.Text = "Guardar";
            this.btnMicroMarcaAltaGuardar.UseVisualStyleBackColor = true;
            // 
            // MicroMarcaAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 119);
            this.Controls.Add(this.btnMicroMarcaAltaGuardar);
            this.Controls.Add(this.btnMicroMarcaAltaLimpiar);
            this.Controls.Add(this.tbMicroMarcaAltaMarca);
            this.Controls.Add(this.lblMicroMarcaAltaMarca);
            this.Name = "MicroMarcaAlta";
            this.Text = "Alta Marca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMicroMarcaAltaMarca;
        private System.Windows.Forms.TextBox tbMicroMarcaAltaMarca;
        private System.Windows.Forms.Button btnMicroMarcaAltaLimpiar;
        private System.Windows.Forms.Button btnMicroMarcaAltaGuardar;
    }
}