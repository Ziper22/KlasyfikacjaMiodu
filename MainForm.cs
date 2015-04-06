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
using KlasyfikacjaMiodu.BottomBar;
using KlasyfikacjaMiodu.SideMenu;
using KlasyfikacjaMiodu.ViewPanel;

namespace KlasyfikacjaMiodu
{
    public partial class MainForm : Form
    {
        private MarkersPanel markersPanel;
        private ImagePanel imagePanel;
        private ScaleHandler scaleHandler;
        private HoneyTypeInformer honeyTypeInformer;
        private TimeCounter timeCounter;
        private TopMenuFile topMenuFile;
        private TopMenuEdit topMenuEdit;
        private TopMenuView topMenuView;
        private SidePanel sidePanel;

        public MainForm()
        {
            InitializeComponent();
            PrepareSidePanel();
            markersPanel = new MarkersPanel(viewPanel, pollensImage);
            imagePanel = new ImagePanel(viewPanel, pollensImage);
            scaleHandler = new ScaleHandler(scale);
            honeyTypeInformer = new HoneyTypeInformer(honeyType);
            timeCounter = new TimeCounter(workTime);
            topMenuFile = new TopMenuFile(newProjectMenuItem, saveProjectMenuItem, loadProjectMenuItem, loadImageMenuItem, quitMenuItem);
            topMenuEdit = new TopMenuEdit(this, editMenu, undoMenuItem, redoMenuItem);
            topMenuView = new TopMenuView(showPanelMenuItem, sidePanel);
        }

        private void PrepareSidePanel()
        {
            sidePanel = new SidePanel();
            sidePanel.Size = new Size(sidePanel.Size.Width, Size.Height);
            sidePanel.StartPosition = FormStartPosition.Manual;

            CenterToScreen();
            Location = new Point(Left - sidePanel.Width/2, Top);

            sidePanel.Location = new Point(Right,Top);
            sidePanel.Show();
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
