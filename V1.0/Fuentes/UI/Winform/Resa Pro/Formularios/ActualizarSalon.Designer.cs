namespace Resa_Pro.Formularios
{
    partial class ActualizarSalon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualizarSalon));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.GCcrearSalon = new DevExpress.XtraEditors.GroupControl();
            this.SBUbicaciones = new DevExpress.XtraEditors.SimpleButton();
            this.CBUbicacion = new System.Windows.Forms.ComboBox();
            this.CBEstado = new System.Windows.Forms.ComboBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.TENombreS = new DevExpress.XtraEditors.TextEdit();
            this.TECapacidad = new DevExpress.XtraEditors.TextEdit();
            this.SBActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.GCagregarServicio = new DevExpress.XtraEditors.GroupControl();
            this.CKDListServicios = new System.Windows.Forms.CheckedListBox();
            this.TBServicio = new System.Windows.Forms.TextBox();
            this.SBQuitarS = new DevExpress.XtraEditors.SimpleButton();
            this.SBAgregarS = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.CKDListInventario = new System.Windows.Forms.CheckedListBox();
            this.TBInventario = new System.Windows.Forms.TextBox();
            this.SBAgregarIV = new DevExpress.XtraEditors.SimpleButton();
            this.SBQuitarIV = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCcrearSalon)).BeginInit();
            this.GCcrearSalon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TENombreS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TECapacidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCagregarServicio)).BeginInit();
            this.GCagregarServicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
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
            this.ribbon.Size = new System.Drawing.Size(779, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 576);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(779, 27);
            // 
            // GCcrearSalon
            // 
            this.GCcrearSalon.Controls.Add(this.SBUbicaciones);
            this.GCcrearSalon.Controls.Add(this.CBUbicacion);
            this.GCcrearSalon.Controls.Add(this.CBEstado);
            this.GCcrearSalon.Controls.Add(this.labelControl4);
            this.GCcrearSalon.Controls.Add(this.labelControl1);
            this.GCcrearSalon.Controls.Add(this.labelControl2);
            this.GCcrearSalon.Controls.Add(this.labelControl3);
            this.GCcrearSalon.Controls.Add(this.TENombreS);
            this.GCcrearSalon.Controls.Add(this.TECapacidad);
            this.GCcrearSalon.Dock = System.Windows.Forms.DockStyle.Top;
            this.GCcrearSalon.Location = new System.Drawing.Point(0, 49);
            this.GCcrearSalon.Name = "GCcrearSalon";
            this.GCcrearSalon.Size = new System.Drawing.Size(779, 144);
            this.GCcrearSalon.TabIndex = 11;
            this.GCcrearSalon.Text = "Crear Salon";
            // 
            // SBUbicaciones
            // 
            this.SBUbicaciones.Image = ((System.Drawing.Image)(resources.GetObject("SBUbicaciones.Image")));
            this.SBUbicaciones.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SBUbicaciones.Location = new System.Drawing.Point(745, 30);
            this.SBUbicaciones.Name = "SBUbicaciones";
            this.SBUbicaciones.Size = new System.Drawing.Size(27, 26);
            this.SBUbicaciones.TabIndex = 15;
            this.SBUbicaciones.Click += new System.EventHandler(this.SBUbicaciones_Click);
            // 
            // CBUbicacion
            // 
            this.CBUbicacion.FormattingEnabled = true;
            this.CBUbicacion.Location = new System.Drawing.Point(362, 35);
            this.CBUbicacion.Name = "CBUbicacion";
            this.CBUbicacion.Size = new System.Drawing.Size(375, 21);
            this.CBUbicacion.TabIndex = 14;
            // 
            // CBEstado
            // 
            this.CBEstado.FormattingEnabled = true;
            this.CBEstado.Location = new System.Drawing.Point(362, 88);
            this.CBEstado.Name = "CBEstado";
            this.CBEstado.Size = new System.Drawing.Size(107, 21);
            this.CBEstado.TabIndex = 12;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(309, 96);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(37, 13);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Estado:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(35, 43);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Nombre:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(309, 43);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Direccion:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(35, 96);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Capacidad:";
            // 
            // TENombreS
            // 
            this.TENombreS.Location = new System.Drawing.Point(102, 36);
            this.TENombreS.MenuManager = this.ribbon;
            this.TENombreS.Name = "TENombreS";
            this.TENombreS.Size = new System.Drawing.Size(166, 20);
            this.TENombreS.TabIndex = 3;
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
            // SBActualizar
            // 
            this.SBActualizar.Image = ((System.Drawing.Image)(resources.GetObject("SBActualizar.Image")));
            this.SBActualizar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBActualizar.Location = new System.Drawing.Point(306, 314);
            this.SBActualizar.Name = "SBActualizar";
            this.SBActualizar.Size = new System.Drawing.Size(75, 54);
            this.SBActualizar.TabIndex = 10;
            this.SBActualizar.Text = "Actualizar";
            this.SBActualizar.Click += new System.EventHandler(this.SBActualizar_Click);
            // 
            // GCagregarServicio
            // 
            this.GCagregarServicio.Controls.Add(this.CKDListServicios);
            this.GCagregarServicio.Controls.Add(this.TBServicio);
            this.GCagregarServicio.Controls.Add(this.SBQuitarS);
            this.GCagregarServicio.Controls.Add(this.SBAgregarS);
            this.GCagregarServicio.Controls.Add(this.labelControl6);
            this.GCagregarServicio.Dock = System.Windows.Forms.DockStyle.Left;
            this.GCagregarServicio.Location = new System.Drawing.Point(0, 193);
            this.GCagregarServicio.Name = "GCagregarServicio";
            this.GCagregarServicio.Size = new System.Drawing.Size(381, 383);
            this.GCagregarServicio.TabIndex = 14;
            this.GCagregarServicio.Text = "Agregar Servicio";
            // 
            // CKDListServicios
            // 
            this.CKDListServicios.CheckOnClick = true;
            this.CKDListServicios.Dock = System.Windows.Forms.DockStyle.Top;
            this.CKDListServicios.FormattingEnabled = true;
            this.CKDListServicios.Location = new System.Drawing.Point(2, 20);
            this.CKDListServicios.Name = "CKDListServicios";
            this.CKDListServicios.Size = new System.Drawing.Size(377, 212);
            this.CKDListServicios.TabIndex = 16;
            // 
            // TBServicio
            // 
            this.TBServicio.Location = new System.Drawing.Point(91, 247);
            this.TBServicio.Name = "TBServicio";
            this.TBServicio.Size = new System.Drawing.Size(213, 21);
            this.TBServicio.TabIndex = 15;
            // 
            // SBQuitarS
            // 
            this.SBQuitarS.Image = ((System.Drawing.Image)(resources.GetObject("SBQuitarS.Image")));
            this.SBQuitarS.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SBQuitarS.Location = new System.Drawing.Point(309, 244);
            this.SBQuitarS.Name = "SBQuitarS";
            this.SBQuitarS.Size = new System.Drawing.Size(30, 27);
            this.SBQuitarS.TabIndex = 12;
            this.SBQuitarS.Click += new System.EventHandler(this.SBQuitarS_Click);
            // 
            // SBAgregarS
            // 
            this.SBAgregarS.Image = ((System.Drawing.Image)(resources.GetObject("SBAgregarS.Image")));
            this.SBAgregarS.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SBAgregarS.Location = new System.Drawing.Point(345, 244);
            this.SBAgregarS.Name = "SBAgregarS";
            this.SBAgregarS.Size = new System.Drawing.Size(30, 27);
            this.SBAgregarS.TabIndex = 11;
            this.SBAgregarS.Click += new System.EventHandler(this.SBAgregarS_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(35, 255);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(41, 13);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Servicio:";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.CKDListInventario);
            this.groupControl1.Controls.Add(this.TBInventario);
            this.groupControl1.Controls.Add(this.SBAgregarIV);
            this.groupControl1.Controls.Add(this.SBActualizar);
            this.groupControl1.Controls.Add(this.SBQuitarIV);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl1.Location = new System.Drawing.Point(387, 193);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(392, 383);
            this.groupControl1.TabIndex = 15;
            this.groupControl1.Text = "Agregar Inventario";
            // 
            // CKDListInventario
            // 
            this.CKDListInventario.CheckOnClick = true;
            this.CKDListInventario.Dock = System.Windows.Forms.DockStyle.Top;
            this.CKDListInventario.FormattingEnabled = true;
            this.CKDListInventario.Location = new System.Drawing.Point(2, 20);
            this.CKDListInventario.Name = "CKDListInventario";
            this.CKDListInventario.Size = new System.Drawing.Size(388, 212);
            this.CKDListInventario.TabIndex = 19;
            // 
            // TBInventario
            // 
            this.TBInventario.Location = new System.Drawing.Point(101, 247);
            this.TBInventario.Name = "TBInventario";
            this.TBInventario.Size = new System.Drawing.Size(213, 21);
            this.TBInventario.TabIndex = 18;
            // 
            // SBAgregarIV
            // 
            this.SBAgregarIV.Image = ((System.Drawing.Image)(resources.GetObject("SBAgregarIV.Image")));
            this.SBAgregarIV.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SBAgregarIV.Location = new System.Drawing.Point(356, 243);
            this.SBAgregarIV.Name = "SBAgregarIV";
            this.SBAgregarIV.Size = new System.Drawing.Size(32, 27);
            this.SBAgregarIV.TabIndex = 13;
            this.SBAgregarIV.Click += new System.EventHandler(this.SBAgregarIV_Click);
            // 
            // SBQuitarIV
            // 
            this.SBQuitarIV.Image = ((System.Drawing.Image)(resources.GetObject("SBQuitarIV.Image")));
            this.SBQuitarIV.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SBQuitarIV.Location = new System.Drawing.Point(320, 243);
            this.SBQuitarIV.Name = "SBQuitarIV";
            this.SBQuitarIV.Size = new System.Drawing.Size(30, 28);
            this.SBQuitarIV.TabIndex = 12;
            this.SBQuitarIV.Click += new System.EventHandler(this.SBQuitarIV_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(25, 250);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(54, 13);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "Inventario:";
            // 
            // ActualizarSalon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 603);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.GCagregarServicio);
            this.Controls.Add(this.GCcrearSalon);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActualizarSalon";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Actualizar salon";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCcrearSalon)).EndInit();
            this.GCcrearSalon.ResumeLayout(false);
            this.GCcrearSalon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TENombreS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TECapacidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCagregarServicio)).EndInit();
            this.GCagregarServicio.ResumeLayout(false);
            this.GCagregarServicio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.GroupControl GCcrearSalon;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton SBActualizar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit TENombreS;
        private DevExpress.XtraEditors.TextEdit TECapacidad;
        private DevExpress.XtraEditors.GroupControl GCagregarServicio;
        private DevExpress.XtraEditors.SimpleButton SBQuitarS;
        private DevExpress.XtraEditors.SimpleButton SBAgregarS;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton SBAgregarIV;
        private DevExpress.XtraEditors.SimpleButton SBQuitarIV;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.ComboBox CBEstado;
        private System.Windows.Forms.TextBox TBServicio;
        private System.Windows.Forms.TextBox TBInventario;
        private System.Windows.Forms.CheckedListBox CKDListServicios;
        private System.Windows.Forms.CheckedListBox CKDListInventario;
        private System.Windows.Forms.ComboBox CBUbicacion;
        private DevExpress.XtraEditors.SimpleButton SBUbicaciones;
    }
}