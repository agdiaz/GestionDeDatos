namespace FrbaBus.Abm_Micro
{
    partial class MicroDecision
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnReasignar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(13, 13);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(311, 29);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar todos los viajes asociados";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnReasignar
            // 
            this.btnReasignar.Location = new System.Drawing.Point(13, 49);
            this.btnReasignar.Name = "btnReasignar";
            this.btnReasignar.Size = new System.Drawing.Size(311, 28);
            this.btnReasignar.TabIndex = 1;
            this.btnReasignar.Text = "Reasignar un micro a todos los viajes asociados";
            this.btnReasignar.UseVisualStyleBackColor = true;
            this.btnReasignar.Click += new System.EventHandler(this.btnReasignar_Click);
            // 
            // MicroDecision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 99);
            this.Controls.Add(this.btnReasignar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "MicroDecision";
            this.Text = "MicroDecision";
            this.Load += new System.EventHandler(this.MicroDecision_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnReasignar;
    }
}