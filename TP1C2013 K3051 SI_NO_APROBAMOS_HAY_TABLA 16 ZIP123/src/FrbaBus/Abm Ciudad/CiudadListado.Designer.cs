namespace FrbaBus.Abm_Ciudad
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
            this.lblCiudadListadoCiudad = new System.Windows.Forms.Label();
            this.cbbCiudadListadoCiudad = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCiudadListadoLimpiar = new System.Windows.Forms.Button();
            this.btnCiudadListadoBuscar = new System.Windows.Forms.Button();
            this.btnCiudadListadoDarBaja = new System.Windows.Forms.Button();
            this.gbCiudadListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCiudadListado
            // 
            this.gbCiudadListado.Controls.Add(this.cbbCiudadListadoCiudad);
            this.gbCiudadListado.Controls.Add(this.lblCiudadListadoCiudad);
            this.gbCiudadListado.Location = new System.Drawing.Point(51, 36);
            this.gbCiudadListado.Name = "gbCiudadListado";
            this.gbCiudadListado.Size = new System.Drawing.Size(472, 68);
            this.gbCiudadListado.TabIndex = 0;
            this.gbCiudadListado.TabStop = false;
            this.gbCiudadListado.Text = "Filtros de busqueda";
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
            // cbbCiudadListadoCiudad
            // 
            this.cbbCiudadListadoCiudad.Location = new System.Drawing.Point(107, 25);
            this.cbbCiudadListadoCiudad.Name = "cbbCiudadListadoCiudad";
            this.cbbCiudadListadoCiudad.Size = new System.Drawing.Size(100, 20);
            this.cbbCiudadListadoCiudad.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(51, 166);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(472, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnCiudadListadoLimpiar
            // 
            this.btnCiudadListadoLimpiar.Location = new System.Drawing.Point(13, 122);
            this.btnCiudadListadoLimpiar.Name = "btnCiudadListadoLimpiar";
            this.btnCiudadListadoLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnCiudadListadoLimpiar.TabIndex = 2;
            this.btnCiudadListadoLimpiar.Text = "Limpiar";
            this.btnCiudadListadoLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnCiudadListadoBuscar
            // 
            this.btnCiudadListadoBuscar.Location = new System.Drawing.Point(532, 122);
            this.btnCiudadListadoBuscar.Name = "btnCiudadListadoBuscar";
            this.btnCiudadListadoBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnCiudadListadoBuscar.TabIndex = 3;
            this.btnCiudadListadoBuscar.Text = "Buscar";
            this.btnCiudadListadoBuscar.UseVisualStyleBackColor = true;
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
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gbCiudadListado);
            this.Name = "CiudadListado";
            this.Text = "CiudadListado";
            this.gbCiudadListado.ResumeLayout(false);
            this.gbCiudadListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCiudadListado;
        private System.Windows.Forms.TextBox cbbCiudadListadoCiudad;
        private System.Windows.Forms.Label lblCiudadListadoCiudad;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCiudadListadoLimpiar;
        private System.Windows.Forms.Button btnCiudadListadoBuscar;
        private System.Windows.Forms.Button btnCiudadListadoDarBaja;
    }
}