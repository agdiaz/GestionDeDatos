namespace FrbaBus.Rol
{
    partial class RolModificar
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
            this.lblRolModificarNuevoRol = new System.Windows.Forms.Label();
            this.tbRolModificarNuevoRol = new System.Windows.Forms.TextBox();
            this.lblRolModificarFuncionalidades = new System.Windows.Forms.Label();
            this.btnRolModificarGuardar = new System.Windows.Forms.Button();
            this.btnRolModificarLimpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbHabilitado = new System.Windows.Forms.CheckBox();
            this.clbFuncionalidades = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRolModificarNuevoRol
            // 
            this.lblRolModificarNuevoRol.AutoSize = true;
            this.lblRolModificarNuevoRol.Location = new System.Drawing.Point(6, 30);
            this.lblRolModificarNuevoRol.Name = "lblRolModificarNuevoRol";
            this.lblRolModificarNuevoRol.Size = new System.Drawing.Size(44, 13);
            this.lblRolModificarNuevoRol.TabIndex = 0;
            this.lblRolModificarNuevoRol.Text = "Nombre";
            // 
            // tbRolModificarNuevoRol
            // 
            this.tbRolModificarNuevoRol.Location = new System.Drawing.Point(56, 27);
            this.tbRolModificarNuevoRol.Name = "tbRolModificarNuevoRol";
            this.tbRolModificarNuevoRol.Size = new System.Drawing.Size(223, 20);
            this.tbRolModificarNuevoRol.TabIndex = 1;
            // 
            // lblRolModificarFuncionalidades
            // 
            this.lblRolModificarFuncionalidades.AutoSize = true;
            this.lblRolModificarFuncionalidades.Location = new System.Drawing.Point(6, 73);
            this.lblRolModificarFuncionalidades.Name = "lblRolModificarFuncionalidades";
            this.lblRolModificarFuncionalidades.Size = new System.Drawing.Size(84, 13);
            this.lblRolModificarFuncionalidades.TabIndex = 2;
            this.lblRolModificarFuncionalidades.Text = "Funcionalidades";
            // 
            // btnRolModificarGuardar
            // 
            this.btnRolModificarGuardar.Location = new System.Drawing.Point(222, 449);
            this.btnRolModificarGuardar.Name = "btnRolModificarGuardar";
            this.btnRolModificarGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnRolModificarGuardar.TabIndex = 4;
            this.btnRolModificarGuardar.Text = "Guardar";
            this.btnRolModificarGuardar.UseVisualStyleBackColor = true;
            this.btnRolModificarGuardar.Click += new System.EventHandler(this.btnRolModificarGuardar_Click);
            // 
            // btnRolModificarLimpiar
            // 
            this.btnRolModificarLimpiar.Location = new System.Drawing.Point(137, 449);
            this.btnRolModificarLimpiar.Name = "btnRolModificarLimpiar";
            this.btnRolModificarLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnRolModificarLimpiar.TabIndex = 5;
            this.btnRolModificarLimpiar.Text = "Limpiar";
            this.btnRolModificarLimpiar.UseVisualStyleBackColor = true;
            this.btnRolModificarLimpiar.Click += new System.EventHandler(this.btnRolModificarLimpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbHabilitado);
            this.groupBox1.Controls.Add(this.clbFuncionalidades);
            this.groupBox1.Controls.Add(this.lblRolModificarNuevoRol);
            this.groupBox1.Controls.Add(this.lblRolModificarFuncionalidades);
            this.groupBox1.Controls.Add(this.tbRolModificarNuevoRol);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 431);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificar Rol";
            // 
            // cbHabilitado
            // 
            this.cbHabilitado.AutoSize = true;
            this.cbHabilitado.Location = new System.Drawing.Point(56, 53);
            this.cbHabilitado.Name = "cbHabilitado";
            this.cbHabilitado.Size = new System.Drawing.Size(73, 17);
            this.cbHabilitado.TabIndex = 4;
            this.cbHabilitado.Text = "Habilitado";
            this.cbHabilitado.UseVisualStyleBackColor = true;
            // 
            // clbFuncionalidades
            // 
            this.clbFuncionalidades.FormattingEnabled = true;
            this.clbFuncionalidades.Location = new System.Drawing.Point(9, 89);
            this.clbFuncionalidades.Name = "clbFuncionalidades";
            this.clbFuncionalidades.Size = new System.Drawing.Size(270, 319);
            this.clbFuncionalidades.TabIndex = 3;
            // 
            // RolModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 484);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRolModificarLimpiar);
            this.Controls.Add(this.btnRolModificarGuardar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RolModificar";
            this.Text = "FrbaBus - Roles :: Modificación";
            this.Load += new System.EventHandler(this.RolModificar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRolModificarNuevoRol;
        private System.Windows.Forms.TextBox tbRolModificarNuevoRol;
        private System.Windows.Forms.Label lblRolModificarFuncionalidades;
        private System.Windows.Forms.Button btnRolModificarGuardar;
        private System.Windows.Forms.Button btnRolModificarLimpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox clbFuncionalidades;
        private System.Windows.Forms.CheckBox cbHabilitado;
    }
}