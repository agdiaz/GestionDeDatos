namespace FrbaBus
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.tsmArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmArchivoSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRol = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRolListado = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRolAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCiudad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCiudadListado = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCiudadAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRecorrido = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRecorridoListado = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRecorridoAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMicro = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMicroListado = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMicroAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmViaje = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmViajeListado = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmViajeAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmClienteListado = new System.Windows.Forms.ToolStripMenuItem();
            this.pasajeroFrecuenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPasaje = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPasajeListado = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPasajeAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEncomienda = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEncomiendaListado = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEncomiendaAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEstadisticas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEstadisticasT5DestMasVendidos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEstadisticasT5DestMasMicrosVacios = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEstadisticasT5ClientesMasPuntos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEstadisticasT5DestMasCancelados = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEstadisticasT5MicrosMasDiasFueraDeServicio = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPremios = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPremiosListado = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPremiosAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsMain
            // 
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmArchivo,
            this.tsmRol,
            this.tsmCiudad,
            this.tsmRecorrido,
            this.tsmMicro,
            this.tsmViaje,
            this.tsmCliente,
            this.tsmPasaje,
            this.tsmEncomienda,
            this.tsmEstadisticas,
            this.tsmPremios});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Size = new System.Drawing.Size(784, 24);
            this.mnsMain.TabIndex = 0;
            this.mnsMain.Text = "menuStrip1";
            // 
            // tsmArchivo
            // 
            this.tsmArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmArchivoSalir});
            this.tsmArchivo.Name = "tsmArchivo";
            this.tsmArchivo.Size = new System.Drawing.Size(60, 20);
            this.tsmArchivo.Text = "Archivo";
            // 
            // tsmArchivoSalir
            // 
            this.tsmArchivoSalir.Name = "tsmArchivoSalir";
            this.tsmArchivoSalir.Size = new System.Drawing.Size(152, 22);
            this.tsmArchivoSalir.Text = "Salir";
            // 
            // tsmRol
            // 
            this.tsmRol.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmRolListado,
            this.tsmRolAlta});
            this.tsmRol.Name = "tsmRol";
            this.tsmRol.Size = new System.Drawing.Size(36, 20);
            this.tsmRol.Text = "Rol";
            // 
            // tsmRolListado
            // 
            this.tsmRolListado.Name = "tsmRolListado";
            this.tsmRolListado.Size = new System.Drawing.Size(152, 22);
            this.tsmRolListado.Text = "Listado";
            this.tsmRolListado.Click += new System.EventHandler(this.tsmRolListado_Click);
            // 
            // tsmRolAlta
            // 
            this.tsmRolAlta.Name = "tsmRolAlta";
            this.tsmRolAlta.Size = new System.Drawing.Size(152, 22);
            this.tsmRolAlta.Text = "Alta";
            // 
            // tsmCiudad
            // 
            this.tsmCiudad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCiudadListado,
            this.tsmCiudadAlta});
            this.tsmCiudad.Name = "tsmCiudad";
            this.tsmCiudad.Size = new System.Drawing.Size(57, 20);
            this.tsmCiudad.Text = "Ciudad";
            // 
            // tsmCiudadListado
            // 
            this.tsmCiudadListado.Name = "tsmCiudadListado";
            this.tsmCiudadListado.Size = new System.Drawing.Size(112, 22);
            this.tsmCiudadListado.Text = "Listado";
            // 
            // tsmCiudadAlta
            // 
            this.tsmCiudadAlta.Name = "tsmCiudadAlta";
            this.tsmCiudadAlta.Size = new System.Drawing.Size(112, 22);
            this.tsmCiudadAlta.Text = "Alta";
            // 
            // tsmRecorrido
            // 
            this.tsmRecorrido.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmRecorridoListado,
            this.tsmRecorridoAlta});
            this.tsmRecorrido.Name = "tsmRecorrido";
            this.tsmRecorrido.Size = new System.Drawing.Size(70, 20);
            this.tsmRecorrido.Text = "Recorrido";
            // 
            // tsmRecorridoListado
            // 
            this.tsmRecorridoListado.Name = "tsmRecorridoListado";
            this.tsmRecorridoListado.Size = new System.Drawing.Size(112, 22);
            this.tsmRecorridoListado.Text = "Listado";
            // 
            // tsmRecorridoAlta
            // 
            this.tsmRecorridoAlta.Name = "tsmRecorridoAlta";
            this.tsmRecorridoAlta.Size = new System.Drawing.Size(112, 22);
            this.tsmRecorridoAlta.Text = "Alta";
            // 
            // tsmMicro
            // 
            this.tsmMicro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMicroListado,
            this.tsmMicroAlta});
            this.tsmMicro.Name = "tsmMicro";
            this.tsmMicro.Size = new System.Drawing.Size(50, 20);
            this.tsmMicro.Text = "Micro";
            this.tsmMicro.Click += new System.EventHandler(this.tsmMicros_Click);
            // 
            // tsmMicroListado
            // 
            this.tsmMicroListado.Name = "tsmMicroListado";
            this.tsmMicroListado.Size = new System.Drawing.Size(152, 22);
            this.tsmMicroListado.Text = "Listado";
            this.tsmMicroListado.Click += new System.EventHandler(this.tsmMicroListado_Click);
            // 
            // tsmMicroAlta
            // 
            this.tsmMicroAlta.Name = "tsmMicroAlta";
            this.tsmMicroAlta.Size = new System.Drawing.Size(152, 22);
            this.tsmMicroAlta.Text = "Alta";
            this.tsmMicroAlta.Click += new System.EventHandler(this.tsmMicroAlta_Click);
            // 
            // tsmViaje
            // 
            this.tsmViaje.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmViajeListado,
            this.tsmViajeAlta});
            this.tsmViaje.Name = "tsmViaje";
            this.tsmViaje.Size = new System.Drawing.Size(44, 20);
            this.tsmViaje.Text = "Viaje";
            // 
            // tsmViajeListado
            // 
            this.tsmViajeListado.Name = "tsmViajeListado";
            this.tsmViajeListado.Size = new System.Drawing.Size(112, 22);
            this.tsmViajeListado.Text = "Listado";
            // 
            // tsmViajeAlta
            // 
            this.tsmViajeAlta.Name = "tsmViajeAlta";
            this.tsmViajeAlta.Size = new System.Drawing.Size(112, 22);
            this.tsmViajeAlta.Text = "Alta";
            // 
            // tsmCliente
            // 
            this.tsmCliente.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmClienteListado,
            this.pasajeroFrecuenteToolStripMenuItem});
            this.tsmCliente.Name = "tsmCliente";
            this.tsmCliente.Size = new System.Drawing.Size(56, 20);
            this.tsmCliente.Text = "Cliente";
            this.tsmCliente.Click += new System.EventHandler(this.tsmPasajero_Click);
            // 
            // tsmClienteListado
            // 
            this.tsmClienteListado.Name = "tsmClienteListado";
            this.tsmClienteListado.Size = new System.Drawing.Size(171, 22);
            this.tsmClienteListado.Text = "Listado";
            // 
            // pasajeroFrecuenteToolStripMenuItem
            // 
            this.pasajeroFrecuenteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarToolStripMenuItem});
            this.pasajeroFrecuenteToolStripMenuItem.Name = "pasajeroFrecuenteToolStripMenuItem";
            this.pasajeroFrecuenteToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.pasajeroFrecuenteToolStripMenuItem.Text = "Pasajero frecuente";
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.consultarToolStripMenuItem.Text = "Consultar";
            // 
            // tsmPasaje
            // 
            this.tsmPasaje.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPasajeListado,
            this.tsmPasajeAlta});
            this.tsmPasaje.Name = "tsmPasaje";
            this.tsmPasaje.Size = new System.Drawing.Size(52, 20);
            this.tsmPasaje.Text = "Pasaje";
            // 
            // tsmPasajeListado
            // 
            this.tsmPasajeListado.Name = "tsmPasajeListado";
            this.tsmPasajeListado.Size = new System.Drawing.Size(112, 22);
            this.tsmPasajeListado.Text = "Listado";
            // 
            // tsmPasajeAlta
            // 
            this.tsmPasajeAlta.Name = "tsmPasajeAlta";
            this.tsmPasajeAlta.Size = new System.Drawing.Size(112, 22);
            this.tsmPasajeAlta.Text = "Alta";
            // 
            // tsmEncomienda
            // 
            this.tsmEncomienda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEncomiendaListado,
            this.tsmEncomiendaAlta});
            this.tsmEncomienda.Name = "tsmEncomienda";
            this.tsmEncomienda.Size = new System.Drawing.Size(85, 20);
            this.tsmEncomienda.Text = "Encomienda";
            // 
            // tsmEncomiendaListado
            // 
            this.tsmEncomiendaListado.Name = "tsmEncomiendaListado";
            this.tsmEncomiendaListado.Size = new System.Drawing.Size(112, 22);
            this.tsmEncomiendaListado.Text = "Listado";
            // 
            // tsmEncomiendaAlta
            // 
            this.tsmEncomiendaAlta.Name = "tsmEncomiendaAlta";
            this.tsmEncomiendaAlta.Size = new System.Drawing.Size(112, 22);
            this.tsmEncomiendaAlta.Text = "Alta";
            // 
            // tsmEstadisticas
            // 
            this.tsmEstadisticas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEstadisticasT5DestMasVendidos,
            this.tsmEstadisticasT5DestMasMicrosVacios,
            this.tsmEstadisticasT5ClientesMasPuntos,
            this.tsmEstadisticasT5DestMasCancelados,
            this.tsmEstadisticasT5MicrosMasDiasFueraDeServicio});
            this.tsmEstadisticas.Name = "tsmEstadisticas";
            this.tsmEstadisticas.Size = new System.Drawing.Size(79, 20);
            this.tsmEstadisticas.Text = "Estadísticas";
            // 
            // tsmEstadisticasT5DestMasVendidos
            // 
            this.tsmEstadisticasT5DestMasVendidos.Name = "tsmEstadisticasT5DestMasVendidos";
            this.tsmEstadisticasT5DestMasVendidos.Size = new System.Drawing.Size(304, 22);
            this.tsmEstadisticasT5DestMasVendidos.Text = "Top 5 destinos más vendidos";
            this.tsmEstadisticasT5DestMasVendidos.Click += new System.EventHandler(this.top5ToolStripMenuItem_Click);
            // 
            // tsmEstadisticasT5DestMasMicrosVacios
            // 
            this.tsmEstadisticasT5DestMasMicrosVacios.Name = "tsmEstadisticasT5DestMasMicrosVacios";
            this.tsmEstadisticasT5DestMasMicrosVacios.Size = new System.Drawing.Size(304, 22);
            this.tsmEstadisticasT5DestMasMicrosVacios.Text = "Top 5 destinos con más micros vacíos";
            // 
            // tsmEstadisticasT5ClientesMasPuntos
            // 
            this.tsmEstadisticasT5ClientesMasPuntos.Name = "tsmEstadisticasT5ClientesMasPuntos";
            this.tsmEstadisticasT5ClientesMasPuntos.Size = new System.Drawing.Size(304, 22);
            this.tsmEstadisticasT5ClientesMasPuntos.Text = "Top 5 clientes con más puntos";
            // 
            // tsmEstadisticasT5DestMasCancelados
            // 
            this.tsmEstadisticasT5DestMasCancelados.Name = "tsmEstadisticasT5DestMasCancelados";
            this.tsmEstadisticasT5DestMasCancelados.Size = new System.Drawing.Size(304, 22);
            this.tsmEstadisticasT5DestMasCancelados.Text = "Top 5 destinos más cancelados ";
            // 
            // tsmEstadisticasT5MicrosMasDiasFueraDeServicio
            // 
            this.tsmEstadisticasT5MicrosMasDiasFueraDeServicio.Name = "tsmEstadisticasT5MicrosMasDiasFueraDeServicio";
            this.tsmEstadisticasT5MicrosMasDiasFueraDeServicio.Size = new System.Drawing.Size(304, 22);
            this.tsmEstadisticasT5MicrosMasDiasFueraDeServicio.Text = "Top 5 micros con más días fuera de servicio";
            // 
            // tsmPremios
            // 
            this.tsmPremios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPremiosListado,
            this.tsmPremiosAlta});
            this.tsmPremios.Name = "tsmPremios";
            this.tsmPremios.Size = new System.Drawing.Size(62, 20);
            this.tsmPremios.Text = "Premios";
            // 
            // tsmPremiosListado
            // 
            this.tsmPremiosListado.Name = "tsmPremiosListado";
            this.tsmPremiosListado.Size = new System.Drawing.Size(112, 22);
            this.tsmPremiosListado.Text = "Listado";
            // 
            // tsmPremiosAlta
            // 
            this.tsmPremiosAlta.Name = "tsmPremiosAlta";
            this.tsmPremiosAlta.Size = new System.Drawing.Size(112, 22);
            this.tsmPremiosAlta.Text = "Alta";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.mnsMain);
            this.MainMenuStrip = this.mnsMain;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrbaBus - Pantalla Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmArchivo;
        private System.Windows.Forms.ToolStripMenuItem tsmArchivoSalir;
        private System.Windows.Forms.ToolStripMenuItem tsmRol;
        private System.Windows.Forms.ToolStripMenuItem tsmRolListado;
        private System.Windows.Forms.ToolStripMenuItem tsmRolAlta;
        private System.Windows.Forms.ToolStripMenuItem tsmCiudad;
        private System.Windows.Forms.ToolStripMenuItem tsmCiudadListado;
        private System.Windows.Forms.ToolStripMenuItem tsmCiudadAlta;
        private System.Windows.Forms.ToolStripMenuItem tsmRecorrido;
        private System.Windows.Forms.ToolStripMenuItem tsmRecorridoListado;
        private System.Windows.Forms.ToolStripMenuItem tsmRecorridoAlta;
        private System.Windows.Forms.ToolStripMenuItem tsmMicro;
        private System.Windows.Forms.ToolStripMenuItem tsmMicroListado;
        private System.Windows.Forms.ToolStripMenuItem tsmMicroAlta;
        private System.Windows.Forms.ToolStripMenuItem tsmViaje;
        private System.Windows.Forms.ToolStripMenuItem tsmViajeListado;
        private System.Windows.Forms.ToolStripMenuItem tsmViajeAlta;
        private System.Windows.Forms.ToolStripMenuItem tsmCliente;
        private System.Windows.Forms.ToolStripMenuItem tsmClienteListado;
        private System.Windows.Forms.ToolStripMenuItem tsmPasaje;
        private System.Windows.Forms.ToolStripMenuItem tsmPasajeListado;
        private System.Windows.Forms.ToolStripMenuItem tsmPasajeAlta;
        private System.Windows.Forms.ToolStripMenuItem tsmEncomienda;
        private System.Windows.Forms.ToolStripMenuItem tsmEncomiendaListado;
        private System.Windows.Forms.ToolStripMenuItem tsmEncomiendaAlta;
        private System.Windows.Forms.ToolStripMenuItem tsmEstadisticas;
        private System.Windows.Forms.ToolStripMenuItem tsmEstadisticasT5DestMasVendidos;
        private System.Windows.Forms.ToolStripMenuItem tsmEstadisticasT5DestMasMicrosVacios;
        private System.Windows.Forms.ToolStripMenuItem tsmEstadisticasT5ClientesMasPuntos;
        private System.Windows.Forms.ToolStripMenuItem tsmEstadisticasT5DestMasCancelados;
        private System.Windows.Forms.ToolStripMenuItem tsmEstadisticasT5MicrosMasDiasFueraDeServicio;
        private System.Windows.Forms.ToolStripMenuItem pasajeroFrecuenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmPremios;
        private System.Windows.Forms.ToolStripMenuItem tsmPremiosListado;
        private System.Windows.Forms.ToolStripMenuItem tsmPremiosAlta;
    }
}

