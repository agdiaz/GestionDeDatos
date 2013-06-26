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
            this.btnRolAltaGuardar = new System.Windows.Forms.Button();
            this.btnRolAltaLimpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clbFuncionalidades = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRolAltaNuevoRol
            // 
            this.lblRolAltaNuevoRol.AutoSize = true;
            this.lblRolAltaNuevoRol.Location = new System.Drawing.Point(6, 30);
            this.lblRolAltaNuevoRol.Name = "lblRolAltaNuevoRol";
            this.lblRolAltaNuevoRol.Size = new System.Drawing.Size(44, 13);
            this.lblRolAltaNuevoRol.TabIndex = 0;
            this.lblRolAltaNuevoRol.Text = "Nombre";
            // 
            // tbRolAltaNuevoRol
            // 
            this.tbRolAltaNuevoRol.Location = new System.Drawing.Point(56, 27);
            this.tbRolAltaNuevoRol.Name = "tbRolAltaNuevoRol";
            this.tbRolAltaNuevoRol.Size = new System.Drawing.Size(223, 20);
            this.tbRolAltaNuevoRol.TabIndex = 1;
            // 
            // lblRolAltaFuncionalidades
            // 
            this.lblRolAltaFuncionalidades.AutoSize = true;
            this.lblRolAltaFuncionalidades.Location = new System.Drawing.Point(6, 58);
            this.lblRolAltaFuncionalidades.Name = "lblRolAltaFuncionalidades";
            this.lblRolAltaFuncionalidades.Size = new System.Drawing.Size(84, 13);
            this.lblRolAltaFuncionalidades.TabIndex = 2;
            this.lblRolAltaFuncionalidades.Text = "Funcionalidades";
            // 
            // btnRolAltaGuardar
            // 
            this.btnRolAltaGuardar.Location = new System.Drawing.Point(222, 449);
            this.btnRolAltaGuardar.Name = "btnRolAltaGuardar";
            this.btnRolAltaGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnRolAltaGuardar.TabIndex = 4;
            this.btnRolAltaGuardar.Text = "Guardar";
            this.btnRolAltaGuardar.UseVisualStyleBackColor = true;
            this.btnRolAltaGuardar.Click += new System.EventHandler(this.btnRolAltaGuardar_Click);
            // 
            // btnRolAltaLimpiar
            // 
            this.btnRolAltaLimpiar.Location = new System.Drawing.Point(137, 449);
            this.btnRolAltaLimpiar.Name = "btnRolAltaLimpiar";
            this.btnRolAltaLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnRolAltaLimpiar.TabIndex = 5;
            this.btnRolAltaLimpiar.Text = "Limpiar";
            this.btnRolAltaLimpiar.UseVisualStyleBackColor = true;
            this.btnRolAltaLimpiar.Click += new System.EventHandler(this.btnRolAltaLimpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clbFuncionalidades);
            this.groupBox1.Controls.Add(this.lblRolAltaNuevoRol);
            this.groupBox1.Controls.Add(this.lblRolAltaFuncionalidades);
            this.groupBox1.Controls.Add(this.tbRolAltaNuevoRol);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 431);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevo Rol";
            // 
            // clbFuncionalidades
            // 
            this.clbFuncionalidades.FormattingEnabled = true;
            this.clbFuncionalidades.Location = new System.Drawing.Point(9, 74);
            this.clbFuncionalidades.Name = "clbFuncionalidades";
            this.clbFuncionalidades.Size = new System.Drawing.Size(270, 334);
            this.clbFuncionalidades.TabIndex = 3;
            // 
            // RolAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 484);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRolAltaLimpiar);
            this.Controls.Add(this.btnRolAltaGuardar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RolAlta";
            this.Text = "FrbaBus - Roles :: Alta";
            this.Load += new System.EventHandler(this.RolAlta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRolAltaNuevoRol;
        private System.Windows.Forms.TextBox tbRolAltaNuevoRol;
        private System.Windows.Forms.Label lblRolAltaFuncionalidades;
        private System.Windows.Forms.Button btnRolAltaGuardar;
        private System.Windows.Forms.Button btnRolAltaLimpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox clbFuncionalidades;
    }
}