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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SBCrear = new DevExpress.XtraEditors.SimpleButton();
            this.SBActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.SBEliminar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
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
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 108);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(690, 309);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // SBCrear
            // 
            this.SBCrear.Image = ((System.Drawing.Image)(resources.GetObject("SBCrear.Image")));
            this.SBCrear.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBCrear.Location = new System.Drawing.Point(162, 433);
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
            this.SBActualizar.Location = new System.Drawing.Point(290, 433);
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
            this.SBEliminar.Location = new System.Drawing.Point(419, 433);
            this.SBEliminar.Name = "SBEliminar";
            this.SBEliminar.Size = new System.Drawing.Size(75, 52);
            this.SBEliminar.TabIndex = 7;
            this.SBEliminar.Text = "Eliminar";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 77);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(32, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Buscar";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(67, 74);
            this.textEdit1.MenuManager = this.ribbon;
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(170, 20);
            this.textEdit1.TabIndex = 9;
            // 
            // simpleButton4
            // 
            this.simpleButton4.Location = new System.Drawing.Point(267, 77);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(75, 23);
            this.simpleButton4.TabIndex = 10;
            this.simpleButton4.Text = "Buscar";
            // 
            // Salones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 518);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.SBEliminar);
            this.Controls.Add(this.SBActualizar);
            this.Controls.Add(this.SBCrear);
            this.Controls.Add(this.gridControl1);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton SBCrear;
        private DevExpress.XtraEditors.SimpleButton SBActualizar;
        private DevExpress.XtraEditors.SimpleButton SBEliminar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
    }
}