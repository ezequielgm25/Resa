namespace Resa_Pro.Formularios
{
    partial class UbicacionF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UbicacionF));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.GCUbicaciones = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SBEliminarU = new DevExpress.XtraEditors.SimpleButton();
            this.SBAgregarU = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.TBUbicacion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCUbicaciones)).BeginInit();
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
            this.ribbon.Size = new System.Drawing.Size(613, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 345);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(613, 27);
            // 
            // GCUbicaciones
            // 
            this.GCUbicaciones.Location = new System.Drawing.Point(0, 46);
            this.GCUbicaciones.MainView = this.gridView1;
            this.GCUbicaciones.MenuManager = this.ribbon;
            this.GCUbicaciones.Name = "GCUbicaciones";
            this.GCUbicaciones.Size = new System.Drawing.Size(682, 228);
            this.GCUbicaciones.TabIndex = 2;
            this.GCUbicaciones.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.GCUbicaciones;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // SBEliminarU
            // 
            this.SBEliminarU.Image = ((System.Drawing.Image)(resources.GetObject("SBEliminarU.Image")));
            this.SBEliminarU.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SBEliminarU.Location = new System.Drawing.Point(561, 289);
            this.SBEliminarU.Name = "SBEliminarU";
            this.SBEliminarU.Size = new System.Drawing.Size(30, 30);
            this.SBEliminarU.TabIndex = 4;
            this.SBEliminarU.Click += new System.EventHandler(this.SBEliminarU_Click);
            // 
            // SBAgregarU
            // 
            this.SBAgregarU.Image = ((System.Drawing.Image)(resources.GetObject("SBAgregarU.Image")));
            this.SBAgregarU.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SBAgregarU.Location = new System.Drawing.Point(511, 290);
            this.SBAgregarU.Name = "SBAgregarU";
            this.SBAgregarU.Size = new System.Drawing.Size(31, 29);
            this.SBAgregarU.TabIndex = 5;
            this.SBAgregarU.Click += new System.EventHandler(this.SBAgregarU_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 298);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Direccion:";
            // 
            // TBUbicacion
            // 
            this.TBUbicacion.Location = new System.Drawing.Point(65, 295);
            this.TBUbicacion.Name = "TBUbicacion";
            this.TBUbicacion.Size = new System.Drawing.Size(431, 21);
            this.TBUbicacion.TabIndex = 7;
            // 
            // UbicacionF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 372);
            this.Controls.Add(this.TBUbicacion);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.SBAgregarU);
            this.Controls.Add(this.SBEliminarU);
            this.Controls.Add(this.GCUbicaciones);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UbicacionF";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Ubicaciones";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCUbicaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraGrid.GridControl GCUbicaciones;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton SBEliminarU;
        private DevExpress.XtraEditors.SimpleButton SBAgregarU;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.TextBox TBUbicacion;
    }
}