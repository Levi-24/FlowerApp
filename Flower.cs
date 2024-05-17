using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerApp
{
    internal class Flower
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public string ImageType { get; set; }

        public Flower(string readLine)
        {
            var data = readLine.Split(";");
            Name = data[0];
            Price = int.Parse(data[1]);
            Color = data[2];

            var image = data[3].Split(".");
            Image = image[0];
            ImageType = image[1];
        }
    }
}
