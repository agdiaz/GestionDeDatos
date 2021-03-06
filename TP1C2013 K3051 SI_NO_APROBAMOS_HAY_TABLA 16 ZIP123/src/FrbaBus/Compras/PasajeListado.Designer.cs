﻿namespace FrbaBus.Compras
{
    partial class PasajeListado
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
            this.lblPasajeListadoMicro = new System.Windows.Forms.Label();
            this.lblPasajeListadoCliente = new System.Windows.Forms.Label();
            this.lblPasajeListadoButaca = new System.Windows.Forms.Label();
            this.lblPasajeListadoPrecio = new System.Windows.Forms.Label();
            this.gbPasajeListadoFiltros = new System.Windows.Forms.GroupBox();
            this.btnPasajeListadoSeleccionarButaca = new System.Windows.Forms.Button();
            this.btnPasajeListadoLimpiar = new System.Windows.Forms.Button();
            this.btnPasajeListadoBuscar = new System.Windows.Forms.Button();
            this.btnPasajeListadoSeleccionarCliente = new System.Windows.Forms.Button();
            this.tbPasajeListadoPrecio = new System.Windows.Forms.TextBox();
            this.tbPasajeListadoButaca = new System.Windows.Forms.TextBox();
            this.tbPasajeListadoCliente = new System.Windows.Forms.TextBox();
            this.tbPasajeListadoMicro = new System.Windows.Forms.TextBox();
            this.dgvPasajeListado = new System.Windows.Forms.DataGridView();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.gbPasajeListadoFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasajeListado)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPasajeListadoMicro
            // 
            this.lblPasajeListadoMicro.AutoSize = true;
            this.lblPasajeListadoMicro.Location = new System.Drawing.Point(9, 22);
            this.lblPasajeListadoMicro.Name = "lblPasajeListadoMicro";
            this.lblPasajeListadoMicro.Size = new System.Drawing.Size(33, 13);
            this.lblPasajeListadoMicro.TabIndex = 0;
            this.lblPasajeListadoMicro.Text = "Micro";
            // 
            // lblPasajeListadoCliente
            // 
            this.lblPasajeListadoCliente.AutoSize = true;
            this.lblPasajeListadoCliente.Location = new System.Drawing.Point(9, 48);
            this.lblPasajeListadoCliente.Name = "lblPasajeListadoCliente";
            this.lblPasajeListadoCliente.Size = new System.Drawing.Size(39, 13);
            this.lblPasajeListadoCliente.TabIndex = 1;
            this.lblPasajeListadoCliente.Text = "Cliente";
            // 
            // lblPasajeListadoButaca
            // 
            this.lblPasajeListadoButaca.AutoSize = true;
            this.lblPasajeListadoButaca.Location = new System.Drawing.Point(9, 74);
            this.lblPasajeListadoButaca.Name = "lblPasajeListadoButaca";
            this.lblPasajeListadoButaca.Size = new System.Drawing.Size(41, 13);
            this.lblPasajeListadoButaca.TabIndex = 2;
            this.lblPasajeListadoButaca.Text = "Butaca";
            // 
            // lblPasajeListadoPrecio
            // 
            this.lblPasajeListadoPrecio.AutoSize = true;
            this.lblPasajeListadoPrecio.Location = new System.Drawing.Point(9, 100);
            this.lblPasajeListadoPrecio.Name = "lblPasajeListadoPrecio";
            this.lblPasajeListadoPrecio.Size = new System.Drawing.Size(37, 13);
            this.lblPasajeListadoPrecio.TabIndex = 3;
            this.lblPasajeListadoPrecio.Text = "Precio";
            // 
            // gbPasajeListadoFiltros
            // 
            this.gbPasajeListadoFiltros.Controls.Add(this.btnPasajeListadoSeleccionarButaca);
            this.gbPasajeListadoFiltros.Controls.Add(this.btnPasajeListadoLimpiar);
            this.gbPasajeListadoFiltros.Controls.Add(this.btnPasajeListadoBuscar);
            this.gbPasajeListadoFiltros.Controls.Add(this.btnPasajeListadoSeleccionarCliente);
            this.gbPasajeListadoFiltros.Controls.Add(this.tbPasajeListadoPrecio);
            this.gbPasajeListadoFiltros.Controls.Add(this.tbPasajeListadoButaca);
            this.gbPasajeListadoFiltros.Controls.Add(this.tbPasajeListadoCliente);
            this.gbPasajeListadoFiltros.Controls.Add(this.tbPasajeListadoMicro);
            this.gbPasajeListadoFiltros.Controls.Add(this.lblPasajeListadoMicro);
            this.gbPasajeListadoFiltros.Controls.Add(this.lblPasajeListadoPrecio);
            this.gbPasajeListadoFiltros.Controls.Add(this.lblPasajeListadoCliente);
            this.gbPasajeListadoFiltros.Controls.Add(this.lblPasajeListadoButaca);
            this.gbPasajeListadoFiltros.Location = new System.Drawing.Point(13, 12);
            this.gbPasajeListadoFiltros.Name = "gbPasajeListadoFiltros";
            this.gbPasajeListadoFiltros.Size = new System.Drawing.Size(450, 152);
            this.gbPasajeListadoFiltros.TabIndex = 4;
            this.gbPasajeListadoFiltros.TabStop = false;
            this.gbPasajeListadoFiltros.Text = "Filtros de busqueda";
            // 
            // btnPasajeListadoSeleccionarButaca
            // 
            this.btnPasajeListadoSeleccionarButaca.Location = new System.Drawing.Point(338, 69);
            this.btnPasajeListadoSeleccionarButaca.Name = "btnPasajeListadoSeleccionarButaca";
            this.btnPasajeListadoSeleccionarButaca.Size = new System.Drawing.Size(110, 23);
            this.btnPasajeListadoSeleccionarButaca.TabIndex = 4;
            this.btnPasajeListadoSeleccionarButaca.Text = "Seleccionar Butaca";
            this.btnPasajeListadoSeleccionarButaca.UseVisualStyleBackColor = true;
            // 
            // btnPasajeListadoLimpiar
            // 
            this.btnPasajeListadoLimpiar.Location = new System.Drawing.Point(288, 122);
            this.btnPasajeListadoLimpiar.Name = "btnPasajeListadoLimpiar";
            this.btnPasajeListadoLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnPasajeListadoLimpiar.TabIndex = 6;
            this.btnPasajeListadoLimpiar.Text = "Limpiar";
            this.btnPasajeListadoLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnPasajeListadoBuscar
            // 
            this.btnPasajeListadoBuscar.Location = new System.Drawing.Point(369, 122);
            this.btnPasajeListadoBuscar.Name = "btnPasajeListadoBuscar";
            this.btnPasajeListadoBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnPasajeListadoBuscar.TabIndex = 7;
            this.btnPasajeListadoBuscar.Text = "Buscar";
            this.btnPasajeListadoBuscar.UseVisualStyleBackColor = true;
            this.btnPasajeListadoBuscar.Click += new System.EventHandler(this.btnPasajeListadoBuscar_Click);
            // 
            // btnPasajeListadoSeleccionarCliente
            // 
            this.btnPasajeListadoSeleccionarCliente.Location = new System.Drawing.Point(338, 43);
            this.btnPasajeListadoSeleccionarCliente.Name = "btnPasajeListadoSeleccionarCliente";
            this.btnPasajeListadoSeleccionarCliente.Size = new System.Drawing.Size(110, 23);
            this.btnPasajeListadoSeleccionarCliente.TabIndex = 2;
            this.btnPasajeListadoSeleccionarCliente.Text = "Seleccionar Cliente";
            this.btnPasajeListadoSeleccionarCliente.UseVisualStyleBackColor = true;
            this.btnPasajeListadoSeleccionarCliente.Click += new System.EventHandler(this.btnPasajeListadoSeleccionarCliente_Click);
            // 
            // tbPasajeListadoPrecio
            // 
            this.tbPasajeListadoPrecio.Location = new System.Drawing.Point(71, 97);
            this.tbPasajeListadoPrecio.Name = "tbPasajeListadoPrecio";
            this.tbPasajeListadoPrecio.Size = new System.Drawing.Size(100, 20);
            this.tbPasajeListadoPrecio.TabIndex = 5;
            // 
            // tbPasajeListadoButaca
            // 
            this.tbPasajeListadoButaca.Location = new System.Drawing.Point(71, 71);
            this.tbPasajeListadoButaca.Name = "tbPasajeListadoButaca";
            this.tbPasajeListadoButaca.Size = new System.Drawing.Size(261, 20);
            this.tbPasajeListadoButaca.TabIndex = 3;
            // 
            // tbPasajeListadoCliente
            // 
            this.tbPasajeListadoCliente.Location = new System.Drawing.Point(71, 45);
            this.tbPasajeListadoCliente.Name = "tbPasajeListadoCliente";
            this.tbPasajeListadoCliente.Size = new System.Drawing.Size(261, 20);
            this.tbPasajeListadoCliente.TabIndex = 1;
            // 
            // tbPasajeListadoMicro
            // 
            this.tbPasajeListadoMicro.Location = new System.Drawing.Point(71, 19);
            this.tbPasajeListadoMicro.Name = "tbPasajeListadoMicro";
            this.tbPasajeListadoMicro.Size = new System.Drawing.Size(261, 20);
            this.tbPasajeListadoMicro.TabIndex = 0;
            // 
            // dgvPasajeListado
            // 
            this.dgvPasajeListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPasajeListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPasajeListado.Location = new System.Drawing.Point(12, 180);
            this.dgvPasajeListado.Name = "dgvPasajeListado";
            this.dgvPasajeListado.Size = new System.Drawing.Size(806, 251);
            this.dgvPasajeListado.TabIndex = 8;
            this.dgvPasajeListado.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPasajeListado_CellContentDoubleClick);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(743, 437);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionar.TabIndex = 9;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // PasajeListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 486);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.dgvPasajeListado);
            this.Controls.Add(this.gbPasajeListadoFiltros);
            this.Name = "PasajeListado";
            this.Text = "Listado de pasajes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PasajeListado_FormClosing);
            this.gbPasajeListadoFiltros.ResumeLayout(false);
            this.gbPasajeListadoFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasajeListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPasajeListadoMicro;
        private System.Windows.Forms.Label lblPasajeListadoCliente;
        private System.Windows.Forms.Label lblPasajeListadoButaca;
        private System.Windows.Forms.Label lblPasajeListadoPrecio;
        private System.Windows.Forms.GroupBox gbPasajeListadoFiltros;
        private System.Windows.Forms.TextBox tbPasajeListadoPrecio;
        private System.Windows.Forms.TextBox tbPasajeListadoButaca;
        private System.Windows.Forms.TextBox tbPasajeListadoCliente;
        private System.Windows.Forms.TextBox tbPasajeListadoMicro;
        private System.Windows.Forms.Button btnPasajeListadoSeleccionarCliente;
        private System.Windows.Forms.Button btnPasajeListadoSeleccionarButaca;
        private System.Windows.Forms.Button btnPasajeListadoBuscar;
        private System.Windows.Forms.Button btnPasajeListadoLimpiar;
        private System.Windows.Forms.DataGridView dgvPasajeListado;
        private System.Windows.Forms.Button btnSeleccionar;
    }
}