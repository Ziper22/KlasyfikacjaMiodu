﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing;
using KlasyfikacjaMiodu.Serialization;

namespace KlasyfikacjaMiodu.TopMenu
{
    /// <summary>
    /// Autor: Dawid Ferszter. <para/>
    /// Klasa odpowiedzialna za przechowywnie zakładki "Plik" w menu.
    /// </summary>
    public class TopMenuFile
    {
        private ToolStripMenuItem newProject;
        private ToolStripMenuItem saveProject;
        private ToolStripMenuItem loadProject;
        private ToolStripMenuItem loadImage;
        private ToolStripMenuItem quit;
        private MainForm mainForm;
        /// <summary>
        /// Konstruktor klasy. Dodaje pola do rozwijanej listy.
        /// </summary>
        /// <param name="newProject">Nowy projekt</param>
        /// <param name="saveProject">Zapisz projekt</param>
        /// <param name="loadProject">Wczytaj projekt</param>
        /// <param name="loadImage">Wczytaj obraz</param>
        /// <param name="quit">Zakończ</param>
        public TopMenuFile(ToolStripMenuItem newProject, ToolStripMenuItem saveProject,
           ToolStripMenuItem loadProject, ToolStripMenuItem loadImage, ToolStripMenuItem quit, MainForm mainForm)
        {
            this.newProject = newProject;
            this.saveProject = saveProject;
            this.loadProject = loadProject;
            this.loadImage = loadImage;
            this.quit = quit;
            this.mainForm = mainForm;

            newProject.Click += NewProject_Click;
            saveProject.Click += SaveProject_Click;
            loadProject.Click += LoadProject_Click;
            loadImage.Click += LoadImage_Click;
            quit.Click += Quit_Click;
        }
        /// <summary>
        /// Funkcja wywołana po wciśnięciu "Nowy projekt".
        /// </summary>
        private void NewProject_Click(object sender, EventArgs e)
        {
            Session.NewDefault();
<<<<<<< HEAD
=======
            Session.Context.Scale = 0.57F;
            RefreshHeaderOfForm("Niezapisany projekt");
>>>>>>> origin/Release-v2
        }
        /// <summary>
        /// Funkcja wywołana po wciśnięciu "Zapisz projekt".
        /// </summary>
        private void SaveProject_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileOk += CheckIfFileHasCorrectExtension;
                sfd.Filter = "Project txt (*.txt)|*.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Serializer serializer = new Serializer();
                    string saveState = "";

                    try
                    {
                        saveState = serializer.Serialize(sfd.FileName);
                    }
                    catch (Exception ex)
                    {
                        if (ex is IOException)
                        {
                             MessageBox.Show("Wystąpił błąd podczas zapisu projektu. Plik jest używany przez inny proces.", "Wystąpił błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                             MessageBox.Show("Wystąpił błąd podczas zapisu projektu.", "Wystąpił błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (saveState == "correct")
                        RefreshHeaderOfForm(sfd.FileName);
                    else if (saveState != "")
                        MessageBox.Show(saveState, "Wystąpił błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
        /// <summary>
        /// Funkcja wywołana po wciśnięciu "Wczytaj projekt".
        /// </summary>
        private void LoadProject_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
<<<<<<< HEAD
                try
                {
                    Serializer.DeserializeImage(fbd);
                    newContext = Serializer.Deserialize(fbd);
                    //Serializer.Serialize(fbd.SelectedPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
=======
                ofd.FileOk += CheckIfFileHasCorrectExtension;
                ofd.Filter = "Project txt (*.txt)|*.txt";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Serializer serializer = new Serializer();
                    string loadState = "";
                    try
                    {
                        loadState = serializer.Deserialize(ofd.FileName);
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show("Wystąpił błąd podczas wczytywania projektu. Plik ze zdjęciem jest uszkodzony.", "Wystąpił błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (loadState == "correct")
                    {
                        try
                        {
                            serializer.Deserialize(ofd.FileName);
                            RefreshHeaderOfForm(ofd.FileName);

                           
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Wystąpił błąd podczas wczytywania projektu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        RefreshHeaderOfForm(ofd.FileName);
                        MainForm.SetEditMode((MainForm)mainForm, false);
                        Session.Context.Scale = 0.57F;
                    }
                    else if (loadState != "")
                        MessageBox.Show(loadState, "Wystąpił błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
>>>>>>> origin/Release-v2
                }
            }
        }
        /// <summary>
        /// Funkcja wywołana po wciśnięciu "Wczytaj obraz".
        /// </summary>
        private void LoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.FileOk += CheckIfFileHasCorrectExtension;
                ofd.Filter = "Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Session.Context.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(ofd.FileName)));

                        Session.Context.Scale = 0.57F;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Nie udało się poprawnie wczytać zdjęcia. Upewnij się, że wybrałeś odpowiednie rozszerzenie lub czy plik nie jest uszkodzony.", "Wystąpił błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        /// <summary>
        /// Funkcja wywołana po wciśnięciu "Zakończ". Kończy działanie programu.
        /// </summary>
        private void Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Odświeża nagłówek z nazwą projektu.
        /// </summary>
        /// <param name="projectPath">Ścieżka do plików.</param>
        private void RefreshHeaderOfForm(string projectPath)
        {
            string projectName = Path.GetFileNameWithoutExtension(projectPath);
            mainForm.Text = projectName + " - Klasyfikacja Miodu";
        }

        /// <summary>
        /// Określa, czy obraz w ramach katalogu projektu istnieje.
        /// </summary>
        /// <param name="txtFilePath">Ścieżka z plikiem .txt</param>
        /// <returns></returns>
        private bool CheckIfProjectImageExists(string txtFilePath)
        {
            string imagePath = Path.GetFileNameWithoutExtension(txtFilePath) + ".jpg";
            string directoryPath = Path.GetDirectoryName(txtFilePath);

            if (File.Exists(directoryPath + "//" + imagePath)) return true;
            else return false;

        }
        /// <summary>
        /// Funkcja sprawdzająca czy rozdzerzenie pliku jest poprawne.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckIfFileHasCorrectExtension(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (sender is SaveFileDialog)
            {
                SaveFileDialog sv = (sender as SaveFileDialog);
                if (Path.GetExtension(sv.FileName).ToLower() != ".txt")
                {
                    e.Cancel = true;
                    MessageBox.Show("Plik musi mieć rozszerzenie .txt", "Wystąpił błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (sender is OpenFileDialog)
            {
                OpenFileDialog ov = (sender as OpenFileDialog);
                if (ov.Filter == "Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png")
                {
                    if (Path.GetExtension(ov.FileName).ToLower() != ".jpg" &&
                        Path.GetExtension(ov.FileName).ToLower() != ".png" &&
                        Path.GetExtension(ov.FileName).ToLower() != ".bmp")
                    {
                        e.Cancel = true;
                        MessageBox.Show("Plik musi mieć rozszerzenie .jpg, .png lub .bmp.", "Wystąpił błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (ov.Filter == "Project txt (*.txt)|*.txt")
                {
                    if (Path.GetExtension(ov.FileName).ToLower() != ".txt")
                    {
                        e.Cancel = true;
                        MessageBox.Show("Plik musi mieć rozszerzenie .txt.", "Wystąpił błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
        }

    }
}
