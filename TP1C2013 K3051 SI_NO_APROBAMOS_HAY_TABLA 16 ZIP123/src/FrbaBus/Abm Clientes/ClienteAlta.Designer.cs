namespace FrbaBus.Abm_Clientes
{
    partial class ClienteAlta
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
            this.lblClienteDNI = new System.Windows.Forms.Label();
            this.lblClienteNombre = new System.Windows.Forms.Label();
            this.lblClienteApellido = new System.Windows.Forms.Label();
            this.lblClienteDireccion = new System.Windows.Forms.Label();
            this.lblClienteTelefono = new System.Windows.Forms.Label();
            this.lblClienteMail = new System.Windows.Forms.Label();
            this.lblClienteFechaNac = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpClienteFechaNac = new System.Windows.Forms.DateTimePicker();
            this.cbClienteEsDiscapacitado = new System.Windows.Forms.CheckBox();
            this.rbClienteHombre = new System.Windows.Forms.RadioButton();
            this.rbClienteMujer = new System.Windows.Forms.RadioButton();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.mtbClienteDNI = new System.Windows.Forms.MaskedTextBox();
            this.mtbClienteTelefono = new System.Windows.Forms.MaskedTextBox();
            this.tbClienteMail = new System.Windows.Forms.TextBox();
            this.tbClienteNombre = new System.Windows.Forms.TextBox();
            this.tbClienteApellido = new System.Windows.Forms.TextBox();
            this.tbClienteDireccion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblClienteDNI
            // 
            this.lblClienteDNI.AutoSize = true;
            this.lblClienteDNI.Location = new System.Drawing.Point(13, 13);
            this.lblClienteDNI.Name = "lblClienteDNI";
            this.lblClienteDNI.Size = new System.Drawing.Size(38, 13);
            this.lblClienteDNI.TabIndex = 0;
            this.lblClienteDNI.Text = "D.N.I.:";
            // 
            // lblClienteNombre
            // 
            this.lblClienteNombre.AutoSize = true;
            this.lblClienteNombre.Location = new System.Drawing.Point(13, 39);
            this.lblClienteNombre.Name = "lblClienteNombre";
            this.lblClienteNombre.Size = new System.Drawing.Size(47, 13);
            this.lblClienteNombre.TabIndex = 1;
            this.lblClienteNombre.Text = "Nombre:";
            // 
            // lblClienteApellido
            // 
            this.lblClienteApellido.AutoSize = true;
            this.lblClienteApellido.Location = new System.Drawing.Point(13, 65);
            this.lblClienteApellido.Name = "lblClienteApellido";
            this.lblClienteApellido.Size = new System.Drawing.Size(47, 13);
            this.lblClienteApellido.TabIndex = 2;
            this.lblClienteApellido.Text = "Apellido:";
            // 
            // lblClienteDireccion
            // 
            this.lblClienteDireccion.AutoSize = true;
            this.lblClienteDireccion.Location = new System.Drawing.Point(13, 91);
            this.lblClienteDireccion.Name = "lblClienteDireccion";
            this.lblClienteDireccion.Size = new System.Drawing.Size(55, 13);
            this.lblClienteDireccion.TabIndex = 3;
            this.lblClienteDireccion.Text = "Dirección:";
            // 
            // lblClienteTelefono
            // 
            this.lblClienteTelefono.AutoSize = true;
            this.lblClienteTelefono.Location = new System.Drawing.Point(13, 117);
            this.lblClienteTelefono.Name = "lblClienteTelefono";
            this.lblClienteTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblClienteTelefono.TabIndex = 4;
            this.lblClienteTelefono.Text = "Teléfono:";
            // 
            // lblClienteMail
            // 
            this.lblClienteMail.AutoSize = true;
            this.lblClienteMail.Location = new System.Drawing.Point(13, 143);
            this.lblClienteMail.Name = "lblClienteMail";
            this.lblClienteMail.Size = new System.Drawing.Size(29, 13);
            this.lblClienteMail.TabIndex = 5;
            this.lblClienteMail.Text = "Mail:";
            // 
            // lblClienteFechaNac
            // 
            this.lblClienteFechaNac.AutoSize = true;
            this.lblClienteFechaNac.Location = new System.Drawing.Point(13, 169);
            this.lblClienteFechaNac.Name = "lblClienteFechaNac";
            this.lblClienteFechaNac.Size = new System.Drawing.Size(63, 13);
            this.lblClienteFechaNac.TabIndex = 6;
            this.lblClienteFechaNac.Text = "Fecha Nac:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Sexo:";
            // 
            // dtpClienteFechaNac
            // 
            this.dtpClienteFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpClienteFechaNac.Location = new System.Drawing.Point(114, 169);
            this.dtpClienteFechaNac.Name = "dtpClienteFechaNac";
            this.dtpClienteFechaNac.Size = new System.Drawing.Size(324, 20);
            this.dtpClienteFechaNac.TabIndex = 6;
            // 
            // cbClienteEsDiscapacitado
            // 
            this.cbClienteEsDiscapacitado.AutoSize = true;
            this.cbClienteEsDiscapacitado.Location = new System.Drawing.Point(12, 196);
            this.cbClienteEsDiscapacitado.Name = "cbClienteEsDiscapacitado";
            this.cbClienteEsDiscapacitado.Size = new System.Drawing.Size(107, 17);
            this.cbClienteEsDiscapacitado.TabIndex = 7;
            this.cbClienteEsDiscapacitado.Text = "Es discapacitado";
            this.cbClienteEsDiscapacitado.UseVisualStyleBackColor = true;
            // 
            // rbClienteHombre
            // 
            this.rbClienteHombre.AutoSize = true;
            this.rbClienteHombre.Location = new System.Drawing.Point(129, 217);
            this.rbClienteHombre.Name = "rbClienteHombre";
            this.rbClienteHombre.Size = new System.Drawing.Size(62, 17);
            this.rbClienteHombre.TabIndex = 8;
            this.rbClienteHombre.TabStop = true;
            this.rbClienteHombre.Text = "Hombre\r\n";
            this.rbClienteHombre.UseVisualStyleBackColor = true;
            // 
            // rbClienteMujer
            // 
            this.rbClienteMujer.AutoSize = true;
            this.rbClienteMujer.Location = new System.Drawing.Point(129, 233);
            this.rbClienteMujer.Name = "rbClienteMujer";
            this.rbClienteMujer.Size = new System.Drawing.Size(51, 17);
            this.rbClienteMujer.TabIndex = 9;
            this.rbClienteMujer.TabStop = true;
            this.rbClienteMujer.Text = "Mujer";
            this.rbClienteMujer.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(377, 259);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(12, 259);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // mtbClienteDNI
            // 
            this.mtbClienteDNI.Location = new System.Drawing.Point(114, 5);
            this.mtbClienteDNI.Mask = "99999999";
            this.mtbClienteDNI.Name = "mtbClienteDNI";
            this.mtbClienteDNI.Size = new System.Drawing.Size(100, 20);
            this.mtbClienteDNI.TabIndex = 0;
            // 
            // mtbClienteTelefono
            // 
            this.mtbClienteTelefono.Location = new System.Drawing.Point(114, 109);
            this.mtbClienteTelefono.Mask = "000000000000";
            this.mtbClienteTelefono.Name = "mtbClienteTelefono";
            this.mtbClienteTelefono.Size = new System.Drawing.Size(236, 20);
            this.mtbClienteTelefono.TabIndex = 4;
            // 
            // tbClienteMail
            // 
            this.tbClienteMail.Location = new System.Drawing.Point(114, 143);
            this.tbClienteMail.Name = "tbClienteMail";
            this.tbClienteMail.Size = new System.Drawing.Size(324, 20);
            this.tbClienteMail.TabIndex = 5;
            // 
            // tbClienteNombre
            // 
            this.tbClienteNombre.Location = new System.Drawing.Point(114, 31);
            this.tbClienteNombre.Name = "tbClienteNombre";
            this.tbClienteNombre.Size = new System.Drawing.Size(324, 20);
            this.tbClienteNombre.TabIndex = 1;
            // 
            // tbClienteApellido
            // 
            this.tbClienteApellido.Location = new System.Drawing.Point(114, 57);
            this.tbClienteApellido.Name = "tbClienteApellido";
            this.tbClienteApellido.Size = new System.Drawing.Size(324, 20);
            this.tbClienteApellido.TabIndex = 2;
            // 
            // tbClienteDireccion
            // 
            this.tbClienteDireccion.Location = new System.Drawing.Point(114, 83);
            this.tbClienteDireccion.Name = "tbClienteDireccion";
            this.tbClienteDireccion.Size = new System.Drawing.Size(324, 20);
            this.tbClienteDireccion.TabIndex = 3;
            // 
            // ClienteAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 294);
            this.Controls.Add(this.tbClienteDireccion);
            this.Controls.Add(this.tbClienteApellido);
            this.Controls.Add(this.tbClienteNombre);
            this.Controls.Add(this.tbClienteMail);
            this.Controls.Add(this.mtbClienteTelefono);
            this.Controls.Add(this.mtbClienteDNI);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.rbClienteMujer);
            this.Controls.Add(this.rbClienteHombre);
            this.Controls.Add(this.cbClienteEsDiscapacitado);
            this.Controls.Add(this.dtpClienteFechaNac);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblClienteFechaNac);
            this.Controls.Add(this.lblClienteMail);
            this.Controls.Add(this.lblClienteTelefono);
            this.Controls.Add(this.lblClienteDireccion);
            this.Controls.Add(this.lblClienteApellido);
            this.Controls.Add(this.lblClienteNombre);
            this.Controls.Add(this.lblClienteDNI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClienteAlta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClienteDNI;
        private System.Windows.Forms.Label lblClienteNombre;
        private System.Windows.Forms.Label lblClienteApellido;
        private System.Windows.Forms.Label lblClienteDireccion;
        private System.Windows.Forms.Label lblClienteTelefono;
        private System.Windows.Forms.Label lblClienteMail;
        private System.Windows.Forms.Label lblClienteFechaNac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpClienteFechaNac;
        private System.Windows.Forms.CheckBox cbClienteEsDiscapacitado;
        private System.Windows.Forms.RadioButton rbClienteHombre;
        private System.Windows.Forms.RadioButton rbClienteMujer;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.MaskedTextBox mtbClienteDNI;
        private System.Windows.Forms.MaskedTextBox mtbClienteTelefono;
        private System.Windows.Forms.TextBox tbClienteMail;
        private System.Windows.Forms.TextBox tbClienteNombre;
        private System.Windows.Forms.TextBox tbClienteApellido;
        private System.Windows.Forms.TextBox tbClienteDireccion;
    }
}