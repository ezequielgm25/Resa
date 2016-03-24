namespace Resa_Pro.Formularios
{
    partial class Salones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Salones));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.GCSalones = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SBCrear = new DevExpress.XtraEditors.SimpleButton();
            this.SBActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.SBEliminar = new DevExpress.XtraEditors.SimpleButton();
            this.gridSplitContainer1 = new DevExpress.XtraGrid.GridSplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCSalones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1)).BeginInit();
            this.gridSplitContainer1.SuspendLayout();
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
            this.ribbon.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.ribbonPageCategory1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbon.Size = new System.Drawing.Size(690, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar1;
            // 
            // ribbonPageCategory1
            // 
            this.ribbonPageCategory1.Name = "ribbonPageCategory1";
            this.ribbonPageCategory1.Text = "ribbonPageCategory1";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 491);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbon;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(690, 27);
            // 
            // GCSalones
            // 
            this.GCSalones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCSalones.Location = new System.Drawing.Point(0, 0);
            this.GCSalones.MainView = this.gridView1;
            this.GCSalones.MenuManager = this.ribbon;
            this.GCSalones.Name = "GCSalones";
            this.GCSalones.Size = new System.Drawing.Size(690, 351);
            this.GCSalones.TabIndex = 2;
            this.GCSalones.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.GCSalones.DoubleClick += new System.EventHandler(this.GCSalones_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.GCSalones;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // SBCrear
            // 
            this.SBCrear.Image = ((System.Drawing.Image)(resources.GetObject("SBCrear.Image")));
            this.SBCrear.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBCrear.Location = new System.Drawing.Point(146, 421);
            this.SBCrear.Name = "SBCrear";
            this.SBCrear.Size = new System.Drawing.Size(75, 52);
            this.SBCrear.TabIndex = 3;
            this.SBCrear.Text = "Crear ";
            this.SBCrear.Click += new System.EventHandler(this.SBCrear_Click);
            // 
            // SBActualizar
            // 
            this.SBActualizar.Image = ((System.Drawing.Image)(resources.GetObject("SBActualizar.Image")));
            this.SBActualizar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBActualizar.Location = new System.Drawing.Point(282, 421);
            this.SBActualizar.Name = "SBActualizar";
            this.SBActualizar.Size = new System.Drawing.Size(75, 52);
            this.SBActualizar.TabIndex = 6;
            this.SBActualizar.Text = "Actualizar";
            this.SBActualizar.Click += new System.EventHandler(this.SBActualizar_Click);
            // 
            // SBEliminar
            // 
            this.SBEliminar.Image = ((System.Drawing.Image)(resources.GetObject("SBEliminar.Image")));
            this.SBEliminar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBEliminar.Location = new System.Drawing.Point(422, 421);
            this.SBEliminar.Name = "SBEliminar";
            this.SBEliminar.Size = new System.Drawing.Size(75, 52);
            this.SBEliminar.TabIndex = 7;
            this.SBEliminar.Text = "Eliminar";
            this.SBEliminar.Click += new System.EventHandler(this.SBEliminar_Click);
            // 
            // gridSplitContainer1
            // 
            this.gridSplitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridSplitContainer1.Grid = this.GCSalones;
            this.gridSplitContainer1.Location = new System.Drawing.Point(0, 49);
            this.gridSplitContainer1.Name = "gridSplitContainer1";
            this.gridSplitContainer1.Panel1.Controls.Add(this.GCSalones);
            this.gridSplitContainer1.Size = new System.Drawing.Size(690, 351);
            this.gridSplitContainer1.TabIndex = 10;
            // 
            // Salones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 518);
            this.Controls.Add(this.SBEliminar);
            this.Controls.Add(this.SBActualizar);
            this.Controls.Add(this.SBCrear);
            this.Controls.Add(this.gridSplitContainer1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbon);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Salones";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Salones";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCSalones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1)).EndInit();
            this.gridSplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraGrid.GridControl GCSalones;
        private DevExpress.XtraEditors.SimpleButton SBCrear;
        private DevExpress.XtraEditors.SimpleButton SBActualizar;
        private DevExpress.XtraEditors.SimpleButton SBEliminar;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridSplitContainer gridSplitContainer1;
    }
}