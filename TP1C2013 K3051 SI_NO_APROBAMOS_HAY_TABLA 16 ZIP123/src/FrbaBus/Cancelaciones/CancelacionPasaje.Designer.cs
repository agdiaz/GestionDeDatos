namespace FrbaBus.Cancelaciones
{
    partial class CancelacionPasaje
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
            this.btnCancelacionPasajeCancelarPasaje = new System.Windows.Forms.Button();
            this.tbCancelacionPasaje = new System.Windows.Forms.TextBox();
            this.lblCancelacionPasajePasaje = new System.Windows.Forms.Label();
            this.btnCancelacionPasajeBuscarCompra = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancelacionPasajeCancelarPasaje
            // 
            this.btnCancelacionPasajeCancelarPasaje.Location = new System.Drawing.Point(281, 78);
            this.btnCancelacionPasajeCancelarPasaje.Name = "btnCancelacionPasajeCancelarPasaje";
            this.btnCancelacionPasajeCancelarPasaje.Size = new System.Drawing.Size(119, 23);
            this.btnCancelacionPasajeCancelarPasaje.TabIndex = 15;
            this.btnCancelacionPasajeCancelarPasaje.Text = "Cancelar Pasaje";
            this.btnCancelacionPasajeCancelarPasaje.UseVisualStyleBackColor = true;
            this.btnCancelacionPasajeCancelarPasaje.Click += new System.EventHandler(this.btnCancelacionPasajeCancelarPasaje_Click);
            // 
            // tbCancelacionPasaje
            // 
            this.tbCancelacionPasaje.Location = new System.Drawing.Point(146, 18);
            this.tbCancelacionPasaje.Name = "tbCancelacionPasaje";
            this.tbCancelacionPasaje.Size = new System.Drawing.Size(115, 20);
            this.tbCancelacionPasaje.TabIndex = 13;
            // 
            // lblCancelacionPasajePasaje
            // 
            this.lblCancelacionPasajePasaje.AutoSize = true;
            this.lblCancelacionPasajePasaje.Location = new System.Drawing.Point(101, 18);
            this.lblCancelacionPasajePasaje.Name = "lblCancelacionPasajePasaje";
            this.lblCancelacionPasajePasaje.Size = new System.Drawing.Size(39, 13);
            this.lblCancelacionPasajePasaje.TabIndex = 10;
            this.lblCancelacionPasajePasaje.Text = "Pasaje";
            // 
            // btnCancelacionPasajeBuscarCompra
            // 
            this.btnCancelacionPasajeBuscarCompra.Location = new System.Drawing.Point(14, 12);
            this.btnCancelacionPasajeBuscarCompra.Name = "btnCancelacionPasajeBuscarCompra";
            this.btnCancelacionPasajeBuscarCompra.Size = new System.Drawing.Size(75, 23);
            this.btnCancelacionPasajeBuscarCompra.TabIndex = 18;
            this.btnCancelacionPasajeBuscarCompra.Text = "Buscar";
            this.btnCancelacionPasajeBuscarCompra.UseVisualStyleBackColor = true;
            this.btnCancelacionPasajeBuscarCompra.Click += new System.EventHandler(this.btnCancelacionPasajeBuscarCompra_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Motivo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(57, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(343, 20);
            this.textBox1.TabIndex = 23;
            // 
            // CancelacionPasaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 110);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelacionPasajeBuscarCompra);
            this.Controls.Add(this.btnCancelacionPasajeCancelarPasaje);
            this.Controls.Add(this.tbCancelacionPasaje);
            this.Controls.Add(this.lblCancelacionPasajePasaje);
            this.Name = "CancelacionPasaje";
            this.Text = "Cancelar Pasaje";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelacionPasajeCancelarPasaje;
        private System.Windows.Forms.TextBox tbCancelacionPasaje;
        private System.Windows.Forms.Label lblCancelacionPasajePasaje;
        private System.Windows.Forms.Button btnCancelacionPasajeBuscarCompra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;

    }
}