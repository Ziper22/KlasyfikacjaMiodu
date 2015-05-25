using System;
using System.Drawing;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.SideMenu
{
    /// <summary>
    ///     Author: Agata Hammermeister
    ///     <para />
    /// </summary>
    public partial class SidePanel : Form
    {
        private readonly Form mainForm;
        private readonly PollenModuleSelector pollenModuleSelector;
        private bool locationChanged;
        bool alignToRight = true;

        public SidePanel(Form mainForm)
        {
            InitializeComponent();
            MouseWheel += SidePanel_MouseWheel;
            pollenModuleSelector = new PollenModuleSelector();
            this.mainForm = mainForm;
            Session.Changed += Session_Changed;
            Session_Changed(Session.Context);

            //SizeChanged += SidePanel_SizeChanged;
            mainForm.SizeChanged += mainForm_SizeChanged;

            this.SizeChanged += SidePanel_SizeChanged;
        }

        #region MainMethods
        public void changeMenuStatus(bool status)
        {
            this.editToolStripMenuItem.Enabled = status;
            this.deleteToolStripMenuItem.Enabled = status;
            this.addToolStripMenuItem.Enabled = status;
            this.menuStrip1.Enabled = status;
        }
        void SidePanel_SizeChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     Allows scrolling side panel with mouse wheel
        /// </summary>
        void SidePanel_MouseWheel(object sender, MouseEventArgs e)
        {
            panel1.Focus();
        }

        /// <summary>
        ///     Loads modules in side panel for all honey types and selects first one by default
        /// </summary>
        private void Session_Changed(Context context)
        {

            panel1.Controls.Clear();
            foreach (HoneyType honey in context.HoneyTypes)
            {
                if (honey.Name=="Zanieczyszczenie")
                {
                    honey.Dirt = true;
                }
                HoneyType_Add(honey);
            }

            if (panel1.Controls.Count > 1)
            {
                PollenModule dirtPollenModule = (PollenModule)panel1.Controls[0];
                dirtPollenModule.HoneyType.Dirt = true;
                dirtPollenModule.HidePercentage();

                PollenModule defaultPollenModule = (PollenModule)panel1.Controls[1];
                defaultPollenModule.Choose();
                pollenModuleSelector.chosenModule = defaultPollenModule;

                HoneyType defaultHoneyType = context.HoneyTypes[1];
                Session.Context.SelectedHoneyType = defaultHoneyType;

                panel1.VerticalScroll.Value = 1;
            }

            Session.Context.HoneyTypeAdded += HoneyType_Add;
        }

        /// <summary>
        ///     On ControlBox click hides side panel instead of closing it
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            Hide();
        }

        #endregion

        #region AddEditDelete

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoneyTypeEditWindow addEditWindow = new HoneyTypeEditWindow();
            addEditWindow.OkButtonClicked += HoneyType_AddToContext;
            addEditWindow.ShowDialog();
        }

        private void HoneyType_Add(HoneyType newHoney)
        {
            PollenModule pollenModule = new PollenModule(newHoney);
            panel1.Controls.Add(pollenModule);
            pollenModuleSelector.AddListeners(pollenModule);
            RefreshPanel();
            panel1.ScrollControlIntoView(pollenModule);
        }

        private void HoneyType_AddToContext(HoneyType newHoney, bool persistent)
        {
            Session.Context.AddHoneyType(newHoney);
            if (persistent)
            {
                DefaultHoneyTypesBase.AddNewHoneyTypeToFile(newHoney);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pollenModuleSelector.chosenModule != null)
            {
                if (pollenModuleSelector.chosenModule.HoneyType.Name == "Zanieczyszczenie")
                {
                    return;
                }
                HoneyTypeEditWindow addEditWindow = new HoneyTypeEditWindow(Session.Context.SelectedHoneyType);
                addEditWindow.OkButtonClicked += HoneyType_Edit;
                addEditWindow.ShowDialog();
            }
        }

        private void HoneyType_Edit(HoneyType honeyType, bool persistent)
        {
            pollenModuleSelector.chosenModule.Edit(honeyType);
            Session.Context.EditedHoneyType(honeyType);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pollenModuleSelector.chosenModule != null)
            {
                if (pollenModuleSelector.chosenModule.HoneyType.Name == "Zanieczyszczenie")
                {
                    return;
                }
                const string message = "Czy na pewno chcesz usunąć wybrany znacznik?";
                const string title = "Znacznik zostanie usunięty";

                DialogResult dialogResult = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    PollenModule activeModule = pollenModuleSelector.chosenModule;
                    if (activeModule != null)
                    {
                        panel1.Controls.Remove(activeModule);
                        Session.Context.RemoveHoneyType(activeModule.HoneyType);
                        pollenModuleSelector.chosenModule = null;
                        Session.Context.SelectedHoneyType = null;
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                }
            }
        }

        #endregion

        #region Location&Orientation

        void mainForm_SizeChanged(object sender, EventArgs e)
        {
            AlignSidePanel();
        }

        private void AlignSidePanel()
        {

            if (panel1.FlowDirection == FlowDirection.LeftToRight) //for horizontal
            {
                if (Screen.PrimaryScreen.WorkingArea.Bottom - mainForm.Bottom < Height)
                {
                    Width = 800;
                    Location = new Point(mainForm.Left + ((mainForm.Width - Width) / 2), mainForm.Bottom - Height);
                }
                else
                {
                    Width = mainForm.Width;
                    Location = new Point(mainForm.Left, mainForm.Bottom);
                }
            }
            else //for vertical
            {
                if (alignToRight)
                {
                    AlignSidePanelToRight();
                }
                else
                {
                    AlignSidePanelToLeft();
                }
            }
        }

        /// <summary>
        ///     Changes orientation of the side panel to vertical
        /// </summary>
        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.FlowDirection = FlowDirection.TopDown;
            Width = 240;
            Height = 481;

            verticalToolStripMenuItem.Text = "Wyrównaj listę";
            horizontalToolStripMenuItem.Text = "Lista pozioma";
            SwapMenuItems();

            AlignSidePanel();
        }

        /// <summary>
        ///     Changes orientation of the side panel to horizontal
        /// </summary>
        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.FlowDirection = FlowDirection.LeftToRight;
            Height = 132;

            if (Screen.PrimaryScreen.WorkingArea.Bottom - mainForm.Bottom < Height)
            {
                Width = 800;
                Location = new Point(mainForm.Left + ((mainForm.Width - Width) / 2), mainForm.Bottom - Height);
            }
            else
            {
                Width = mainForm.Width;

                Location = new Point(mainForm.Left, mainForm.Bottom);
            }

            verticalToolStripMenuItem.Text = "Lista pionowa";
            horizontalToolStripMenuItem.Text = "Wyrównaj listę";
            SwapMenuItems();

            AlignSidePanel(); RefreshPanel();           
        }

        private void AlignSidePanelToLeft()
        {
            alignToRight = false;

            //if (panel1.FlowDirection==FlowDirection.LeftToRight)
            //{
            //    MessageBox.Show("dupa");
            //    verticalView();
            //}
            if (Screen.PrimaryScreen.WorkingArea.Left + mainForm.Left < Width)
            {
                Location = new Point(mainForm.Left, mainForm.Top + (mainForm.Height - Height) / 2);
            }
            else
            {
                Location = new Point(mainForm.Left - Width, mainForm.Top);
            }
        }

        private void AlignSidePanelToRight()
        {
            alignToRight = true;

            if (Screen.PrimaryScreen.WorkingArea.Right - mainForm.Right < Width)
            {
                Location = new Point(mainForm.Right - Width, (mainForm.Top + (mainForm.Height - Height) / 2));
            }
            else
            {
                Location = new Point(mainForm.Right, mainForm.Top);
            }
        }

        ///<summary>
        /// Changes order of "Orientation" menu toolstrip items so the "Align" item is always first
        /// </summary>
        private void SwapMenuItems()
        {
            ToolStripItem tmpItem = orientationToolStripMenuItem.DropDownItems[0];

            if (tmpItem.Text != "Wyrównaj listę")
            {
                orientationToolStripMenuItem.DropDownItems.RemoveAt(0);
                orientationToolStripMenuItem.DropDownItems.Add(tmpItem);
            }
            if (panel1.FlowDirection==FlowDirection.LeftToRight)
            {  
                doLewejToolStripMenuItem.Visible = false;
                doPrawejToolStripMenuItem.Visible = false;
            }
            else
            {
                doLewejToolStripMenuItem.Visible = true;
                doPrawejToolStripMenuItem.Visible = true; 
            }

        }

        private void RefreshPanel()
        {
            if (panel1.FlowDirection == FlowDirection.LeftToRight)
            {
                panel1.FlowDirection = FlowDirection.TopDown;
                panel1.FlowDirection = FlowDirection.LeftToRight;
            }
        }

        private void toLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alignToRight = false;
            AlignSidePanel();
        }

        private void toRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alignToRight = true;
            AlignSidePanel();
        }
        #endregion
    }
}