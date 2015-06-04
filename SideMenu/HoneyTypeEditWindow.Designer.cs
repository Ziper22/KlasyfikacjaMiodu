namespace KlasyfikacjaMiodu.SideMenu
{
    /// <summary>
    /// Klasa odpowiedzialna za okno edycji typów miodu.
    /// Klasa generowana automatycznie.
    /// </summary>
    partial class HoneyTypeEditWindow
    {

        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Funkcja odpowiedzialna za zwolnienie zasobów.
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
        /// Funkcja inicjująca komponenty okna.
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
            this.label6 = new System.Windows.Forms.Label();
            this.percentNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.warningLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.honeyNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa pyłku:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(91, 6);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
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
            this.chooseColorButton.Location = new System.Drawing.Point(91, 84);
            this.chooseColorButton.Name = "chooseColorButton";
            this.chooseColorButton.Size = new System.Drawing.Size(100, 23);
            this.chooseColorButton.TabIndex = 4;
            this.chooseColorButton.Text = "Wybierz kolor";
            this.chooseColorButton.UseVisualStyleBackColor = true;
            this.chooseColorButton.Click += new System.EventHandler(this.ChooseColorButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(149, 123);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(58, 123);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // specimenPictureBox
            // 
            this.specimenPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.specimenPictureBox.Location = new System.Drawing.Point(58, 84);
            this.specimenPictureBox.Name = "specimenPictureBox";
            this.specimenPictureBox.Size = new System.Drawing.Size(23, 23);
            this.specimenPictureBox.TabIndex = 8;
            this.specimenPictureBox.TabStop = false;
            this.specimenPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SpecimenPictureBox_MouseClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Min. procent:";
            // 
            // percentNumericUpDown
            // 
            this.percentNumericUpDown.Location = new System.Drawing.Point(91, 59);
            this.percentNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.percentNumericUpDown.Name = "percentNumericUpDown";
            this.percentNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.percentNumericUpDown.Size = new System.Drawing.Size(45, 20);
            this.percentNumericUpDown.TabIndex = 3;
            this.percentNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.percentNumericUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PercentNumericUpDown_KeyUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox);
            this.panel1.Controls.Add(this.warningLabel);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.honeyNameTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.percentNumericUpDown);
            this.panel1.Controls.Add(this.label6);
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
            this.panel1.Size = new System.Drawing.Size(272, 193);
            this.panel1.TabIndex = 0;
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(58, 151);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(166, 17);
            this.checkBox.TabIndex = 19;
            this.checkBox.Text = "Dodaj pyłek do bazy na stałe";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // warningLabel
            // 
            this.warningLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.warningLabel.AutoSize = true;
            this.warningLabel.BackColor = System.Drawing.SystemColors.Control;
            this.warningLabel.ForeColor = System.Drawing.Color.Red;
            this.warningLabel.Location = new System.Drawing.Point(10, 171);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(259, 13);
            this.warningLabel.TabIndex = 18;
            this.warningLabel.Text = "Co najmniej jedna z nowych nazw istnieje już w bazie!";
            this.warningLabel.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Np. Lipowy";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Np. Lipa";
            // 
            // honeyNameTextBox
            // 
            this.honeyNameTextBox.Location = new System.Drawing.Point(91, 32);
            this.honeyNameTextBox.Name = "honeyNameTextBox";
            this.honeyNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.honeyNameTextBox.TabIndex = 2;
            this.honeyNameTextBox.TextChanged += new System.EventHandler(this.HoneyNameTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nazwa miodu:";
            // 
            // HoneyTypeEditWindow
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(272, 193);
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown percentNumericUpDown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox honeyNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.CheckBox checkBox;

    }
}