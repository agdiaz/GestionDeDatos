namespace FrbaBus.Cancelaciones
{
    partial class CancelacionCompra
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
            this.btnBuscarCompraCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCompra = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMotivo = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBuscarCompraCancel
            // 
            this.btnBuscarCompraCancel.Location = new System.Drawing.Point(12, 12);
            this.btnBuscarCompraCancel.Name = "btnBuscarCompraCancel";
            this.btnBuscarCompraCancel.Size = new System.Drawing.Size(89, 23);
            this.btnBuscarCompraCancel.TabIndex = 0;
            this.btnBuscarCompraCancel.Text = "Buscar compra";
            this.btnBuscarCompraCancel.UseVisualStyleBackColor = true;
            this.btnBuscarCompraCancel.Click += new System.EventHandler(this.btnBuscarCompraCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID compra";
            // 
            // tbCompra
            // 
            this.tbCompra.Location = new System.Drawing.Point(178, 14);
            this.tbCompra.Name = "tbCompra";
            this.tbCompra.Size = new System.Drawing.Size(135, 20);
            this.tbCompra.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Motivo";
            // 
            // tbMotivo
            // 
            this.tbMotivo.Location = new System.Drawing.Point(84, 45);
            this.tbMotivo.Name = "tbMotivo";
            this.tbMotivo.Size = new System.Drawing.Size(135, 20);
            this.tbMotivo.TabIndex = 7;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(215, 76);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar compra";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // CancelacionCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 111);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.tbMotivo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCompra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscarCompraCancel);
            this.Name = "CancelacionCompra";
            this.Text = "CancelacionCompra";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarCompraCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCompra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMotivo;
        private System.Windows.Forms.Button btnCancelar;

    }
}