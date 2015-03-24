using KlasyfikacjaMiodu.TopMenu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private TopMenuFile topMenuFile;
        private TopMenuEdit topMenuEdit;
        private TopMenuView topMenuView;

        public MainForm()
        {
            InitializeComponent();
            ResizeRedraw = true;
            markersPanel = new MarkersPanel(imagePanel, scale, pictureBox1);
            timeCounter = new TimeCounter(workTime);
            topMenuFile = new TopMenuFile(newProjectMenuItem, saveProjectMenuItem, 
                loadProjectMenuItem, loadImageMenuItem, quitMenuItem);
            topMenuEdit = new TopMenuEdit(undoMenuItem, redoMenuItem);
            topMenuView = new TopMenuView(showPanelMenuItem);
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
