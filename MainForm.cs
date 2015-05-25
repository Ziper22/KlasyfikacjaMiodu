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
            imagePanel = new ImagePanel(viewPanel, pollensImage, this);
            scaleHandler = new ScaleHandler(scale);
            honeyTypeInformer = new HoneyTypeInformer(honeyType);
            timeCounter = new TimeCounter(workTime, stoperButton);
            topMenuFile = new TopMenuFile(newProjectMenuItem, saveProjectMenuItem, loadProjectMenuItem, loadImageMenuItem, quitMenuItem, this);
            topMenuEdit = new TopMenuEdit(this, editMenu, undoMenuItem, redoMenuItem);
            topMenuView = new TopMenuView(showPanelMenuItem, centerImageMenuItem, sidePanel, viewPanel);
            viewPanel.MouseMove += viewPanel_MouseMove;
            viewPanel.MouseLeave += viewPanel_MouseLeave;
        }

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

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x2000000;
                return cp;
            }
        }

        void viewPanel_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            p.X = (int)(p.X / (viewPanel.Width / pollensImage.Image.PhysicalDimension.Width));
            p.Y = (int)(p.Y / (viewPanel.Height / pollensImage.Image.PhysicalDimension.Height));
            mousePostion.Text = p.ToString();
        }

        private void AddMousePositionEvent()
        {
            GlobalMouseHandler gmh = new GlobalMouseHandler();
            gmh.TheMouseMoved += new MouseMovedEvent(gmh_TheMouseMoved);
            Application.AddMessageFilter(gmh);
        }

        void gmh_TheMouseMoved()
        {
            Point p = System.Windows.Forms.Cursor.Position;
            Point pf = new Point(p.X - Left, p.Y - Top);
            mousePostion.Text = pf.ToString();
        }

        void viewPanel_MouseLeave(object sender, EventArgs e)
        {
            mousePostion.Text = "";
        }

        public delegate void MouseMovedEvent();

        public class GlobalMouseHandler : IMessageFilter
        {
            private const int WM_MOUSEMOVE = 0x0200;

            public event MouseMovedEvent TheMouseMoved;

            #region IMessageFilter Members

            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == WM_MOUSEMOVE)
                {
                    if (TheMouseMoved != null)
                    {
                        TheMouseMoved();
                    }
                }
                // Always allow message to continue to the next filter control
                return false;
            }

            #endregion
        }

        private void topMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        /// <summary>
        /// Sets application into edit mode.
        /// </summary>
        private void editMode_CheckedChanged(object sender, EventArgs e)
        {
            if (editMode.Checked)
            {
                Session.Context.EditMode = true;
                timeCounter.StartTimer();
                this.ChangeMenuStatus(true);
                sidePanel.Enabled = true;
            }
            else
            {
                Session.Context.EditMode = false;
                timeCounter.PauseTimer();
                this.ChangeMenuStatus(false);
                sidePanel.Enabled = false;
            }
        }
        /// <summary>
        /// Changes "Enabled" property in main menu.
        /// </summary>
        private void ChangeMenuStatus(bool status)
        {
            fileMenu.Enabled = status;
            editMenu.Enabled = status;
            viewMenu.Enabled = status;
        }
    }
}
