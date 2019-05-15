using System;
using System.Drawing;
using System.IO;

namespace CropImages
{
    class Program
    {
        static void Main(string[] args)
        {
            var convertedDirectory = $"{args[0]}\\Converted";

            if (!Directory.Exists(convertedDirectory))
            {
                Directory.CreateDirectory(convertedDirectory);
            }

            foreach(var file in Directory.EnumerateFiles(args[0], "*.jpg", SearchOption.TopDirectoryOnly))
            {
                using (var stream = File.OpenRead(file))
                {
                    var image = Image.FromStream(stream);
                    var newImage = new Bitmap(image, new Size(256, 256));

                    newImage.Save($"{convertedDirectory}\\{new FileInfo(file).Name}");
                }
            }
        }
    }
}
