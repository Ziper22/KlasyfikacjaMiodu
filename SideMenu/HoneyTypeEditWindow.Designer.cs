namespace KlasyfikacjaMiodu.SideMenu
{
    partial class HoneyTypeEditWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chooseColorButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.specimenPictureBox = new System.Windows.Forms.PictureBox();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.percentNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.specimenPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.percentNumericUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(70, 6);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kolor:";
            // 
            // chooseColorButton
            // 
            this.chooseColorButton.Location = new System.Drawing.Point(70, 84);
            this.chooseColorButton.Name = "chooseColorButton";
            this.chooseColorButton.Size = new System.Drawing.Size(100, 23);
            this.chooseColorButton.TabIndex = 4;
            this.chooseColorButton.Text = "Wybierz kolor";
            this.chooseColorButton.UseVisualStyleBackColor = true;
            this.chooseColorButton.Click += new System.EventHandler(this.chooseColorButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(127, 123);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(40, 123);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // specimenPictureBox
            // 
            this.specimenPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.specimenPictureBox.Location = new System.Drawing.Point(176, 84);
            this.specimenPictureBox.Name = "specimenPictureBox";
            this.specimenPictureBox.Size = new System.Drawing.Size(26, 23);
            this.specimenPictureBox.TabIndex = 8;
            this.specimenPictureBox.TabStop = false;
            // 
            // valueTextBox
            // 
            this.valueTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.valueTextBox.Location = new System.Drawing.Point(70, 32);
            this.valueTextBox.MaxLength = 4;
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(45, 20);
            this.valueTextBox.TabIndex = 2;
            this.valueTextBox.Text = "10";
            this.valueTextBox.TextChanged += new System.EventHandler(this.valueTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Ilość:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Procent:";
            // 
            // percentNumericUpDown
            // 
            this.percentNumericUpDown.Location = new System.Drawing.Point(70, 59);
            this.percentNumericUpDown.Name = "percentNumericUpDown";
            this.percentNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.percentNumericUpDown.Size = new System.Drawing.Size(45, 20);
            this.percentNumericUpDown.TabIndex = 3;
            this.percentNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.percentNumericUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.percentNumericUpDown_KeyUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.percentNumericUpDown);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.valueTextBox);
            this.panel1.Controls.Add(this.specimenPictureBox);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Controls.Add(this.chooseColorButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.nameTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 173);
            this.panel1.TabIndex = 0;
            // 
            // HoneyTypeEditWindow
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(223, 173);
            this.Controls.Add(this.panel1);
            this.Name = "HoneyTypeEditWindow";
            this.Text = "AddEditWindow";
            ((System.ComponentModel.ISupportInitialize)(this.specimenPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.percentNumericUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button chooseColorButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.PictureBox specimenPictureBox;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown percentNumericUpDown;
        private System.Windows.Forms.Panel panel1;

    }
}