﻿namespace Resa_Pro.Formularios
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.GCcrearSalon = new DevExpress.XtraEditors.GroupControl();
            this.SBUbicaciones = new DevExpress.XtraEditors.SimpleButton();
            this.CBUbicacion = new System.Windows.Forms.ComboBox();
            this.CBEstado = new System.Windows.Forms.ComboBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.TECapacidad = new DevExpress.XtraEditors.TextEdit();
            this.SBCrearSalon = new DevExpress.XtraEditors.SimpleButton();
            this.GCagregarServicio = new DevExpress.XtraEditors.GroupControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.TBServicio = new System.Windows.Forms.TextBox();
            this.SBEliminarS = new DevExpress.XtraEditors.SimpleButton();
            this.SBAgregarS = new DevExpress.XtraEditors.SimpleButton();
            this.CKDListServicios = new System.Windows.Forms.CheckedListBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.TBInventario = new System.Windows.Forms.TextBox();
            this.SBEliminarI = new DevExpress.XtraEditors.SimpleButton();
            this.SBAgregarI = new DevExpress.XtraEditors.SimpleButton();
            this.CKDListInventario = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TENombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCcrearSalon)).BeginInit();
            this.GCcrearSalon.SuspendLayout();
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
            this.ribbon.Size = new System.Drawing.Size(782, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 546);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(782, 27);
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
            this.GCcrearSalon.Controls.Add(this.SBUbicaciones);
            this.GCcrearSalon.Controls.Add(this.CBUbicacion);
            this.GCcrearSalon.Controls.Add(this.CBEstado);
            this.GCcrearSalon.Controls.Add(this.labelControl4);
            this.GCcrearSalon.Controls.Add(this.labelControl1);
            this.GCcrearSalon.Controls.Add(this.labelControl2);
            this.GCcrearSalon.Controls.Add(this.labelControl3);
            this.GCcrearSalon.Controls.Add(this.TENombre);
            this.GCcrearSalon.Controls.Add(this.TECapacidad);
            this.GCcrearSalon.Dock = System.Windows.Forms.DockStyle.Top;
            this.GCcrearSalon.Location = new System.Drawing.Point(0, 49);
            this.GCcrearSalon.Name = "GCcrearSalon";
            this.GCcrearSalon.Size = new System.Drawing.Size(782, 126);
            this.GCcrearSalon.TabIndex = 10;
            this.GCcrearSalon.Text = "Crear Salon";
            // 
            // SBUbicaciones
            // 
            this.SBUbicaciones.Image = ((System.Drawing.Image)(resources.GetObject("SBUbicaciones.Image")));
            this.SBUbicaciones.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SBUbicaciones.Location = new System.Drawing.Point(743, 30);
            this.SBUbicaciones.Name = "SBUbicaciones";
            this.SBUbicaciones.Size = new System.Drawing.Size(27, 26);
            this.SBUbicaciones.TabIndex = 14;
            this.SBUbicaciones.Click += new System.EventHandler(this.SBUbicaciones_Click);
            // 
            // CBUbicacion
            // 
            this.CBUbicacion.FormattingEnabled = true;
            this.CBUbicacion.Location = new System.Drawing.Point(362, 35);
            this.CBUbicacion.Name = "CBUbicacion";
            this.CBUbicacion.Size = new System.Drawing.Size(375, 21);
            this.CBUbicacion.TabIndex = 13;
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
            // SBCrearSalon
            // 
            this.SBCrearSalon.Image = ((System.Drawing.Image)(resources.GetObject("SBCrearSalon.Image")));
            this.SBCrearSalon.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBCrearSalon.Location = new System.Drawing.Point(310, 311);
            this.SBCrearSalon.Name = "SBCrearSalon";
            this.SBCrearSalon.Size = new System.Drawing.Size(75, 54);
            this.SBCrearSalon.TabIndex = 10;
            this.SBCrearSalon.Text = "Crear";
            this.SBCrearSalon.Click += new System.EventHandler(this.SBCrearSalon_Click);
            // 
            // GCagregarServicio
            // 
            this.GCagregarServicio.Controls.Add(this.labelControl6);
            this.GCagregarServicio.Controls.Add(this.TBServicio);
            this.GCagregarServicio.Controls.Add(this.SBEliminarS);
            this.GCagregarServicio.Controls.Add(this.SBAgregarS);
            this.GCagregarServicio.Controls.Add(this.CKDListServicios);
            this.GCagregarServicio.Dock = System.Windows.Forms.DockStyle.Left;
            this.GCagregarServicio.Location = new System.Drawing.Point(0, 175);
            this.GCagregarServicio.Name = "GCagregarServicio";
            this.GCagregarServicio.Size = new System.Drawing.Size(381, 371);
            this.GCagregarServicio.TabIndex = 13;
            this.GCagregarServicio.Text = "Agregar Servicio";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(35, 251);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(41, 13);
            this.labelControl6.TabIndex = 6;
            this.labelControl6.Text = "Servicio:";
            // 
            // TBServicio
            // 
            this.TBServicio.Location = new System.Drawing.Point(88, 243);
            this.TBServicio.Name = "TBServicio";
            this.TBServicio.Size = new System.Drawing.Size(212, 21);
            this.TBServicio.TabIndex = 3;
            // 
            // SBEliminarS
            // 
            this.SBEliminarS.Image = ((System.Drawing.Image)(resources.GetObject("SBEliminarS.Image")));
            this.SBEliminarS.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SBEliminarS.Location = new System.Drawing.Point(306, 238);
            this.SBEliminarS.Name = "SBEliminarS";
            this.SBEliminarS.Size = new System.Drawing.Size(31, 29);
            this.SBEliminarS.TabIndex = 2;
            this.SBEliminarS.Click += new System.EventHandler(this.SBEliminarS_Click);
            // 
            // SBAgregarS
            // 
            this.SBAgregarS.Image = ((System.Drawing.Image)(resources.GetObject("SBAgregarS.Image")));
            this.SBAgregarS.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SBAgregarS.Location = new System.Drawing.Point(343, 239);
            this.SBAgregarS.Name = "SBAgregarS";
            this.SBAgregarS.Size = new System.Drawing.Size(30, 28);
            this.SBAgregarS.TabIndex = 1;
            this.SBAgregarS.Click += new System.EventHandler(this.SBAgregarS_Click);
            // 
            // CKDListServicios
            // 
            this.CKDListServicios.CheckOnClick = true;
            this.CKDListServicios.Dock = System.Windows.Forms.DockStyle.Top;
            this.CKDListServicios.FormattingEnabled = true;
            this.CKDListServicios.Location = new System.Drawing.Point(2, 20);
            this.CKDListServicios.Name = "CKDListServicios";
            this.CKDListServicios.Size = new System.Drawing.Size(377, 212);
            this.CKDListServicios.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.TBInventario);
            this.groupControl1.Controls.Add(this.SBEliminarI);
            this.groupControl1.Controls.Add(this.SBAgregarI);
            this.groupControl1.Controls.Add(this.SBCrearSalon);
            this.groupControl1.Controls.Add(this.CKDListInventario);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl1.Location = new System.Drawing.Point(387, 175);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(395, 371);
            this.groupControl1.TabIndex = 14;
            this.groupControl1.Text = "Agregar Inventario";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(31, 251);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(54, 13);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Inventario:";
            // 
            // TBInventario
            // 
            this.TBInventario.Location = new System.Drawing.Point(100, 243);
            this.TBInventario.Name = "TBInventario";
            this.TBInventario.Size = new System.Drawing.Size(212, 21);
            this.TBInventario.TabIndex = 4;
            // 
            // SBEliminarI
            // 
            this.SBEliminarI.Image = ((System.Drawing.Image)(resources.GetObject("SBEliminarI.Image")));
            this.SBEliminarI.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SBEliminarI.Location = new System.Drawing.Point(318, 238);
            this.SBEliminarI.Name = "SBEliminarI";
            this.SBEliminarI.Size = new System.Drawing.Size(30, 30);
            this.SBEliminarI.TabIndex = 3;
            this.SBEliminarI.Click += new System.EventHandler(this.SBEliminarI_Click);
            // 
            // SBAgregarI
            // 
            this.SBAgregarI.Image = ((System.Drawing.Image)(resources.GetObject("SBAgregarI.Image")));
            this.SBAgregarI.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SBAgregarI.Location = new System.Drawing.Point(354, 239);
            this.SBAgregarI.Name = "SBAgregarI";
            this.SBAgregarI.Size = new System.Drawing.Size(31, 29);
            this.SBAgregarI.TabIndex = 2;
            this.SBAgregarI.Click += new System.EventHandler(this.SBAgregarI_Click);
            // 
            // CKDListInventario
            // 
            this.CKDListInventario.CheckOnClick = true;
            this.CKDListInventario.Dock = System.Windows.Forms.DockStyle.Top;
            this.CKDListInventario.FormattingEnabled = true;
            this.CKDListInventario.Location = new System.Drawing.Point(2, 20);
            this.CKDListInventario.Name = "CKDListInventario";
            this.CKDListInventario.Size = new System.Drawing.Size(391, 212);
            this.CKDListInventario.TabIndex = 1;
            // 
            // CrearSalonF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 573);
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
            this.Name = "CrearSalonF";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Crear salon";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TENombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCcrearSalon)).EndInit();
            this.GCcrearSalon.ResumeLayout(false);
            this.GCcrearSalon.PerformLayout();
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
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit TENombre;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GroupControl GCcrearSalon;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton SBCrearSalon;
        private DevExpress.XtraEditors.GroupControl GCagregarServicio;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit TECapacidad;
        private System.Windows.Forms.ComboBox CBEstado;
        private DevExpress.XtraEditors.SimpleButton SBEliminarS;
        private DevExpress.XtraEditors.SimpleButton SBAgregarS;
        private System.Windows.Forms.CheckedListBox CKDListServicios;
        private DevExpress.XtraEditors.SimpleButton SBEliminarI;
        private DevExpress.XtraEditors.SimpleButton SBAgregarI;
        private System.Windows.Forms.CheckedListBox CKDListInventario;
        private System.Windows.Forms.TextBox TBServicio;
        private System.Windows.Forms.TextBox TBInventario;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton SBUbicaciones;
        private System.Windows.Forms.ComboBox CBUbicacion;
    }
}