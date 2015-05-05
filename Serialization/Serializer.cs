using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace KlasyfikacjaMiodu.Serialization
{
    public class Serializer
    {
        private HoneyTypeSerializer honeyTypeSerializer;
        private MarkerSerializer markerSerializer;

        private List<string> honeyTypeStringList;
        private List<string> markerStringList;

        public Serializer()
        {
            honeyTypeSerializer = new HoneyTypeSerializer();
            markerSerializer = new MarkerSerializer();

            honeyTypeStringList = new List<string>();
            markerStringList = new List<string>();
        }

        public void Serialize(SaveFileDialog sfd)
        {
            honeyTypeStringList = honeyTypeSerializer.Serialize(Session.Context);
            markerStringList = markerSerializer.Serialize(Session.Context);

                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    sw.WriteLine("===--- HONEY TYPES ---===");
                    for (int i = 0; i < honeyTypeStringList.Count; i++)
                        sw.WriteLine("HoneyType {0} ---> {1}\r\n", i + 1, honeyTypeStringList[i]);

                    sw.WriteLine("===--- MARKERS ---===");
                    for (int i = 0; i < markerStringList.Count; i++)
                        sw.WriteLine("Marker {0} ---> {1}\r\n", i + 1, markerStringList[i]);

                    sw.WriteLine("===--- TIME ---===");
                    sw.WriteLine("Timer:" + TimeSerializer.Serialize());
                
                }
        }
        public void SerializeImage(SaveFileDialog sfd)
        {
            string path = Path.Combine(Path.GetDirectoryName(sfd.FileName), Path.GetFileNameWithoutExtension(sfd.FileName)) + ".jpg";
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    Session.Context.Image.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
        }

        public Context Deserialize(OpenFileDialog ofd)
        {
            Marker marker;
            Context context = Session.Context;
            using (StreamReader sr = File.OpenText(ofd.FileName))
            {
                string line = String.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line != "")
                    {
                        if (line.Contains("HoneyType")) // linijka z HoneyTypem
                            context.AddHoneyType(honeyTypeSerializer.Deserialize(line));
                        else if (line.Contains("Marker")) // linijka z Markerem
                        {
                            marker = markerSerializer.Deserialize(line);
                            if (marker != null)
                                context.AddMArker(markerSerializer.Deserialize(line));
                        }
                        else if (line.Contains("Timer")) //linijka z czasem
                            context.TimeSpan = TimeSerializer.Deserialize(line);
                    }
                }
            }

            return context;
        }

        public void DeserializeImage(OpenFileDialog ofd)
        {
            Image img;
            string imagePath = Path.Combine(Path.GetDirectoryName(ofd.FileName), Path.GetFileNameWithoutExtension(ofd.FileName)) + ".jpg";
            if (File.Exists(imagePath))
            {
                using (var bmpTemp = new Bitmap(imagePath))
                {
                    img = new Bitmap(bmpTemp);
                }
                Session.Context.Image = img;
             }

        }
    }
}
