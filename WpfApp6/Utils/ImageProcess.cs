using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WpfApp6.Model;

namespace WpfApp6.Utils
{
    class ImageProcess
    {
        public static byte[] imageToByteArray(BitmapImage imageIn)
        {
            try
            {
                byte[] data;
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(imageIn));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    data = ms.ToArray();
                }
                return data;
            }
            catch { return null; }//убрать
        }

        public static BitmapImage FromByteToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                try
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = ms;
                    image.CacheOption = BitmapCacheOption.OnLoad; // here
                    image.EndInit();
                    return image;
                }
                catch { return null; }//надо будет убрать это
            }
        }

        public static bool ImageFromPath(string _savepath, Person personforAdd)
        {
            try
            {
                BitmapImage bmpImg = new BitmapImage();
                bmpImg.BeginInit();
                bmpImg.UriSource = new Uri(_savepath, UriKind.Absolute);
                bmpImg.DecodePixelWidth = 350;
                bmpImg.CacheOption = BitmapCacheOption.OnLoad;
                bmpImg.EndInit();
                personforAdd.Image = bmpImg;
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("There was an error with format of file." +
                    "Please check the path.");
                return false;
               // _savepath = "";
            }
        }
    }
}
