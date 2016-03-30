namespace Resa_Pro.Formularios
{
    partial class VerSalon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerSalon));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.LBLEstadoS = new System.Windows.Forms.Label();
            this.LBLCapacidadS = new System.Windows.Forms.Label();
            this.LBLUbicacionS = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LBLNombreS = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CGServicios = new DevExpress.XtraEditors.GroupControl();
            this.GCServicios = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CGInventarios = new DevExpress.XtraEditors.GroupControl();
            this.GCInventarios = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CGServicios)).BeginInit();
            this.CGServicios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCServicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CGInventarios)).BeginInit();
            this.CGInventarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCInventarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
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
            this.ribbon.Size = new System.Drawing.Size(646, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 462);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(646, 27);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.pictureEdit1);
            this.groupControl1.Controls.Add(this.LBLEstadoS);
            this.groupControl1.Controls.Add(this.LBLCapacidadS);
            this.groupControl1.Controls.Add(this.LBLUbicacionS);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.LBLNombreS);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 49);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(646, 172);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Informacion";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::Resa_Pro.Properties.Resources.Salon_icono;
            this.pictureEdit1.Location = new System.Drawing.Point(540, 38);
            this.pictureEdit1.MenuManager = this.ribbon;
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(101, 112);
            this.pictureEdit1.TabIndex = 14;
            // 
            // LBLEstadoS
            // 
            this.LBLEstadoS.AutoSize = true;
            this.LBLEstadoS.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLEstadoS.Location = new System.Drawing.Point(115, 136);
            this.LBLEstadoS.Name = "LBLEstadoS";
            this.LBLEstadoS.Size = new System.Drawing.Size(81, 14);
            this.LBLEstadoS.TabIndex = 13;
            this.LBLEstadoS.Text = "-EstadoSalon-";
            // 
            // LBLCapacidadS
            // 
            this.LBLCapacidadS.AutoSize = true;
            this.LBLCapacidadS.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLCapacidadS.Location = new System.Drawing.Point(115, 105);
            this.LBLCapacidadS.Name = "LBLCapacidadS";
            this.LBLCapacidadS.Size = new System.Drawing.Size(98, 14);
            this.LBLCapacidadS.TabIndex = 12;
            this.LBLCapacidadS.Text = "-CapacidadSalon-";
            // 
            // LBLUbicacionS
            // 
            this.LBLUbicacionS.AutoSize = true;
            this.LBLUbicacionS.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLUbicacionS.Location = new System.Drawing.Point(115, 76);
            this.LBLUbicacionS.Name = "LBLUbicacionS";
            this.LBLUbicacionS.Size = new System.Drawing.Size(95, 14);
            this.LBLUbicacionS.TabIndex = 11;
            this.LBLUbicacionS.Text = "-UbicacionSalon-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Estado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Capacidad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ubicacion:";
            // 
            // LBLNombreS
            // 
            this.LBLNombreS.AutoSize = true;
            this.LBLNombreS.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLNombreS.Location = new System.Drawing.Point(115, 41);
            this.LBLNombreS.Name = "LBLNombreS";
            this.LBLNombreS.Size = new System.Drawing.Size(87, 14);
            this.LBLNombreS.TabIndex = 4;
            this.LBLNombreS.Text = "-NombreSalon-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // CGServicios
            // 
            this.CGServicios.Controls.Add(this.GCServicios);
            this.CGServicios.Dock = System.Windows.Forms.DockStyle.Left;
            this.CGServicios.Location = new System.Drawing.Point(0, 221);
            this.CGServicios.Name = "CGServicios";
            this.CGServicios.Size = new System.Drawing.Size(300, 241);
            this.CGServicios.TabIndex = 3;
            this.CGServicios.Text = "Servicios";
            // 
            // GCServicios
            // 
            this.GCServicios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCServicios.Location = new System.Drawing.Point(2, 20);
            this.GCServicios.MainView = this.gridView1;
            this.GCServicios.MenuManager = this.ribbon;
            this.GCServicios.Name = "GCServicios";
            this.GCServicios.Size = new System.Drawing.Size(296, 219);
            this.GCServicios.TabIndex = 0;
            this.GCServicios.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.GCServicios;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // CGInventarios
            // 
            this.CGInventarios.Controls.Add(this.GCInventarios);
            this.CGInventarios.Dock = System.Windows.Forms.DockStyle.Right;
            this.CGInventarios.Location = new System.Drawing.Point(346, 221);
            this.CGInventarios.Name = "CGInventarios";
            this.CGInventarios.Size = new System.Drawing.Size(300, 241);
            this.CGInventarios.TabIndex = 4;
            this.CGInventarios.Text = "Inventarios";
            // 
            // GCInventarios
            // 
            this.GCInventarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCInventarios.Location = new System.Drawing.Point(2, 20);
            this.GCInventarios.MainView = this.gridView2;
            this.GCInventarios.MenuManager = this.ribbon;
            this.GCInventarios.Name = "GCInventarios";
            this.GCInventarios.Size = new System.Drawing.Size(296, 219);
            this.GCInventarios.TabIndex = 1;
            this.GCInventarios.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.GCInventarios;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // VerSalon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 489);
            this.Controls.Add(this.CGInventarios);
            this.Controls.Add(this.CGServicios);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VerSalon";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Ver salon";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CGServicios)).EndInit();
            this.CGServicios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCServicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CGInventarios)).EndInit();
            this.CGInventarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCInventarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label LBLNombreS;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl CGServicios;
        private DevExpress.XtraGrid.GridControl GCServicios;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl CGInventarios;
        private DevExpress.XtraGrid.GridControl GCInventarios;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private System.Windows.Forms.Label LBLEstadoS;
        private System.Windows.Forms.Label LBLCapacidadS;
        private System.Windows.Forms.Label LBLUbicacionS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
    }
}