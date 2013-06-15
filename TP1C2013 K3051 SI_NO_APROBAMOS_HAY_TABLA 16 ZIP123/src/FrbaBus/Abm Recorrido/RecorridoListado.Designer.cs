namespace FrbaBus.Abm_Recorrido
{
    partial class RecorridoListado
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
            this.lblRecorridoListadoCiudadOrigen = new System.Windows.Forms.Label();
            this.lblRecorridoListadoCiudadDestino = new System.Windows.Forms.Label();
            this.lblRecorridoListadoTipoServicio = new System.Windows.Forms.Label();
            this.tbRecorridoListadoCiudadOrigen = new System.Windows.Forms.TextBox();
            this.gbRecorridoListado = new System.Windows.Forms.GroupBox();
            this.tbRecorridoListadoCiudadDestino = new System.Windows.Forms.TextBox();
            this.cbbRecorridoListadoTipoServicio = new System.Windows.Forms.ComboBox();
            this.btnRecorridoListadoLimpiar = new System.Windows.Forms.Button();
            this.btnRecorridoListadoBuscar = new System.Windows.Forms.Button();
            this.dgvRecorridoListado = new System.Windows.Forms.DataGridView();
            this.btnRecorridoListadoDarBaja = new System.Windows.Forms.Button();
            this.gbRecorridoListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecorridoListado)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecorridoListadoCiudadOrigen
            // 
            this.lblRecorridoListadoCiudadOrigen.AutoSize = true;
            this.lblRecorridoListadoCiudadOrigen.Location = new System.Drawing.Point(18, 19);
            this.lblRecorridoListadoCiudadOrigen.Name = "lblRecorridoListadoCiudadOrigen";
            this.lblRecorridoListadoCiudadOrigen.Size = new System.Drawing.Size(72, 13);
            this.lblRecorridoListadoCiudadOrigen.TabIndex = 0;
            this.lblRecorridoListadoCiudadOrigen.Text = "Ciudad origen";
            // 
            // lblRecorridoListadoCiudadDestino
            // 
            this.lblRecorridoListadoCiudadDestino.AutoSize = true;
            this.lblRecorridoListadoCiudadDestino.Location = new System.Drawing.Point(18, 48);
            this.lblRecorridoListadoCiudadDestino.Name = "lblRecorridoListadoCiudadDestino";
            this.lblRecorridoListadoCiudadDestino.Size = new System.Drawing.Size(77, 13);
            this.lblRecorridoListadoCiudadDestino.TabIndex = 1;
            this.lblRecorridoListadoCiudadDestino.Text = "Ciudad destino";
            // 
            // lblRecorridoListadoTipoServicio
            // 
            this.lblRecorridoListadoTipoServicio.AutoSize = true;
            this.lblRecorridoListadoTipoServicio.Location = new System.Drawing.Point(18, 75);
            this.lblRecorridoListadoTipoServicio.Name = "lblRecorridoListadoTipoServicio";
            this.lblRecorridoListadoTipoServicio.Size = new System.Drawing.Size(82, 13);
            this.lblRecorridoListadoTipoServicio.TabIndex = 2;
            this.lblRecorridoListadoTipoServicio.Text = "Tipo de servicio";
            // 
            // tbRecorridoListadoCiudadOrigen
            // 
            this.tbRecorridoListadoCiudadOrigen.Location = new System.Drawing.Point(110, 19);
            this.tbRecorridoListadoCiudadOrigen.Name = "tbRecorridoListadoCiudadOrigen";
            this.tbRecorridoListadoCiudadOrigen.Size = new System.Drawing.Size(121, 20);
            this.tbRecorridoListadoCiudadOrigen.TabIndex = 3;
            // 
            // gbRecorridoListado
            // 
            this.gbRecorridoListado.Controls.Add(this.cbbRecorridoListadoTipoServicio);
            this.gbRecorridoListado.Controls.Add(this.tbRecorridoListadoCiudadDestino);
            this.gbRecorridoListado.Controls.Add(this.tbRecorridoListadoCiudadOrigen);
            this.gbRecorridoListado.Controls.Add(this.lblRecorridoListadoCiudadOrigen);
            this.gbRecorridoListado.Controls.Add(this.lblRecorridoListadoTipoServicio);
            this.gbRecorridoListado.Controls.Add(this.lblRecorridoListadoCiudadDestino);
            this.gbRecorridoListado.Location = new System.Drawing.Point(12, 23);
            this.gbRecorridoListado.Name = "gbRecorridoListado";
            this.gbRecorridoListado.Size = new System.Drawing.Size(481, 106);
            this.gbRecorridoListado.TabIndex = 4;
            this.gbRecorridoListado.TabStop = false;
            this.gbRecorridoListado.Text = "Filtros de busqueda";
            // 
            // tbRecorridoListadoCiudadDestino
            // 
            this.tbRecorridoListadoCiudadDestino.Location = new System.Drawing.Point(110, 45);
            this.tbRecorridoListadoCiudadDestino.Name = "tbRecorridoListadoCiudadDestino";
            this.tbRecorridoListadoCiudadDestino.Size = new System.Drawing.Size(121, 20);
            this.tbRecorridoListadoCiudadDestino.TabIndex = 4;
            // 
            // cbbRecorridoListadoTipoServicio
            // 
            this.cbbRecorridoListadoTipoServicio.FormattingEnabled = true;
            this.cbbRecorridoListadoTipoServicio.Location = new System.Drawing.Point(110, 72);
            this.cbbRecorridoListadoTipoServicio.Name = "cbbRecorridoListadoTipoServicio";
            this.cbbRecorridoListadoTipoServicio.Size = new System.Drawing.Size(121, 21);
            this.cbbRecorridoListadoTipoServicio.TabIndex = 5;
            // 
            // btnRecorridoListadoLimpiar
            // 
            this.btnRecorridoListadoLimpiar.Location = new System.Drawing.Point(12, 148);
            this.btnRecorridoListadoLimpiar.Name = "btnRecorridoListadoLimpiar";
            this.btnRecorridoListadoLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnRecorridoListadoLimpiar.TabIndex = 5;
            this.btnRecorridoListadoLimpiar.Text = "Limpiar";
            this.btnRecorridoListadoLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnRecorridoListadoBuscar
            // 
            this.btnRecorridoListadoBuscar.Location = new System.Drawing.Point(418, 148);
            this.btnRecorridoListadoBuscar.Name = "btnRecorridoListadoBuscar";
            this.btnRecorridoListadoBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnRecorridoListadoBuscar.TabIndex = 6;
            this.btnRecorridoListadoBuscar.Text = "Buscar";
            this.btnRecorridoListadoBuscar.UseVisualStyleBackColor = true;
            // 
            // dgvRecorridoListado
            // 
            this.dgvRecorridoListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecorridoListado.Location = new System.Drawing.Point(12, 200);
            this.dgvRecorridoListado.Name = "dgvRecorridoListado";
            this.dgvRecorridoListado.Size = new System.Drawing.Size(481, 150);
            this.dgvRecorridoListado.TabIndex = 7;
            // 
            // btnRecorridoListadoDarBaja
            // 
            this.btnRecorridoListadoDarBaja.Location = new System.Drawing.Point(418, 368);
            this.btnRecorridoListadoDarBaja.Name = "btnRecorridoListadoDarBaja";
            this.btnRecorridoListadoDarBaja.Size = new System.Drawing.Size(75, 23);
            this.btnRecorridoListadoDarBaja.TabIndex = 9;
            this.btnRecorridoListadoDarBaja.Text = "Dar de baja";
            this.btnRecorridoListadoDarBaja.UseVisualStyleBackColor = true;
            // 
            // RecorridoListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 409);
            this.Controls.Add(this.btnRecorridoListadoDarBaja);
            this.Controls.Add(this.dgvRecorridoListado);
            this.Controls.Add(this.btnRecorridoListadoBuscar);
            this.Controls.Add(this.btnRecorridoListadoLimpiar);
            this.Controls.Add(this.gbRecorridoListado);
            this.Name = "RecorridoListado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado recorridos";
            this.gbRecorridoListado.ResumeLayout(false);
            this.gbRecorridoListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecorridoListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRecorridoListadoCiudadOrigen;
        private System.Windows.Forms.Label lblRecorridoListadoCiudadDestino;
        private System.Windows.Forms.Label lblRecorridoListadoTipoServicio;
        private System.Windows.Forms.TextBox tbRecorridoListadoCiudadOrigen;
        private System.Windows.Forms.GroupBox gbRecorridoListado;
        private System.Windows.Forms.ComboBox cbbRecorridoListadoTipoServicio;
        private System.Windows.Forms.TextBox tbRecorridoListadoCiudadDestino;
        private System.Windows.Forms.Button btnRecorridoListadoLimpiar;
        private System.Windows.Forms.Button btnRecorridoListadoBuscar;
        private System.Windows.Forms.DataGridView dgvRecorridoListado;
        private System.Windows.Forms.Button btnRecorridoListadoDarBaja;
    }
}