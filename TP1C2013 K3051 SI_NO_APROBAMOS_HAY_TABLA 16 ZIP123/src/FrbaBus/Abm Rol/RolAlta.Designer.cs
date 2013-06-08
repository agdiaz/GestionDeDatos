namespace FrbaBus.Rol
{
    partial class RolAlta
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
            this.lblRolAltaNuevoRol = new System.Windows.Forms.Label();
            this.tbRolAltaNuevoRol = new System.Windows.Forms.TextBox();
            this.lblRolAltaFuncionalidades = new System.Windows.Forms.Label();
            this.cbbRolAltaFuncionalidades = new System.Windows.Forms.ComboBox();
            this.btnRolAltaGuardar = new System.Windows.Forms.Button();
            this.btnRolAltaLimpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRolAltaNuevoRol
            // 
            this.lblRolAltaNuevoRol.AutoSize = true;
            this.lblRolAltaNuevoRol.Location = new System.Drawing.Point(27, 29);
            this.lblRolAltaNuevoRol.Name = "lblRolAltaNuevoRol";
            this.lblRolAltaNuevoRol.Size = new System.Drawing.Size(58, 13);
            this.lblRolAltaNuevoRol.TabIndex = 0;
            this.lblRolAltaNuevoRol.Text = "Nuevo Rol";
            // 
            // tbRolAltaNuevoRol
            // 
            this.tbRolAltaNuevoRol.Location = new System.Drawing.Point(164, 26);
            this.tbRolAltaNuevoRol.Name = "tbRolAltaNuevoRol";
            this.tbRolAltaNuevoRol.Size = new System.Drawing.Size(121, 20);
            this.tbRolAltaNuevoRol.TabIndex = 1;
            // 
            // lblRolAltaFuncionalidades
            // 
            this.lblRolAltaFuncionalidades.AutoSize = true;
            this.lblRolAltaFuncionalidades.Location = new System.Drawing.Point(27, 71);
            this.lblRolAltaFuncionalidades.Name = "lblRolAltaFuncionalidades";
            this.lblRolAltaFuncionalidades.Size = new System.Drawing.Size(84, 13);
            this.lblRolAltaFuncionalidades.TabIndex = 2;
            this.lblRolAltaFuncionalidades.Text = "Funcionalidades";
            // 
            // cbbRolAltaFuncionalidades
            // 
            this.cbbRolAltaFuncionalidades.FormattingEnabled = true;
            this.cbbRolAltaFuncionalidades.Location = new System.Drawing.Point(164, 68);
            this.cbbRolAltaFuncionalidades.Name = "cbbRolAltaFuncionalidades";
            this.cbbRolAltaFuncionalidades.Size = new System.Drawing.Size(121, 21);
            this.cbbRolAltaFuncionalidades.TabIndex = 3;
            // 
            // btnRolAltaGuardar
            // 
            this.btnRolAltaGuardar.Location = new System.Drawing.Point(573, 227);
            this.btnRolAltaGuardar.Name = "btnRolAltaGuardar";
            this.btnRolAltaGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnRolAltaGuardar.TabIndex = 4;
            this.btnRolAltaGuardar.Text = "Guardar";
            this.btnRolAltaGuardar.UseVisualStyleBackColor = true;
            // 
            // btnRolAltaLimpiar
            // 
            this.btnRolAltaLimpiar.Location = new System.Drawing.Point(13, 227);
            this.btnRolAltaLimpiar.Name = "btnRolAltaLimpiar";
            this.btnRolAltaLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnRolAltaLimpiar.TabIndex = 5;
            this.btnRolAltaLimpiar.Text = "Limpiar";
            this.btnRolAltaLimpiar.UseVisualStyleBackColor = true;
            // 
            // RolAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 262);
            this.Controls.Add(this.btnRolAltaLimpiar);
            this.Controls.Add(this.btnRolAltaGuardar);
            this.Controls.Add(this.cbbRolAltaFuncionalidades);
            this.Controls.Add(this.lblRolAltaFuncionalidades);
            this.Controls.Add(this.tbRolAltaNuevoRol);
            this.Controls.Add(this.lblRolAltaNuevoRol);
            this.Name = "RolAlta";
            this.Text = "RolAlta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRolAltaNuevoRol;
        private System.Windows.Forms.TextBox tbRolAltaNuevoRol;
        private System.Windows.Forms.Label lblRolAltaFuncionalidades;
        private System.Windows.Forms.ComboBox cbbRolAltaFuncionalidades;
        private System.Windows.Forms.Button btnRolAltaGuardar;
        private System.Windows.Forms.Button btnRolAltaLimpiar;
    }
}