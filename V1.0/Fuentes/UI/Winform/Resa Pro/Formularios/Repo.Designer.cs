namespace Resa_Pro.Formularios
{
    partial class Repo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Repo));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.CrystalReportV = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SBReportarOrganizadores = new System.Windows.Forms.GroupBox();
            this.SBReporteGlobal = new DevExpress.XtraEditors.SimpleButton();
            this.SBPorcentajeI = new DevExpress.XtraEditors.SimpleButton();
            this.SBOrganizadores = new DevExpress.XtraEditors.SimpleButton();
            this.SBReportarUsuarios = new DevExpress.XtraEditors.SimpleButton();
            this.SBReportesEventos = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SBReportarOrganizadores.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbon.Size = new System.Drawing.Size(1340, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 616);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1340, 27);
            // 
            // CrystalReportV
            // 
            this.CrystalReportV.ActiveViewIndex = -1;
            this.CrystalReportV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrystalReportV.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrystalReportV.Dock = System.Windows.Forms.DockStyle.Top;
            this.CrystalReportV.Location = new System.Drawing.Point(0, 49);
            this.CrystalReportV.Name = "CrystalReportV";
            this.CrystalReportV.Size = new System.Drawing.Size(1340, 481);
            this.CrystalReportV.TabIndex = 2;
            // 
            // SBReportarOrganizadores
            // 
            this.SBReportarOrganizadores.Controls.Add(this.SBReporteGlobal);
            this.SBReportarOrganizadores.Controls.Add(this.SBPorcentajeI);
            this.SBReportarOrganizadores.Controls.Add(this.SBOrganizadores);
            this.SBReportarOrganizadores.Controls.Add(this.SBReportarUsuarios);
            this.SBReportarOrganizadores.Controls.Add(this.SBReportesEventos);
            this.SBReportarOrganizadores.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SBReportarOrganizadores.Location = new System.Drawing.Point(0, 536);
            this.SBReportarOrganizadores.Name = "SBReportarOrganizadores";
            this.SBReportarOrganizadores.Size = new System.Drawing.Size(1340, 80);
            this.SBReportarOrganizadores.TabIndex = 5;
            this.SBReportarOrganizadores.TabStop = false;
            this.SBReportarOrganizadores.Text = "Reportes";
            // 
            // SBReporteGlobal
            // 
            this.SBReporteGlobal.Image = ((System.Drawing.Image)(resources.GetObject("SBReporteGlobal.Image")));
            this.SBReporteGlobal.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBReporteGlobal.Location = new System.Drawing.Point(1138, 20);
            this.SBReporteGlobal.Name = "SBReporteGlobal";
            this.SBReporteGlobal.Size = new System.Drawing.Size(114, 53);
            this.SBReporteGlobal.TabIndex = 4;
            this.SBReporteGlobal.Text = "Reporte global";
            this.SBReporteGlobal.Click += new System.EventHandler(this.SBReporteGlobal_Click);
            // 
            // SBPorcentajeI
            // 
            this.SBPorcentajeI.Image = ((System.Drawing.Image)(resources.GetObject("SBPorcentajeI.Image")));
            this.SBPorcentajeI.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBPorcentajeI.Location = new System.Drawing.Point(601, 21);
            this.SBPorcentajeI.Name = "SBPorcentajeI";
            this.SBPorcentajeI.Size = new System.Drawing.Size(141, 53);
            this.SBPorcentajeI.TabIndex = 3;
            this.SBPorcentajeI.Text = "Porcentajes de itinerario";
            this.SBPorcentajeI.Click += new System.EventHandler(this.SBPorcentajeI_Click);
            // 
            // SBOrganizadores
            // 
            this.SBOrganizadores.Image = ((System.Drawing.Image)(resources.GetObject("SBOrganizadores.Image")));
            this.SBOrganizadores.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBOrganizadores.Location = new System.Drawing.Point(912, 20);
            this.SBOrganizadores.Name = "SBOrganizadores";
            this.SBOrganizadores.Size = new System.Drawing.Size(129, 53);
            this.SBOrganizadores.TabIndex = 2;
            this.SBOrganizadores.Text = "Reportar organizadores";
            this.SBOrganizadores.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // SBReportarUsuarios
            // 
            this.SBReportarUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("SBReportarUsuarios.Image")));
            this.SBReportarUsuarios.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBReportarUsuarios.Location = new System.Drawing.Point(296, 20);
            this.SBReportarUsuarios.Name = "SBReportarUsuarios";
            this.SBReportarUsuarios.Size = new System.Drawing.Size(116, 53);
            this.SBReportarUsuarios.TabIndex = 1;
            this.SBReportarUsuarios.Text = "Reportar usuarios";
            this.SBReportarUsuarios.Click += new System.EventHandler(this.SBReportarUsuarios_Click);
            // 
            // SBReportesEventos
            // 
            this.SBReportesEventos.Image = ((System.Drawing.Image)(resources.GetObject("SBReportesEventos.Image")));
            this.SBReportesEventos.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBReportesEventos.Location = new System.Drawing.Point(84, 20);
            this.SBReportesEventos.Name = "SBReportesEventos";
            this.SBReportesEventos.Size = new System.Drawing.Size(102, 53);
            this.SBReportesEventos.TabIndex = 0;
            this.SBReportesEventos.Text = "Reportar eventos";
            this.SBReportesEventos.Click += new System.EventHandler(this.SBReportesEventos_Click);
            // 
            // Repo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1340, 643);
            this.Controls.Add(this.SBReportarOrganizadores);
            this.Controls.Add(this.CrystalReportV);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Repo";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Repositorio";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.SBReportarOrganizadores.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrystalReportV;
        private System.Windows.Forms.GroupBox SBReportarOrganizadores;
        private DevExpress.XtraEditors.SimpleButton SBReportesEventos;
        private DevExpress.XtraEditors.SimpleButton SBReportarUsuarios;
        private DevExpress.XtraEditors.SimpleButton SBOrganizadores;
        private DevExpress.XtraEditors.SimpleButton SBPorcentajeI;
        private DevExpress.XtraEditors.SimpleButton SBReporteGlobal;
    }
}