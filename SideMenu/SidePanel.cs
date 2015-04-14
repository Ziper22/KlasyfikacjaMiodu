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
            pollenModuleSelector = new PollenModuleSelector();
            this.mainForm = mainForm;
            LocationChanged += SidePanel_LocationChanged;
            Session.Changed += Session_Changed;
            Session_Changed(Session.Context);           
        }

        /// <summary>
        ///     Loads modules in side panel for all honey types
        /// </summary>
        private void Session_Changed(Context context)
        {
                foreach (HoneyType honey in context.HoneyTypes)
                {
                    HoneyType_Add(honey);
                }
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
        }

        private void HoneyType_AddToContext(HoneyType newHoney)
        {
            HoneyType_Add(newHoney);
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
        ///     Detects if location of the side panel has been changed
        /// </summary>
        private void SidePanel_LocationChanged(object sender, EventArgs e)
        {
            locationChanged = true;
        }

        /// <summary>
        ///     Changes orientation of the side panel to vertical
        /// </summary>
        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.FlowDirection = FlowDirection.TopDown;

            Size = new Size(225, mainForm.Height);

            if (locationChanged)
            {
                mainForm.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - (mainForm.Width + Width)) / 2,
                    (Screen.PrimaryScreen.WorkingArea.Height - mainForm.Height) / 2);
            }
            Location = new Point(mainForm.Right, mainForm.Top);

            verticalToolStripMenuItem.Text = "Wyrównaj";
            horizontalToolStripMenuItem.Text = "Lista pozioma";
        }

        /// <summary>
        ///     Changes orientation of the side panel to horizontal
        /// </summary>
        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.FlowDirection = FlowDirection.LeftToRight;

            Size = new Size(mainForm.Width, 132);

            if (locationChanged)
            {
                mainForm.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - mainForm.Width) / 2,
                    (Screen.PrimaryScreen.WorkingArea.Height - (mainForm.Height + Height)) / 2);
            }
            Location = new Point(mainForm.Left, mainForm.Bottom);

            verticalToolStripMenuItem.Text = "Lista pionowa";
            horizontalToolStripMenuItem.Text = "Wyrównaj";
        }

        #endregion
    }
}