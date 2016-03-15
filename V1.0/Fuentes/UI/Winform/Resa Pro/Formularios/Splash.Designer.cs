namespace Resa_Pro
{
    partial class Splash
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.timerSplash = new System.Windows.Forms.Timer(this.components);
            this.pbFondo = new System.Windows.Forms.PictureBox();
            this.PBProgresiveB = new System.Windows.Forms.PictureBox();
            this.LBLVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timerEfecto = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbFondo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBProgresiveB)).BeginInit();
            this.SuspendLayout();
            // 
            // timerSplash
            // 
            this.timerSplash.Tick += new System.EventHandler(this.timerSplash_Tick);
            // 
            // pbFondo
            // 
            this.pbFondo.BackColor = System.Drawing.Color.Transparent;
            this.pbFondo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbFondo.BackgroundImage")));
            this.pbFondo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbFondo.Location = new System.Drawing.Point(23, 28);
            this.pbFondo.Name = "pbFondo";
            this.pbFondo.Size = new System.Drawing.Size(154, 134);
            this.pbFondo.TabIndex = 0;
            this.pbFondo.TabStop = false;
            // 
            // PBProgresiveB
            // 
            this.PBProgresiveB.BackColor = System.Drawing.Color.Black;
            this.PBProgresiveB.Location = new System.Drawing.Point(82, 287);
            this.PBProgresiveB.Name = "PBProgresiveB";
            this.PBProgresiveB.Size = new System.Drawing.Size(306, 22);
            this.PBProgresiveB.TabIndex = 1;
            this.PBProgresiveB.TabStop = false;
            // 
            // LBLVersion
            // 
            this.LBLVersion.AutoSize = true;
            this.LBLVersion.BackColor = System.Drawing.Color.Transparent;
            this.LBLVersion.Font = new System.Drawing.Font("Copperplate Gothic Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLVersion.ForeColor = System.Drawing.Color.Red;
            this.LBLVersion.Location = new System.Drawing.Point(69, 344);
            this.LBLVersion.Name = "LBLVersion";
            this.LBLVersion.Size = new System.Drawing.Size(108, 17);
            this.LBLVersion.TabIndex = 3;
            this.LBLVersion.Text = "Version 1.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Copperplate Gothic Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(90, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Todos los derechos reservados resa 2016";
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.Lime;
            this.BackgroundImage = global::Resa_Pro.Properties.Resources.FondoSplash;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(472, 445);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBLVersion);
            this.Controls.Add(this.PBProgresiveB);
            this.Controls.Add(this.pbFondo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Splash";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Lime;
            ((System.ComponentModel.ISupportInitialize)(this.pbFondo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBProgresiveB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerSplash;
        private System.Windows.Forms.PictureBox pbFondo;
        private System.Windows.Forms.PictureBox PBProgresiveB;
        private System.Windows.Forms.Label LBLVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerEfecto;
    }
}

