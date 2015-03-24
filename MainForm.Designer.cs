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
            this.imagePanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.scaleDesc = new System.Windows.Forms.Label();
<<<<<<< HEAD
=======
            this.scale = new System.Windows.Forms.ComboBox();
>>>>>>> origin/master
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
<<<<<<< HEAD
            this.percentDesc = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.scale = new System.Windows.Forms.NumericUpDown();
=======
>>>>>>> origin/master
            this.imagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.topMenu.SuspendLayout();
<<<<<<< HEAD
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scale)).BeginInit();
=======
>>>>>>> origin/master
            this.SuspendLayout();
            // 
            // imagePanel
            // 
            this.imagePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.imagePanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.imagePanel.Controls.Add(this.pictureBox1);
            this.imagePanel.Location = new System.Drawing.Point(51, 73);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(370, 243);
            this.imagePanel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = global::KlasyfikacjaMiodu.Properties.Resources.ulan;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(370, 243);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
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
<<<<<<< HEAD
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Controls.Add(this.scaleDesc, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
=======
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.scaleDesc, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.scale, 1, 0);
>>>>>>> origin/master
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
<<<<<<< HEAD
            this.tableLayoutPanel1.Size = new System.Drawing.Size(170, 32);
=======
            this.tableLayoutPanel1.Size = new System.Drawing.Size(154, 32);
>>>>>>> origin/master
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
<<<<<<< HEAD
=======
            // 
            // scale
            // 
            this.scale.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.scale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.scale.FormattingEnabled = true;
            this.scale.Items.AddRange(new object[] {
            "10%",
            "25%",
            "50%",
            "75%",
            "100%",
            "125%",
            "150%",
            "200%",
            "400%",
            "800%"});
            this.scale.Location = new System.Drawing.Point(64, 4);
            this.scale.Name = "scale";
            this.scale.Size = new System.Drawing.Size(83, 24);
            this.scale.TabIndex = 1;
>>>>>>> origin/master
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
<<<<<<< HEAD
            this.topMenu.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
=======
>>>>>>> origin/master
            this.topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.viewMenu});
            this.topMenu.Location = new System.Drawing.Point(0, 0);
            this.topMenu.Name = "topMenu";
<<<<<<< HEAD
            this.topMenu.Size = new System.Drawing.Size(784, 29);
=======
            this.topMenu.Size = new System.Drawing.Size(784, 24);
>>>>>>> origin/master
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
<<<<<<< HEAD
            this.fileMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(47, 25);
=======
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(38, 20);
>>>>>>> origin/master
            this.fileMenu.Text = "Plik";
            // 
            // newProjectMenuItem
            // 
            this.newProjectMenuItem.Name = "newProjectMenuItem";
<<<<<<< HEAD
            this.newProjectMenuItem.Size = new System.Drawing.Size(236, 26);
=======
            this.newProjectMenuItem.Size = new System.Drawing.Size(191, 22);
>>>>>>> origin/master
            this.newProjectMenuItem.Text = "Nowy projekt";
            // 
            // saveProjectMenuItem
            // 
            this.saveProjectMenuItem.Name = "saveProjectMenuItem";
<<<<<<< HEAD
            this.saveProjectMenuItem.Size = new System.Drawing.Size(236, 26);
=======
            this.saveProjectMenuItem.Size = new System.Drawing.Size(191, 22);
>>>>>>> origin/master
            this.saveProjectMenuItem.Text = "Zapisz Projekt (Ctrl+S)";
            // 
            // loadProjectMenuItem
            // 
            this.loadProjectMenuItem.Name = "loadProjectMenuItem";
<<<<<<< HEAD
            this.loadProjectMenuItem.Size = new System.Drawing.Size(236, 26);
=======
            this.loadProjectMenuItem.Size = new System.Drawing.Size(191, 22);
>>>>>>> origin/master
            this.loadProjectMenuItem.Text = "Wczytaj projekt...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
<<<<<<< HEAD
            this.toolStripSeparator1.Size = new System.Drawing.Size(233, 6);
=======
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
>>>>>>> origin/master
            // 
            // loadImageMenuItem
            // 
            this.loadImageMenuItem.Name = "loadImageMenuItem";
<<<<<<< HEAD
            this.loadImageMenuItem.Size = new System.Drawing.Size(236, 26);
=======
            this.loadImageMenuItem.Size = new System.Drawing.Size(191, 22);
>>>>>>> origin/master
            this.loadImageMenuItem.Text = "Wczytaj zdjęcie...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
<<<<<<< HEAD
            this.toolStripSeparator2.Size = new System.Drawing.Size(233, 6);
=======
            this.toolStripSeparator2.Size = new System.Drawing.Size(188, 6);
>>>>>>> origin/master
            // 
            // quitMenuItem
            // 
            this.quitMenuItem.Name = "quitMenuItem";
<<<<<<< HEAD
            this.quitMenuItem.Size = new System.Drawing.Size(236, 26);
=======
            this.quitMenuItem.Size = new System.Drawing.Size(191, 22);
>>>>>>> origin/master
            this.quitMenuItem.Text = "Wyjście";
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoMenuItem,
            this.redoMenuItem});
<<<<<<< HEAD
            this.editMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(66, 25);
=======
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(53, 20);
>>>>>>> origin/master
            this.editMenu.Text = "Edycja";
            // 
            // undoMenuItem
            // 
            this.undoMenuItem.Name = "undoMenuItem";
<<<<<<< HEAD
            this.undoMenuItem.Size = new System.Drawing.Size(180, 26);
=======
            this.undoMenuItem.Size = new System.Drawing.Size(151, 22);
>>>>>>> origin/master
            this.undoMenuItem.Text = "Cofnij (Ctrl+Z)";
            // 
            // redoMenuItem
            // 
            this.redoMenuItem.Name = "redoMenuItem";
<<<<<<< HEAD
            this.redoMenuItem.Size = new System.Drawing.Size(180, 26);
=======
            this.redoMenuItem.Size = new System.Drawing.Size(151, 22);
>>>>>>> origin/master
            this.redoMenuItem.Text = "Dalej (Ctrl+Y)";
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPanelMenuItem});
<<<<<<< HEAD
            this.viewMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(67, 25);
=======
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(53, 20);
>>>>>>> origin/master
            this.viewMenu.Text = "Widok";
            // 
            // showPanelMenuItem
            // 
            this.showPanelMenuItem.Name = "showPanelMenuItem";
<<<<<<< HEAD
            this.showPanelMenuItem.Size = new System.Drawing.Size(222, 26);
            this.showPanelMenuItem.Text = "Pokaż panel (Ctrl+P)";
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
=======
            this.showPanelMenuItem.Size = new System.Drawing.Size(182, 22);
            this.showPanelMenuItem.Text = "Pokaż panel (Ctrl+P)";
            // 
>>>>>>> origin/master
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.topMenu);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.imagePanel);
<<<<<<< HEAD
=======
            this.Controls.Add(this.topMenu);
>>>>>>> origin/master
            this.MainMenuStrip = this.topMenu;
            this.MinimumSize = new System.Drawing.Size(400, 240);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.imagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
<<<<<<< HEAD
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scale)).EndInit();
=======
>>>>>>> origin/master
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Panel imagePanel;
        private Panel bottomPanel;
        private Label workTimeDesc;
        private Label workTime;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label scaleDesc;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label honeyTypeDesc;
        private Label honeyType;
        private TableLayoutPanel tableLayoutPanel1;
<<<<<<< HEAD
=======
        private ComboBox scale;
>>>>>>> origin/master
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
<<<<<<< HEAD
        private FlowLayoutPanel flowLayoutPanel2;
        private Label percentDesc;
        private NumericUpDown scale;
=======
>>>>>>> origin/master
    }
}

