namespace Resa_Pro.Formularios
{
    partial class CrearSalonF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearSalonF));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.TENombre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.TEDireccion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.GCcrearSalon = new DevExpress.XtraEditors.GroupControl();
            this.CBEstado = new System.Windows.Forms.ComboBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.SBCrearSalon = new DevExpress.XtraEditors.SimpleButton();
            this.TECapacidad = new DevExpress.XtraEditors.TextEdit();
            this.GCagregarServicio = new DevExpress.XtraEditors.GroupControl();
            this.TBDescripcionS = new System.Windows.Forms.TextBox();
            this.TBNombreS = new System.Windows.Forms.TextBox();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.SBQuitarS = new DevExpress.XtraEditors.SimpleButton();
            this.SBAgregarS = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.GCServicios = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.TBNombreIV = new System.Windows.Forms.TextBox();
            this.SBAgregarI = new DevExpress.XtraEditors.SimpleButton();
            this.SBQuitarI = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.GCInventarios = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TENombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEDireccion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCcrearSalon)).BeginInit();
            this.GCcrearSalon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TECapacidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCagregarServicio)).BeginInit();
            this.GCagregarServicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCServicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
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
            this.ribbon.Size = new System.Drawing.Size(769, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 503);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(769, 27);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(35, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Nombre:";
            // 
            // TENombre
            // 
            this.TENombre.Location = new System.Drawing.Point(102, 36);
            this.TENombre.MenuManager = this.ribbon;
            this.TENombre.Name = "TENombre";
            this.TENombre.Size = new System.Drawing.Size(166, 20);
            this.TENombre.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(300, 43);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Direccion:";
            // 
            // TEDireccion
            // 
            this.TEDireccion.Location = new System.Drawing.Point(362, 36);
            this.TEDireccion.MenuManager = this.ribbon;
            this.TEDireccion.Name = "TEDireccion";
            this.TEDireccion.Size = new System.Drawing.Size(368, 20);
            this.TEDireccion.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(35, 96);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Capacidad:";
            // 
            // GCcrearSalon
            // 
            this.GCcrearSalon.Controls.Add(this.CBEstado);
            this.GCcrearSalon.Controls.Add(this.labelControl4);
            this.GCcrearSalon.Controls.Add(this.SBCrearSalon);
            this.GCcrearSalon.Controls.Add(this.labelControl1);
            this.GCcrearSalon.Controls.Add(this.labelControl2);
            this.GCcrearSalon.Controls.Add(this.TEDireccion);
            this.GCcrearSalon.Controls.Add(this.labelControl3);
            this.GCcrearSalon.Controls.Add(this.TENombre);
            this.GCcrearSalon.Controls.Add(this.TECapacidad);
            this.GCcrearSalon.Dock = System.Windows.Forms.DockStyle.Top;
            this.GCcrearSalon.Location = new System.Drawing.Point(0, 49);
            this.GCcrearSalon.Name = "GCcrearSalon";
            this.GCcrearSalon.Size = new System.Drawing.Size(769, 144);
            this.GCcrearSalon.TabIndex = 10;
            this.GCcrearSalon.Text = "Crear Salon";
            // 
            // CBEstado
            // 
            this.CBEstado.FormattingEnabled = true;
            this.CBEstado.Location = new System.Drawing.Point(362, 88);
            this.CBEstado.Name = "CBEstado";
            this.CBEstado.Size = new System.Drawing.Size(92, 21);
            this.CBEstado.TabIndex = 12;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(300, 96);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(37, 13);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Estado:";
            // 
            // SBCrearSalon
            // 
            this.SBCrearSalon.Image = ((System.Drawing.Image)(resources.GetObject("SBCrearSalon.Image")));
            this.SBCrearSalon.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBCrearSalon.Location = new System.Drawing.Point(655, 69);
            this.SBCrearSalon.Name = "SBCrearSalon";
            this.SBCrearSalon.Size = new System.Drawing.Size(75, 54);
            this.SBCrearSalon.TabIndex = 10;
            this.SBCrearSalon.Text = "Crear";
            this.SBCrearSalon.Click += new System.EventHandler(this.SBCrearSalon_Click);
            // 
            // TECapacidad
            // 
            this.TECapacidad.Location = new System.Drawing.Point(102, 89);
            this.TECapacidad.MenuManager = this.ribbon;
            this.TECapacidad.Name = "TECapacidad";
            this.TECapacidad.Properties.Mask.EditMask = "d";
            this.TECapacidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.TECapacidad.Size = new System.Drawing.Size(99, 20);
            this.TECapacidad.TabIndex = 9;
            // 
            // GCagregarServicio
            // 
            this.GCagregarServicio.Controls.Add(this.TBDescripcionS);
            this.GCagregarServicio.Controls.Add(this.TBNombreS);
            this.GCagregarServicio.Controls.Add(this.labelControl7);
            this.GCagregarServicio.Controls.Add(this.SBQuitarS);
            this.GCagregarServicio.Controls.Add(this.SBAgregarS);
            this.GCagregarServicio.Controls.Add(this.labelControl6);
            this.GCagregarServicio.Controls.Add(this.GCServicios);
            this.GCagregarServicio.Dock = System.Windows.Forms.DockStyle.Left;
            this.GCagregarServicio.Location = new System.Drawing.Point(0, 193);
            this.GCagregarServicio.Name = "GCagregarServicio";
            this.GCagregarServicio.Size = new System.Drawing.Size(381, 310);
            this.GCagregarServicio.TabIndex = 13;
            this.GCagregarServicio.Text = "Agregar Servicio";
            // 
            // TBDescripcionS
            // 
            this.TBDescripcionS.Location = new System.Drawing.Point(102, 201);
            this.TBDescripcionS.Name = "TBDescripcionS";
            this.TBDescripcionS.Size = new System.Drawing.Size(213, 21);
            this.TBDescripcionS.TabIndex = 15;
            // 
            // TBNombreS
            // 
            this.TBNombreS.Location = new System.Drawing.Point(102, 171);
            this.TBNombreS.Name = "TBNombreS";
            this.TBNombreS.Size = new System.Drawing.Size(213, 21);
            this.TBNombreS.TabIndex = 14;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(35, 204);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(58, 13);
            this.labelControl7.TabIndex = 13;
            this.labelControl7.Text = "Descripcion:";
            // 
            // SBQuitarS
            // 
            this.SBQuitarS.Image = ((System.Drawing.Image)(resources.GetObject("SBQuitarS.Image")));
            this.SBQuitarS.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBQuitarS.Location = new System.Drawing.Point(147, 241);
            this.SBQuitarS.Name = "SBQuitarS";
            this.SBQuitarS.Size = new System.Drawing.Size(75, 54);
            this.SBQuitarS.TabIndex = 12;
            this.SBQuitarS.Text = "Quitar";
            this.SBQuitarS.Click += new System.EventHandler(this.SBQuitarS_Click);
            // 
            // SBAgregarS
            // 
            this.SBAgregarS.Image = ((System.Drawing.Image)(resources.GetObject("SBAgregarS.Image")));
            this.SBAgregarS.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBAgregarS.Location = new System.Drawing.Point(240, 241);
            this.SBAgregarS.Name = "SBAgregarS";
            this.SBAgregarS.Size = new System.Drawing.Size(75, 54);
            this.SBAgregarS.TabIndex = 11;
            this.SBAgregarS.Text = "Agregar";
            this.SBAgregarS.Click += new System.EventHandler(this.SBAgregarS_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(35, 174);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(41, 13);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Servicio:";
            // 
            // GCServicios
            // 
            this.GCServicios.Location = new System.Drawing.Point(12, 23);
            this.GCServicios.MainView = this.gridView1;
            this.GCServicios.MenuManager = this.ribbon;
            this.GCServicios.Name = "GCServicios";
            this.GCServicios.Size = new System.Drawing.Size(353, 135);
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
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.TBNombreIV);
            this.groupControl1.Controls.Add(this.SBAgregarI);
            this.groupControl1.Controls.Add(this.SBQuitarI);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.GCInventarios);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl1.Location = new System.Drawing.Point(388, 193);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(381, 310);
            this.groupControl1.TabIndex = 14;
            this.groupControl1.Text = "Agregar Inventario";
            // 
            // TBNombreIV
            // 
            this.TBNombreIV.Location = new System.Drawing.Point(94, 171);
            this.TBNombreIV.Name = "TBNombreIV";
            this.TBNombreIV.Size = new System.Drawing.Size(213, 21);
            this.TBNombreIV.TabIndex = 15;
            // 
            // SBAgregarI
            // 
            this.SBAgregarI.Image = ((System.Drawing.Image)(resources.GetObject("SBAgregarI.Image")));
            this.SBAgregarI.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBAgregarI.Location = new System.Drawing.Point(232, 241);
            this.SBAgregarI.Name = "SBAgregarI";
            this.SBAgregarI.Size = new System.Drawing.Size(75, 54);
            this.SBAgregarI.TabIndex = 13;
            this.SBAgregarI.Text = "Agregar";
            this.SBAgregarI.Click += new System.EventHandler(this.SBAgregarI_Click);
            // 
            // SBQuitarI
            // 
            this.SBQuitarI.Image = ((System.Drawing.Image)(resources.GetObject("SBQuitarI.Image")));
            this.SBQuitarI.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBQuitarI.Location = new System.Drawing.Point(137, 241);
            this.SBQuitarI.Name = "SBQuitarI";
            this.SBQuitarI.Size = new System.Drawing.Size(75, 54);
            this.SBQuitarI.TabIndex = 12;
            this.SBQuitarI.Text = "Quitar";
            this.SBQuitarI.Click += new System.EventHandler(this.SBQuitarI_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(34, 174);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(54, 13);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "Inventario:";
            // 
            // GCInventarios
            // 
            this.GCInventarios.Location = new System.Drawing.Point(11, 23);
            this.GCInventarios.MainView = this.gridView2;
            this.GCInventarios.MenuManager = this.ribbon;
            this.GCInventarios.Name = "GCInventarios";
            this.GCInventarios.Size = new System.Drawing.Size(358, 135);
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
            // CrearSalonF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 530);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.GCagregarServicio);
            this.Controls.Add(this.GCcrearSalon);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CrearSalonF";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Crear salon";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TENombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEDireccion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCcrearSalon)).EndInit();
            this.GCcrearSalon.ResumeLayout(false);
            this.GCcrearSalon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TECapacidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCagregarServicio)).EndInit();
            this.GCagregarServicio.ResumeLayout(false);
            this.GCagregarServicio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCServicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCInventarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit TENombre;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit TEDireccion;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GroupControl GCcrearSalon;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton SBCrearSalon;
        private DevExpress.XtraEditors.GroupControl GCagregarServicio;
        private DevExpress.XtraGrid.GridControl GCServicios;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl GCInventarios;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton SBQuitarS;
        private DevExpress.XtraEditors.SimpleButton SBAgregarS;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton SBAgregarI;
        private DevExpress.XtraEditors.SimpleButton SBQuitarI;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit TECapacidad;
        private System.Windows.Forms.ComboBox CBEstado;
        private System.Windows.Forms.TextBox TBDescripcionS;
        private System.Windows.Forms.TextBox TBNombreS;
        private System.Windows.Forms.TextBox TBNombreIV;
    }
}