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
    public static class Serializer
    {
        private static List<string> honeyTypeStringList;
        private static List<string> markerStringList;

        public static void Serialize(string folderPath)
        {
            honeyTypeStringList = HoneyTypeSerializer.Serialize(Session.Context);
            markerStringList = MarkerSerializer.Serialize(Session.Context);

                using (StreamWriter sw = new StreamWriter(folderPath + "/info.txt"))
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
        public static void SerializeImage(FolderBrowserDialog fbd)
        {
            string destPath = fbd.SelectedPath + @"\";

            using (Bitmap myBitmap = new Bitmap(Session.Context.Image))
            {
                ImageCodecInfo codecInfo = Serializer.GetEncoderInfo(ImageFormat.Jpeg);
                EncoderParameters parameters = new EncoderParameters(1);

                if (codecInfo != null)
                {
                    // Quality: 100
                    parameters.Param[0] = new EncoderParameter(
                        System.Drawing.Imaging.Encoder.Quality, 100L);
                    myBitmap.Save(destPath + "projectImage.jpg", codecInfo, parameters);
                }
            }



            // Session.Context.Image.Save(fbd.SelectedPath, ImageFormat.Bmp);
            // Serialization.Serializer.Serialize(Session.Context, fbd.SelectedPath);
        }

        public static Context Deserialize(FolderBrowserDialog fbd)
        {
            Marker marker;
            Context context = new Context();
            using (StreamReader sr = File.OpenText(fbd.SelectedPath + @"\info.txt"))
            {
                string line = String.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line != "")
                    {
                        if (line.Contains("HoneyType")) // linijka z HoneyTypem
                            context.AddHoneyType(HoneyTypeSerializer.Deserialize(line));
                        else if (line.Contains("Marker")) // linijka z Markerem
                        {
                            marker = MarkerSerializer.Deserialize(line);
                            if (marker != null)
                                context.AddMArker(MarkerSerializer.Deserialize(line));
                        }
                        else if (line.Contains("Timer")) //linijka z czasem
                            context.TimeSpan = TimeSerializer.Deserialize(line);
                    }
                }
            }

            return context;
        }

        public static void DeserializeImage(FolderBrowserDialog fbd)
        {
            string imagePath = fbd.SelectedPath + @"\projectImage.jpg";
            if (File.Exists(imagePath))
                Session.Context.Image = Image.FromFile(imagePath);
        }

        public static ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            return ImageCodecInfo.GetImageEncoders().ToList().Find(delegate(ImageCodecInfo codec)
            {
                return codec.FormatID == format.Guid;
            });
        }
    }
}
