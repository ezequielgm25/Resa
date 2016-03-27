namespace Resa_Pro.Formularios
{
    partial class EventosF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventosF));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.GCEventos = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SBEliminarE = new DevExpress.XtraEditors.SimpleButton();
            this.SBActualizarE = new DevExpress.XtraEditors.SimpleButton();
            this.SBAgregarE = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCEventos)).BeginInit();
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
            this.ribbon.Size = new System.Drawing.Size(890, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 502);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(890, 27);
            // 
            // GCEventos
            // 
            this.GCEventos.Dock = System.Windows.Forms.DockStyle.Top;
            this.GCEventos.Location = new System.Drawing.Point(0, 49);
            this.GCEventos.MainView = this.gridView1;
            this.GCEventos.MenuManager = this.ribbon;
            this.GCEventos.Name = "GCEventos";
            this.GCEventos.Size = new System.Drawing.Size(890, 349);
            this.GCEventos.TabIndex = 3;
            this.GCEventos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.GCEventos.DoubleClick += new System.EventHandler(this.GCEventos_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.GCEventos;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // SBEliminarE
            // 
            this.SBEliminarE.Image = ((System.Drawing.Image)(resources.GetObject("SBEliminarE.Image")));
            this.SBEliminarE.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBEliminarE.Location = new System.Drawing.Point(557, 420);
            this.SBEliminarE.Name = "SBEliminarE";
            this.SBEliminarE.Size = new System.Drawing.Size(75, 61);
            this.SBEliminarE.TabIndex = 8;
            this.SBEliminarE.Text = "Eliminar";
            this.SBEliminarE.Click += new System.EventHandler(this.SBEliminarE_Click);
            // 
            // SBActualizarE
            // 
            this.SBActualizarE.Image = ((System.Drawing.Image)(resources.GetObject("SBActualizarE.Image")));
            this.SBActualizarE.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBActualizarE.Location = new System.Drawing.Point(387, 420);
            this.SBActualizarE.Name = "SBActualizarE";
            this.SBActualizarE.Size = new System.Drawing.Size(75, 61);
            this.SBActualizarE.TabIndex = 7;
            this.SBActualizarE.Text = "Actualizar";
            this.SBActualizarE.Click += new System.EventHandler(this.SBActualizarE_Click);
            // 
            // SBAgregarE
            // 
            this.SBAgregarE.Image = ((System.Drawing.Image)(resources.GetObject("SBAgregarE.Image")));
            this.SBAgregarE.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBAgregarE.Location = new System.Drawing.Point(231, 420);
            this.SBAgregarE.Name = "SBAgregarE";
            this.SBAgregarE.Size = new System.Drawing.Size(75, 61);
            this.SBAgregarE.TabIndex = 6;
            this.SBAgregarE.Text = "Agregar";
            this.SBAgregarE.Click += new System.EventHandler(this.SBAgregarE_Click);
            // 
            // Eventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 529);
            this.Controls.Add(this.SBEliminarE);
            this.Controls.Add(this.SBActualizarE);
            this.Controls.Add(this.SBAgregarE);
            this.Controls.Add(this.GCEventos);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Eventos";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Eventos";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCEventos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraGrid.GridControl GCEventos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton SBEliminarE;
        private DevExpress.XtraEditors.SimpleButton SBActualizarE;
        private DevExpress.XtraEditors.SimpleButton SBAgregarE;
    }
}