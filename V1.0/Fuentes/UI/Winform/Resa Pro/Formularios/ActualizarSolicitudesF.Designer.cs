namespace Resa_Pro.Formularios
{
    partial class ActualizarSolicitudesF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualizarSolicitudesF));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.GCSalon = new DevExpress.XtraEditors.GroupControl();
            this.GCSalones = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GCDetallesEvento = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.DateEditTFinal = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.DateEditTInicio = new DevExpress.XtraEditors.DateEdit();
            this.TBTopicoE = new System.Windows.Forms.TextBox();
            this.TBTipoE = new System.Windows.Forms.TextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.TBDescripcionE = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.TBTituloE = new System.Windows.Forms.TextBox();
            this.LBLTitulo = new DevExpress.XtraEditors.LabelControl();
            this.GCOrganizador = new DevExpress.XtraEditors.GroupControl();
            this.LBLNombreSalon = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.TBCorreoO = new System.Windows.Forms.TextBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.TBDescripcionO = new System.Windows.Forms.TextBox();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.SBActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.SBOrganizador = new DevExpress.XtraEditors.SimpleButton();
            this.CBOrganizador = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCSalon)).BeginInit();
            this.GCSalon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCSalones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCDetallesEvento)).BeginInit();
            this.GCDetallesEvento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditTFinal.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditTFinal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditTInicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditTInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCOrganizador)).BeginInit();
            this.GCOrganizador.SuspendLayout();
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
            this.ribbon.Size = new System.Drawing.Size(1028, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 492);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1028, 27);
            // 
            // GCSalon
            // 
            this.GCSalon.Controls.Add(this.GCSalones);
            this.GCSalon.Dock = System.Windows.Forms.DockStyle.Left;
            this.GCSalon.Location = new System.Drawing.Point(0, 49);
            this.GCSalon.Name = "GCSalon";
            this.GCSalon.Size = new System.Drawing.Size(244, 443);
            this.GCSalon.TabIndex = 4;
            this.GCSalon.Text = "Salon";
            // 
            // GCSalones
            // 
            this.GCSalones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCSalones.Location = new System.Drawing.Point(2, 20);
            this.GCSalones.MainView = this.gridView1;
            this.GCSalones.MenuManager = this.ribbon;
            this.GCSalones.Name = "GCSalones";
            this.GCSalones.Size = new System.Drawing.Size(240, 421);
            this.GCSalones.TabIndex = 2;
            this.GCSalones.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.GCSalones.Click += new System.EventHandler(this.GCSalones_Click_1);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.GCSalones;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.SearchInPreview = true;
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // GCDetallesEvento
            // 
            this.GCDetallesEvento.Controls.Add(this.groupControl1);
            this.GCDetallesEvento.Controls.Add(this.TBTopicoE);
            this.GCDetallesEvento.Controls.Add(this.TBTipoE);
            this.GCDetallesEvento.Controls.Add(this.labelControl3);
            this.GCDetallesEvento.Controls.Add(this.labelControl2);
            this.GCDetallesEvento.Controls.Add(this.TBDescripcionE);
            this.GCDetallesEvento.Controls.Add(this.labelControl1);
            this.GCDetallesEvento.Controls.Add(this.TBTituloE);
            this.GCDetallesEvento.Controls.Add(this.LBLTitulo);
            this.GCDetallesEvento.Dock = System.Windows.Forms.DockStyle.Left;
            this.GCDetallesEvento.Location = new System.Drawing.Point(244, 49);
            this.GCDetallesEvento.Name = "GCDetallesEvento";
            this.GCDetallesEvento.Size = new System.Drawing.Size(410, 443);
            this.GCDetallesEvento.TabIndex = 5;
            this.GCDetallesEvento.Text = "Detalles del evento";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.DateEditTFinal);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.DateEditTInicio);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(2, 276);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(406, 165);
            this.groupControl1.TabIndex = 8;
            this.groupControl1.Text = "Fecha y hora del evento";
            // 
            // DateEditTFinal
            // 
            this.DateEditTFinal.EditValue = null;
            this.DateEditTFinal.Location = new System.Drawing.Point(129, 106);
            this.DateEditTFinal.MenuManager = this.ribbon;
            this.DateEditTFinal.Name = "DateEditTFinal";
            this.DateEditTFinal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEditTFinal.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.DateEditTFinal.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEditTFinal.Properties.Mask.EditMask = "g";
            this.DateEditTFinal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.DateEditTFinal.Size = new System.Drawing.Size(131, 20);
            this.DateEditTFinal.TabIndex = 11;
            this.DateEditTFinal.EditValueChanged += new System.EventHandler(this.DateEditTFinal_EditValueChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(13, 109);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(61, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Tiempo final:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 46);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(79, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Tiempo de inicio:";
            // 
            // DateEditTInicio
            // 
            this.DateEditTInicio.EditValue = null;
            this.DateEditTInicio.Location = new System.Drawing.Point(129, 43);
            this.DateEditTInicio.MenuManager = this.ribbon;
            this.DateEditTInicio.Name = "DateEditTInicio";
            this.DateEditTInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEditTInicio.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.DateEditTInicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEditTInicio.Properties.Mask.EditMask = "g";
            this.DateEditTInicio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.DateEditTInicio.Size = new System.Drawing.Size(131, 20);
            this.DateEditTInicio.TabIndex = 10;
            this.DateEditTInicio.EditValueChanged += new System.EventHandler(this.DateEditTInicio_EditValueChanged);
            // 
            // TBTopicoE
            // 
            this.TBTopicoE.Location = new System.Drawing.Point(82, 123);
            this.TBTopicoE.Name = "TBTopicoE";
            this.TBTopicoE.Size = new System.Drawing.Size(215, 21);
            this.TBTopicoE.TabIndex = 7;
            // 
            // TBTipoE
            // 
            this.TBTipoE.Location = new System.Drawing.Point(82, 85);
            this.TBTipoE.Name = "TBTipoE";
            this.TBTipoE.Size = new System.Drawing.Size(215, 21);
            this.TBTipoE.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(15, 131);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(35, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Topico:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Tipo:";
            // 
            // TBDescripcionE
            // 
            this.TBDescripcionE.Location = new System.Drawing.Point(82, 161);
            this.TBDescripcionE.Multiline = true;
            this.TBDescripcionE.Name = "TBDescripcionE";
            this.TBDescripcionE.Size = new System.Drawing.Size(313, 110);
            this.TBDescripcionE.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 161);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Descripcion:";
            // 
            // TBTituloE
            // 
            this.TBTituloE.Location = new System.Drawing.Point(82, 48);
            this.TBTituloE.Name = "TBTituloE";
            this.TBTituloE.Size = new System.Drawing.Size(313, 21);
            this.TBTituloE.TabIndex = 1;
            // 
            // LBLTitulo
            // 
            this.LBLTitulo.Location = new System.Drawing.Point(15, 51);
            this.LBLTitulo.Name = "LBLTitulo";
            this.LBLTitulo.Size = new System.Drawing.Size(30, 13);
            this.LBLTitulo.TabIndex = 0;
            this.LBLTitulo.Text = "Titulo:";
            // 
            // GCOrganizador
            // 
            this.GCOrganizador.Controls.Add(this.CBOrganizador);
            this.GCOrganizador.Controls.Add(this.SBOrganizador);
            this.GCOrganizador.Controls.Add(this.LBLNombreSalon);
            this.GCOrganizador.Controls.Add(this.labelControl9);
            this.GCOrganizador.Controls.Add(this.TBCorreoO);
            this.GCOrganizador.Controls.Add(this.labelControl8);
            this.GCOrganizador.Controls.Add(this.TBDescripcionO);
            this.GCOrganizador.Controls.Add(this.labelControl7);
            this.GCOrganizador.Controls.Add(this.labelControl6);
            this.GCOrganizador.Dock = System.Windows.Forms.DockStyle.Top;
            this.GCOrganizador.Location = new System.Drawing.Point(654, 49);
            this.GCOrganizador.Name = "GCOrganizador";
            this.GCOrganizador.Size = new System.Drawing.Size(374, 239);
            this.GCOrganizador.TabIndex = 8;
            this.GCOrganizador.Text = "Organizador";
            // 
            // LBLNombreSalon
            // 
            this.LBLNombreSalon.Location = new System.Drawing.Point(102, 211);
            this.LBLNombreSalon.Name = "LBLNombreSalon";
            this.LBLNombreSalon.Size = new System.Drawing.Size(110, 13);
            this.LBLNombreSalon.TabIndex = 15;
            this.LBLNombreSalon.Text = "- - - -Nombre Salon ----";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(14, 211);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(82, 13);
            this.labelControl9.TabIndex = 14;
            this.labelControl9.Text = "Solicitud al salon:";
            // 
            // TBCorreoO
            // 
            this.TBCorreoO.Location = new System.Drawing.Point(91, 167);
            this.TBCorreoO.Name = "TBCorreoO";
            this.TBCorreoO.ReadOnly = true;
            this.TBCorreoO.Size = new System.Drawing.Size(232, 21);
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
            this.TBDescripcionO.ReadOnly = true;
            this.TBDescripcionO.Size = new System.Drawing.Size(232, 59);
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
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(14, 37);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(41, 13);
            this.labelControl6.TabIndex = 9;
            this.labelControl6.Text = "Nombre:";
            // 
            // SBActualizar
            // 
            this.SBActualizar.Image = ((System.Drawing.Image)(resources.GetObject("SBActualizar.Image")));
            this.SBActualizar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBActualizar.Location = new System.Drawing.Point(791, 371);
            this.SBActualizar.Name = "SBActualizar";
            this.SBActualizar.Size = new System.Drawing.Size(75, 59);
            this.SBActualizar.TabIndex = 9;
            this.SBActualizar.Text = "Actualizar";
            this.SBActualizar.Click += new System.EventHandler(this.SBActualizar_Click);
            // 
            // SBOrganizador
            // 
            this.SBOrganizador.Image = ((System.Drawing.Image)(resources.GetObject("SBOrganizador.Image")));
            this.SBOrganizador.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SBOrganizador.Location = new System.Drawing.Point(326, 32);
            this.SBOrganizador.Name = "SBOrganizador";
            this.SBOrganizador.Size = new System.Drawing.Size(39, 23);
            this.SBOrganizador.TabIndex = 18;
            this.SBOrganizador.Click += new System.EventHandler(this.SBOrganizador_Click);
            // 
            // CBOrganizador
            // 
            this.CBOrganizador.FormattingEnabled = true;
            this.CBOrganizador.Location = new System.Drawing.Point(88, 34);
            this.CBOrganizador.Name = "CBOrganizador";
            this.CBOrganizador.Size = new System.Drawing.Size(232, 21);
            this.CBOrganizador.TabIndex = 19;
            this.CBOrganizador.SelectedValueChanged += new System.EventHandler(this.CBOrganizador_SelectedValueChanged);
            // 
            // ActualizarSolicitudesF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 519);
            this.Controls.Add(this.SBActualizar);
            this.Controls.Add(this.GCOrganizador);
            this.Controls.Add(this.GCDetallesEvento);
            this.Controls.Add(this.GCSalon);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActualizarSolicitudesF";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Actualizar Solicitudes";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCSalon)).EndInit();
            this.GCSalon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCSalones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCDetallesEvento)).EndInit();
            this.GCDetallesEvento.ResumeLayout(false);
            this.GCDetallesEvento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditTFinal.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditTFinal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditTInicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditTInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCOrganizador)).EndInit();
            this.GCOrganizador.ResumeLayout(false);
            this.GCOrganizador.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.GroupControl GCSalon;
        private DevExpress.XtraGrid.GridControl GCSalones;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl GCDetallesEvento;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.DateEdit DateEditTFinal;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit DateEditTInicio;
        private System.Windows.Forms.TextBox TBTopicoE;
        private System.Windows.Forms.TextBox TBTipoE;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.TextBox TBDescripcionE;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox TBTituloE;
        private DevExpress.XtraEditors.LabelControl LBLTitulo;
        private DevExpress.XtraEditors.GroupControl GCOrganizador;
        private DevExpress.XtraEditors.LabelControl LBLNombreSalon;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private System.Windows.Forms.TextBox TBCorreoO;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.TextBox TBDescripcionO;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton SBActualizar;
        private DevExpress.XtraEditors.SimpleButton SBOrganizador;
        private System.Windows.Forms.ComboBox CBOrganizador;
    }
}