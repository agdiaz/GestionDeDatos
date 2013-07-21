namespace FrbaBus.Cancelaciones
{
    partial class CancelacionesListado
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
            this.dgvCancelaciones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCancelaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCancelaciones
            // 
            this.dgvCancelaciones.AllowUserToAddRows = false;
            this.dgvCancelaciones.AllowUserToDeleteRows = false;
            this.dgvCancelaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCancelaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCancelaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCancelaciones.Location = new System.Drawing.Point(13, 20);
            this.dgvCancelaciones.Name = "dgvCancelaciones";
            this.dgvCancelaciones.ReadOnly = true;
            this.dgvCancelaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCancelaciones.Size = new System.Drawing.Size(647, 369);
            this.dgvCancelaciones.TabIndex = 1;
            // 
            // CancelacionesListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 401);
            this.Controls.Add(this.dgvCancelaciones);
            this.Name = "CancelacionesListado";
            this.Text = "FrbaBus - Cancelaciones :: Listado";
            this.Load += new System.EventHandler(this.CancelacionesListado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCancelaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCancelaciones;
    }
}