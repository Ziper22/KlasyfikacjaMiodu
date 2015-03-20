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
    public partial class MainForm : Form
    {
        private MarkersPanel markersPanel;
        private TimeCounter timeCounter;

        public MainForm()
        {
            InitializeComponent();
            ResizeRedraw = true;
            markersPanel = new MarkersPanel(imagePanel, scale, pictureBox1);
            timeCounter = new TimeCounter(workTime);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x2000000;
                return cp;
            }
        }
    }
}
