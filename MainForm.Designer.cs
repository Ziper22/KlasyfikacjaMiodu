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
            this.workTimeDesc = new System.Windows.Forms.Label();
            this.workTime = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.scaleDesc = new System.Windows.Forms.Label();
            this.scale = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.honeyTypeDesc = new System.Windows.Forms.Label();
            this.honeyType = new System.Windows.Forms.Label();
            this.imagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
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
            this.bottomPanel.Controls.Add(this.flowLayoutPanel3);
            this.bottomPanel.Controls.Add(this.flowLayoutPanel2);
            this.bottomPanel.Controls.Add(this.flowLayoutPanel1);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 409);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(784, 32);
            this.bottomPanel.TabIndex = 1;
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
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.scaleDesc);
            this.flowLayoutPanel2.Controls.Add(this.scale);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(106, 32);
            this.flowLayoutPanel2.TabIndex = 4;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // scaleDesc
            // 
            this.scaleDesc.AutoSize = true;
            this.scaleDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.scaleDesc.Location = new System.Drawing.Point(3, 6);
            this.scaleDesc.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.scaleDesc.Name = "scaleDesc";
            this.scaleDesc.Size = new System.Drawing.Size(53, 20);
            this.scaleDesc.TabIndex = 0;
            this.scaleDesc.Text = "Skala:";
            // 
            // scale
            // 
            this.scale.AutoSize = true;
            this.scale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.scale.Location = new System.Drawing.Point(56, 6);
            this.scale.Margin = new System.Windows.Forms.Padding(0);
            this.scale.Name = "scale";
            this.scale.Size = new System.Drawing.Size(50, 20);
            this.scale.TabIndex = 1;
            this.scale.Text = "100%";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.imagePanel);
            this.MinimumSize = new System.Drawing.Size(400, 240);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.imagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Panel imagePanel;
        private Panel bottomPanel;
        private Label workTimeDesc;
        private Label workTime;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label scaleDesc;
        private Label scale;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label honeyTypeDesc;
        private Label honeyType;
    }
}

