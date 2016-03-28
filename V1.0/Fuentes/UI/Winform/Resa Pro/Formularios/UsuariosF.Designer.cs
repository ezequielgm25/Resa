namespace Resa_Pro.Formularios
{
    partial class UsuariosF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsuariosF));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.GCUsuarios = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SBEliminarU = new DevExpress.XtraEditors.SimpleButton();
            this.SBActualizarU = new DevExpress.XtraEditors.SimpleButton();
            this.SBAgregarU = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCUsuarios)).BeginInit();
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
            this.ribbon.Size = new System.Drawing.Size(901, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 502);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(901, 27);
            // 
            // GCUsuarios
            // 
            this.GCUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.GCUsuarios.Location = new System.Drawing.Point(0, 49);
            this.GCUsuarios.MainView = this.gridView1;
            this.GCUsuarios.MenuManager = this.ribbon;
            this.GCUsuarios.Name = "GCUsuarios";
            this.GCUsuarios.Size = new System.Drawing.Size(901, 341);
            this.GCUsuarios.TabIndex = 2;
            this.GCUsuarios.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.GCUsuarios;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // SBEliminarU
            // 
            this.SBEliminarU.Image = ((System.Drawing.Image)(resources.GetObject("SBEliminarU.Image")));
            this.SBEliminarU.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBEliminarU.Location = new System.Drawing.Point(556, 418);
            this.SBEliminarU.Name = "SBEliminarU";
            this.SBEliminarU.Size = new System.Drawing.Size(75, 61);
            this.SBEliminarU.TabIndex = 11;
            this.SBEliminarU.Text = "Eliminar";
            this.SBEliminarU.Click += new System.EventHandler(this.SBEliminarU_Click);
            // 
            // SBActualizarU
            // 
            this.SBActualizarU.Image = ((System.Drawing.Image)(resources.GetObject("SBActualizarU.Image")));
            this.SBActualizarU.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBActualizarU.Location = new System.Drawing.Point(398, 418);
            this.SBActualizarU.Name = "SBActualizarU";
            this.SBActualizarU.Size = new System.Drawing.Size(75, 61);
            this.SBActualizarU.TabIndex = 10;
            this.SBActualizarU.Text = "Actualizar";
            this.SBActualizarU.Click += new System.EventHandler(this.SBActualizarU_Click);
            // 
            // SBAgregarU
            // 
            this.SBAgregarU.Image = ((System.Drawing.Image)(resources.GetObject("SBAgregarU.Image")));
            this.SBAgregarU.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBAgregarU.Location = new System.Drawing.Point(249, 418);
            this.SBAgregarU.Name = "SBAgregarU";
            this.SBAgregarU.Size = new System.Drawing.Size(75, 61);
            this.SBAgregarU.TabIndex = 9;
            this.SBAgregarU.Text = "Agregar";
            this.SBAgregarU.Click += new System.EventHandler(this.SBAgregarU_Click);
            // 
            // UsuariosF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 529);
            this.Controls.Add(this.SBEliminarU);
            this.Controls.Add(this.SBActualizarU);
            this.Controls.Add(this.SBAgregarU);
            this.Controls.Add(this.GCUsuarios);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsuariosF";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Usuarios";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraGrid.GridControl GCUsuarios;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton SBEliminarU;
        private DevExpress.XtraEditors.SimpleButton SBActualizarU;
        private DevExpress.XtraEditors.SimpleButton SBAgregarU;
    }
}