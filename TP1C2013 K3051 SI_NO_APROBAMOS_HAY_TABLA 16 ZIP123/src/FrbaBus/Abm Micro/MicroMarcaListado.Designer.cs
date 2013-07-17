namespace FrbaBus.Abm_Micro
{
    partial class MicroMarcaListado
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
            this.lblMicroMarcaListadoMarca = new System.Windows.Forms.Label();
            this.cbbMicroMarcaListadoMarca = new System.Windows.Forms.ComboBox();
            this.gbMicroMarcaListado = new System.Windows.Forms.GroupBox();
            this.lblMicroMarcaListadoModelo = new System.Windows.Forms.Label();
            this.cbbMicroMarcaListadoModelo = new System.Windows.Forms.ComboBox();
            this.btnMicroMarcaListadoBuscar = new System.Windows.Forms.Button();
            this.btnMicroMarcaListadoLimpiar = new System.Windows.Forms.Button();
            this.dgvMicroMarcaListado = new System.Windows.Forms.DataGridView();
            this.gbMicroMarcaListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMicroMarcaListado)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMicroMarcaListadoMarca
            // 
            this.lblMicroMarcaListadoMarca.AutoSize = true;
            this.lblMicroMarcaListadoMarca.Location = new System.Drawing.Point(6, 33);
            this.lblMicroMarcaListadoMarca.Name = "lblMicroMarcaListadoMarca";
            this.lblMicroMarcaListadoMarca.Size = new System.Drawing.Size(37, 13);
            this.lblMicroMarcaListadoMarca.TabIndex = 0;
            this.lblMicroMarcaListadoMarca.Text = "Marca";
            // 
            // cbbMicroMarcaListadoMarca
            // 
            this.cbbMicroMarcaListadoMarca.FormattingEnabled = true;
            this.cbbMicroMarcaListadoMarca.Location = new System.Drawing.Point(73, 30);
            this.cbbMicroMarcaListadoMarca.Name = "cbbMicroMarcaListadoMarca";
            this.cbbMicroMarcaListadoMarca.Size = new System.Drawing.Size(121, 21);
            this.cbbMicroMarcaListadoMarca.TabIndex = 1;
            // 
            // gbMicroMarcaListado
            // 
            this.gbMicroMarcaListado.Controls.Add(this.btnMicroMarcaListadoLimpiar);
            this.gbMicroMarcaListado.Controls.Add(this.btnMicroMarcaListadoBuscar);
            this.gbMicroMarcaListado.Controls.Add(this.cbbMicroMarcaListadoModelo);
            this.gbMicroMarcaListado.Controls.Add(this.lblMicroMarcaListadoModelo);
            this.gbMicroMarcaListado.Controls.Add(this.cbbMicroMarcaListadoMarca);
            this.gbMicroMarcaListado.Controls.Add(this.lblMicroMarcaListadoMarca);
            this.gbMicroMarcaListado.Location = new System.Drawing.Point(12, 12);
            this.gbMicroMarcaListado.Name = "gbMicroMarcaListado";
            this.gbMicroMarcaListado.Size = new System.Drawing.Size(391, 100);
            this.gbMicroMarcaListado.TabIndex = 2;
            this.gbMicroMarcaListado.TabStop = false;
            this.gbMicroMarcaListado.Text = "Filtros de búsqueda";
            // 
            // lblMicroMarcaListadoModelo
            // 
            this.lblMicroMarcaListadoModelo.AutoSize = true;
            this.lblMicroMarcaListadoModelo.Location = new System.Drawing.Point(8, 66);
            this.lblMicroMarcaListadoModelo.Name = "lblMicroMarcaListadoModelo";
            this.lblMicroMarcaListadoModelo.Size = new System.Drawing.Size(42, 13);
            this.lblMicroMarcaListadoModelo.TabIndex = 2;
            this.lblMicroMarcaListadoModelo.Text = "Modelo";
            // 
            // cbbMicroMarcaListadoModelo
            // 
            this.cbbMicroMarcaListadoModelo.FormattingEnabled = true;
            this.cbbMicroMarcaListadoModelo.Location = new System.Drawing.Point(73, 63);
            this.cbbMicroMarcaListadoModelo.Name = "cbbMicroMarcaListadoModelo";
            this.cbbMicroMarcaListadoModelo.Size = new System.Drawing.Size(121, 21);
            this.cbbMicroMarcaListadoModelo.TabIndex = 3;
            // 
            // btnMicroMarcaListadoBuscar
            // 
            this.btnMicroMarcaListadoBuscar.Location = new System.Drawing.Point(310, 28);
            this.btnMicroMarcaListadoBuscar.Name = "btnMicroMarcaListadoBuscar";
            this.btnMicroMarcaListadoBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnMicroMarcaListadoBuscar.TabIndex = 4;
            this.btnMicroMarcaListadoBuscar.Text = "Buscar";
            this.btnMicroMarcaListadoBuscar.UseVisualStyleBackColor = true;
            // 
            // btnMicroMarcaListadoLimpiar
            // 
            this.btnMicroMarcaListadoLimpiar.Location = new System.Drawing.Point(310, 61);
            this.btnMicroMarcaListadoLimpiar.Name = "btnMicroMarcaListadoLimpiar";
            this.btnMicroMarcaListadoLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnMicroMarcaListadoLimpiar.TabIndex = 5;
            this.btnMicroMarcaListadoLimpiar.Text = "Limpiar";
            this.btnMicroMarcaListadoLimpiar.UseVisualStyleBackColor = true;
            // 
            // dgvMicroMarcaListado
            // 
            this.dgvMicroMarcaListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMicroMarcaListado.Location = new System.Drawing.Point(13, 132);
            this.dgvMicroMarcaListado.Name = "dgvMicroMarcaListado";
            this.dgvMicroMarcaListado.Size = new System.Drawing.Size(390, 150);
            this.dgvMicroMarcaListado.TabIndex = 3;
            // 
            // MicroMarcaListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 301);
            this.Controls.Add(this.dgvMicroMarcaListado);
            this.Controls.Add(this.gbMicroMarcaListado);
            this.Name = "MicroMarcaListado";
            this.Text = "Listado Marca";
            this.gbMicroMarcaListado.ResumeLayout(false);
            this.gbMicroMarcaListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMicroMarcaListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMicroMarcaListadoMarca;
        private System.Windows.Forms.ComboBox cbbMicroMarcaListadoMarca;
        private System.Windows.Forms.GroupBox gbMicroMarcaListado;
        private System.Windows.Forms.ComboBox cbbMicroMarcaListadoModelo;
        private System.Windows.Forms.Label lblMicroMarcaListadoModelo;
        private System.Windows.Forms.Button btnMicroMarcaListadoLimpiar;
        private System.Windows.Forms.Button btnMicroMarcaListadoBuscar;
        private System.Windows.Forms.DataGridView dgvMicroMarcaListado;
    }
}