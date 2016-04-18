namespace Resa_Pro.Formularios
{
    partial class OrganizadoresF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrganizadoresF));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.GCOrganizador = new DevExpress.XtraEditors.GroupControl();
            this.SBActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.SBAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.SBEliminar = new DevExpress.XtraEditors.SimpleButton();
            this.TBCorreoO = new System.Windows.Forms.TextBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.TBDescripcionO = new System.Windows.Forms.TextBox();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.TBNombreO = new System.Windows.Forms.TextBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.GCOrganizadores = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCOrganizador)).BeginInit();
            this.GCOrganizador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCOrganizadores)).BeginInit();
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
            this.ribbon.Size = new System.Drawing.Size(826, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 315);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(826, 27);
            // 
            // GCOrganizador
            // 
            this.GCOrganizador.Controls.Add(this.SBActualizar);
            this.GCOrganizador.Controls.Add(this.SBAgregar);
            this.GCOrganizador.Controls.Add(this.SBEliminar);
            this.GCOrganizador.Controls.Add(this.TBCorreoO);
            this.GCOrganizador.Controls.Add(this.labelControl8);
            this.GCOrganizador.Controls.Add(this.TBDescripcionO);
            this.GCOrganizador.Controls.Add(this.labelControl7);
            this.GCOrganizador.Controls.Add(this.TBNombreO);
            this.GCOrganizador.Controls.Add(this.labelControl6);
            this.GCOrganizador.Dock = System.Windows.Forms.DockStyle.Left;
            this.GCOrganizador.Location = new System.Drawing.Point(0, 49);
            this.GCOrganizador.Name = "GCOrganizador";
            this.GCOrganizador.Size = new System.Drawing.Size(346, 266);
            this.GCOrganizador.TabIndex = 8;
            this.GCOrganizador.Text = "Organizador";
            // 
            // SBActualizar
            // 
            this.SBActualizar.Image = ((System.Drawing.Image)(resources.GetObject("SBActualizar.Image")));
            this.SBActualizar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBActualizar.Location = new System.Drawing.Point(137, 205);
            this.SBActualizar.Name = "SBActualizar";
            this.SBActualizar.Size = new System.Drawing.Size(75, 55);
            this.SBActualizar.TabIndex = 16;
            this.SBActualizar.Text = "Actualizar";
            this.SBActualizar.Click += new System.EventHandler(this.SBActualizar_Click);
            // 
            // SBAgregar
            // 
            this.SBAgregar.Image = ((System.Drawing.Image)(resources.GetObject("SBAgregar.Image")));
            this.SBAgregar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBAgregar.Location = new System.Drawing.Point(14, 205);
            this.SBAgregar.Name = "SBAgregar";
            this.SBAgregar.Size = new System.Drawing.Size(71, 55);
            this.SBAgregar.TabIndex = 15;
            this.SBAgregar.Text = "Agregar";
            this.SBAgregar.Click += new System.EventHandler(this.SBAgregar_Click);
            // 
            // SBEliminar
            // 
            this.SBEliminar.Image = ((System.Drawing.Image)(resources.GetObject("SBEliminar.Image")));
            this.SBEliminar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBEliminar.Location = new System.Drawing.Point(259, 205);
            this.SBEliminar.Name = "SBEliminar";
            this.SBEliminar.Size = new System.Drawing.Size(71, 55);
            this.SBEliminar.TabIndex = 14;
            this.SBEliminar.Text = "Eliminar";
            this.SBEliminar.Click += new System.EventHandler(this.SBEliminar_Click);
            // 
            // TBCorreoO
            // 
            this.TBCorreoO.Location = new System.Drawing.Point(91, 167);
            this.TBCorreoO.Name = "TBCorreoO";
            this.TBCorreoO.Size = new System.Drawing.Size(239, 21);
            this.TBCorreoO.TabIndex = 13;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(14, 175);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(37, 13);
            this.labelControl8.TabIndex = 12;
            this.labelControl8.Text = "Correo:";
            // 
            // TBDescripcionO
            // 
            this.TBDescripcionO.Location = new System.Drawing.Point(91, 85);
            this.TBDescripcionO.Multiline = true;
            this.TBDescripcionO.Name = "TBDescripcionO";
            this.TBDescripcionO.Size = new System.Drawing.Size(239, 59);
            this.TBDescripcionO.TabIndex = 11;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(14, 93);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(58, 13);
            this.labelControl7.TabIndex = 10;
            this.labelControl7.Text = "Descripcion:";
            // 
            // TBNombreO
            // 
            this.TBNombreO.Location = new System.Drawing.Point(91, 37);
            this.TBNombreO.Name = "TBNombreO";
            this.TBNombreO.Size = new System.Drawing.Size(239, 21);
            this.TBNombreO.TabIndex = 9;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(14, 37);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(41, 13);
            this.labelControl6.TabIndex = 9;
            this.labelControl6.Text = "Nombre:";
            // 
            // GCOrganizadores
            // 
            this.GCOrganizadores.Dock = System.Windows.Forms.DockStyle.Right;
            this.GCOrganizadores.Location = new System.Drawing.Point(352, 49);
            this.GCOrganizadores.MainView = this.gridView1;
            this.GCOrganizadores.MenuManager = this.ribbon;
            this.GCOrganizadores.Name = "GCOrganizadores";
            this.GCOrganizadores.Size = new System.Drawing.Size(474, 266);
            this.GCOrganizadores.TabIndex = 9;
            this.GCOrganizadores.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.GCOrganizadores.Click += new System.EventHandler(this.GCOrganizadores_Click);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.GCOrganizadores;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // OrganizadoresF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 342);
            this.Controls.Add(this.GCOrganizadores);
            this.Controls.Add(this.GCOrganizador);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrganizadoresF";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Organizadores";
            this.Load += new System.EventHandler(this.OrganizadoresF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCOrganizador)).EndInit();
            this.GCOrganizador.ResumeLayout(false);
            this.GCOrganizador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCOrganizadores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.GroupControl GCOrganizador;
        private DevExpress.XtraEditors.SimpleButton SBAgregar;
        private DevExpress.XtraEditors.SimpleButton SBEliminar;
        private System.Windows.Forms.TextBox TBCorreoO;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.TextBox TBDescripcionO;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.Windows.Forms.TextBox TBNombreO;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraGrid.GridControl GCOrganizadores;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton SBActualizar;
    }
}