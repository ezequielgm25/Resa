namespace Resa_Pro.Formularios
{
    partial class Loging
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loging));
            this.BtnIniciarSesion = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.LblUsuario = new DevExpress.XtraEditors.LabelControl();
            this.Lblpass = new DevExpress.XtraEditors.LabelControl();
            this.TbUsuario = new System.Windows.Forms.TextBox();
            this.TbPass = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnIniciarSesion
            // 
            this.BtnIniciarSesion.Appearance.BackColor = System.Drawing.Color.Red;
            this.BtnIniciarSesion.Appearance.BackColor2 = System.Drawing.Color.White;
            this.BtnIniciarSesion.Appearance.BorderColor = System.Drawing.Color.DarkRed;
            this.BtnIniciarSesion.Appearance.Font = new System.Drawing.Font("Copperplate Gothic Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIniciarSesion.Appearance.Options.UseBackColor = true;
            this.BtnIniciarSesion.Appearance.Options.UseBorderColor = true;
            this.BtnIniciarSesion.Appearance.Options.UseFont = true;
            this.BtnIniciarSesion.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.BtnIniciarSesion.Location = new System.Drawing.Point(224, 304);
            this.BtnIniciarSesion.LookAndFeel.SkinMaskColor = System.Drawing.Color.White;
            this.BtnIniciarSesion.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.White;
            this.BtnIniciarSesion.Name = "BtnIniciarSesion";
            this.BtnIniciarSesion.Size = new System.Drawing.Size(109, 23);
            this.BtnIniciarSesion.TabIndex = 1;
            this.BtnIniciarSesion.Text = "Iniciar Sesión";
            this.BtnIniciarSesion.Click += new System.EventHandler(this.BtnIniciarSesion_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Appearance.BackColor = System.Drawing.Color.Red;
            this.BtnCancelar.Appearance.BackColor2 = System.Drawing.Color.White;
            this.BtnCancelar.Appearance.BorderColor = System.Drawing.Color.Black;
            this.BtnCancelar.Appearance.Font = new System.Drawing.Font("Copperplate Gothic Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Appearance.Options.UseBackColor = true;
            this.BtnCancelar.Appearance.Options.UseBorderColor = true;
            this.BtnCancelar.Appearance.Options.UseFont = true;
            this.BtnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.BtnCancelar.Location = new System.Drawing.Point(128, 304);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(81, 23);
            this.BtnCancelar.TabIndex = 2;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // LblUsuario
            // 
            this.LblUsuario.Appearance.Font = new System.Drawing.Font("Copperplate Gothic Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuario.Location = new System.Drawing.Point(102, 200);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(69, 17);
            this.LblUsuario.TabIndex = 3;
            this.LblUsuario.Text = "Usuario";
            // 
            // Lblpass
            // 
            this.Lblpass.Appearance.Font = new System.Drawing.Font("Copperplate Gothic Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lblpass.Location = new System.Drawing.Point(102, 250);
            this.Lblpass.Name = "Lblpass";
            this.Lblpass.Size = new System.Drawing.Size(107, 17);
            this.Lblpass.TabIndex = 4;
            this.Lblpass.Text = "Contraseña";
            // 
            // TbUsuario
            // 
            this.TbUsuario.BackColor = System.Drawing.Color.White;
            this.TbUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbUsuario.Location = new System.Drawing.Point(224, 199);
            this.TbUsuario.Name = "TbUsuario";
            this.TbUsuario.Size = new System.Drawing.Size(125, 22);
            this.TbUsuario.TabIndex = 8;
            // 
            // TbPass
            // 
            this.TbPass.BackColor = System.Drawing.Color.White;
            this.TbPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPass.Location = new System.Drawing.Point(224, 245);
            this.TbPass.Name = "TbPass";
            this.TbPass.Size = new System.Drawing.Size(125, 22);
            this.TbPass.TabIndex = 9;
            this.TbPass.UseSystemPasswordChar = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(188, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(134, 121);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Loging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.BackgroundImage = global::Resa_Pro.Properties.Resources.FondoLoging;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(444, 442);
            this.ControlBox = false;
            this.Controls.Add(this.TbPass);
            this.Controls.Add(this.TbUsuario);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Lblpass);
            this.Controls.Add(this.LblUsuario);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnIniciarSesion);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Loging";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Lime;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton BtnIniciarSesion;
        private DevExpress.XtraEditors.SimpleButton BtnCancelar;
        private DevExpress.XtraEditors.LabelControl LblUsuario;
        private DevExpress.XtraEditors.LabelControl Lblpass;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox TbUsuario;
        private System.Windows.Forms.TextBox TbPass;
    }
}