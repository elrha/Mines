using PlayerInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPlayer
{
    public class Player : IPlayer
    {
        private int width;

        private int height;

        private static Random rand = new Random();

        // note : IPlayer Interface
        public string GetName()
        {
            return "Random Player";
        }

        // note : IPlayer Interface
        public Bitmap GetImage()
        {
            var newImage = Properties.Resources.flag.Clone() as Bitmap;
            var RandColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));

            for (int h = 0; h < newImage.Size.Height; h++)
            {
                for (int w = 0; w < newImage.Size.Width; w++)
                {
                    var pixel = newImage.GetPixel(w, h);
                    if (pixel.R > 150 && pixel.G < 100 && pixel.B < 100)
                    {
                        newImage.SetPixel(w, h, RandColor);
                    }
                }
            }

            return newImage;
        }

        // note : IPlayer Interface
        public void Initialize(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        // note : IPlayer Interface
        public int GetPosition(MineType[] mineField)
        {
            while(true)
            {
                var retIndex = rand.Next() % (width * height);
                if (mineField[retIndex] == MineType.NONE)
                    return retIndex;
            }
        }
    }
}
