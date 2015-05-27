using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace KlasyfikacjaMiodu.Serialization
{
    public class Serializer
    {

        public Serializer()
        {

        }

        public void Serialize(SaveFileDialog sfd)
        {
            SerializeImage(sfd.FileName);
            SerializeTxt(sfd.FileName);
        }
        private void SerializeImage(string imagePath)
        {
            string path = Path.Combine(Path.GetDirectoryName(imagePath), Path.GetFileNameWithoutExtension(imagePath)) + ".jpg";
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
        private void SerializeTxt(string txtPath)
        {
            string honeyTypeString;
            string markerString;

            using (StreamWriter sw = new StreamWriter(txtPath))
            {
                foreach (var honeyType in Session.Context.HoneyTypes)
                {
                    honeyTypeString =
                        "HoneyType NAME:" + honeyType.Name + " " +
                        "DESCRIPTION_NAME:" + honeyType.DescriptionName + " " +
                        "MARKER_COLOR:" + ToHexConverter(honeyType.MarkerColor) + " " +
                        "MINIMAL_POLLENS_PERCENTAGE_AMOUNT:" + honeyType.MinimalPollensPercentageAmount;
                    sw.WriteLine(honeyTypeString);
                }
                sw.WriteLine();

                foreach (var marker in Session.Context.Markers)
                {
                    markerString =
                        "Marker X: " + marker.X + " " +
                        "Y: " + marker.Y + " " +
                        "SIZE: " + marker.Size + " " +
                        "TYPE_NAME: " + marker.HoneyType.Name;
                    sw.WriteLine(markerString);
                }
                sw.WriteLine();

                sw.WriteLine("Timer:" + Session.Context.TimeSpan.ToString());
            }
        }

        public void Deserialize(OpenFileDialog ofd)
        {
            if (!CheckIfProjectImageExists(ofd.FileName)) return;

            DeserializeImage(ofd);
            Context context = DeserializeTxt(ofd);

            Session.NewClear();
            foreach (var honeyType in context.HoneyTypes)
                Session.Context.AddHoneyType(honeyType);
            foreach (var marker in context.Markers)
                Session.Context.AddMArker(marker);
            Session.Context.TimeSpan = context.TimeSpan;

        }
        private void DeserializeImage(OpenFileDialog ofd)
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
        private Context DeserializeTxt(OpenFileDialog ofd)
        {
            Context context = new Context(true);

            RegexOptions options = RegexOptions.IgnoreCase;
            Regex honeyTypeRegex = new Regex(@"(?:HoneyType\s*name:\s*)([a-ząćśóźżłńę ]+)(?:\s*description_name:\s*)([a-ząćśóźżłńę ]+)(?:\s*marker_color:\s*)(#[0-9abcdef]{6})(?:\s*minimal_pollens_percentage_amount:\s*)(\d+)", options);
            Regex markerRegex = new Regex(@"(?:marker\s*x:\s*)(\d+)(?:\s*y:\s*)(\d+)(?:\s*size:\s*)(\d+)(?:\s*type_name:\s*)([a-ząćśóźżłńę ]+)", options);
            Regex timerRegex = new Regex(@"(?:timer:\s*)(\d\d:\d\d:\d\d)", options);

            using (StreamReader sr = File.OpenText(ofd.FileName))
            {
                Match honeyTypeMatchResult;
                Match markerMatchResult;
                Match timerMatchResult;

                string line = String.Empty;

                bool isFileCorrect = true;
                while ((line = sr.ReadLine()) != null)
                {
                    if ((honeyTypeMatchResult = honeyTypeRegex.Match(line)).Success)
                    {
                        // dodaj pyłek do Contextu
                        var g = honeyTypeMatchResult.Groups;
                        string name = g[1].Value.Trim();
                        string descName = g[2].Value.Trim();
                        Color color = ToColorConverter(g[3].Value);
                        float minPollens = float.Parse(g[4].Value);

                        bool typeExists = context.HoneyTypes.Any<HoneyType>(type => type.Name == name || type.DescriptionName == descName);
                        if (typeExists)
                            continue;
                        context.AddHoneyType(new HoneyType(name, descName, color, minPollens));
                    }
                    else if ((markerMatchResult = markerRegex.Match(line)).Success)
                    {
                        // dodaj marker do Contextu
                        var g = markerMatchResult.Groups;
                        string name = g[4].Value;
                        var honeyType = context.HoneyTypes.SingleOrDefault(type => type.Name == name);
                        if (honeyType == null)
                        {
                            isFileCorrect = false;
                            break;
                        }
                        int x = int.Parse(g[1].Value);
                        int y = int.Parse(g[2].Value);
                        int size = int.Parse(g[3].Value);

                        context.AddMArker(new Marker(x, y, size, honeyType));
                    }
                    else if ((timerMatchResult = timerRegex.Match(line)).Success)
                    {
                        TimeSpan ts = TimeSpan.Parse(timerMatchResult.Groups[1].Value);
                        context.TimeSpan = ts;
                    }
                    else if (String.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    else
                    {
                        isFileCorrect = false;
                        break;
                    }
                }
                if (!isFileCorrect)
                {
                    return null;
                }
                return context;
            }
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

        private String ToHexConverter(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
        private Color ToColorConverter(string hex)
        {
            return System.Drawing.ColorTranslator.FromHtml(hex);
        }
    }
}