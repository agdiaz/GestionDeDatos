namespace FrbaBus.Rol
{
    partial class RolListado
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
            this.gbRolListado = new System.Windows.Forms.GroupBox();
            this.lblRolListadoRol = new System.Windows.Forms.Label();
            this.lblRolListadoFuncionalidades = new System.Windows.Forms.Label();
            this.tbRolListadoRol = new System.Windows.Forms.TextBox();
            this.cbbRolListadoFuncionalidades = new System.Windows.Forms.ComboBox();
            this.dgvRolListado = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gbRolListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRolListado)).BeginInit();
            this.SuspendLayout();
            // 
            // gbRolListado
            // 
            this.gbRolListado.Controls.Add(this.cbbRolListadoFuncionalidades);
            this.gbRolListado.Controls.Add(this.tbRolListadoRol);
            this.gbRolListado.Controls.Add(this.lblRolListadoFuncionalidades);
            this.gbRolListado.Controls.Add(this.lblRolListadoRol);
            this.gbRolListado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbRolListado.Location = new System.Drawing.Point(32, 26);
            this.gbRolListado.Name = "gbRolListado";
            this.gbRolListado.Size = new System.Drawing.Size(606, 100);
            this.gbRolListado.TabIndex = 0;
            this.gbRolListado.TabStop = false;
            this.gbRolListado.Text = "Filtros de busqueda";
            // 
            // lblRolListadoRol
            // 
            this.lblRolListadoRol.AutoSize = true;
            this.lblRolListadoRol.Location = new System.Drawing.Point(17, 31);
            this.lblRolListadoRol.Name = "lblRolListadoRol";
            this.lblRolListadoRol.Size = new System.Drawing.Size(23, 13);
            this.lblRolListadoRol.TabIndex = 0;
            this.lblRolListadoRol.Text = "Rol";
            // 
            // lblRolListadoFuncionalidades
            // 
            this.lblRolListadoFuncionalidades.AutoSize = true;
            this.lblRolListadoFuncionalidades.Location = new System.Drawing.Point(17, 63);
            this.lblRolListadoFuncionalidades.Name = "lblRolListadoFuncionalidades";
            this.lblRolListadoFuncionalidades.Size = new System.Drawing.Size(84, 13);
            this.lblRolListadoFuncionalidades.TabIndex = 1;
            this.lblRolListadoFuncionalidades.Text = "Funcionalidades";
            // 
            // tbRolListadoRol
            // 
            this.tbRolListadoRol.Location = new System.Drawing.Point(146, 28);
            this.tbRolListadoRol.Name = "tbRolListadoRol";
            this.tbRolListadoRol.Size = new System.Drawing.Size(121, 20);
            this.tbRolListadoRol.TabIndex = 2;
            // 
            // cbbRolListadoFuncionalidades
            // 
            this.cbbRolListadoFuncionalidades.FormattingEnabled = true;
            this.cbbRolListadoFuncionalidades.Location = new System.Drawing.Point(146, 60);
            this.cbbRolListadoFuncionalidades.Name = "cbbRolListadoFuncionalidades";
            this.cbbRolListadoFuncionalidades.Size = new System.Drawing.Size(121, 21);
            this.cbbRolListadoFuncionalidades.TabIndex = 3;
            // 
            // dgvRolListado
            // 
            this.dgvRolListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRolListado.Location = new System.Drawing.Point(32, 145);
            this.dgvRolListado.Name = "dgvRolListado";
            this.dgvRolListado.Size = new System.Drawing.Size(606, 150);
            this.dgvRolListado.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(625, 425);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 425);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Dar de baja";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // RolListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 460);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvRolListado);
            this.Controls.Add(this.gbRolListado);
            this.Name = "RolListado";
            this.Text = "RolListado";
            this.gbRolListado.ResumeLayout(false);
            this.gbRolListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRolListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRolListado;
        private System.Windows.Forms.ComboBox cbbRolListadoFuncionalidades;
        private System.Windows.Forms.TextBox tbRolListadoRol;
        private System.Windows.Forms.Label lblRolListadoFuncionalidades;
        private System.Windows.Forms.Label lblRolListadoRol;
        private System.Windows.Forms.DataGridView dgvRolListado;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}