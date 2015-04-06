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
        private PollenModuleSelector pollenModuleSelector;
        private Form mainForm;
        private bool locationChanged;
        private bool orientationVertical;

        public SidePanel(Form mainForm)
        {
            InitializeComponent();
            pollenModuleSelector = new PollenModuleSelector();
            Session.Changed += Session_Changed;
            this.mainForm = mainForm;
            LocationChanged +=SidePanel_LocationChanged;
            orientationVertical = true;
        }

        private void Session_Changed(Context context)
        {
            foreach (HoneyType honey in Session.Context.HoneyTypes)
            {
                HoneyType_Add(honey);
            }
        }

        #region AddEditDelete

        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PollenModule pm1 = new PollenModule("Ułan", Color.Goldenrod);
            panel1.Controls.Add(pm1);
            pollenModuleSelector.AddListeners(pm1);
            PollenModule pm2 = new PollenModule("Ułan", Color.Goldenrod);
            panel1.Controls.Add(pm2);
            pollenModuleSelector.AddListeners(pm2);
            PollenModule pm3 = new PollenModule("Ułan", Color.Goldenrod);
            panel1.Controls.Add(pm3);
            pollenModuleSelector.AddListeners(pm3);
            PollenModule pm4 = new PollenModule("Ułan", Color.Goldenrod);
            panel1.Controls.Add(pm4);
            pollenModuleSelector.AddListeners(pm4);
            PollenModule pm5 = new PollenModule("Ułan", Color.Goldenrod);
            panel1.Controls.Add(pm5);
            pollenModuleSelector.AddListeners(pm5);
            PollenModule pm6 = new PollenModule("Ułan", Color.Goldenrod);
            panel1.Controls.Add(pm6);
            pollenModuleSelector.AddListeners(pm6);
            PollenModule pm7 = new PollenModule("Ułan", Color.Goldenrod);
            panel1.Controls.Add(pm7);
            pollenModuleSelector.AddListeners(pm7);

            HoneyTypeEditWindow addEditWindow = new HoneyTypeEditWindow();
            addEditWindow.OkButtonClicked += HoneyType_Add;
            addEditWindow.ShowDialog();
        }

        private void HoneyType_Add(HoneyType honeyType)
        {
            PollenModule pollenModule = new PollenModule(honeyType);
            panel1.Controls.Add(pollenModule);
            pollenModuleSelector.AddListeners(pollenModule);
        }

        private void edytujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (panel1.HasChildren)//
            //  {
            //HoneyTypeEditWindow addEditWindow = new HoneyTypeEditWindow(pollenModuleSelector.chosenModule.HoneyType);
            HoneyTypeEditWindow addEditWindow = new HoneyTypeEditWindow(Session.Context.SelectedHoneyType);
            addEditWindow.OkButtonClicked += HoneyType_Edit;
            addEditWindow.ShowDialog();
            // }
        }

        private void HoneyType_Edit(HoneyType honeyType)
        {
            pollenModuleSelector.chosenModule.Edit(honeyType);
        }

        private void usuńToolStripMenuItem_Click(object sender, EventArgs e) //Delete
        {
            // if (panel1.HasChildren)//
            //      {
            const string message = "Czy na pewno chcesz usunąć wybrany znacznik?";
            const string title = "Znacznik zostanie usunięty";

            DialogResult dialogResult = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                PollenModule activeModule = pollenModuleSelector.chosenModule;
                if (activeModule != null)
                {
                    if (panel1.Container != null) panel1.Container.Remove(activeModule);
                    Session.Context.RemoveHoneyType(activeModule.HoneyType);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }
            //     }
        }

        #endregion

        #region Location&Orientation

        private void SidePanel_LocationChanged(object sender, EventArgs e)
        {
            locationChanged = true;
        }

        private void pionowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.FlowDirection = FlowDirection.TopDown;
            orientationVertical = true;

            Size = new Size(250, mainForm.Height);

            if (locationChanged)
            {
                mainForm.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - (mainForm.Width + Width))/2,
                    (Screen.PrimaryScreen.WorkingArea.Height - mainForm.Height)/2);
                //czeeeeeemuuu nie jest ładnie na środku jak defaultowo ;_;
            }
            Location = new Point(mainForm.Right, mainForm.Top);

            pionowaToolStripMenuItem.Text = "Wyrównaj";
            poziomaToolStripMenuItem.Text = "Pozioma";

        }

        private void poziomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.FlowDirection = FlowDirection.LeftToRight;
            orientationVertical = false;

            Size = new Size(mainForm.Width, 130);

            if (locationChanged)
            {
                mainForm.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - mainForm.Width)/2,
                    (Screen.PrimaryScreen.WorkingArea.Height - (mainForm.Height + Height))/2);
                //Location = new Point(mainForm.Left - Width / 2, Top);
            }
            Location = new Point(mainForm.Left, mainForm.Bottom);

            //Location = new Point(mainForm.Left - Width / 2, Top);
            //jak rogi się spotykają (poz defaultowa) to wyśrodkować wszystko

            pionowaToolStripMenuItem.Text = "Pionowa";
            poziomaToolStripMenuItem.Text = "Wyrównaj";

        }

        #endregion

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            Hide();
        }
    }
}