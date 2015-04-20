using System.Security.AccessControl;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda wsparcia projektanta - nie należy modyfikować
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.viewPanel = new System.Windows.Forms.Panel();
            this.pollensImage = new System.Windows.Forms.PictureBox();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.scaleDesc = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.scale = new System.Windows.Forms.NumericUpDown();
            this.percentDesc = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.honeyTypeDesc = new System.Windows.Forms.Label();
            this.honeyType = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.workTimeDesc = new System.Windows.Forms.Label();
            this.workTime = new System.Windows.Forms.Label();
            this.topMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProjectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.undoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.showPanelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mousePostion = new System.Windows.Forms.Label();
            this.viewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pollensImage)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scale)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.topMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewPanel
            // 
            this.viewPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.viewPanel.BackColor = System.Drawing.Color.Transparent;
            this.viewPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.viewPanel.Controls.Add(this.pollensImage);
            this.viewPanel.Location = new System.Drawing.Point(51, 73);
            this.viewPanel.Margin = new System.Windows.Forms.Padding(0);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(370, 243);
            this.viewPanel.TabIndex = 0;
            // 
            // pollensImage
            // 
            this.pollensImage.BackColor = System.Drawing.SystemColors.Control;
            this.pollensImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pollensImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pollensImage.Enabled = false;
            this.pollensImage.Image = global::KlasyfikacjaMiodu.Properties.Resources.honeyPollens;
            this.pollensImage.Location = new System.Drawing.Point(0, 0);
            this.pollensImage.Margin = new System.Windows.Forms.Padding(0);
            this.pollensImage.Name = "pollensImage";
            this.pollensImage.Size = new System.Drawing.Size(370, 243);
            this.pollensImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pollensImage.TabIndex = 0;
            this.pollensImage.TabStop = false;
            // 
            // bottomPanel
            // 
            this.bottomPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bottomPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bottomPanel.Controls.Add(this.tableLayoutPanel1);
            this.bottomPanel.Controls.Add(this.flowLayoutPanel3);
            this.bottomPanel.Controls.Add(this.flowLayoutPanel1);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 410);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(784, 32);
            this.bottomPanel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel1.Controls.Add(this.scaleDesc, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(170, 32);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // scaleDesc
            // 
            this.scaleDesc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.scaleDesc.AutoSize = true;
            this.scaleDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.scaleDesc.Location = new System.Drawing.Point(3, 6);
            this.scaleDesc.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.scaleDesc.Name = "scaleDesc";
            this.scaleDesc.Size = new System.Drawing.Size(53, 20);
            this.scaleDesc.TabIndex = 0;
            this.scaleDesc.Text = "Skala:";
            this.scaleDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.scale);
            this.flowLayoutPanel2.Controls.Add(this.percentDesc);
            this.flowLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(60, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(97, 26);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // scale
            // 
            this.scale.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.scale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.scale.Location = new System.Drawing.Point(3, 3);
            this.scale.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.scale.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.scale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scale.Name = "scale";
            this.scale.Size = new System.Drawing.Size(51, 22);
            this.scale.TabIndex = 3;
            this.scale.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // percentDesc
            // 
            this.percentDesc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.percentDesc.AutoSize = true;
            this.percentDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.percentDesc.Location = new System.Drawing.Point(54, 6);
            this.percentDesc.Margin = new System.Windows.Forms.Padding(0);
            this.percentDesc.Name = "percentDesc";
            this.percentDesc.Size = new System.Drawing.Size(20, 16);
            this.percentDesc.TabIndex = 1;
            this.percentDesc.Text = "%";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.Controls.Add(this.honeyTypeDesc);
            this.flowLayoutPanel3.Controls.Add(this.honeyType);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(289, 6);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(205, 20);
            this.flowLayoutPanel3.TabIndex = 5;
            this.flowLayoutPanel3.WrapContents = false;
            // 
            // honeyTypeDesc
            // 
            this.honeyTypeDesc.AutoSize = true;
            this.honeyTypeDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.honeyTypeDesc.Location = new System.Drawing.Point(0, 0);
            this.honeyTypeDesc.Margin = new System.Windows.Forms.Padding(0);
            this.honeyTypeDesc.Name = "honeyTypeDesc";
            this.honeyTypeDesc.Size = new System.Drawing.Size(52, 20);
            this.honeyTypeDesc.TabIndex = 0;
            this.honeyTypeDesc.Text = "Miód:";
            // 
            // honeyType
            // 
            this.honeyType.AutoSize = true;
            this.honeyType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.honeyType.Location = new System.Drawing.Point(52, 0);
            this.honeyType.Margin = new System.Windows.Forms.Padding(0);
            this.honeyType.Name = "honeyType";
            this.honeyType.Size = new System.Drawing.Size(153, 20);
            this.honeyType.TabIndex = 1;
            this.honeyType.Text = "Niesklasyfikowany";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.workTimeDesc);
            this.flowLayoutPanel1.Controls.Add(this.workTime);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(619, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(165, 32);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // workTimeDesc
            // 
            this.workTimeDesc.AutoSize = true;
            this.workTimeDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.workTimeDesc.Location = new System.Drawing.Point(0, 6);
            this.workTimeDesc.Margin = new System.Windows.Forms.Padding(0);
            this.workTimeDesc.Name = "workTimeDesc";
            this.workTimeDesc.Size = new System.Drawing.Size(91, 20);
            this.workTimeDesc.TabIndex = 0;
            this.workTimeDesc.Text = "Czas pracy:";
            // 
            // workTime
            // 
            this.workTime.AutoSize = true;
            this.workTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.workTime.Location = new System.Drawing.Point(91, 6);
            this.workTime.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.workTime.Name = "workTime";
            this.workTime.Size = new System.Drawing.Size(71, 20);
            this.workTime.TabIndex = 1;
            this.workTime.Text = "00:00:00";
            // 
            // topMenu
            // 
            this.topMenu.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.viewMenu});
            this.topMenu.Location = new System.Drawing.Point(0, 0);
            this.topMenu.Name = "topMenu";
            this.topMenu.Size = new System.Drawing.Size(784, 29);
            this.topMenu.TabIndex = 2;
            this.topMenu.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectMenuItem,
            this.saveProjectMenuItem,
            this.loadProjectMenuItem,
            this.toolStripSeparator1,
            this.loadImageMenuItem,
            this.toolStripSeparator2,
            this.quitMenuItem});
            this.fileMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(47, 25);
            this.fileMenu.Text = "Plik";
            // 
            // newProjectMenuItem
            // 
            this.newProjectMenuItem.Name = "newProjectMenuItem";
            this.newProjectMenuItem.Size = new System.Drawing.Size(194, 26);
            this.newProjectMenuItem.Text = "Nowy";
            // 
            // saveProjectMenuItem
            // 
            this.saveProjectMenuItem.Name = "saveProjectMenuItem";
            this.saveProjectMenuItem.Size = new System.Drawing.Size(194, 26);
            this.saveProjectMenuItem.Text = "Zapisz";
            // 
            // loadProjectMenuItem
            // 
            this.loadProjectMenuItem.Name = "loadProjectMenuItem";
            this.loadProjectMenuItem.Size = new System.Drawing.Size(194, 26);
            this.loadProjectMenuItem.Text = "Wczytaj";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(191, 6);
            // 
            // loadImageMenuItem
            // 
            this.loadImageMenuItem.Name = "loadImageMenuItem";
            this.loadImageMenuItem.Size = new System.Drawing.Size(194, 26);
            this.loadImageMenuItem.Text = "Wczytaj zdjęcie...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(191, 6);
            // 
            // quitMenuItem
            // 
            this.quitMenuItem.Name = "quitMenuItem";
            this.quitMenuItem.Size = new System.Drawing.Size(194, 26);
            this.quitMenuItem.Text = "Wyjście";
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoMenuItem,
            this.redoMenuItem});
            this.editMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(66, 25);
            this.editMenu.Text = "Edycja";
            // 
            // undoMenuItem
            // 
            this.undoMenuItem.Name = "undoMenuItem";
            this.undoMenuItem.Size = new System.Drawing.Size(203, 26);
            this.undoMenuItem.Text = "Cofnij (Ctrl+Z)";
            // 
            // redoMenuItem
            // 
            this.redoMenuItem.Name = "redoMenuItem";
            this.redoMenuItem.Size = new System.Drawing.Size(203, 26);
            this.redoMenuItem.Text = "Przywróć (Ctrl+Y)";
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPanelMenuItem});
            this.viewMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(67, 25);
            this.viewMenu.Text = "Widok";
            // 
            // showPanelMenuItem
            // 
            this.showPanelMenuItem.Name = "showPanelMenuItem";
            this.showPanelMenuItem.Size = new System.Drawing.Size(152, 26);
            this.showPanelMenuItem.Text = "Ukryj listę";
            // 
            // mousePostion
            // 
            this.mousePostion.AutoSize = true;
            this.mousePostion.Location = new System.Drawing.Point(695, 381);
            this.mousePostion.Name = "mousePostion";
            this.mousePostion.Size = new System.Drawing.Size(77, 13);
            this.mousePostion.TabIndex = 3;
            this.mousePostion.Text = "mouse position";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.mousePostion);
            this.Controls.Add(this.topMenu);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.viewPanel);
            this.MainMenuStrip = this.topMenu;
            this.MinimumSize = new System.Drawing.Size(400, 240);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.viewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pollensImage)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scale)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pollensImage;
        private Panel viewPanel;
        private Panel bottomPanel;
        private Label workTimeDesc;
        private Label workTime;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label scaleDesc;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label honeyTypeDesc;
        private Label honeyType;
        private TableLayoutPanel tableLayoutPanel1;
        private MenuStrip topMenu;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem newProjectMenuItem;
        private ToolStripMenuItem saveProjectMenuItem;
        private ToolStripMenuItem loadProjectMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem loadImageMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem quitMenuItem;
        private ToolStripMenuItem editMenu;
        private ToolStripMenuItem undoMenuItem;
        private ToolStripMenuItem redoMenuItem;
        private ToolStripMenuItem viewMenu;
        private ToolStripMenuItem showPanelMenuItem;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label percentDesc;
        private NumericUpDown scale;
        private Label mousePostion;
    }
}

