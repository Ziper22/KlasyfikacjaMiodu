using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu
{
    /// <summary>
    /// Author: Agata Hammermeister<para/>
    /// Contains information on number/percentage of each marked <see cref="HoneyType"/>. Displayed on the side panel.
    /// </summary>
    public class PollenModule:FlowLayoutPanel
    {
        public HoneyType HoneyType { get; private set; }
        public double Number;
        public double Percentage;

        public PictureBox MarkerColor;
        public Label HoneyName;

        public FlowLayoutPanel PollenValues;
        public Label PollenNumber;
        public Label PollenPercentage;

        public FlowDirection FlowDirection;
        public FlowDirection FlowDirectionValues;

        public PollenModule()
        {
            MarkerColor = new PictureBox();
            HoneyName = new Label();
            PollenValues = new FlowLayoutPanel();
            PollenNumber = new Label();
            PollenPercentage = new Label();

            Controls.Add(MarkerColor);
            Controls.Add(HoneyName);
            Controls.Add(PollenValues);
            PollenValues.Controls.Add(PollenNumber);
            PollenValues.Controls.Add(PollenPercentage);
           
            MarkerColor.Size = new Size(40,40);
            HoneyName.Size = new Size(60, 40);
            PollenValues.Size = new Size(30,40);
            PollenNumber.Size = new Size(30, 20);
            PollenPercentage.Size = new Size(30, 20);
            AutoSize = true;
            FlowDirection = FlowDirection.LeftToRight;
            FlowDirectionValues = FlowDirection.TopDown;
        }

        public PollenModule(double pollenNumber, double pollenPercentage, HoneyType honeyType):this()
        {
            HoneyName.Text = honeyType.Name;
            MarkerColor.BackColor = honeyType.MarkerColor;
            Number = pollenNumber;
            Percentage = pollenPercentage;
        }

        public PollenModule(string honeyName, Color color):this()
        {
            HoneyName.Text = honeyName;
            MarkerColor.BackColor = color;
            Number = 0;
            Percentage = 0;
            PollenNumber.Text = Number.ToString();
            PollenPercentage.Text = Percentage.ToString();
        }

        public void Edit()
        {
            HoneyTypeEditWindow addEditWindow = new HoneyTypeEditWindow();
            addEditWindow.Show();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            //Color backColor = Color.FromArgb((int)(BackColor.GetHue()*1.1f));
            //MarkerColor.BackColor = backColor;
            Color color = MarkerColor.BackColor;
            float correctionFactor = 0.4f;
            float red = (255 - color.R) * correctionFactor + color.R;
            float green = (255 - color.G) * correctionFactor + color.G;
            float blue = (255 - color.B) * correctionFactor + color.B;
            Color lighterColor = Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
            MarkerColor.BackColor = lighterColor;
        }

        //protected override void OnMouseHover(EventArgs e)
        //{
        //    Color color = MarkerColor.BackColor;
        //    float correctionFactor = 0.2f;
        //    float red = (255 - color.R) * correctionFactor + color.R;
        //    float green = (255 - color.G) * correctionFactor + color.G;
        //    float blue = (255 - color.B) * correctionFactor + color.B;
        //    Color lighterColor = Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        //    MarkerColor.BackColor = lighterColor;
        //}

        protected override void OnMouseLeave(EventArgs e)
        {
            Color color = MarkerColor.BackColor;
            float correctionFactor = -0.4f;
            float red = (255 - color.R) * correctionFactor + color.R;
            float green = (255 - color.G) * correctionFactor + color.G;
            float blue = (255 - color.B) * correctionFactor + color.B;
            Color lighterColor = Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
            MarkerColor.BackColor = lighterColor;
        }
    }
}
