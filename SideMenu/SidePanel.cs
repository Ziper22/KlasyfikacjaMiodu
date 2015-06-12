using System;
using System.Drawing;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.SideMenu
{
    /// <summary>
    ///     Autor: Agata Hammermeister.
    ///     Klasa odpowiedzialna za boczny panel.
    /// </summary>
    public partial class SidePanel : Form
    {
        private readonly Form mainForm;
        private readonly PollenModuleSelector pollenModuleSelector;
        private bool locationChanged;
        bool alignToRight = true;
        /// <summary>
        /// Konstruktor klasy.
        /// </summary>
        /// <param name="mainForm"></param>
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

        /// <summary>
        /// Funkcja wywoływana przy zmianie rozmiaru bocznego panelu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SidePanel_SizeChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///      Pozwala a scrollowanie bocznego panelu za pomocą kółka myszy.
        /// </summary>
        void SidePanel_MouseWheel(object sender, MouseEventArgs e)
        {
            panel1.Focus();
        }

        /// <summary>
        ///     Ładuje moduły z typami miodów do bocznego panelu i zaznacza pierwszy.   
        /// </summary>
        private void Session_Changed(Context context)
        {

            panel1.Controls.Clear();
            foreach (HoneyType honey in context.HoneyTypes)
            {
                if (honey.Name == "Zanieczyszczenie")
                {
                    honey.Dirt = true;
                }
                HoneyType_Add(honey);
            }

<<<<<<< HEAD
            if (panel1.Controls.Count > 0)
            {
                PollenModule defaultPollenModule = (PollenModule) panel1.Controls[0];
                defaultPollenModule.Choose();
                pollenModuleSelector.chosenModule = defaultPollenModule;

                HoneyType defaultHoneyType = context.HoneyTypes[0];
                Session.Context.SelectedHoneyType = defaultHoneyType;
            }

=======
            if (panel1.Controls.Count > 1)
            {
                PollenModule dirtPollenModule = (PollenModule)panel1.Controls[0];
                dirtPollenModule.HoneyType.Dirt = true;

                PollenModule defaultPollenModule = (PollenModule)panel1.Controls[1];
                defaultPollenModule.Choose();
                pollenModuleSelector.chosenModule = defaultPollenModule;

                HoneyType defaultHoneyType = context.HoneyTypes[1];
                Session.Context.SelectedHoneyType = defaultHoneyType;
            }
            panel1.VerticalScroll.Value = 1;
>>>>>>> origin/Release-v2
            Session.Context.HoneyTypeAdded += HoneyType_Add;
        }

        /// <summary>
        ///     Chowa panel zamiast go zamykać.
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            Hide();
        }

        /// <summary>
        /// Blokuje panel.
        /// </summary>
        /// <param name="block"></param>
        public void SetPanel(bool block)
        {
            addToolStripMenuItem.Enabled = block;
            editToolStripMenuItem.Enabled = block;
            deleteToolStripMenuItem.Enabled = block;
            orientationToolStripMenuItem.Enabled = block;
        }

        /// <summary>
        /// Obsługuje zdarzenie przy kliknięciu "Dodaj".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoneyTypeEditWindow addEditWindow = new HoneyTypeEditWindow();
            addEditWindow.OkButtonClicked += HoneyType_AddToContext;
            addEditWindow.ShowDialog();
        }
        /// <summary>
        /// Dodawanie nowego typu miodu.
        /// </summary>
        /// <param name="newHoney"></param>
        private void HoneyType_Add(HoneyType newHoney)
        {
            PollenModule pollenModule = new PollenModule(newHoney);
            panel1.Controls.Add(pollenModule);
            pollenModuleSelector.AddListeners(pollenModule);
            RefreshPanel();
            panel1.ScrollControlIntoView(pollenModule);
        }
        /// <summary>
        /// Dodawanie nowego typu miodu do Contextu.
        /// </summary>
        /// <param name="newHoney"></param>
        /// <param name="persistent"></param>
        private void HoneyType_AddToContext(HoneyType newHoney, bool persistent)
        {
            Session.Context.AddHoneyType(newHoney);
            if (persistent)
            {
                DefaultHoneyTypesBase.AddNewHoneyTypeToFile(newHoney);
            }
            panel1.ScrollControlIntoView(panel1.Controls[panel1.Controls.Count - 1]);
        }
        /// <summary>
        /// Obsługuje zdarzenie przy kliknięciu "Edytuj".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
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
                else return;
            }
            catch (Exception) { return; }
        }
        /// <summary>
        /// Edytowanie istniejącego już typu miodu.
        /// </summary>
        /// <param name="honeyType"></param>
        /// <param name="persistent"></param>
        private void HoneyType_Edit(HoneyType honeyType, bool persistent)
        {
            pollenModuleSelector.chosenModule.Edit(honeyType);
            Session.Context.EditedHoneyType(honeyType);
        }
        /// <summary>
        /// Obsługuje zdarzenie przy kliknięciu "Usuń".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
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
                else return;
            }
            catch (Exception) { return; }
        }


        /// <summary>
        /// Wyrównuje panel przy każdej zmianie głównego okna.
        /// </summary>
        void mainForm_SizeChanged(object sender, EventArgs e)
        {
            AlignSidePanel();
        }

        ///<summary>
        /// Wyrównuje panel zależnie od jego orientacji.
        /// </summary>
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
        ///     Zmienia orientację panelu na pionową.
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
            HideDropDownMenuItems();
        }

        /// <summary>
        /// Ukrywa elementy paska menu.
        /// </summary>
        private void HideDropDownMenuItems()
        {
            foreach (ToolStripMenuItem item in orientationToolStripMenuItem.DropDownItems)
            {
                item.Visible = false;
            }
        }

        /// <summary>
        /// Pokazuje elementy paska menu.
        /// </summary>
        private void ShowDropDownMenuItems()
        {
            foreach (ToolStripMenuItem item in orientationToolStripMenuItem.DropDownItems)
            {
                item.Visible = true;
            }
        }

        /// <summary>
        ///     Zmienia orientację panelu na poziomą.
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


        /// <summary>
        /// Wyrównuje boczny panel do lewej strony zależnie od jego orientacji.
        /// </summary>
        private void AlignSidePanelToLeft()
        {
            alignToRight = false;

            if (Screen.PrimaryScreen.WorkingArea.Left + mainForm.Left < Width)
            {
                Location = new Point(mainForm.Left, mainForm.Top + (mainForm.Height - Height) / 2);
            }
            else
            {
                Location = new Point(mainForm.Left - Width, mainForm.Top);
            }
        }

        /// <summary>
        /// Wyrównuje boczny panel do prawej strony zależnie od jego orientacji.
        /// </summary>
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

        /// <summary>
        /// Zmienia kolejność elementów w menu.
        /// </summary>
        private void SwapMenuItems()
        {
            ToolStripItem tmpItem = orientationToolStripMenuItem.DropDownItems[0];

            if (tmpItem.Text != "Wyrównaj listę")
            {
                orientationToolStripMenuItem.DropDownItems.RemoveAt(0);
                orientationToolStripMenuItem.DropDownItems.Add(tmpItem);
            }
            if (panel1.FlowDirection == FlowDirection.LeftToRight)
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

        /// <summary>
        /// Odświeża orientację panelu.
        /// </summary>
        private void RefreshPanel()
        {
            if (panel1.FlowDirection == FlowDirection.LeftToRight)
            {
                panel1.FlowDirection = FlowDirection.TopDown;
                panel1.FlowDirection = FlowDirection.LeftToRight;
            }
        }

        /// <summary>
        /// Wyrównuje panel do lewej.
        /// </summary>
        private void toLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alignToRight = false;
            AlignSidePanel();
        }

        /// <summary>
        /// Wyrównuje panel do prawej.
        /// </summary>
        private void toRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alignToRight = true;
            AlignSidePanel();
        }

        /// <summary>
        /// Funkcja wywoływana po wciśnięciu orientationToolStripMenuItem.
        /// </summary>
        private void orientationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDropDownMenuItems();
        }

    }
}