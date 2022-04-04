using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace BookOfRecipes.Classes
{
    internal class ImageFromBase64
    {
        public static BitmapImage FrBase64(string base64)
        {
            try
            {
                BitmapImage bI = new BitmapImage();
                bI.BeginInit();
                bI.StreamSource = new MemoryStream(Convert.FromBase64String(base64));
                bI.EndInit();

                return bI;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public static string FrImage(string path)
        {
            try
            {
                byte[] imageBytes = File.ReadAllBytes(path);
                return Convert.ToBase64String(imageBytes);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
