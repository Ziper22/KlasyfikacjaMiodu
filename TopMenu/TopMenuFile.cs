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
        BinaryFormatter formatter = new BinaryFormatter(); // potrzebne do serializacji

        private ToolStripMenuItem newProject;
        private ToolStripMenuItem saveProject;
        private ToolStripMenuItem loadProject;
        private ToolStripMenuItem loadImage;
        private ToolStripMenuItem quit;

        public TopMenuFile(ToolStripMenuItem newProject, ToolStripMenuItem saveProject,
           ToolStripMenuItem loadProject, ToolStripMenuItem loadImage, ToolStripMenuItem quit)
        {
            this.newProject = newProject;
            this.saveProject = saveProject;
            this.loadProject = loadProject;
            this.loadImage = loadImage;
            this.quit = quit;

            newProject.Click += NewProject_Click;
            saveProject.Click += SaveProject_Click;
            loadProject.Click += LoadProject_Click;
            loadImage.Click += LoadImage_Click;
            quit.Click += Quit_Click;
        }

        private void NewProject_Click(object sender, EventArgs e)
        {
            Session.NewDefault();
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
                        serializer.SerializeImage(sfd);
                        serializer.Serialize(sfd);
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
                    try
                    {
                        Session.NewClear();
                        serializer.DeserializeImage(ofd);
                        serializer.Deserialize(ofd);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
        }

        private void LoadImage_Click(object sender, EventArgs e)
        {
            Bitmap bmp;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    bmp = new Bitmap(ofd.FileName);
                    Session.Context.Image = (Image)bmp;
                }
            }
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
