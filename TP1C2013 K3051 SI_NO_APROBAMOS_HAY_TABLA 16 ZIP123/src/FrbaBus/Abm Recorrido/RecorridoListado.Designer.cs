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
            this.gbRecorridoListado = new System.Windows.Forms.GroupBox();
            this.cbCiudadDestino = new System.Windows.Forms.ComboBox();
            this.cbCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.cbbRecorridoListadoTipoServicio = new System.Windows.Forms.ComboBox();
            this.btnRecorridoListadoBuscar = new System.Windows.Forms.Button();
            this.btnRecorridoListadoLimpiar = new System.Windows.Forms.Button();
            this.dgvRecorridoListado = new System.Windows.Forms.DataGridView();
            this.btnRecorridoListadoDarBaja = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.gbRecorridoListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecorridoListado)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecorridoListadoCiudadOrigen
            // 
            this.lblRecorridoListadoCiudadOrigen.AutoSize = true;
            this.lblRecorridoListadoCiudadOrigen.Location = new System.Drawing.Point(6, 19);
            this.lblRecorridoListadoCiudadOrigen.Name = "lblRecorridoListadoCiudadOrigen";
            this.lblRecorridoListadoCiudadOrigen.Size = new System.Drawing.Size(72, 13);
            this.lblRecorridoListadoCiudadOrigen.TabIndex = 0;
            this.lblRecorridoListadoCiudadOrigen.Text = "Ciudad origen";
            // 
            // lblRecorridoListadoCiudadDestino
            // 
            this.lblRecorridoListadoCiudadDestino.AutoSize = true;
            this.lblRecorridoListadoCiudadDestino.Location = new System.Drawing.Point(6, 46);
            this.lblRecorridoListadoCiudadDestino.Name = "lblRecorridoListadoCiudadDestino";
            this.lblRecorridoListadoCiudadDestino.Size = new System.Drawing.Size(77, 13);
            this.lblRecorridoListadoCiudadDestino.TabIndex = 1;
            this.lblRecorridoListadoCiudadDestino.Text = "Ciudad destino";
            // 
            // lblRecorridoListadoTipoServicio
            // 
            this.lblRecorridoListadoTipoServicio.AutoSize = true;
            this.lblRecorridoListadoTipoServicio.Location = new System.Drawing.Point(6, 73);
            this.lblRecorridoListadoTipoServicio.Name = "lblRecorridoListadoTipoServicio";
            this.lblRecorridoListadoTipoServicio.Size = new System.Drawing.Size(82, 13);
            this.lblRecorridoListadoTipoServicio.TabIndex = 2;
            this.lblRecorridoListadoTipoServicio.Text = "Tipo de servicio";
            // 
            // gbRecorridoListado
            // 
            this.gbRecorridoListado.Controls.Add(this.cbCiudadDestino);
            this.gbRecorridoListado.Controls.Add(this.cbCiudadOrigen);
            this.gbRecorridoListado.Controls.Add(this.cbbRecorridoListadoTipoServicio);
            this.gbRecorridoListado.Controls.Add(this.btnRecorridoListadoBuscar);
            this.gbRecorridoListado.Controls.Add(this.btnRecorridoListadoLimpiar);
            this.gbRecorridoListado.Controls.Add(this.lblRecorridoListadoCiudadOrigen);
            this.gbRecorridoListado.Controls.Add(this.lblRecorridoListadoTipoServicio);
            this.gbRecorridoListado.Controls.Add(this.lblRecorridoListadoCiudadDestino);
            this.gbRecorridoListado.Location = new System.Drawing.Point(12, 12);
            this.gbRecorridoListado.Name = "gbRecorridoListado";
            this.gbRecorridoListado.Size = new System.Drawing.Size(481, 106);
            this.gbRecorridoListado.TabIndex = 4;
            this.gbRecorridoListado.TabStop = false;
            this.gbRecorridoListado.Text = "Filtros de busqueda";
            // 
            // cbCiudadDestino
            // 
            this.cbCiudadDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCiudadDestino.FormattingEnabled = true;
            this.cbCiudadDestino.Location = new System.Drawing.Point(110, 43);
            this.cbCiudadDestino.Name = "cbCiudadDestino";
            this.cbCiudadDestino.Size = new System.Drawing.Size(282, 21);
            this.cbCiudadDestino.TabIndex = 8;
            // 
            // cbCiudadOrigen
            // 
            this.cbCiudadOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCiudadOrigen.FormattingEnabled = true;
            this.cbCiudadOrigen.Location = new System.Drawing.Point(110, 16);
            this.cbCiudadOrigen.Name = "cbCiudadOrigen";
            this.cbCiudadOrigen.Size = new System.Drawing.Size(282, 21);
            this.cbCiudadOrigen.TabIndex = 7;
            // 
            // cbbRecorridoListadoTipoServicio
            // 
            this.cbbRecorridoListadoTipoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRecorridoListadoTipoServicio.FormattingEnabled = true;
            this.cbbRecorridoListadoTipoServicio.Location = new System.Drawing.Point(110, 70);
            this.cbbRecorridoListadoTipoServicio.Name = "cbbRecorridoListadoTipoServicio";
            this.cbbRecorridoListadoTipoServicio.Size = new System.Drawing.Size(282, 21);
            this.cbbRecorridoListadoTipoServicio.TabIndex = 5;
            // 
            // btnRecorridoListadoBuscar
            // 
            this.btnRecorridoListadoBuscar.Location = new System.Drawing.Point(400, 19);
            this.btnRecorridoListadoBuscar.Name = "btnRecorridoListadoBuscar";
            this.btnRecorridoListadoBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnRecorridoListadoBuscar.TabIndex = 6;
            this.btnRecorridoListadoBuscar.Text = "Buscar";
            this.btnRecorridoListadoBuscar.UseVisualStyleBackColor = true;
            this.btnRecorridoListadoBuscar.Click += new System.EventHandler(this.btnRecorridoListadoBuscar_Click);
            // 
            // btnRecorridoListadoLimpiar
            // 
            this.btnRecorridoListadoLimpiar.Location = new System.Drawing.Point(400, 48);
            this.btnRecorridoListadoLimpiar.Name = "btnRecorridoListadoLimpiar";
            this.btnRecorridoListadoLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnRecorridoListadoLimpiar.TabIndex = 5;
            this.btnRecorridoListadoLimpiar.Text = "Limpiar";
            this.btnRecorridoListadoLimpiar.UseVisualStyleBackColor = true;
            this.btnRecorridoListadoLimpiar.Click += new System.EventHandler(this.btnRecorridoListadoLimpiar_Click);
            // 
            // dgvRecorridoListado
            // 
            this.dgvRecorridoListado.AllowUserToAddRows = false;
            this.dgvRecorridoListado.AllowUserToDeleteRows = false;
            this.dgvRecorridoListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecorridoListado.Location = new System.Drawing.Point(12, 134);
            this.dgvRecorridoListado.Name = "dgvRecorridoListado";
            this.dgvRecorridoListado.ReadOnly = true;
            this.dgvRecorridoListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecorridoListado.Size = new System.Drawing.Size(481, 228);
            this.dgvRecorridoListado.TabIndex = 7;
            // 
            // btnRecorridoListadoDarBaja
            // 
            this.btnRecorridoListadoDarBaja.Location = new System.Drawing.Point(92, 368);
            this.btnRecorridoListadoDarBaja.Name = "btnRecorridoListadoDarBaja";
            this.btnRecorridoListadoDarBaja.Size = new System.Drawing.Size(75, 23);
            this.btnRecorridoListadoDarBaja.TabIndex = 9;
            this.btnRecorridoListadoDarBaja.Text = "Dar de baja";
            this.btnRecorridoListadoDarBaja.UseVisualStyleBackColor = true;
            this.btnRecorridoListadoDarBaja.Click += new System.EventHandler(this.btnRecorridoListadoDarBaja_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(12, 368);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 10;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // RecorridoListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 409);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnRecorridoListadoDarBaja);
            this.Controls.Add(this.dgvRecorridoListado);
            this.Controls.Add(this.gbRecorridoListado);
            this.Name = "RecorridoListado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrbaBus - Recorridos :: Listado";
            this.Load += new System.EventHandler(this.RecorridoListado_Load);
            this.gbRecorridoListado.ResumeLayout(false);
            this.gbRecorridoListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecorridoListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRecorridoListadoCiudadOrigen;
        private System.Windows.Forms.Label lblRecorridoListadoCiudadDestino;
        private System.Windows.Forms.Label lblRecorridoListadoTipoServicio;
        private System.Windows.Forms.GroupBox gbRecorridoListado;
        private System.Windows.Forms.ComboBox cbbRecorridoListadoTipoServicio;
        private System.Windows.Forms.Button btnRecorridoListadoLimpiar;
        private System.Windows.Forms.Button btnRecorridoListadoBuscar;
        private System.Windows.Forms.DataGridView dgvRecorridoListado;
        private System.Windows.Forms.Button btnRecorridoListadoDarBaja;
        private System.Windows.Forms.ComboBox cbCiudadOrigen;
        private System.Windows.Forms.ComboBox cbCiudadDestino;
        private System.Windows.Forms.Button btnModificar;
    }
}