namespace FrbaBus.Compras
{
    partial class PasajeAlta
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbMicro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.tbCliente = new System.Windows.Forms.TextBox();
            this.tbButaca = new System.Windows.Forms.TextBox();
            this.btnSeleccionarButaca = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPrecio = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Micro:";
            // 
            // tbMicro
            // 
            this.tbMicro.Location = new System.Drawing.Point(63, 38);
            this.tbMicro.Name = "tbMicro";
            this.tbMicro.Size = new System.Drawing.Size(240, 20);
            this.tbMicro.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Butaca:";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Location = new System.Drawing.Point(309, 62);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(114, 23);
            this.btnBuscarCliente.TabIndex = 4;
            this.btnBuscarCliente.Text = "Seleccionar cliente";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // tbCliente
            // 
            this.tbCliente.Location = new System.Drawing.Point(63, 64);
            this.tbCliente.Name = "tbCliente";
            this.tbCliente.Size = new System.Drawing.Size(240, 20);
            this.tbCliente.TabIndex = 5;
            // 
            // tbButaca
            // 
            this.tbButaca.Location = new System.Drawing.Point(63, 90);
            this.tbButaca.Name = "tbButaca";
            this.tbButaca.Size = new System.Drawing.Size(238, 20);
            this.tbButaca.TabIndex = 6;
            // 
            // btnSeleccionarButaca
            // 
            this.btnSeleccionarButaca.Location = new System.Drawing.Point(309, 87);
            this.btnSeleccionarButaca.Name = "btnSeleccionarButaca";
            this.btnSeleccionarButaca.Size = new System.Drawing.Size(114, 23);
            this.btnSeleccionarButaca.TabIndex = 7;
            this.btnSeleccionarButaca.Text = "Seleccionar butaca";
            this.btnSeleccionarButaca.UseVisualStyleBackColor = true;
            this.btnSeleccionarButaca.Click += new System.EventHandler(this.btnSeleccionarButaca_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(369, 165);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(288, 165);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Precio:";
            // 
            // tbPrecio
            // 
            this.tbPrecio.Enabled = false;
            this.tbPrecio.Location = new System.Drawing.Point(63, 116);
            this.tbPrecio.Name = "tbPrecio";
            this.tbPrecio.Size = new System.Drawing.Size(100, 20);
            this.tbPrecio.TabIndex = 11;
            // 
            // PasajeAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 200);
            this.Controls.Add(this.tbPrecio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnSeleccionarButaca);
            this.Controls.Add(this.tbButaca);
            this.Controls.Add(this.tbCliente);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMicro);
            this.Controls.Add(this.label1);
            this.Name = "PasajeAlta";
            this.Text = "FrbaBus - Pasajes :: Alta";
            this.Load += new System.EventHandler(this.PasajeAlta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMicro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TextBox tbCliente;
        private System.Windows.Forms.TextBox tbButaca;
        private System.Windows.Forms.Button btnSeleccionarButaca;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPrecio;
    }
}