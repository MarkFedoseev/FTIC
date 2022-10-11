using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FTIC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void FtIButt_Click(object sender, EventArgs e)
        {
            string selfDir = Environment.CurrentDirectory + "\\";
            List<byte> bytes = File.ReadAllBytes(Path.Text).ToList();
            Encoding utf8 = Encoding.UTF8;

            string filename = Path.Text.Split('\\').Last();
            byte[] tecbytes = utf8.GetBytes(filename);
            for (int i = 0; i < tecbytes.Length; i++)
                bytes.Add(tecbytes[i]);

            byte sumbt1 = 0;
            byte sumbt2 = 0;
            if (tecbytes.Length > 255)
            {
                sumbt1 = 255;
                sumbt2 = Convert.ToByte(tecbytes.Length - 255);
            }
            else
                sumbt1 = Convert.ToByte(tecbytes.Length);
            bytes.Add(sumbt1);
            bytes.Add(sumbt2);

            int imgHeight = Convert.ToInt32(Math.Ceiling(Math.Sqrt(Math.Ceiling(bytes.Count / 3.0)))) + 1;
            int imgWidth = Convert.ToInt32(Math.Ceiling(Math.Ceiling(bytes.Count / 3.0) / imgHeight)) + 1;
            Bitmap img = new Bitmap(imgWidth, imgHeight);
            int timer = 0;
            int pixTimer = 0;
            while (timer < bytes.Count)
            {
                Color pixColor = new Color();
                if (bytes.Count - timer >= 3)
                    pixColor = Color.FromArgb(bytes[timer], bytes[timer + 1], bytes[timer + 2]);
                else if (bytes.Count - timer == 2)
                    pixColor = Color.FromArgb(2, bytes[timer], bytes[timer + 1], 0);
                else if (bytes.Count - timer == 1)
                    pixColor = Color.FromArgb(1, bytes[timer], 0, 0);
                timer += 3;
                img.SetPixel(pixTimer % imgWidth, pixTimer / imgWidth, pixColor);
                pixTimer++;
            }


            string datetime = DateTime.Now.ToString();
            string datetimeforsave = datetime.Split(' ')[1].Replace(':', '.');
            //string datetimeforsave = datetime.Remove(13) + "." + datetime[14] + datetime[15] + "." + datetime[17] + datetime[18];
            img.Save(selfDir + datetimeforsave + ".bmp");
        }

        private void ItFButt_Click(object sender, EventArgs e)
        {
            string selfDir = Environment.CurrentDirectory + "\\";
            Bitmap image = new Bitmap(Path.Text);
            List<byte> bytes = new List<byte>();
            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                {
                    if (!(y >= image.Height - 2))
                    {
                        bytes.Add(image.GetPixel(x, y).R);
                        bytes.Add(image.GetPixel(x, y).G);
                        bytes.Add(image.GetPixel(x, y).B);
                    }
                    else
                    {
                        if (image.GetPixel(x, y).A == 255)
                        {
                            bytes.Add(image.GetPixel(x, y).R);
                            bytes.Add(image.GetPixel(x, y).G);
                            bytes.Add(image.GetPixel(x, y).B);
                        }
                        else if (image.GetPixel(x, y).A == 2)
                        {
                            bytes.Add(image.GetPixel(x, y).R);
                            bytes.Add(image.GetPixel(x, y).G);
                            break;
                        }
                        else if (image.GetPixel(x, y).A == 1)
                        {
                            bytes.Add(image.GetPixel(x, y).R);
                            break;
                        }
                        else
                            break;
                    }
                }
            int numOfTecBytes = Convert.ToInt32(bytes.Last()) + Convert.ToInt32(bytes[bytes.Count - 2]);
            byte[] tecbytes = new byte[numOfTecBytes];
            for (int i = bytes.Count - numOfTecBytes - 2; i < bytes.Count - 2; i++)
                tecbytes[i - (bytes.Count - numOfTecBytes - 2)] = bytes[i];
            bytes.RemoveRange(bytes.Count - numOfTecBytes - 2, numOfTecBytes + 2);

            string filename = Encoding.UTF8.GetString(tecbytes, 0, tecbytes.Length);

            File.WriteAllBytes(selfDir + filename, bytes.ToArray());
        }

        private void Path_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
