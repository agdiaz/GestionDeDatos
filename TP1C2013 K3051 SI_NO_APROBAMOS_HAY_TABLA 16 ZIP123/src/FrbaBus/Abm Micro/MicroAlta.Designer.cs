namespace FrbaBus.Abm_Micro
{
    partial class MicroAlta
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
            this.cbbMicroAltaTipoServicio = new System.Windows.Forms.ComboBox();
            this.lblMicroAltaTipoServicio = new System.Windows.Forms.Label();
            this.lblMicroAltaTipoEmpresa = new System.Windows.Forms.Label();
            this.cbbMicroAltaTipoEmpresa = new System.Windows.Forms.ComboBox();
            this.lblMicroAltaKgsEncomiendas = new System.Windows.Forms.Label();
            this.btnMicroAltaGuardar = new System.Windows.Forms.Button();
            this.btnMicroAltaLimpiar = new System.Windows.Forms.Button();
            this.lblMicroAltaModelo = new System.Windows.Forms.Label();
            this.cbbMicroAltaTipoModelo = new System.Windows.Forms.ComboBox();
            this.mtbMicroAltaKgsEncomiendas = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaAlta = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbMicroAltaTipoServicio
            // 
            this.cbbMicroAltaTipoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMicroAltaTipoServicio.FormattingEnabled = true;
            this.cbbMicroAltaTipoServicio.Location = new System.Drawing.Point(112, 24);
            this.cbbMicroAltaTipoServicio.Name = "cbbMicroAltaTipoServicio";
            this.cbbMicroAltaTipoServicio.Size = new System.Drawing.Size(152, 21);
            this.cbbMicroAltaTipoServicio.TabIndex = 0;
            // 
            // lblMicroAltaTipoServicio
            // 
            this.lblMicroAltaTipoServicio.AutoSize = true;
            this.lblMicroAltaTipoServicio.Location = new System.Drawing.Point(6, 27);
            this.lblMicroAltaTipoServicio.Name = "lblMicroAltaTipoServicio";
            this.lblMicroAltaTipoServicio.Size = new System.Drawing.Size(82, 13);
            this.lblMicroAltaTipoServicio.TabIndex = 1;
            this.lblMicroAltaTipoServicio.Text = "Tipo de servicio";
            // 
            // lblMicroAltaTipoEmpresa
            // 
            this.lblMicroAltaTipoEmpresa.AutoSize = true;
            this.lblMicroAltaTipoEmpresa.Location = new System.Drawing.Point(6, 48);
            this.lblMicroAltaTipoEmpresa.Name = "lblMicroAltaTipoEmpresa";
            this.lblMicroAltaTipoEmpresa.Size = new System.Drawing.Size(37, 13);
            this.lblMicroAltaTipoEmpresa.TabIndex = 4;
            this.lblMicroAltaTipoEmpresa.Text = "Marca";
            // 
            // cbbMicroAltaTipoEmpresa
            // 
            this.cbbMicroAltaTipoEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMicroAltaTipoEmpresa.FormattingEnabled = true;
            this.cbbMicroAltaTipoEmpresa.Location = new System.Drawing.Point(112, 42);
            this.cbbMicroAltaTipoEmpresa.Name = "cbbMicroAltaTipoEmpresa";
            this.cbbMicroAltaTipoEmpresa.Size = new System.Drawing.Size(161, 21);
            this.cbbMicroAltaTipoEmpresa.TabIndex = 5;
            this.cbbMicroAltaTipoEmpresa.SelectedIndexChanged += new System.EventHandler(this.cbbMicroAltaTipoEmpresa_SelectedIndexChanged);
            // 
            // lblMicroAltaKgsEncomiendas
            // 
            this.lblMicroAltaKgsEncomiendas.AutoSize = true;
            this.lblMicroAltaKgsEncomiendas.Location = new System.Drawing.Point(6, 54);
            this.lblMicroAltaKgsEncomiendas.Name = "lblMicroAltaKgsEncomiendas";
            this.lblMicroAltaKgsEncomiendas.Size = new System.Drawing.Size(170, 13);
            this.lblMicroAltaKgsEncomiendas.TabIndex = 6;
            this.lblMicroAltaKgsEncomiendas.Text = "Kgs disponibles para encomiendas";
            // 
            // btnMicroAltaGuardar
            // 
            this.btnMicroAltaGuardar.Enabled = false;
            this.btnMicroAltaGuardar.Location = new System.Drawing.Point(21, 296);
            this.btnMicroAltaGuardar.Name = "btnMicroAltaGuardar";
            this.btnMicroAltaGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnMicroAltaGuardar.TabIndex = 8;
            this.btnMicroAltaGuardar.Text = "Guardar";
            this.btnMicroAltaGuardar.UseVisualStyleBackColor = true;
            this.btnMicroAltaGuardar.Click += new System.EventHandler(this.btnMicroAltaGuardar_Click);
            // 
            // btnMicroAltaLimpiar
            // 
            this.btnMicroAltaLimpiar.Location = new System.Drawing.Point(102, 296);
            this.btnMicroAltaLimpiar.Name = "btnMicroAltaLimpiar";
            this.btnMicroAltaLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnMicroAltaLimpiar.TabIndex = 9;
            this.btnMicroAltaLimpiar.Text = "Limpiar";
            this.btnMicroAltaLimpiar.UseVisualStyleBackColor = true;
            this.btnMicroAltaLimpiar.Click += new System.EventHandler(this.btnMicroAltaLimpiar_Click);
            // 
            // lblMicroAltaModelo
            // 
            this.lblMicroAltaModelo.AutoSize = true;
            this.lblMicroAltaModelo.Location = new System.Drawing.Point(6, 20);
            this.lblMicroAltaModelo.Name = "lblMicroAltaModelo";
            this.lblMicroAltaModelo.Size = new System.Drawing.Size(42, 13);
            this.lblMicroAltaModelo.TabIndex = 10;
            this.lblMicroAltaModelo.Text = "Modelo";
            // 
            // cbbMicroAltaTipoModelo
            // 
            this.cbbMicroAltaTipoModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMicroAltaTipoModelo.FormattingEnabled = true;
            this.cbbMicroAltaTipoModelo.Items.AddRange(new object[] {
            "Modelo"});
            this.cbbMicroAltaTipoModelo.Location = new System.Drawing.Point(112, 17);
            this.cbbMicroAltaTipoModelo.Name = "cbbMicroAltaTipoModelo";
            this.cbbMicroAltaTipoModelo.Size = new System.Drawing.Size(161, 21);
            this.cbbMicroAltaTipoModelo.TabIndex = 11;
            // 
            // mtbMicroAltaKgsEncomiendas
            // 
            this.mtbMicroAltaKgsEncomiendas.Location = new System.Drawing.Point(198, 51);
            this.mtbMicroAltaKgsEncomiendas.Mask = "99999";
            this.mtbMicroAltaKgsEncomiendas.Name = "mtbMicroAltaKgsEncomiendas";
            this.mtbMicroAltaKgsEncomiendas.Size = new System.Drawing.Size(66, 20);
            this.mtbMicroAltaKgsEncomiendas.TabIndex = 13;
            this.mtbMicroAltaKgsEncomiendas.ValidatingType = typeof(int);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Patente";
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(112, 68);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(100, 20);
            this.txtPatente.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Fecha alta:";
            // 
            // dtpFechaAlta
            // 
            this.dtpFechaAlta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaAlta.Location = new System.Drawing.Point(72, 19);
            this.dtpFechaAlta.Name = "dtpFechaAlta";
            this.dtpFechaAlta.Size = new System.Drawing.Size(192, 20);
            this.dtpFechaAlta.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMicroAltaModelo);
            this.groupBox1.Controls.Add(this.lblMicroAltaTipoEmpresa);
            this.groupBox1.Controls.Add(this.cbbMicroAltaTipoEmpresa);
            this.groupBox1.Controls.Add(this.txtPatente);
            this.groupBox1.Controls.Add(this.cbbMicroAltaTipoModelo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 100);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbbMicroAltaTipoServicio);
            this.groupBox2.Controls.Add(this.lblMicroAltaTipoServicio);
            this.groupBox2.Controls.Add(this.lblMicroAltaKgsEncomiendas);
            this.groupBox2.Controls.Add(this.mtbMicroAltaKgsEncomiendas);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 100);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Servicio";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dtpFechaAlta);
            this.groupBox3.Location = new System.Drawing.Point(12, 224);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(279, 66);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Opciones";
            // 
            // MicroAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 335);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnMicroAltaLimpiar);
            this.Controls.Add(this.btnMicroAltaGuardar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MicroAlta";
            this.Text = "FrbaBus - Micros :: Alta";
            this.Load += new System.EventHandler(this.MicroAlta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbMicroAltaTipoServicio;
        private System.Windows.Forms.Label lblMicroAltaTipoServicio;
        private System.Windows.Forms.Label lblMicroAltaTipoEmpresa;
        private System.Windows.Forms.ComboBox cbbMicroAltaTipoEmpresa;
        private System.Windows.Forms.Label lblMicroAltaKgsEncomiendas;
        private System.Windows.Forms.Button btnMicroAltaGuardar;
        private System.Windows.Forms.Button btnMicroAltaLimpiar;
        private System.Windows.Forms.Label lblMicroAltaModelo;
        private System.Windows.Forms.ComboBox cbbMicroAltaTipoModelo;
        private System.Windows.Forms.MaskedTextBox mtbMicroAltaKgsEncomiendas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaAlta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}