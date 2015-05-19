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

        public SidePanel(Form mainForm)
        {
            InitializeComponent();
            MouseWheel += SidePanel_MouseWheel;
            pollenModuleSelector = new PollenModuleSelector();
            this.mainForm = mainForm;
            Session.Changed += Session_Changed;
            Session_Changed(Session.Context);
            this.SizeChanged += SidePanel_SizeChanged;
        }

        void SidePanel_SizeChanged(object sender, EventArgs e)
        {
            AlignVerticalPanel();
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
                HoneyType_Add(honey);
            }

            if (panel1.Controls.Count > 0)
            {
                PollenModule defaultPollenModule = (PollenModule) panel1.Controls[0];
                defaultPollenModule.Choose();
                pollenModuleSelector.chosenModule = defaultPollenModule;

                HoneyType defaultHoneyType = context.HoneyTypes[0];
                Session.Context.SelectedHoneyType = defaultHoneyType;
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
            AlignVerticalPanel();
            panel1.ScrollControlIntoView(pollenModule);
        }

        private void HoneyType_AddToContext(HoneyType newHoney)
        {
            Session.Context.AddHoneyType(newHoney);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pollenModuleSelector.chosenModule != null)
            {
                HoneyTypeEditWindow addEditWindow = new HoneyTypeEditWindow(Session.Context.SelectedHoneyType);
                addEditWindow.OkButtonClicked += HoneyType_Edit;
                addEditWindow.ShowDialog();
            }
        }

        private void HoneyType_Edit(HoneyType honeyType)
        {
            pollenModuleSelector.chosenModule.Edit(honeyType);
            Session.Context.EditedHoneyType(honeyType);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pollenModuleSelector.chosenModule != null)
            {
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

        /// <summary>
        ///     Changes orientation of the side panel to vertical
        /// </summary>
        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.FlowDirection = FlowDirection.TopDown;
            Width = 240;

            if (Screen.PrimaryScreen.WorkingArea.Width - mainForm.Width < Width)
            {
                Height = 481;
                CenterMainForm();
                Location = new Point(mainForm.Right - Width, (mainForm.Top + (mainForm.Height - Height) / 2));
            }
            else
            {
                Height = mainForm.Height;

                mainForm.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - (mainForm.Width + Width)) / 2,
                    (Screen.PrimaryScreen.WorkingArea.Height - mainForm.Height) / 2);
                Location = new Point(mainForm.Right, mainForm.Top);
            }

            verticalToolStripMenuItem.Text = "Wyrównaj";
            horizontalToolStripMenuItem.Text = "Lista pozioma";
            ChangeMenuItemsOrder();    
        }

        /// <summary>
        ///     Changes orientation of the side panel to horizontal
        /// </summary>
        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.FlowDirection = FlowDirection.LeftToRight;
            Height = 132;

            if (Screen.PrimaryScreen.WorkingArea.Height - mainForm.Height < Height)
            {
                Width = 800;
                CenterMainForm();
                Location = new Point(mainForm.Left + ((mainForm.Width - Width) / 2), mainForm.Bottom - Height - 40);
            }
            else
            {
                Width = mainForm.Width;

                mainForm.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - mainForm.Width) / 2,
                    (Screen.PrimaryScreen.WorkingArea.Height - (mainForm.Height + Height)) / 2);
                Location = new Point(mainForm.Left, mainForm.Bottom);
            }
            AlignVerticalPanel();

            //do poprawy
            verticalToolStripMenuItem.Text = "Lista pionowa";
            horizontalToolStripMenuItem.Text = "Wyrównaj";
            ChangeMenuItemsOrder();
        }

        ///<summary>
        /// Changes order of "Orientation" menu toolstrip items
        /// </summary>
        private void ChangeMenuItemsOrder()
        {
            ToolStripItem tmpItem = orientationToolStripMenuItem.DropDownItems[0]; 

            if (tmpItem.Text!="Wyrównaj")
            {
                orientationToolStripMenuItem.DropDownItems.RemoveAt(0);
                orientationToolStripMenuItem.DropDownItems.Add(tmpItem);  
            }         
        }

        /// <summary>
        ///     Centers main form if it isn't maximized
        /// </summary>
        private void CenterMainForm()
        {
            if (mainForm.Size != mainForm.MaximumSize)
            {
                mainForm.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - mainForm.Width) / 2,
                    (Screen.PrimaryScreen.WorkingArea.Height - mainForm.Height) / 2);
            }
        }

        /// <summary>
        ///     Scrolls panel to the last pollen module
        /// </summary>
        private void AlignVerticalPanel()
        {
            if (panel1.FlowDirection == FlowDirection.LeftToRight)
            {
                panel1.FlowDirection = FlowDirection.TopDown;
                panel1.FlowDirection = FlowDirection.LeftToRight;
                //int pollenModulesNumber = panel1.Controls.Count;
                //panel1.ScrollControlIntoView(panel1.Controls[pollenModulesNumber - 1]);
            }
        }
        #endregion
    }
}