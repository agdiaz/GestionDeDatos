﻿namespace FrbaBus.Rol
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
            this.button3 = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.cbbRolListadoFuncionalidades = new System.Windows.Forms.ComboBox();
            this.tbRolListadoRol = new System.Windows.Forms.TextBox();
            this.lblRolListadoFuncionalidades = new System.Windows.Forms.Label();
            this.lblRolListadoRol = new System.Windows.Forms.Label();
            this.dgvRolListado = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gbRolListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRolListado)).BeginInit();
            this.SuspendLayout();
            // 
            // gbRolListado
            // 
            this.gbRolListado.Controls.Add(this.button3);
            this.gbRolListado.Controls.Add(this.btnFiltrar);
            this.gbRolListado.Controls.Add(this.cbbRolListadoFuncionalidades);
            this.gbRolListado.Controls.Add(this.tbRolListadoRol);
            this.gbRolListado.Controls.Add(this.lblRolListadoFuncionalidades);
            this.gbRolListado.Controls.Add(this.lblRolListadoRol);
            this.gbRolListado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbRolListado.Location = new System.Drawing.Point(24, 26);
            this.gbRolListado.Name = "gbRolListado";
            this.gbRolListado.Size = new System.Drawing.Size(435, 100);
            this.gbRolListado.TabIndex = 0;
            this.gbRolListado.TabStop = false;
            this.gbRolListado.Text = "Filtros de busqueda";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(344, 57);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Limpiar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(344, 28);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(78, 25);
            this.btnFiltrar.TabIndex = 2;
            this.btnFiltrar.Text = "Buscar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // cbbRolListadoFuncionalidades
            // 
            this.cbbRolListadoFuncionalidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRolListadoFuncionalidades.FormattingEnabled = true;
            this.cbbRolListadoFuncionalidades.Location = new System.Drawing.Point(107, 60);
            this.cbbRolListadoFuncionalidades.Name = "cbbRolListadoFuncionalidades";
            this.cbbRolListadoFuncionalidades.Size = new System.Drawing.Size(231, 21);
            this.cbbRolListadoFuncionalidades.TabIndex = 1;
            // 
            // tbRolListadoRol
            // 
            this.tbRolListadoRol.Location = new System.Drawing.Point(107, 28);
            this.tbRolListadoRol.Name = "tbRolListadoRol";
            this.tbRolListadoRol.Size = new System.Drawing.Size(231, 20);
            this.tbRolListadoRol.TabIndex = 0;
            // 
            // lblRolListadoFuncionalidades
            // 
            this.lblRolListadoFuncionalidades.AutoSize = true;
            this.lblRolListadoFuncionalidades.Location = new System.Drawing.Point(17, 63);
            this.lblRolListadoFuncionalidades.Name = "lblRolListadoFuncionalidades";
            this.lblRolListadoFuncionalidades.Size = new System.Drawing.Size(73, 13);
            this.lblRolListadoFuncionalidades.TabIndex = 1;
            this.lblRolListadoFuncionalidades.Text = "Funcionalidad";
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
            // dgvRolListado
            // 
            this.dgvRolListado.AllowUserToAddRows = false;
            this.dgvRolListado.AllowUserToDeleteRows = false;
            this.dgvRolListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRolListado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRolListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRolListado.Location = new System.Drawing.Point(24, 132);
            this.dgvRolListado.Name = "dgvRolListado";
            this.dgvRolListado.ReadOnly = true;
            this.dgvRolListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRolListado.Size = new System.Drawing.Size(435, 150);
            this.dgvRolListado.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(105, 310);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Dar de baja";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RolListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 357);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvRolListado);
            this.Controls.Add(this.gbRolListado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RolListado";
            this.Text = "FrbaBus - Roles :: Listado";
            this.Load += new System.EventHandler(this.RolListado_Load);
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
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button button3;
    }
}