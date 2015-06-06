using KlasyfikacjaMiodu.TopMenu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    /// <summary>
    /// Klasa odpowiedzialna za główne okno programu.
    /// Klasa wygenerowana automatycznie.
    /// </summary>
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
        /// <summary>
        /// Konstruktor klasy MainForm().
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            PrepareSidePanel();
            markersPanel = new MarkersPanel(viewPanel, pollensImage);
            imagePanel = new ImagePanel(viewPanel, pollensImage, this);
            scaleHandler = new ScaleHandler(scale);
            honeyTypeInformer = new HoneyTypeInformer(honeyType);
            timeCounter = new TimeCounter(workTime, stoperButton);
            topMenuFile = new TopMenuFile(newProjectMenuItem, saveProjectMenuItem, loadProjectMenuItem, loadImageMenuItem, quitMenuItem, this);
            topMenuEdit = new TopMenuEdit(this, editMenu, undoMenuItem, redoMenuItem);
            topMenuView = new TopMenuView(showPanelMenuItem, centerImageMenuItem, sidePanel, viewPanel);
            Icon = Properties.Resources.Icon;
        }
        /// <summary>
        /// Funkcja tworząca boczny panel.
        /// </summary>
        private void PrepareSidePanel()
        {
            sidePanel = new SidePanel(this);
            sidePanel.Size = new Size(sidePanel.Size.Width, Size.Height);
            sidePanel.StartPosition = FormStartPosition.Manual;
            sidePanel.Owner = this;

            CenterToScreen();
            Location = new Point(Left - sidePanel.Width / 2, Top);

            sidePanel.Location = new Point(Right, Top);
            sidePanel.Show();
        }
        /// <summary>
        /// Właściwość zwracająca obiekt CreateParams
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x2000000;
                return cp;
            }
        }

        /// <summary>
        /// Funkcja blokuje tryb edycji.
        /// </summary>
        public static void SetEditMode(MainForm mainForm, bool status)
        {
            Session.Context.EditMode = status;

            mainForm.sidePanel.SetPanel(status);

            mainForm.showPanelMenuItem.Enabled = status;
            mainForm.centerImageMenuItem.Enabled = status;

            mainForm.undoMenuItem.Visible = status;
            mainForm.redoMenuItem.Visible = status;

            mainForm.wlaczEdytowanieToolStripMenuItem.Visible = !status;

            if (mainForm.timeCounter.Running && status == false)
                mainForm.timeCounter.PauseTimer();

            else if(!mainForm.timeCounter.Running && status == true)
                mainForm.timeCounter.StartTimer();
        }
       
       /// <summary>
       /// Funkcja włączająca tryb edycji.
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        public void wlaczEdytowanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.SetEditMode((MainForm)this,true);
        }

        private void guideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("wordpad.exe", "../../Resources/obsluga_programu.docx");
        }

        private void honeyListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("wordpad.exe", "../../Resources/lista_miodow_i_pylkow.docx");
        }
    }
}
