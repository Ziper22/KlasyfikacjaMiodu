using System;
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
    /// Author: Dawid Ferszter. <para/>
    /// Class responsible for handling "File" menu.
    /// </summary>
    public class TopMenuFile
    {
        private ToolStripMenuItem newProject;
        private ToolStripMenuItem saveProject;
        private ToolStripMenuItem loadProject;
        private ToolStripMenuItem loadImage;
        private ToolStripMenuItem quit;
        private MainForm mainForm;

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

        private void NewProject_Click(object sender, EventArgs e)
        {
            Session.NewDefault();
            Session.Context.Scale = 0.57F;
            RefreshHeaderOfForm("Unknown");
        }

        private void SaveProject_Click(object sender, EventArgs e)
        {
            Serializer serializer = new Serializer();
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Project txt (*.txt)|*.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        serializer.Serialize(sfd);
                        RefreshHeaderOfForm(sfd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadProject_Click(object sender, EventArgs e)
        {
            Serializer serializer = new Serializer();

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Project txt (*.txt)|*.txt";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (CheckIfProjectImageExists(ofd.FileName))
                    {
                        try
                        {
                            Session.NewClear();
                            serializer.Deserialize(ofd);
                            RefreshHeaderOfForm(ofd.FileName);

                        
                            mainForm.TurnOffEditMode();
                            mainForm.AddEditModeToMenu();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Nie znaleziono pliku ze zdjęciem.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Session.Context.Scale = 0.57F;
        }

        private void LoadImage_Click(object sender, EventArgs e)
        {
            Bitmap bmp;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        bmp = new Bitmap(ofd.FileName);
                        Session.Context.Image = (Image)bmp;
                        Session.Context.Scale = 0.57F;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Refreshes header of form with name of project.
        /// </summary>
        /// <param name="projectPath">Path with project files.</param>
        private void RefreshHeaderOfForm(string projectPath)
        {
            string projectName = Path.GetFileNameWithoutExtension(projectPath);
            mainForm.Text = "Klasyfikacja Miodu - [" + projectName + "]";
        }

        /// <summary>
        /// Determines if image within project directory exists.
        /// </summary>
        /// <param name="txtFilePath">Path with .txt file.</param>
        /// <returns></returns>
        private bool CheckIfProjectImageExists(string txtFilePath)
        {
            string imagePath = Path.GetFileNameWithoutExtension(txtFilePath) + ".jpg";
            string directoryPath = Path.GetDirectoryName(txtFilePath);

            if (File.Exists(directoryPath + "//" + imagePath)) return true;
            else return false;

        }
    }
}
