namespace FrbaBus.Abm_Recompensa
{
    partial class RecompensaCanjearPuntos
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
            this.lblRecompensaCanjearPuntosDni = new System.Windows.Forms.Label();
            this.lblRecompensaCanjearPuntosPuntosAcumulados = new System.Windows.Forms.Label();
            this.tbRecompensaCanjearPuntosDni = new System.Windows.Forms.TextBox();
            this.tbRecompensaCanjearPuntosPuntosAcumulados = new System.Windows.Forms.TextBox();
            this.gbRecompensaCanjearPuntos = new System.Windows.Forms.GroupBox();
            this.dgvRecompensaCanjearPuntos = new System.Windows.Forms.DataGridView();
            this.btnRecompensaCanjearPuntosCanjear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gbRecompensaCanjearPuntos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecompensaCanjearPuntos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecompensaCanjearPuntosDni
            // 
            this.lblRecompensaCanjearPuntosDni.AutoSize = true;
            this.lblRecompensaCanjearPuntosDni.Location = new System.Drawing.Point(13, 13);
            this.lblRecompensaCanjearPuntosDni.Name = "lblRecompensaCanjearPuntosDni";
            this.lblRecompensaCanjearPuntosDni.Size = new System.Drawing.Size(61, 13);
            this.lblRecompensaCanjearPuntosDni.TabIndex = 0;
            this.lblRecompensaCanjearPuntosDni.Text = "DNI Cliente";
            // 
            // lblRecompensaCanjearPuntosPuntosAcumulados
            // 
            this.lblRecompensaCanjearPuntosPuntosAcumulados.AutoSize = true;
            this.lblRecompensaCanjearPuntosPuntosAcumulados.Location = new System.Drawing.Point(13, 41);
            this.lblRecompensaCanjearPuntosPuntosAcumulados.Name = "lblRecompensaCanjearPuntosPuntosAcumulados";
            this.lblRecompensaCanjearPuntosPuntosAcumulados.Size = new System.Drawing.Size(100, 13);
            this.lblRecompensaCanjearPuntosPuntosAcumulados.TabIndex = 1;
            this.lblRecompensaCanjearPuntosPuntosAcumulados.Text = "Puntos acumulados";
            // 
            // tbRecompensaCanjearPuntosDni
            // 
            this.tbRecompensaCanjearPuntosDni.Location = new System.Drawing.Point(124, 10);
            this.tbRecompensaCanjearPuntosDni.Name = "tbRecompensaCanjearPuntosDni";
            this.tbRecompensaCanjearPuntosDni.Size = new System.Drawing.Size(194, 20);
            this.tbRecompensaCanjearPuntosDni.TabIndex = 3;
            // 
            // tbRecompensaCanjearPuntosPuntosAcumulados
            // 
            this.tbRecompensaCanjearPuntosPuntosAcumulados.Location = new System.Drawing.Point(124, 38);
            this.tbRecompensaCanjearPuntosPuntosAcumulados.Name = "tbRecompensaCanjearPuntosPuntosAcumulados";
            this.tbRecompensaCanjearPuntosPuntosAcumulados.Size = new System.Drawing.Size(194, 20);
            this.tbRecompensaCanjearPuntosPuntosAcumulados.TabIndex = 4;
            // 
            // gbRecompensaCanjearPuntos
            // 
            this.gbRecompensaCanjearPuntos.Controls.Add(this.dgvRecompensaCanjearPuntos);
            this.gbRecompensaCanjearPuntos.Location = new System.Drawing.Point(16, 124);
            this.gbRecompensaCanjearPuntos.Name = "gbRecompensaCanjearPuntos";
            this.gbRecompensaCanjearPuntos.Size = new System.Drawing.Size(302, 197);
            this.gbRecompensaCanjearPuntos.TabIndex = 5;
            this.gbRecompensaCanjearPuntos.TabStop = false;
            this.gbRecompensaCanjearPuntos.Text = "Premios disponibles";
            // 
            // dgvRecompensaCanjearPuntos
            // 
            this.dgvRecompensaCanjearPuntos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecompensaCanjearPuntos.Location = new System.Drawing.Point(12, 19);
            this.dgvRecompensaCanjearPuntos.Name = "dgvRecompensaCanjearPuntos";
            this.dgvRecompensaCanjearPuntos.Size = new System.Drawing.Size(290, 172);
            this.dgvRecompensaCanjearPuntos.TabIndex = 0;
            // 
            // btnRecompensaCanjearPuntosCanjear
            // 
            this.btnRecompensaCanjearPuntosCanjear.Location = new System.Drawing.Point(253, 348);
            this.btnRecompensaCanjearPuntosCanjear.Name = "btnRecompensaCanjearPuntosCanjear";
            this.btnRecompensaCanjearPuntosCanjear.Size = new System.Drawing.Size(75, 23);
            this.btnRecompensaCanjearPuntosCanjear.TabIndex = 6;
            this.btnRecompensaCanjearPuntosCanjear.Text = "Canjear";
            this.btnRecompensaCanjearPuntosCanjear.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(253, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // RecompensaCanjearPuntos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 383);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRecompensaCanjearPuntosCanjear);
            this.Controls.Add(this.gbRecompensaCanjearPuntos);
            this.Controls.Add(this.tbRecompensaCanjearPuntosPuntosAcumulados);
            this.Controls.Add(this.tbRecompensaCanjearPuntosDni);
            this.Controls.Add(this.lblRecompensaCanjearPuntosPuntosAcumulados);
            this.Controls.Add(this.lblRecompensaCanjearPuntosDni);
            this.Name = "RecompensaCanjearPuntos";
            this.Text = "RecompensaCanjearPuntos";
            this.gbRecompensaCanjearPuntos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecompensaCanjearPuntos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecompensaCanjearPuntosDni;
        private System.Windows.Forms.Label lblRecompensaCanjearPuntosPuntosAcumulados;
        private System.Windows.Forms.TextBox tbRecompensaCanjearPuntosDni;
        private System.Windows.Forms.TextBox tbRecompensaCanjearPuntosPuntosAcumulados;
        private System.Windows.Forms.GroupBox gbRecompensaCanjearPuntos;
        private System.Windows.Forms.DataGridView dgvRecompensaCanjearPuntos;
        private System.Windows.Forms.Button btnRecompensaCanjearPuntosCanjear;
        private System.Windows.Forms.Button button1;
    }
}