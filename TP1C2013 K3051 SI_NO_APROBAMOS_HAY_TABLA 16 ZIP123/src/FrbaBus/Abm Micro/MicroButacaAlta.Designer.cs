namespace FrbaBus.Abm_Micro
{
    partial class MicroButacaAlta
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
            this.lblMicroButacaAltaMicro = new System.Windows.Forms.Label();
            this.lblMicroButacaAltaButaca = new System.Windows.Forms.Label();
            this.tbMicroButacaAltaMicro = new System.Windows.Forms.TextBox();
            this.tbMicroButacaAltaButaca = new System.Windows.Forms.TextBox();
            this.btnMicroButacaAltaLimpiar = new System.Windows.Forms.Button();
            this.btnMicroButacaAltaGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMicroButacaAltaMicro
            // 
            this.lblMicroButacaAltaMicro.AutoSize = true;
            this.lblMicroButacaAltaMicro.Location = new System.Drawing.Point(13, 13);
            this.lblMicroButacaAltaMicro.Name = "lblMicroButacaAltaMicro";
            this.lblMicroButacaAltaMicro.Size = new System.Drawing.Size(33, 13);
            this.lblMicroButacaAltaMicro.TabIndex = 0;
            this.lblMicroButacaAltaMicro.Text = "Micro";
            // 
            // lblMicroButacaAltaButaca
            // 
            this.lblMicroButacaAltaButaca.AutoSize = true;
            this.lblMicroButacaAltaButaca.Location = new System.Drawing.Point(13, 44);
            this.lblMicroButacaAltaButaca.Name = "lblMicroButacaAltaButaca";
            this.lblMicroButacaAltaButaca.Size = new System.Drawing.Size(41, 13);
            this.lblMicroButacaAltaButaca.TabIndex = 1;
            this.lblMicroButacaAltaButaca.Text = "Butaca";
            // 
            // tbMicroButacaAltaMicro
            // 
            this.tbMicroButacaAltaMicro.Location = new System.Drawing.Point(71, 10);
            this.tbMicroButacaAltaMicro.Name = "tbMicroButacaAltaMicro";
            this.tbMicroButacaAltaMicro.Size = new System.Drawing.Size(100, 20);
            this.tbMicroButacaAltaMicro.TabIndex = 2;
            // 
            // tbMicroButacaAltaButaca
            // 
            this.tbMicroButacaAltaButaca.Location = new System.Drawing.Point(71, 41);
            this.tbMicroButacaAltaButaca.Name = "tbMicroButacaAltaButaca";
            this.tbMicroButacaAltaButaca.Size = new System.Drawing.Size(100, 20);
            this.tbMicroButacaAltaButaca.TabIndex = 3;
            // 
            // btnMicroButacaAltaLimpiar
            // 
            this.btnMicroButacaAltaLimpiar.Location = new System.Drawing.Point(17, 115);
            this.btnMicroButacaAltaLimpiar.Name = "btnMicroButacaAltaLimpiar";
            this.btnMicroButacaAltaLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnMicroButacaAltaLimpiar.TabIndex = 4;
            this.btnMicroButacaAltaLimpiar.Text = "Limpiar";
            this.btnMicroButacaAltaLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnMicroButacaAltaGuardar
            // 
            this.btnMicroButacaAltaGuardar.Location = new System.Drawing.Point(350, 115);
            this.btnMicroButacaAltaGuardar.Name = "btnMicroButacaAltaGuardar";
            this.btnMicroButacaAltaGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnMicroButacaAltaGuardar.TabIndex = 5;
            this.btnMicroButacaAltaGuardar.Text = "Guardar";
            this.btnMicroButacaAltaGuardar.UseVisualStyleBackColor = true;
            // 
            // MicroButacaAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 154);
            this.Controls.Add(this.btnMicroButacaAltaGuardar);
            this.Controls.Add(this.btnMicroButacaAltaLimpiar);
            this.Controls.Add(this.tbMicroButacaAltaButaca);
            this.Controls.Add(this.tbMicroButacaAltaMicro);
            this.Controls.Add(this.lblMicroButacaAltaButaca);
            this.Controls.Add(this.lblMicroButacaAltaMicro);
            this.Name = "MicroButacaAlta";
            this.Text = "Alta Butaca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMicroButacaAltaMicro;
        private System.Windows.Forms.Label lblMicroButacaAltaButaca;
        private System.Windows.Forms.TextBox tbMicroButacaAltaMicro;
        private System.Windows.Forms.TextBox tbMicroButacaAltaButaca;
        private System.Windows.Forms.Button btnMicroButacaAltaLimpiar;
        private System.Windows.Forms.Button btnMicroButacaAltaGuardar;
    }
}