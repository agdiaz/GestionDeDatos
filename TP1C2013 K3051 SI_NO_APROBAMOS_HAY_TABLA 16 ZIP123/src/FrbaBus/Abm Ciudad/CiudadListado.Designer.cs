﻿namespace FrbaBus.Abm_Ciudad
{
    partial class CiudadListado
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
            this.gbCiudadListado = new System.Windows.Forms.GroupBox();
            this.tbCiudadListadoCiudad = new System.Windows.Forms.TextBox();
            this.lblCiudadListadoCiudad = new System.Windows.Forms.Label();
            this.dgvCiudadListado = new System.Windows.Forms.DataGridView();
            this.btnCiudadListadoLimpiar = new System.Windows.Forms.Button();
            this.btnCiudadListadoBuscar = new System.Windows.Forms.Button();
            this.btnCiudadListadoDarBaja = new System.Windows.Forms.Button();
            this.gbCiudadListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCiudadListado)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCiudadListado
            // 
            this.gbCiudadListado.Controls.Add(this.tbCiudadListadoCiudad);
            this.gbCiudadListado.Controls.Add(this.lblCiudadListadoCiudad);
            this.gbCiudadListado.Location = new System.Drawing.Point(51, 36);
            this.gbCiudadListado.Name = "gbCiudadListado";
            this.gbCiudadListado.Size = new System.Drawing.Size(472, 68);
            this.gbCiudadListado.TabIndex = 0;
            this.gbCiudadListado.TabStop = false;
            this.gbCiudadListado.Text = "Filtros de busqueda";
            // 
            // tbCiudadListadoCiudad
            // 
            this.tbCiudadListadoCiudad.Location = new System.Drawing.Point(107, 25);
            this.tbCiudadListadoCiudad.Name = "tbCiudadListadoCiudad";
            this.tbCiudadListadoCiudad.Size = new System.Drawing.Size(100, 20);
            this.tbCiudadListadoCiudad.TabIndex = 1;
            // 
            // lblCiudadListadoCiudad
            // 
            this.lblCiudadListadoCiudad.AutoSize = true;
            this.lblCiudadListadoCiudad.Location = new System.Drawing.Point(23, 28);
            this.lblCiudadListadoCiudad.Name = "lblCiudadListadoCiudad";
            this.lblCiudadListadoCiudad.Size = new System.Drawing.Size(40, 13);
            this.lblCiudadListadoCiudad.TabIndex = 0;
            this.lblCiudadListadoCiudad.Text = "Ciudad";
            // 
            // dgvCiudadListado
            // 
            this.dgvCiudadListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCiudadListado.Location = new System.Drawing.Point(51, 166);
            this.dgvCiudadListado.Name = "dgvCiudadListado";
            this.dgvCiudadListado.Size = new System.Drawing.Size(472, 150);
            this.dgvCiudadListado.TabIndex = 1;
            // 
            // btnCiudadListadoLimpiar
            // 
            this.btnCiudadListadoLimpiar.Location = new System.Drawing.Point(13, 122);
            this.btnCiudadListadoLimpiar.Name = "btnCiudadListadoLimpiar";
            this.btnCiudadListadoLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnCiudadListadoLimpiar.TabIndex = 2;
            this.btnCiudadListadoLimpiar.Text = "Limpiar";
            this.btnCiudadListadoLimpiar.UseVisualStyleBackColor = true;
            this.btnCiudadListadoLimpiar.Click += new System.EventHandler(this.btnCiudadListadoLimpiar_Click);
            // 
            // btnCiudadListadoBuscar
            // 
            this.btnCiudadListadoBuscar.Location = new System.Drawing.Point(532, 122);
            this.btnCiudadListadoBuscar.Name = "btnCiudadListadoBuscar";
            this.btnCiudadListadoBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnCiudadListadoBuscar.TabIndex = 3;
            this.btnCiudadListadoBuscar.Text = "Buscar";
            this.btnCiudadListadoBuscar.UseVisualStyleBackColor = true;
            this.btnCiudadListadoBuscar.Click += new System.EventHandler(this.btnCiudadListadoBuscar_Click);
            // 
            // btnCiudadListadoDarBaja
            // 
            this.btnCiudadListadoDarBaja.Enabled = false;
            this.btnCiudadListadoDarBaja.Location = new System.Drawing.Point(531, 343);
            this.btnCiudadListadoDarBaja.Name = "btnCiudadListadoDarBaja";
            this.btnCiudadListadoDarBaja.Size = new System.Drawing.Size(75, 23);
            this.btnCiudadListadoDarBaja.TabIndex = 4;
            this.btnCiudadListadoDarBaja.Text = "Dar de baja";
            this.btnCiudadListadoDarBaja.UseVisualStyleBackColor = true;
            // 
            // CiudadListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 378);
            this.Controls.Add(this.btnCiudadListadoDarBaja);
            this.Controls.Add(this.btnCiudadListadoBuscar);
            this.Controls.Add(this.btnCiudadListadoLimpiar);
            this.Controls.Add(this.dgvCiudadListado);
            this.Controls.Add(this.gbCiudadListado);
            this.Name = "CiudadListado";
            this.Text = "Listado ciudades";
            this.Load += new System.EventHandler(this.CiudadListado_Load);
            this.gbCiudadListado.ResumeLayout(false);
            this.gbCiudadListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCiudadListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCiudadListado;
        private System.Windows.Forms.TextBox tbCiudadListadoCiudad;
        private System.Windows.Forms.Label lblCiudadListadoCiudad;
        private System.Windows.Forms.DataGridView dgvCiudadListado;
        private System.Windows.Forms.Button btnCiudadListadoLimpiar;
        private System.Windows.Forms.Button btnCiudadListadoBuscar;
        private System.Windows.Forms.Button btnCiudadListadoDarBaja;
    }
}