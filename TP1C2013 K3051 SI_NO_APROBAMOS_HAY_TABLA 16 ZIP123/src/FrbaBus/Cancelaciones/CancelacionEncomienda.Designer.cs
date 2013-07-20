namespace FrbaBus.Cancelaciones
{
    partial class CancelacionEncomienda
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
            this.lblCancelacionEncomiendaEncomienda = new System.Windows.Forms.Label();
            this.tbCancelacionEncomiendaEncomienda = new System.Windows.Forms.TextBox();
            this.btnCancelacionEncomiendaCancelarEncomienda = new System.Windows.Forms.Button();
            this.btnCancelacionEncomiendaBuscarCompra = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCancelacionEncomiendaEncomienda
            // 
            this.lblCancelacionEncomiendaEncomienda.AutoSize = true;
            this.lblCancelacionEncomiendaEncomienda.Location = new System.Drawing.Point(96, 21);
            this.lblCancelacionEncomiendaEncomienda.Name = "lblCancelacionEncomiendaEncomienda";
            this.lblCancelacionEncomiendaEncomienda.Size = new System.Drawing.Size(66, 13);
            this.lblCancelacionEncomiendaEncomienda.TabIndex = 1;
            this.lblCancelacionEncomiendaEncomienda.Text = "Encomienda";
            // 
            // tbCancelacionEncomiendaEncomienda
            // 
            this.tbCancelacionEncomiendaEncomienda.Location = new System.Drawing.Point(168, 18);
            this.tbCancelacionEncomiendaEncomienda.Name = "tbCancelacionEncomiendaEncomienda";
            this.tbCancelacionEncomiendaEncomienda.Size = new System.Drawing.Size(113, 20);
            this.tbCancelacionEncomiendaEncomienda.TabIndex = 4;
            // 
            // btnCancelacionEncomiendaCancelarEncomienda
            // 
            this.btnCancelacionEncomiendaCancelarEncomienda.Location = new System.Drawing.Point(287, 81);
            this.btnCancelacionEncomiendaCancelarEncomienda.Name = "btnCancelacionEncomiendaCancelarEncomienda";
            this.btnCancelacionEncomiendaCancelarEncomienda.Size = new System.Drawing.Size(119, 23);
            this.btnCancelacionEncomiendaCancelarEncomienda.TabIndex = 6;
            this.btnCancelacionEncomiendaCancelarEncomienda.Text = "Cancelar Encomienda";
            this.btnCancelacionEncomiendaCancelarEncomienda.UseVisualStyleBackColor = true;
            // 
            // btnCancelacionEncomiendaBuscarCompra
            // 
            this.btnCancelacionEncomiendaBuscarCompra.Location = new System.Drawing.Point(15, 16);
            this.btnCancelacionEncomiendaBuscarCompra.Name = "btnCancelacionEncomiendaBuscarCompra";
            this.btnCancelacionEncomiendaBuscarCompra.Size = new System.Drawing.Size(75, 23);
            this.btnCancelacionEncomiendaBuscarCompra.TabIndex = 9;
            this.btnCancelacionEncomiendaBuscarCompra.Text = " Buscar";
            this.btnCancelacionEncomiendaBuscarCompra.UseVisualStyleBackColor = true;
            this.btnCancelacionEncomiendaBuscarCompra.Click += new System.EventHandler(this.btnCancelacionEncomiendaBuscarCompra_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Motivo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(294, 20);
            this.textBox1.TabIndex = 14;
            // 
            // CancelacionEncomienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 118);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelacionEncomiendaBuscarCompra);
            this.Controls.Add(this.btnCancelacionEncomiendaCancelarEncomienda);
            this.Controls.Add(this.tbCancelacionEncomiendaEncomienda);
            this.Controls.Add(this.lblCancelacionEncomiendaEncomienda);
            this.Name = "CancelacionEncomienda";
            this.Text = "Cancelar Encomienda";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCancelacionEncomiendaEncomienda;
        private System.Windows.Forms.TextBox tbCancelacionEncomiendaEncomienda;
        private System.Windows.Forms.Button btnCancelacionEncomiendaCancelarEncomienda;
        private System.Windows.Forms.Button btnCancelacionEncomiendaBuscarCompra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}