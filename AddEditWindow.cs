using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu
{
    /// <summary>
    /// Author: Marek Borski<para/>
    /// </summary>
    /// 
    public partial class AddEditWindow : Form
    {
        public AddEditWindow()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //private List<PollenModule> PollensList = new List<PollenModule>();
        //private List<TextBox> TextBoxesList = new List<TextBox>();
        //private List<Label> LabelsList = new List<Label>();

        //private TextBox textbox;
        //private Label label;
        //private Button accept, cancel, chooseColor;
        //private Panel panel;
        //private PictureBox marker;

        //private int y1 = 25, y2 = 25, colorCode;
        //private string name, description;

        //public SidePanel()
        //{
        //    InitializeComponent();
        //}


        //void chooseColor_Click(object sender, EventArgs e) 
        //{
        //    ColorDialog dlg = new ColorDialog();
        //    if (dlg.ShowDialog() == DialogResult.OK)
        //    {
        //        colorCode = dlg.Color.ToArgb();
        //        chooseColor.Text = "Wybrano";
        //    }
        //}

        //private void cancel_Click(object sender, EventArgs e) 
        //{
        //    Remove_GetInformationPanel();
        //}

        //void accept_Click(object sender, EventArgs e) 
        //{
        //    name = TextBoxesList[0].Text;
        //    description = TextBoxesList[1].Text;

        //    Remove_GetInformationPanel();

        //    NewPollen();
        //}

        //private void NewPollen()
        //{
        //    PollensList.Add(new PollenModule(0, 0, new HoneyType(name, description, Color.FromArgb(colorCode))));

        //    marker = new PictureBox();
        //    this.Controls.Add(marker);
        //    marker.Location = new Point(5, y2);
        //    marker.Size = new System.Drawing.Size(30, 30);
        //    marker.BackColor = Color.FromArgb(colorCode);

        //    label = new Label();
        //    this.Controls.Add(label);
        //    label.Location = new Point(40, y2 + 10);
        //    label.Text = name;

        //    label = new Label();
        //    this.Controls.Add(label);
        //    label.Location = new Point(40, y2 + 20);
        //    label.Text = description;

        //    y2 += 35;
        //}

        //private void GetInformationPanel(string text) 
        //{
        //    label = new Label();
        //    this.Controls.Add(label);
        //    label.Location = new Point(0, y1);
        //    label.Text = text;
        //    label.BringToFront();
        //    LabelsList.Add(label);

        //    textbox = new TextBox();
        //    this.Controls.Add(textbox);
        //    textbox.Location = new Point(100, y1);
        //    textbox.BringToFront();
        //    TextBoxesList.Add(textbox);

        //    y1 += 30;
        //}

        //private void Remove_GetInformationPanel() 
        //{
        //    this.Controls.Remove(panel);
        //    this.Controls.Remove(accept);
        //    this.Controls.Remove(cancel);
        //    this.Controls.Remove(chooseColor);
        //    for (int i = 0; i < 2; i++)
        //    {
        //        this.Controls.Remove(TextBoxesList[i]);
        //        this.Controls.Remove(LabelsList[i]);
        //    }
        //    this.Controls.Remove(LabelsList[2]);
        //    TextBoxesList.Clear();
        //    LabelsList.Clear();

        //}

        //private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    panel = new Panel();
        //    this.Controls.Add(panel);
        //    panel.Location = new Point(0, 25);
        //    panel.Size = new System.Drawing.Size(290, 230);
        //    panel.BringToFront();

        //    GetInformationPanel("Name:");
        //    GetInformationPanel("Description:");

        //    label = new Label();
        //    this.Controls.Add(label);
        //    label.Location = new Point(0, y1);
        //    label.Text = "Color:";
        //    label.BringToFront();
        //    LabelsList.Add(label);

        //    chooseColor = new Button();
        //    this.Controls.Add(chooseColor);
        //    chooseColor.Location = new Point(75, y1);
        //    chooseColor.Size = new System.Drawing.Size(150, 23);
        //    chooseColor.Text = "Wybierz kolor";
        //    chooseColor.BringToFront();

        //    chooseColor.Click += chooseColor_Click;

        //    accept = new Button();
        //    this.Controls.Add(accept);
        //    accept.Location = new Point(80, 120);
        //    accept.Text = "OK";
        //    accept.BringToFront();

        //    accept.Click += accept_Click;

        //    cancel = new Button();
        //    this.Controls.Add(cancel);
        //    cancel.Location = new Point(0, 120);
        //    cancel.Text = "Anuluj";
        //    cancel.BringToFront();

        //    cancel.Click += cancel_Click;

        //    y1 = 25;
        //}

    }
}
