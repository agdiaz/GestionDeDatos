namespace FrbaBus.Abm_Recorrido
{
    partial class RecorridoModificar
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
            this.lblRecorridoModificarCiudadOrigen = new System.Windows.Forms.Label();
            this.lblRecorridoModificarCiudadDestino = new System.Windows.Forms.Label();
            this.lblRecorridoModificarTipoServicio = new System.Windows.Forms.Label();
            this.cbbRecorridoModificarTipoServicio = new System.Windows.Forms.ComboBox();
            this.btnRecorridoModificarLimpiar = new System.Windows.Forms.Button();
            this.btnRecorridoModificarGuardar = new System.Windows.Forms.Button();
            this.lblRecorridoModificarPrecioBasePorKgs = new System.Windows.Forms.Label();
            this.lblRecorridoModificarPrecioBasePorPasaje = new System.Windows.Forms.Label();
            this.tbRecorridoModificarPrecioBasePorKgs = new System.Windows.Forms.TextBox();
            this.tbRecorridoModificarPrecioBasePorPasaje = new System.Windows.Forms.TextBox();
            this.cbCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.cbCiudadDestino = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblRecorridoModificarCiudadOrigen
            // 
            this.lblRecorridoModificarCiudadOrigen.AutoSize = true;
            this.lblRecorridoModificarCiudadOrigen.Location = new System.Drawing.Point(12, 20);
            this.lblRecorridoModificarCiudadOrigen.Name = "lblRecorridoModificarCiudadOrigen";
            this.lblRecorridoModificarCiudadOrigen.Size = new System.Drawing.Size(72, 13);
            this.lblRecorridoModificarCiudadOrigen.TabIndex = 0;
            this.lblRecorridoModificarCiudadOrigen.Text = "Ciudad origen";
            // 
            // lblRecorridoModificarCiudadDestino
            // 
            this.lblRecorridoModificarCiudadDestino.AutoSize = true;
            this.lblRecorridoModificarCiudadDestino.Location = new System.Drawing.Point(12, 50);
            this.lblRecorridoModificarCiudadDestino.Name = "lblRecorridoModificarCiudadDestino";
            this.lblRecorridoModificarCiudadDestino.Size = new System.Drawing.Size(77, 13);
            this.lblRecorridoModificarCiudadDestino.TabIndex = 1;
            this.lblRecorridoModificarCiudadDestino.Text = "Ciudad destino";
            // 
            // lblRecorridoModificarTipoServicio
            // 
            this.lblRecorridoModificarTipoServicio.AutoSize = true;
            this.lblRecorridoModificarTipoServicio.Location = new System.Drawing.Point(12, 77);
            this.lblRecorridoModificarTipoServicio.Name = "lblRecorridoModificarTipoServicio";
            this.lblRecorridoModificarTipoServicio.Size = new System.Drawing.Size(82, 13);
            this.lblRecorridoModificarTipoServicio.TabIndex = 2;
            this.lblRecorridoModificarTipoServicio.Text = "Tipo de servicio";
            // 
            // cbbRecorridoModificarTipoServicio
            // 
            this.cbbRecorridoModificarTipoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRecorridoModificarTipoServicio.FormattingEnabled = true;
            this.cbbRecorridoModificarTipoServicio.Location = new System.Drawing.Point(140, 74);
            this.cbbRecorridoModificarTipoServicio.Name = "cbbRecorridoModificarTipoServicio";
            this.cbbRecorridoModificarTipoServicio.Size = new System.Drawing.Size(187, 21);
            this.cbbRecorridoModificarTipoServicio.TabIndex = 2;
            // 
            // btnRecorridoModificarLimpiar
            // 
            this.btnRecorridoModificarLimpiar.Location = new System.Drawing.Point(95, 175);
            this.btnRecorridoModificarLimpiar.Name = "btnRecorridoModificarLimpiar";
            this.btnRecorridoModificarLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnRecorridoModificarLimpiar.TabIndex = 6;
            this.btnRecorridoModificarLimpiar.Text = "Limpiar";
            this.btnRecorridoModificarLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnRecorridoModificarGuardar
            // 
            this.btnRecorridoModificarGuardar.Location = new System.Drawing.Point(14, 175);
            this.btnRecorridoModificarGuardar.Name = "btnRecorridoModificarGuardar";
            this.btnRecorridoModificarGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnRecorridoModificarGuardar.TabIndex = 5;
            this.btnRecorridoModificarGuardar.Text = "Guardar";
            this.btnRecorridoModificarGuardar.UseVisualStyleBackColor = true;
            this.btnRecorridoModificarGuardar.Click += new System.EventHandler(this.btnRecorridoModificarGuardar_Click);
            // 
            // lblRecorridoModificarPrecioBasePorKgs
            // 
            this.lblRecorridoModificarPrecioBasePorKgs.AutoSize = true;
            this.lblRecorridoModificarPrecioBasePorKgs.Location = new System.Drawing.Point(12, 104);
            this.lblRecorridoModificarPrecioBasePorKgs.Name = "lblRecorridoModificarPrecioBasePorKgs";
            this.lblRecorridoModificarPrecioBasePorKgs.Size = new System.Drawing.Size(102, 13);
            this.lblRecorridoModificarPrecioBasePorKgs.TabIndex = 8;
            this.lblRecorridoModificarPrecioBasePorKgs.Text = "Precio base por Kgs";
            // 
            // lblRecorridoModificarPrecioBasePorPasaje
            // 
            this.lblRecorridoModificarPrecioBasePorPasaje.AutoSize = true;
            this.lblRecorridoModificarPrecioBasePorPasaje.Location = new System.Drawing.Point(12, 130);
            this.lblRecorridoModificarPrecioBasePorPasaje.Name = "lblRecorridoModificarPrecioBasePorPasaje";
            this.lblRecorridoModificarPrecioBasePorPasaje.Size = new System.Drawing.Size(115, 13);
            this.lblRecorridoModificarPrecioBasePorPasaje.TabIndex = 9;
            this.lblRecorridoModificarPrecioBasePorPasaje.Text = "Precio base por pasaje";
            // 
            // tbRecorridoModificarPrecioBasePorKgs
            // 
            this.tbRecorridoModificarPrecioBasePorKgs.Location = new System.Drawing.Point(140, 101);
            this.tbRecorridoModificarPrecioBasePorKgs.Name = "tbRecorridoModificarPrecioBasePorKgs";
            this.tbRecorridoModificarPrecioBasePorKgs.Size = new System.Drawing.Size(187, 20);
            this.tbRecorridoModificarPrecioBasePorKgs.TabIndex = 3;
            // 
            // tbRecorridoModificarPrecioBasePorPasaje
            // 
            this.tbRecorridoModificarPrecioBasePorPasaje.Location = new System.Drawing.Point(140, 127);
            this.tbRecorridoModificarPrecioBasePorPasaje.Name = "tbRecorridoModificarPrecioBasePorPasaje";
            this.tbRecorridoModificarPrecioBasePorPasaje.Size = new System.Drawing.Size(187, 20);
            this.tbRecorridoModificarPrecioBasePorPasaje.TabIndex = 4;
            // 
            // cbCiudadOrigen
            // 
            this.cbCiudadOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCiudadOrigen.FormattingEnabled = true;
            this.cbCiudadOrigen.Location = new System.Drawing.Point(140, 17);
            this.cbCiudadOrigen.Name = "cbCiudadOrigen";
            this.cbCiudadOrigen.Size = new System.Drawing.Size(323, 21);
            this.cbCiudadOrigen.TabIndex = 0;
            // 
            // cbCiudadDestino
            // 
            this.cbCiudadDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCiudadDestino.FormattingEnabled = true;
            this.cbCiudadDestino.Location = new System.Drawing.Point(140, 47);
            this.cbCiudadDestino.Name = "cbCiudadDestino";
            this.cbCiudadDestino.Size = new System.Drawing.Size(323, 21);
            this.cbCiudadDestino.TabIndex = 1;
            // 
            // RecorridoModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 210);
            this.Controls.Add(this.cbCiudadDestino);
            this.Controls.Add(this.cbCiudadOrigen);
            this.Controls.Add(this.tbRecorridoModificarPrecioBasePorPasaje);
            this.Controls.Add(this.tbRecorridoModificarPrecioBasePorKgs);
            this.Controls.Add(this.lblRecorridoModificarPrecioBasePorPasaje);
            this.Controls.Add(this.lblRecorridoModificarPrecioBasePorKgs);
            this.Controls.Add(this.btnRecorridoModificarGuardar);
            this.Controls.Add(this.btnRecorridoModificarLimpiar);
            this.Controls.Add(this.cbbRecorridoModificarTipoServicio);
            this.Controls.Add(this.lblRecorridoModificarTipoServicio);
            this.Controls.Add(this.lblRecorridoModificarCiudadDestino);
            this.Controls.Add(this.lblRecorridoModificarCiudadOrigen);
            this.Name = "RecorridoModificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrbaBus - Recorridos :: Modificar";
            this.Load += new System.EventHandler(this.RecorridoModificar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecorridoModificarCiudadOrigen;
        private System.Windows.Forms.Label lblRecorridoModificarCiudadDestino;
        private System.Windows.Forms.Label lblRecorridoModificarTipoServicio;
        private System.Windows.Forms.ComboBox cbbRecorridoModificarTipoServicio;
        private System.Windows.Forms.Button btnRecorridoModificarLimpiar;
        private System.Windows.Forms.Button btnRecorridoModificarGuardar;
        private System.Windows.Forms.Label lblRecorridoModificarPrecioBasePorKgs;
        private System.Windows.Forms.Label lblRecorridoModificarPrecioBasePorPasaje;
        private System.Windows.Forms.TextBox tbRecorridoModificarPrecioBasePorKgs;
        private System.Windows.Forms.TextBox tbRecorridoModificarPrecioBasePorPasaje;
        private System.Windows.Forms.ComboBox cbCiudadOrigen;
        private System.Windows.Forms.ComboBox cbCiudadDestino;
    }
}