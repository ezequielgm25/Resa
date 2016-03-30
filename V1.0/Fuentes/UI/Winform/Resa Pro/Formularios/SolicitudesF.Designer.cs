namespace Resa_Pro.Formularios
{
    partial class SolicitudesF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolicitudesF));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.GCSolicitudes = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SBAgregarS = new DevExpress.XtraEditors.SimpleButton();
            this.SBActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.SBEliminar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCSolicitudes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.ribbon.Size = new System.Drawing.Size(941, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 501);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(941, 27);
            // 
            // GCSolicitudes
            // 
            this.GCSolicitudes.Dock = System.Windows.Forms.DockStyle.Top;
            this.GCSolicitudes.Location = new System.Drawing.Point(0, 49);
            this.GCSolicitudes.MainView = this.gridView1;
            this.GCSolicitudes.MenuManager = this.ribbon;
            this.GCSolicitudes.Name = "GCSolicitudes";
            this.GCSolicitudes.Size = new System.Drawing.Size(941, 349);
            this.GCSolicitudes.TabIndex = 2;
            this.GCSolicitudes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.GCSolicitudes.DoubleClick += new System.EventHandler(this.GCSolicitudes_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.GCSolicitudes;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // SBAgregarS
            // 
            this.SBAgregarS.Image = ((System.Drawing.Image)(resources.GetObject("SBAgregarS.Image")));
            this.SBAgregarS.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBAgregarS.Location = new System.Drawing.Point(247, 420);
            this.SBAgregarS.Name = "SBAgregarS";
            this.SBAgregarS.Size = new System.Drawing.Size(75, 61);
            this.SBAgregarS.TabIndex = 3;
            this.SBAgregarS.Text = "Agregar";
            this.SBAgregarS.Click += new System.EventHandler(this.SBAgregarS_Click);
            // 
            // SBActualizar
            // 
            this.SBActualizar.Image = ((System.Drawing.Image)(resources.GetObject("SBActualizar.Image")));
            this.SBActualizar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBActualizar.Location = new System.Drawing.Point(403, 420);
            this.SBActualizar.Name = "SBActualizar";
            this.SBActualizar.Size = new System.Drawing.Size(75, 61);
            this.SBActualizar.TabIndex = 4;
            this.SBActualizar.Text = "Actualizar";
            this.SBActualizar.Click += new System.EventHandler(this.SBActualizar_Click);
            // 
            // SBEliminar
            // 
            this.SBEliminar.Image = ((System.Drawing.Image)(resources.GetObject("SBEliminar.Image")));
            this.SBEliminar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBEliminar.Location = new System.Drawing.Point(573, 420);
            this.SBEliminar.Name = "SBEliminar";
            this.SBEliminar.Size = new System.Drawing.Size(75, 61);
            this.SBEliminar.TabIndex = 5;
            this.SBEliminar.Text = "Eliminar";
            this.SBEliminar.Click += new System.EventHandler(this.SBEliminar_Click);
            // 
            // SolicitudesF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 528);
            this.Controls.Add(this.SBEliminar);
            this.Controls.Add(this.SBActualizar);
            this.Controls.Add(this.SBAgregarS);
            this.Controls.Add(this.GCSolicitudes);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SolicitudesF";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Solicitudes";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCSolicitudes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraGrid.GridControl GCSolicitudes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton SBAgregarS;
        private DevExpress.XtraEditors.SimpleButton SBActualizar;
        private DevExpress.XtraEditors.SimpleButton SBEliminar;
    }
}