using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerInterface
{
    public interface IPlayer
    {
        string GetName();

        Bitmap GetImage();

        void Initialize(int width, int height);

        int GetPosition(MineType[] mineField);
    }
}