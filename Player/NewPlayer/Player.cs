using PlayerInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPlayer
{
    public class Player : IPlayer
    {
        private static Random rand = new Random();

        public string GetName()
        {
            return "Mario";
        }

        public Bitmap GetImage()
        {
            return Properties.Resources.mario;
        }

        public void Initialize(int width, int height)
        {
        }

        public int GetPosition(MineType[] mineField)
        {
            while (true)
            {
                var retIndex = rand.Next() % (mineField.Count());
                if (mineField[retIndex] == MineType.NONE)
                    return retIndex;
            }
        }
    }
}
