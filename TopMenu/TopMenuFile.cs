using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing;

namespace KlasyfikacjaMiodu.TopMenu
{
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> origin/master
    /// <summary>
    /// Author: Dawid Ferszter. <para/>
    /// Class responsible for handling "File" menu.
    /// </summary>
<<<<<<< HEAD
=======
=======
>>>>>>> origin/master
>>>>>>> origin/master
    public class TopMenuFile
    {
        BinaryFormatter formatter = new BinaryFormatter(); // potrzebne do serializacji
        OpenFileDialog ofd = new OpenFileDialog();  // okno z odczytem danych
        SaveFileDialog sfd = new SaveFileDialog();  // okno z zapisem danych

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

<<<<<<< HEAD
=======
<<<<<<< HEAD
=======

>>>>>>> origin/master
>>>>>>> origin/master
        private void NewProject_Click(object sender, EventArgs e)
        {
            Session.New();
        }

        private void SaveProject_Click(object sender, EventArgs e)
        {
            sfd.Filter = "Miodek project file (.ulan)|*.ulan";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (Stream output = File.Create(sfd.FileName))
                { formatter.Serialize(output, Session.Context); }
            }
        }

        private void LoadProject_Click(object sender, EventArgs e)
        {
            Context newContext = new Context();

            ofd.Filter = "Miodek project file (.ulan)|*.ulan";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (Stream input = File.OpenRead(ofd.FileName)) 
                    { newContext = (Context)formatter.Deserialize(input); }
                }
                catch (Exception ex)
                {
<<<<<<< HEAD
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
=======
<<<<<<< HEAD
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
=======
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
>>>>>>> origin/master
>>>>>>> origin/master
                }

                Session.Load(newContext);
            }
        }

        private void LoadImage_Click(object sender, EventArgs e)
        {
            Bitmap bmp;
            ofd.Filter = "Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png" ;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                bmp = new Bitmap(ofd.FileName);
                Session.Context.Image = (Image)bmp;
            }
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
