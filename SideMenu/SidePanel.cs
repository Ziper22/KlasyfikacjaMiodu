using System;
using System.Drawing;
using System.Windows.Forms;
using KlasyfikacjaMiodu.SideMenu;

namespace KlasyfikacjaMiodu.SideMenu
{
    /// <summary>
    /// Author: Agata Hammermeister<para/>
    /// </summary>

    public partial class SidePanel : Form
    {
        private readonly PollenModuleSelector pollenModuleSelector;
        private readonly Form mainForm;
        private bool locationChanged;

        public SidePanel(Form mainForm)
        {
            InitializeComponent();
            pollenModuleSelector = new PollenModuleSelector();
            Session.Changed += Session_Changed;
            this.mainForm = mainForm;
            LocationChanged += SidePanel_LocationChanged;
        }
        /// <summary>
        /// Loads modules in side panel for all honey types
        /// </summary>
        private void Session_Changed(Context context)
        {
            foreach (HoneyType honey in Session.Context.HoneyTypes)
            {
                HoneyType_Add(honey);
            }
        }

        #region AddEditDelete

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoneyType facelia = new HoneyType("Facelia", "faceliowy", "facelio", Color.MediumSlateBlue, 14, 1);
            PollenModule pm1 = new PollenModule(facelia);
            panel1.Controls.Add(pm1);
            pollenModuleSelector.AddListeners(pm1);

            HoneyType wrzos = new HoneyType("Wrzos", "wrzosowy", "wrzosowo", Color.Purple, 14, 1);
            PollenModule pm2 = new PollenModule(wrzos);
            panel1.Controls.Add(pm2);
            pollenModuleSelector.AddListeners(pm2);

            HoneyType malina = new HoneyType("Malina", "malinowy", "malinowo", Color.MediumVioletRed, 14, 1);
            PollenModule pm3 = new PollenModule(malina);
            panel1.Controls.Add(pm3);
            pollenModuleSelector.AddListeners(pm3);

            HoneyType nawłoć = new HoneyType("Nawłoć", "nawłociowy", "nawłociowo", Color.Goldenrod, 14, 1);
            PollenModule pm4 = new PollenModule(nawłoć);
            panel1.Controls.Add(pm4);
            pollenModuleSelector.AddListeners(pm4);

            HoneyType rzepak = new HoneyType("Rzepak", "rzepakowy", "rzepakowo", Color.Gold, 14, 1);
            PollenModule pm5 = new PollenModule(rzepak);
            panel1.Controls.Add(pm5);
            pollenModuleSelector.AddListeners(pm5);

            HoneyType akacja = new HoneyType("Akacja", "akacjowy", "akacjowo", Color.Ivory, 14, 1);
            PollenModule pm6 = new PollenModule(akacja);
            panel1.Controls.Add(pm6);
            pollenModuleSelector.AddListeners(pm6);

            HoneyType lipa = new HoneyType("Lipa", "lipowy", "lipowo", Color.GreenYellow, 14, 1);
            PollenModule pm7 = new PollenModule(lipa);
            panel1.Controls.Add(pm7);
            pollenModuleSelector.AddListeners(pm7);

            HoneyTypeEditWindow addEditWindow = new HoneyTypeEditWindow();
            addEditWindow.OkButtonClicked += HoneyType_Add;
            addEditWindow.ShowDialog();
        }

        private void HoneyType_Add(HoneyType newHoney)
        {
            PollenModule pollenModule = new PollenModule(newHoney);
            panel1.Controls.Add(pollenModule);
            pollenModuleSelector.AddListeners(pollenModule);
            Session.Context.AddHoneyType(newHoney);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pollenModuleSelector.chosenModule!=null)
            {
                HoneyTypeEditWindow addEditWindow = new HoneyTypeEditWindow(Session.Context.SelectedHoneyType);
                addEditWindow.OkButtonClicked += HoneyType_Edit;
                addEditWindow.ShowDialog();
            }
        }

        private void HoneyType_Edit(HoneyType honeyType)
        {
            //edithoney
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
        ///Detects if location of the side panel has been changed 
        /// </summary>
        private void SidePanel_LocationChanged(object sender, EventArgs e)
        {
            locationChanged = true;
        }

        /// <summary>
        /// Changes orientation of the side panel to vertical
        /// </summary>
        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.FlowDirection = FlowDirection.TopDown;

            Size = new Size(250, mainForm.Height);

            if (locationChanged)
            {
                mainForm.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - (mainForm.Width + Width))/2,
                    (Screen.PrimaryScreen.WorkingArea.Height - mainForm.Height)/2);               
            }
            Location = new Point(mainForm.Right, mainForm.Top);

            verticalToolStripMenuItem.Text = "Wyrównaj";
            horizontalToolStripMenuItem.Text = "Pozioma";

        }

        /// <summary>
        /// Changes orientation of the side panel to horizontal
        /// </summary>
        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.FlowDirection = FlowDirection.LeftToRight;

            Size = new Size(mainForm.Width, 130);

            if (locationChanged)
            {
                mainForm.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - mainForm.Width)/2,
                    (Screen.PrimaryScreen.WorkingArea.Height - (mainForm.Height + Height))/2);
            }
            Location = new Point(mainForm.Left, mainForm.Bottom);

            verticalToolStripMenuItem.Text = "Pionowa";
            horizontalToolStripMenuItem.Text = "Wyrównaj";
        }

        #endregion

        /// <summary>
        /// On ControlBox click hides side panel instead of closing it
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            Hide();
        }
    }
}