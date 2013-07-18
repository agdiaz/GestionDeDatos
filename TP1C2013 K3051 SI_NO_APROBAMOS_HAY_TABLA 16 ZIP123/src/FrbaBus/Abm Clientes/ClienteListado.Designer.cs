namespace FrbaBus.Abm_Clientes
{
    partial class ClienteListado
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
            this.dgvClienteListado = new System.Windows.Forms.DataGridView();
            this.btnDarBaja = new System.Windows.Forms.Button();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbDiscNA = new System.Windows.Forms.RadioButton();
            this.rbDiscNo = new System.Windows.Forms.RadioButton();
            this.rbDiscSi = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbFemenino = new System.Windows.Forms.CheckBox();
            this.cbMasculino = new System.Windows.Forms.CheckBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnModificarCliente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClienteListado)).BeginInit();
            this.gbFiltros.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvClienteListado
            // 
            this.dgvClienteListado.AllowUserToAddRows = false;
            this.dgvClienteListado.AllowUserToDeleteRows = false;
            this.dgvClienteListado.AllowUserToResizeRows = false;
            this.dgvClienteListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClienteListado.Location = new System.Drawing.Point(12, 142);
            this.dgvClienteListado.MultiSelect = false;
            this.dgvClienteListado.Name = "dgvClienteListado";
            this.dgvClienteListado.ReadOnly = true;
            this.dgvClienteListado.RowHeadersVisible = false;
            this.dgvClienteListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClienteListado.ShowEditingIcon = false;
            this.dgvClienteListado.Size = new System.Drawing.Size(957, 257);
            this.dgvClienteListado.TabIndex = 0;
            // 
            // btnDarBaja
            // 
            this.btnDarBaja.Location = new System.Drawing.Point(93, 406);
            this.btnDarBaja.Name = "btnDarBaja";
            this.btnDarBaja.Size = new System.Drawing.Size(75, 23);
            this.btnDarBaja.TabIndex = 1;
            this.btnDarBaja.Text = "Dar de baja";
            this.btnDarBaja.UseVisualStyleBackColor = true;
            this.btnDarBaja.Click += new System.EventHandler(this.btnDarBaja_Click);
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.groupBox2);
            this.gbFiltros.Controls.Add(this.groupBox1);
            this.gbFiltros.Controls.Add(this.txtApellido);
            this.gbFiltros.Controls.Add(this.txtNombre);
            this.gbFiltros.Controls.Add(this.txtDni);
            this.gbFiltros.Controls.Add(this.label3);
            this.gbFiltros.Controls.Add(this.label2);
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Controls.Add(this.btnBuscar);
            this.gbFiltros.Controls.Add(this.btnLimpiar);
            this.gbFiltros.Location = new System.Drawing.Point(12, 12);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(957, 123);
            this.gbFiltros.TabIndex = 2;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros de búsqueda";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbDiscNA);
            this.groupBox2.Controls.Add(this.rbDiscNo);
            this.groupBox2.Controls.Add(this.rbDiscSi);
            this.groupBox2.Location = new System.Drawing.Point(457, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 67);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Discapacitado";
            // 
            // rbDiscNA
            // 
            this.rbDiscNA.AutoSize = true;
            this.rbDiscNA.Location = new System.Drawing.Point(94, 21);
            this.rbDiscNA.Name = "rbDiscNA";
            this.rbDiscNA.Size = new System.Drawing.Size(76, 17);
            this.rbDiscNA.TabIndex = 2;
            this.rbDiscNA.TabStop = true;
            this.rbDiscNA.Text = "No importa";
            this.rbDiscNA.UseVisualStyleBackColor = true;
            // 
            // rbDiscNo
            // 
            this.rbDiscNo.AutoSize = true;
            this.rbDiscNo.Location = new System.Drawing.Point(48, 21);
            this.rbDiscNo.Name = "rbDiscNo";
            this.rbDiscNo.Size = new System.Drawing.Size(39, 17);
            this.rbDiscNo.TabIndex = 1;
            this.rbDiscNo.TabStop = true;
            this.rbDiscNo.Text = "No";
            this.rbDiscNo.UseVisualStyleBackColor = true;
            // 
            // rbDiscSi
            // 
            this.rbDiscSi.AutoSize = true;
            this.rbDiscSi.Location = new System.Drawing.Point(7, 20);
            this.rbDiscSi.Name = "rbDiscSi";
            this.rbDiscSi.Size = new System.Drawing.Size(34, 17);
            this.rbDiscSi.TabIndex = 0;
            this.rbDiscSi.TabStop = true;
            this.rbDiscSi.Text = "Si";
            this.rbDiscSi.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbFemenino);
            this.groupBox1.Controls.Add(this.cbMasculino);
            this.groupBox1.Location = new System.Drawing.Point(341, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(110, 72);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sexo";
            // 
            // cbFemenino
            // 
            this.cbFemenino.AutoSize = true;
            this.cbFemenino.Location = new System.Drawing.Point(6, 45);
            this.cbFemenino.Name = "cbFemenino";
            this.cbFemenino.Size = new System.Drawing.Size(52, 17);
            this.cbFemenino.TabIndex = 1;
            this.cbFemenino.Text = "Mujer";
            this.cbFemenino.UseVisualStyleBackColor = true;
            // 
            // cbMasculino
            // 
            this.cbMasculino.AutoSize = true;
            this.cbMasculino.Location = new System.Drawing.Point(6, 22);
            this.cbMasculino.Name = "cbMasculino";
            this.cbMasculino.Size = new System.Drawing.Size(63, 17);
            this.cbMasculino.TabIndex = 0;
            this.cbMasculino.Text = "Hombre";
            this.cbMasculino.UseVisualStyleBackColor = true;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(63, 71);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(251, 20);
            this.txtApellido.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(63, 45);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(251, 20);
            this.txtNombre.TabIndex = 6;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(63, 19);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(109, 20);
            this.txtDni.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Apellido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "D.N.I.:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(876, 15);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(876, 44);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 0;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnModificarCliente
            // 
            this.btnModificarCliente.Location = new System.Drawing.Point(12, 406);
            this.btnModificarCliente.Name = "btnModificarCliente";
            this.btnModificarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnModificarCliente.TabIndex = 3;
            this.btnModificarCliente.Text = "Modificar";
            this.btnModificarCliente.UseVisualStyleBackColor = true;
            this.btnModificarCliente.Click += new System.EventHandler(this.btnModificarCliente_Click);
            // 
            // ClienteListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 454);
            this.Controls.Add(this.btnModificarCliente);
            this.Controls.Add(this.gbFiltros);
            this.Controls.Add(this.btnDarBaja);
            this.Controls.Add(this.dgvClienteListado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClienteListado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrbaBus - Clientes :: Listado";
            this.Load += new System.EventHandler(this.ClienteListado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClienteListado)).EndInit();
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDarBaja;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvClienteListado;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbFemenino;
        private System.Windows.Forms.CheckBox cbMasculino;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbDiscNA;
        private System.Windows.Forms.RadioButton rbDiscNo;
        private System.Windows.Forms.RadioButton rbDiscSi;
        private System.Windows.Forms.Button btnModificarCliente;
    }
}