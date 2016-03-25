namespace Resa_Pro.Formularios
{
    partial class AgregarSolicitud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarSolicitud));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.GCSalones = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GCSalon = new DevExpress.XtraEditors.GroupControl();
            this.GCDetallesEvento = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.DateEditTFinal = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.DateEditTInicio = new DevExpress.XtraEditors.DateEdit();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LBLTitulo = new DevExpress.XtraEditors.LabelControl();
            this.GCOrganizador = new DevExpress.XtraEditors.GroupControl();
            this.LBLNombreSalon = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.SBGuardar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCSalones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCSalon)).BeginInit();
            this.GCSalon.SuspendLayout();
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
            this.ribbon.Size = new System.Drawing.Size(1000, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 509);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1000, 27);
            // 
            // GCSalones
            // 
            this.GCSalones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCSalones.Location = new System.Drawing.Point(2, 20);
            this.GCSalones.MainView = this.gridView1;
            this.GCSalones.MenuManager = this.ribbon;
            this.GCSalones.Name = "GCSalones";
            this.GCSalones.Size = new System.Drawing.Size(240, 438);
            this.GCSalones.TabIndex = 2;
            this.GCSalones.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            // GCSalon
            // 
            this.GCSalon.Controls.Add(this.GCSalones);
            this.GCSalon.Dock = System.Windows.Forms.DockStyle.Left;
            this.GCSalon.Location = new System.Drawing.Point(0, 49);
            this.GCSalon.Name = "GCSalon";
            this.GCSalon.Size = new System.Drawing.Size(244, 460);
            this.GCSalon.TabIndex = 3;
            this.GCSalon.Text = "Salon";
            // 
            // GCDetallesEvento
            // 
            this.GCDetallesEvento.Controls.Add(this.groupControl1);
            this.GCDetallesEvento.Controls.Add(this.textBox4);
            this.GCDetallesEvento.Controls.Add(this.textBox3);
            this.GCDetallesEvento.Controls.Add(this.labelControl3);
            this.GCDetallesEvento.Controls.Add(this.labelControl2);
            this.GCDetallesEvento.Controls.Add(this.textBox2);
            this.GCDetallesEvento.Controls.Add(this.labelControl1);
            this.GCDetallesEvento.Controls.Add(this.textBox1);
            this.GCDetallesEvento.Controls.Add(this.LBLTitulo);
            this.GCDetallesEvento.Dock = System.Windows.Forms.DockStyle.Left;
            this.GCDetallesEvento.Location = new System.Drawing.Point(244, 49);
            this.GCDetallesEvento.Name = "GCDetallesEvento";
            this.GCDetallesEvento.Size = new System.Drawing.Size(410, 460);
            this.GCDetallesEvento.TabIndex = 4;
            this.GCDetallesEvento.Text = "Detalles del evento";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.DateEditTFinal);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.DateEditTInicio);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(2, 293);
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
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(13, 109);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(79, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Tiempo de inicio:";
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
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(82, 123);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(215, 21);
            this.textBox4.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(82, 85);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(215, 21);
            this.textBox3.TabIndex = 6;
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
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(82, 161);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(313, 110);
            this.textBox2.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 161);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Descripcion:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(82, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(313, 21);
            this.textBox1.TabIndex = 1;
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
            this.GCOrganizador.Controls.Add(this.LBLNombreSalon);
            this.GCOrganizador.Controls.Add(this.labelControl9);
            this.GCOrganizador.Controls.Add(this.textBox7);
            this.GCOrganizador.Controls.Add(this.labelControl8);
            this.GCOrganizador.Controls.Add(this.textBox6);
            this.GCOrganizador.Controls.Add(this.labelControl7);
            this.GCOrganizador.Controls.Add(this.textBox5);
            this.GCOrganizador.Controls.Add(this.labelControl6);
            this.GCOrganizador.Dock = System.Windows.Forms.DockStyle.Top;
            this.GCOrganizador.Location = new System.Drawing.Point(654, 49);
            this.GCOrganizador.Name = "GCOrganizador";
            this.GCOrganizador.Size = new System.Drawing.Size(346, 239);
            this.GCOrganizador.TabIndex = 7;
            this.GCOrganizador.Text = "Organizador";
            this.GCOrganizador.Paint += new System.Windows.Forms.PaintEventHandler(this.GCOrganizador_Paint);
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
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(91, 167);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(232, 21);
            this.textBox7.TabIndex = 13;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(14, 175);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(37, 13);
            this.labelControl8.TabIndex = 12;
            this.labelControl8.Text = "Correo:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(91, 85);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(219, 59);
            this.textBox6.TabIndex = 11;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(14, 93);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(58, 13);
            this.labelControl7.TabIndex = 10;
            this.labelControl7.Text = "Descripcion:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(91, 37);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(219, 21);
            this.textBox5.TabIndex = 9;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(14, 37);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(41, 13);
            this.labelControl6.TabIndex = 9;
            this.labelControl6.Text = "Nombre:";
            // 
            // SBGuardar
            // 
            this.SBGuardar.Image = ((System.Drawing.Image)(resources.GetObject("SBGuardar.Image")));
            this.SBGuardar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.SBGuardar.Location = new System.Drawing.Point(801, 347);
            this.SBGuardar.Name = "SBGuardar";
            this.SBGuardar.Size = new System.Drawing.Size(75, 60);
            this.SBGuardar.TabIndex = 8;
            this.SBGuardar.Text = "Guardar";
            // 
            // AgregarSolicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 536);
            this.Controls.Add(this.SBGuardar);
            this.Controls.Add(this.GCOrganizador);
            this.Controls.Add(this.GCDetallesEvento);
            this.Controls.Add(this.GCSalon);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarSolicitud";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Agregar una solicitud";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCSalones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCSalon)).EndInit();
            this.GCSalon.ResumeLayout(false);
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
        private DevExpress.XtraGrid.GridControl GCSalones;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl GCSalon;
        private DevExpress.XtraEditors.GroupControl GCDetallesEvento;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.TextBox textBox2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraEditors.LabelControl LBLTitulo;
        private DevExpress.XtraEditors.DateEdit DateEditTInicio;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.DateEdit DateEditTFinal;
        private DevExpress.XtraEditors.GroupControl GCOrganizador;
        private System.Windows.Forms.TextBox textBox7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.TextBox textBox6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.Windows.Forms.TextBox textBox5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton SBGuardar;
        private DevExpress.XtraEditors.LabelControl LBLNombreSalon;
        private DevExpress.XtraEditors.LabelControl labelControl9;
    }
}