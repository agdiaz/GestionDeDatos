﻿namespace FrbaBus.Abm_Recorrido
{
    partial class RecorridoAlta
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
            this.lblRecorridoAltaCiudadOrigen = new System.Windows.Forms.Label();
            this.lblRecorridoAltaCiudadDestino = new System.Windows.Forms.Label();
            this.lblRecorridoAltaTipoServicio = new System.Windows.Forms.Label();
            this.tbRecorridoAltaCiudadOrigen = new System.Windows.Forms.TextBox();
            this.tbRecorridoAltaCiudadDestino = new System.Windows.Forms.TextBox();
            this.cbbRecorridoAltaTipoServicio = new System.Windows.Forms.ComboBox();
            this.btnRecorridoAltaLimpiar = new System.Windows.Forms.Button();
            this.btnRecorridoAltaGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRecorridoAltaCiudadOrigen
            // 
            this.lblRecorridoAltaCiudadOrigen.AutoSize = true;
            this.lblRecorridoAltaCiudadOrigen.Location = new System.Drawing.Point(34, 29);
            this.lblRecorridoAltaCiudadOrigen.Name = "lblRecorridoAltaCiudadOrigen";
            this.lblRecorridoAltaCiudadOrigen.Size = new System.Drawing.Size(72, 13);
            this.lblRecorridoAltaCiudadOrigen.TabIndex = 0;
            this.lblRecorridoAltaCiudadOrigen.Text = "Ciudad origen";
            // 
            // lblRecorridoAltaCiudadDestino
            // 
            this.lblRecorridoAltaCiudadDestino.AutoSize = true;
            this.lblRecorridoAltaCiudadDestino.Location = new System.Drawing.Point(34, 56);
            this.lblRecorridoAltaCiudadDestino.Name = "lblRecorridoAltaCiudadDestino";
            this.lblRecorridoAltaCiudadDestino.Size = new System.Drawing.Size(77, 13);
            this.lblRecorridoAltaCiudadDestino.TabIndex = 1;
            this.lblRecorridoAltaCiudadDestino.Text = "Ciudad destino";
            // 
            // lblRecorridoAltaTipoServicio
            // 
            this.lblRecorridoAltaTipoServicio.AutoSize = true;
            this.lblRecorridoAltaTipoServicio.Location = new System.Drawing.Point(34, 83);
            this.lblRecorridoAltaTipoServicio.Name = "lblRecorridoAltaTipoServicio";
            this.lblRecorridoAltaTipoServicio.Size = new System.Drawing.Size(82, 13);
            this.lblRecorridoAltaTipoServicio.TabIndex = 2;
            this.lblRecorridoAltaTipoServicio.Text = "Tipo de servicio";
            // 
            // tbRecorridoAltaCiudadOrigen
            // 
            this.tbRecorridoAltaCiudadOrigen.Location = new System.Drawing.Point(130, 26);
            this.tbRecorridoAltaCiudadOrigen.Name = "tbRecorridoAltaCiudadOrigen";
            this.tbRecorridoAltaCiudadOrigen.Size = new System.Drawing.Size(121, 20);
            this.tbRecorridoAltaCiudadOrigen.TabIndex = 3;
            // 
            // tbRecorridoAltaCiudadDestino
            // 
            this.tbRecorridoAltaCiudadDestino.Location = new System.Drawing.Point(130, 53);
            this.tbRecorridoAltaCiudadDestino.Name = "tbRecorridoAltaCiudadDestino";
            this.tbRecorridoAltaCiudadDestino.Size = new System.Drawing.Size(121, 20);
            this.tbRecorridoAltaCiudadDestino.TabIndex = 4;
            // 
            // cbbRecorridoAltaTipoServicio
            // 
            this.cbbRecorridoAltaTipoServicio.FormattingEnabled = true;
            this.cbbRecorridoAltaTipoServicio.Location = new System.Drawing.Point(130, 80);
            this.cbbRecorridoAltaTipoServicio.Name = "cbbRecorridoAltaTipoServicio";
            this.cbbRecorridoAltaTipoServicio.Size = new System.Drawing.Size(121, 21);
            this.cbbRecorridoAltaTipoServicio.TabIndex = 5;
            // 
            // btnRecorridoAltaLimpiar
            // 
            this.btnRecorridoAltaLimpiar.Location = new System.Drawing.Point(12, 114);
            this.btnRecorridoAltaLimpiar.Name = "btnRecorridoAltaLimpiar";
            this.btnRecorridoAltaLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnRecorridoAltaLimpiar.TabIndex = 6;
            this.btnRecorridoAltaLimpiar.Text = "Limpiar";
            this.btnRecorridoAltaLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnRecorridoAltaGuardar
            // 
            this.btnRecorridoAltaGuardar.Location = new System.Drawing.Point(388, 114);
            this.btnRecorridoAltaGuardar.Name = "btnRecorridoAltaGuardar";
            this.btnRecorridoAltaGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnRecorridoAltaGuardar.TabIndex = 7;
            this.btnRecorridoAltaGuardar.Text = "Guardar";
            this.btnRecorridoAltaGuardar.UseVisualStyleBackColor = true;
            // 
            // RecorridoAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 146);
            this.Controls.Add(this.btnRecorridoAltaGuardar);
            this.Controls.Add(this.btnRecorridoAltaLimpiar);
            this.Controls.Add(this.cbbRecorridoAltaTipoServicio);
            this.Controls.Add(this.tbRecorridoAltaCiudadDestino);
            this.Controls.Add(this.tbRecorridoAltaCiudadOrigen);
            this.Controls.Add(this.lblRecorridoAltaTipoServicio);
            this.Controls.Add(this.lblRecorridoAltaCiudadDestino);
            this.Controls.Add(this.lblRecorridoAltaCiudadOrigen);
            this.Name = "RecorridoAlta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta recorrido";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecorridoAltaCiudadOrigen;
        private System.Windows.Forms.Label lblRecorridoAltaCiudadDestino;
        private System.Windows.Forms.Label lblRecorridoAltaTipoServicio;
        private System.Windows.Forms.TextBox tbRecorridoAltaCiudadOrigen;
        private System.Windows.Forms.TextBox tbRecorridoAltaCiudadDestino;
        private System.Windows.Forms.ComboBox cbbRecorridoAltaTipoServicio;
        private System.Windows.Forms.Button btnRecorridoAltaLimpiar;
        private System.Windows.Forms.Button btnRecorridoAltaGuardar;
    }
}