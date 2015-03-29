namespace KlasyfikacjaMiodu
{
    partial class SidePanel
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dodajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edytujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuńToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orientacjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pionowaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poziomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(1, 2, 0, 2);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajToolStripMenuItem,
            this.edytujToolStripMenuItem,
            this.usuńToolStripMenuItem,
            this.orientacjaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(1, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(233, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dodajToolStripMenuItem
            // 
            this.dodajToolStripMenuItem.Name = "dodajToolStripMenuItem";
            this.dodajToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.dodajToolStripMenuItem.Text = "Dodaj";
            this.dodajToolStripMenuItem.Click += new System.EventHandler(this.dodajToolStripMenuItem_Click);
            // 
            // edytujToolStripMenuItem
            // 
            this.edytujToolStripMenuItem.Name = "edytujToolStripMenuItem";
            this.edytujToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.edytujToolStripMenuItem.Text = "Edytuj";
            this.edytujToolStripMenuItem.Click += new System.EventHandler(this.edytujToolStripMenuItem_Click);
            // 
            // usuńToolStripMenuItem
            // 
            this.usuńToolStripMenuItem.Name = "usuńToolStripMenuItem";
            this.usuńToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.usuńToolStripMenuItem.Text = "Usuń";
            this.usuńToolStripMenuItem.Click += new System.EventHandler(this.usuńToolStripMenuItem_Click);
            // 
            // orientacjaToolStripMenuItem
            // 
            this.orientacjaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pionowaToolStripMenuItem,
            this.poziomaToolStripMenuItem});
            this.orientacjaToolStripMenuItem.Name = "orientacjaToolStripMenuItem";
            this.orientacjaToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.orientacjaToolStripMenuItem.Text = "Orientacja";
            // 
            // pionowaToolStripMenuItem
            // 
            this.pionowaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pionowaToolStripMenuItem.Name = "pionowaToolStripMenuItem";
            this.pionowaToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.pionowaToolStripMenuItem.Text = "Pionowa";
            this.pionowaToolStripMenuItem.Click += new System.EventHandler(this.pionowaToolStripMenuItem_Click);
            // 
            // poziomaToolStripMenuItem
            // 
            this.poziomaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.poziomaToolStripMenuItem.Name = "poziomaToolStripMenuItem";
            this.poziomaToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.poziomaToolStripMenuItem.Text = "Pozioma";
            this.poziomaToolStripMenuItem.Click += new System.EventHandler(this.poziomaToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 300);
            this.panel1.TabIndex = 1;
            // 
            // SidePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(233, 324);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SidePanel";
            this.ShowInTaskbar = false;
            this.Text = "SidePanel";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dodajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edytujToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuńToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel panel1;
        private System.Windows.Forms.ToolStripMenuItem orientacjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pionowaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poziomaToolStripMenuItem;
    }
}