﻿namespace KlasyfikacjaMiodu.SideMenu
{
    /// <summary>
    ///     Klasa odpowiedzialna za boczny panel.
    /// </summary>
    partial class SidePanel
    {

        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///     Funkcja czyszcząca wykorzystane zasoby.
        /// </summary>
        /// <param name="disposing">Prawda jeśli dane powinny być wyczyszczone.</param>
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
        /// Funkcja inicjująca komponenty bocznego panelu.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orientationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doLewejToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doPrawejToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(1, 2, 0, 2);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.orientationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(1, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(224, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.addToolStripMenuItem.Text = "Dodaj";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.editToolStripMenuItem.Text = "Edytuj";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.deleteToolStripMenuItem.Text = "Usuń";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // orientationToolStripMenuItem
            // 
            this.orientationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verticalToolStripMenuItem,
            this.horizontalToolStripMenuItem});
            this.orientationToolStripMenuItem.Name = "orientationToolStripMenuItem";
            this.orientationToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.orientationToolStripMenuItem.Text = "Widok";
            this.orientationToolStripMenuItem.Click += new System.EventHandler(this.orientationToolStripMenuItem_Click);
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doLewejToolStripMenuItem,
            this.doPrawejToolStripMenuItem});
            this.verticalToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.verticalToolStripMenuItem.Text = "Wyrównaj listę";
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
            // 
            // doLewejToolStripMenuItem
            // 
            this.doLewejToolStripMenuItem.Name = "doLewejToolStripMenuItem";
            this.doLewejToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.doLewejToolStripMenuItem.Text = "Do lewej";
            this.doLewejToolStripMenuItem.Click += new System.EventHandler(this.toLeftToolStripMenuItem_Click);
            // 
            // doPrawejToolStripMenuItem
            // 
            this.doPrawejToolStripMenuItem.Name = "doPrawejToolStripMenuItem";
            this.doPrawejToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.doPrawejToolStripMenuItem.Text = "Do prawej";
            this.doPrawejToolStripMenuItem.Click += new System.EventHandler(this.toRightToolStripMenuItem_Click);
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.horizontalToolStripMenuItem.Text = "Lista pozioma";
            this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 337);
            this.panel1.TabIndex = 1;
            this.panel1.WrapContents = false;
            // 
            // SidePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(224, 361);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SidePanel";
            this.ShowInTaskbar = false;
            this.Text = "Lista pyłków";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orientationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel panel1;
        private System.Windows.Forms.ToolStripMenuItem doLewejToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doPrawejToolStripMenuItem;
    }
}