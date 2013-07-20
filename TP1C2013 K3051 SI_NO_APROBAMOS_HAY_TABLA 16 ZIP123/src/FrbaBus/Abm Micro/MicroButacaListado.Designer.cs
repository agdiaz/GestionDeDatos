namespace FrbaBus.Abm_Micro
{
    partial class MicroButacaListado
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.tbPiso = new System.Windows.Forms.TextBox();
            this.cbTipoButaca = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNroButaca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscarMicro = new System.Windows.Forms.Button();
            this.tbMicro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvOcupadas = new System.Windows.Forms.DataGridView();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.dgvLibres = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOcupadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibres)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.tbPiso);
            this.groupBox1.Controls.Add(this.cbTipoButaca);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbNroButaca);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnBuscarMicro);
            this.groupBox1.Controls.Add(this.tbMicro);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(565, 102);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(484, 102);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // tbPiso
            // 
            this.tbPiso.Location = new System.Drawing.Point(92, 107);
            this.tbPiso.Name = "tbPiso";
            this.tbPiso.Size = new System.Drawing.Size(277, 20);
            this.tbPiso.TabIndex = 8;
            // 
            // cbTipoButaca
            // 
            this.cbTipoButaca.FormattingEnabled = true;
            this.cbTipoButaca.Location = new System.Drawing.Point(92, 79);
            this.cbTipoButaca.Name = "cbTipoButaca";
            this.cbTipoButaca.Size = new System.Drawing.Size(277, 21);
            this.cbTipoButaca.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Piso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo de butaca";
            // 
            // tbNroButaca
            // 
            this.tbNroButaca.Location = new System.Drawing.Point(92, 49);
            this.tbNroButaca.Name = "tbNroButaca";
            this.tbNroButaca.Size = new System.Drawing.Size(277, 20);
            this.tbNroButaca.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nro de butaca";
            // 
            // btnBuscarMicro
            // 
            this.btnBuscarMicro.Location = new System.Drawing.Point(375, 19);
            this.btnBuscarMicro.Name = "btnBuscarMicro";
            this.btnBuscarMicro.Size = new System.Drawing.Size(124, 23);
            this.btnBuscarMicro.TabIndex = 2;
            this.btnBuscarMicro.Text = "Buscar micro";
            this.btnBuscarMicro.UseVisualStyleBackColor = true;
            this.btnBuscarMicro.Click += new System.EventHandler(this.btnBuscarMicro_Click);
            // 
            // tbMicro
            // 
            this.tbMicro.Location = new System.Drawing.Point(92, 22);
            this.tbMicro.Name = "tbMicro";
            this.tbMicro.Size = new System.Drawing.Size(277, 20);
            this.tbMicro.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Micro";
            // 
            // dgvOcupadas
            // 
            this.dgvOcupadas.AllowUserToAddRows = false;
            this.dgvOcupadas.AllowUserToDeleteRows = false;
            this.dgvOcupadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvOcupadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOcupadas.Location = new System.Drawing.Point(12, 180);
            this.dgvOcupadas.Name = "dgvOcupadas";
            this.dgvOcupadas.ReadOnly = true;
            this.dgvOcupadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOcupadas.Size = new System.Drawing.Size(328, 202);
            this.dgvOcupadas.TabIndex = 1;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(584, 398);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionar.TabIndex = 2;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // dgvLibres
            // 
            this.dgvLibres.AllowUserToAddRows = false;
            this.dgvLibres.AllowUserToDeleteRows = false;
            this.dgvLibres.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvLibres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLibres.Location = new System.Drawing.Point(348, 180);
            this.dgvLibres.Name = "dgvLibres";
            this.dgvLibres.ReadOnly = true;
            this.dgvLibres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLibres.Size = new System.Drawing.Size(311, 202);
            this.dgvLibres.TabIndex = 3;
            this.dgvLibres.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLibres_CellContentDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(348, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Libres";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ocupadas";
            // 
            // MicroButacaListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvLibres);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.dgvOcupadas);
            this.Controls.Add(this.groupBox1);
            this.Name = "MicroButacaListado";
            this.Text = "FrbaBus - Micro - Butacas :: Listado";
            this.Load += new System.EventHandler(this.MicroButacaListado_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOcupadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscarMicro;
        private System.Windows.Forms.TextBox tbMicro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNroButaca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvOcupadas;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.TextBox tbPiso;
        private System.Windows.Forms.ComboBox cbTipoButaca;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvLibres;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}